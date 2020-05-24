using Microsoft.WindowsAPICodePack.Taskbar;
using Newtonsoft.Json;
using qcz.Dump;
using qcz.Dump.StubMetaHistory;
using qcz.Dump.UserGroups;
using qcz.Util;
using qczWikiStat.Models;
using qczWikiStat.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace qczWikiStat
{
	public partial class MainForm : Form
	{
		private const string NICE_DATETIME_FORMAT_STRING = "yyyy. MMMM d.";
		private static CultureInfo hungarianCulture = CultureInfo.GetCultureInfo("hu-HU");

		private StubMetaHistoryDumpReader smhDump = null;
		private UserGroupsDumpReader ugDump = null;
		private BackgroundWorker dumpBackgroundWorker;
		private List<OrderItem> orderItems = null;
		private string order = "all";
		private FileStringListReader botsReader;
		private FileStringListReader anonsReader;
		private List<ServiceRankRequirement> ServiceRankRequirements = new List<ServiceRankRequirement>();
		private Dictionary<string, List<string>> Aliases = new Dictionary<string, List<string>>();

		private Dictionary<int, string> namespaces;
		private List<int> selectedAllNamespaces;
		private List<int> selectedPeriodNamespaces;
		private List<int> selectedAllPercentNamespaces;
		private List<int> selectedPeriodPercentNamespaces;

		private string doubleFormat = "#,0.00";
		private string percentFormat = "0.##%";

		public string StubMetHistoryDumpFilePath { get; private set; }
		public string UserGroupsDumpFilePath { get; private set; }

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainFormLoad(object sender, EventArgs e)
		{
			var assemblyPath = Path.GetDirectoryName(typeof(MainForm).Assembly.Location);
			try
			{
				using (StreamReader serviceReqsReader = File.OpenText(Path.Combine(assemblyPath, "ServiceRankRequirements.json")))
				{
					JsonSerializer serializer = new JsonSerializer();
					ServiceRankRequirements = (List<ServiceRankRequirement>)serializer.Deserialize(serviceReqsReader, typeof(List<ServiceRankRequirement>));
					if (ServiceRankRequirements.Count > 0)
					{
						int i = 0;
						foreach (var rank in ServiceRankRequirements)
						{
							rank.Level = ++i;
						}

						rankListComboBox.Items.AddRange(ServiceRankRequirements.ToArray());
						rankListComboBox.SelectedIndex = 0;
					}
				}
				reqsStatusLabel.Text = $"{ServiceRankRequirements.Count} rangdefiníció betöltve.";
			}
			catch (Exception ex)
			{
				reqsStatusLabel.Text = $"A rangdefiníciókat nem sikerült betölteni ({ex.GetType()}/{ex.Message})";
			}

			try
			{
				using (StreamReader serviceReqsReader = File.OpenText(Path.Combine(assemblyPath, "Aliases.json")))
				{
					JsonSerializer serializer = new JsonSerializer();
					Aliases = (Dictionary<string, List<string>>)serializer.Deserialize(serviceReqsReader, typeof(Dictionary<string, List<string>>));
				}
				aliasStatusLabel.Text = $"{Aliases.Count} alias betöltve.";
			}
			catch (Exception ex)
			{
				aliasStatusLabel.Text = $"Az aliasokat nem sikerült betölteni ({ex.GetType()}/{ex.Message})";
			}

			int year = DateTime.Now.Month == 1 ? DateTime.Now.Year - 1 : DateTime.Now.Year;
			int month = DateTime.Now.Month == 1 ? 12 : DateTime.Now.Month - 1;
			startDatePicker.Value = new DateTime(year, month, 1);
			endDatePicker.Value = new DateTime(year, month, DateTime.DaysInMonth(year, month));

			botsReader = new FileStringListReader("bots.txt");
			anonsReader = new FileStringListReader("anons.txt");
			if (botsReader.Valid)
			{
				if (botsReader.Count > 0)
				{
					useBotListCheckBox.Text += " (" + botsReader.Count + ")";
					useBotListCheckBox.Enabled = true;
					useBotListCheckBox.Checked = true;
				}
				else
					useBotListCheckBox.Text += " (nincsenek elemek a fájlban)";
			}
			else
			{
				useBotListCheckBox.Text += " (a fájlt nem sikerült betölteni)";
			}
			if (anonsReader.Valid)
			{
				if (anonsReader.Count > 0)
				{
					useAnonListCheckBox.Text += " (" + anonsReader.Count + ")";
					useAnonListCheckBox.Enabled = true;
					useAnonListCheckBox.Checked = true;
				}
				else
					useAnonListCheckBox.Text += " (nincsenek elemek a fájlban)";
			}
			else
			{
				useAnonListCheckBox.Text += " (a fájlt nem sikerült betölteni)";
			}

			selectedAllNamespaces = new List<int>() { 0 };
			selectedPeriodNamespaces = new List<int>() { 0 };
			selectedAllPercentNamespaces = new List<int>();
			selectedPeriodPercentNamespaces = new List<int>();
		}

		private void AbortBackgroundWorker()
		{
			if (dumpBackgroundWorker != null && dumpBackgroundWorker.IsBusy)
				dumpBackgroundWorker.CancelAsync();
		}

		private void MainFormClosed(object sender, FormClosedEventArgs e)
		{
			AbortBackgroundWorker();
		}

		private void StartDateCheckBoxCheckStateChanged(object sender, EventArgs e)
		{
			periodDataGroupBox.Enabled = startDateCheckBox.Checked;
		}

		private void ShowPrivilegesCheckBoxCheckedChanged(object sender, EventArgs e)
		{
			privilegesUnderCheckBox.Enabled = privilegesInNewColumnCheckBix.Enabled = showPrivilegesCheckBox.Checked;
		}

		private void UpdateLoadButtonEnabled()
		{
			if (ugDumpTextBox.Text != "" && smhDumpTextBox.Text != "")
				loadDumpsButton.Enabled = true;
		}

		private void BrowseSmhDumpButtonClick(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK &&
				File.Exists(openFileDialog.FileName))
			{
				smhDumpTextBox.Text = openFileDialog.FileName;
				UpdateLoadButtonEnabled();
			}
		}

		private void BrowseUgDumpButtonClick(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK &&
				File.Exists(openFileDialog.FileName))
			{
				ugDumpTextBox.Text = openFileDialog.FileName;
				UpdateLoadButtonEnabled();
			}
		}

		private void UpdateOrderList()
		{
			string selected = "all";
			if (orderListBox.SelectedIndex > -1)
				selected = ((OrderItem)orderListBox.SelectedItem).OrderId;
			orderListBox.Items.Clear();
			foreach (OrderItem oi in orderItems) {
				if (oi.Type == OrderItemType.Period && !startDateCheckBox.Checked) continue;
				orderListBox.Items.Add(oi);
			}
			foreach (object o in orderListBox.Items)
				if (((OrderItem)o).OrderId == selected)
					orderListBox.SelectedItem = o;
			if (orderListBox.SelectedIndex == -1) orderListBox.SelectedIndex = 0;
		}

		private void LoadDumpsButtonClick(object sender, EventArgs e)
		{
			browseSmhDumpButton.Enabled = false;
			browseUgDumpButton.Enabled = false;
			loadDumpsButton.Enabled = false;

			StubMetHistoryDumpFilePath = smhDumpTextBox.Text;
			UserGroupsDumpFilePath = ugDumpTextBox.Text;

			smhDump = new StubMetaHistoryDumpReader(smhDumpTextBox.Text, XmlDumpReaderBase.NONE);
			ugDump = new UserGroupsDumpReader(ugDumpTextBox.Text);
			orderItems = new List<OrderItem>();

			orderItems.Add(new OrderItem() { OrderId = "all", Desc = "Összes szerkesztés" });
			orderItems.Add(new OrderItem() { OrderId = "allRev", Desc = "Összes visszaállított szerkesztés" });
			orderItems.Add(new OrderItem() { OrderId = "allRev%", Desc = "Összes visszaállított szerkesztés %" });
			orderItems.Add(new OrderItem() { OrderId = "period", Desc = "Szerkesztés az adott időszakban", Type = OrderItemType.Period });
			orderItems.Add(new OrderItem() { OrderId = "periodRev", Desc = "Visszaállított szerkesztés az adott időszakban", Type = OrderItemType.Period });
			orderItems.Add(new OrderItem() { OrderId = "periodRev%", Desc = "Visszaállított szerkesztés % az adott időszakban", Type = OrderItemType.Period });
			orderItems.Add(new OrderItem() { OrderId = "name", Desc = "Felhasználónév" });
			orderItems.Add(new OrderItem() { OrderId = "rank", Desc = "Rang" });

			namespaces = smhDump.GetNamespaces();
			namespaces.Add(0, "(fő)");
			/*allEditsNamespaceList.Clear();
			periodEditsNamespaceList.Clear();*/
			List<OrderItem> allSub = new List<OrderItem>();
			List<OrderItem> periodSub = new List<OrderItem>();
			List<OrderItem> allPcSub = new List<OrderItem>();
			List<OrderItem> periodPcSub = new List<OrderItem>();
			foreach (KeyValuePair<int, string> kw in namespaces)
			{
				if (kw.Key >= 0) {
					allSub.Add(new OrderItem() { OrderId = "allns" + kw.Key, Desc = "Összes szerkesztés száma a(z) " + kw.Value + " névtérben" });
					periodSub.Add(new OrderItem()
					{
						OrderId = "periodns" + kw.Key,
						Desc = "Szerkesztések száma az adott időszakban a(z) " + kw.Value + " névtérben",
						Type = OrderItemType.Period
					});
					allPcSub.Add(new OrderItem() { OrderId = "allpcns" + kw.Key, Desc = "Összes szerkesztés %-a a(z) " + kw.Value + " névtérben" });
					periodPcSub.Add(new OrderItem()
					{
						OrderId = "periodpcns" + kw.Key,
						Desc = "Szerkesztések %-a az adott időszakban a(z) " + kw.Value + " névtérben",
						Type = OrderItemType.Period
					});
				}
			}
			orderItems.Add(new OrderItem() { OrderId = "firstedit", Desc = "Első szerkesztés" });
			orderItems.Add(new OrderItem() { OrderId = "lastedit", Desc = "Utolsó szerkesztés" });
			orderItems.Add(new OrderItem() { OrderId = "days", Desc = "Első és utolsó szerkesztés között eltelt napok" });
			orderItems.Add(new OrderItem() { OrderId = "activedays", Desc = "Aktív napok (a szerkesztéssel töltött napok)" });
			orderItems.Add(new OrderItem() { OrderId = "meanedits", Desc = "Napi átlagos szerk. (Összes szerk / első és utolsó nap között eltelt napok)" });
			orderItems.Add(new OrderItem() { OrderId = "periodactivedays", Desc = "Aktív napok az adott időszakban (a szerkesztéssel töltött napok)", Type = OrderItemType.Period });
			orderItems.Add(new OrderItem() { OrderId = "periodmeanedits", Desc = "Napi átlagos szerk. (Szerk. az adott időszakban / napok száma az időszakban)", Type = OrderItemType.Period });
			orderItems.AddRange(allSub);
			orderItems.AddRange(periodSub);
			orderItems.AddRange(allPcSub);
			orderItems.AddRange(periodPcSub);
			UpdateOrderList();

			allNsInfoLabel.Text = GenerateSelectedNamespacesLabelText(selectedAllNamespaces);
			periodNsInfoLabel.Text = GenerateSelectedNamespacesLabelText(selectedPeriodNamespaces);
			allNsPcInfoLabel.Text = GenerateSelectedNamespacesLabelText(selectedAllPercentNamespaces);
			periodNsPcInfoLabel.Text = GenerateSelectedNamespacesLabelText(selectedPeriodPercentNamespaces);
			settingsTabControl.Enabled = true;
		}

		private void ChooseFileClick(object sender, EventArgs e)
		{
			saveFileDialog.FileName = $"Wikistatisztika {DateTime.Now:yyyy-MM-dd HH-mm-ss}.txt";
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				outputFileTextBox.Text = saveFileDialog.FileName;
				doStatisticsButton.Enabled = true;
			}
		}

		private void DoStatisticsButtonClick(object sender, EventArgs e)
		{
			settingsTabControl.SelectTab(0);
			settingsTabControl.Enabled = false;
			doStatisticsButton.Visible = false;
			exitButton.Visible = true;
			cancelButton.Visible = true;
			order = ((OrderItem)orderListBox.SelectedItem).OrderId;
			progressBar.Value = 0;
			progressBar.Visible = true;
			progressText.Visible = true;


			dumpBackgroundWorker = new BackgroundWorker();
			dumpBackgroundWorker.DoWork += DumpBackgroundWorkerDoWork;
			dumpBackgroundWorker.RunWorkerCompleted += DumpBackgroundWorkerRunWorkerCompleted;
			dumpBackgroundWorker.WorkerSupportsCancellation = true;
			dumpBackgroundWorker.RunWorkerAsync();
			progressText.Text = "Feldolgozás folyamatban...";
		}
		
		private void ExitButtonClick(object sender, EventArgs e)
		{
			AbortBackgroundWorker();
			Application.Exit();
		}

		private string GenerateSelectedNamespacesLabelText(List<int> selectedNS)
		{
			if (selectedNS.Count == 0) return "< nincs kiválasztva egyetlen névtér sem >";
			string ret = "";
			int i = 0;
			foreach (int ns in selectedNS)
			{
				i++;
				ret = ret.AppendWithComma(namespaces[ns]);
				if (i == 3) break;
			}
			if (selectedNS.Count > 3) ret += " (+" + (selectedNS.Count - 3) + " további)";
			return ret;
		}

		private void SelectAllNsButtonClick(object sender, EventArgs e)
		{
			using (NamespacesForm nf = new NamespacesForm(
				   "Válaszd ki azokat a névtereket, melyet szeretnéd, hogy megjelenjenek a statisztikában (az összes szerkesztésre nézve)",
				   namespaces, selectedAllNamespaces))
			{
				if (nf.ShowDialog() == DialogResult.OK)
				{
					selectedAllNamespaces = nf.SelectedNamespaces;
					allNsInfoLabel.Text = GenerateSelectedNamespacesLabelText(selectedAllNamespaces);
				}
			}
		}

		private void SelectPeriodNsButtonClick(object sender, EventArgs e)
		{
			using (NamespacesForm nf = new NamespacesForm(
				   "Válaszd ki azokat a névtereket, melyet szeretnéd, hogy megjelenjenek a statisztikában (a megadott időszakra nézve)",
				   namespaces, selectedPeriodNamespaces))
			{
				if (nf.ShowDialog() == DialogResult.OK)
				{
					selectedPeriodNamespaces = nf.SelectedNamespaces;
					periodNsInfoLabel.Text = GenerateSelectedNamespacesLabelText(selectedPeriodNamespaces);
				}
			}
		}

		private void SelectAllPcNsButtonClick(object sender, EventArgs e)
		{
			using (NamespacesForm nf = new NamespacesForm(
				   "Válaszd ki azokat a névtereket, melyet szeretnéd, hogy megjelenjenek a statisztikában (az összes szerkesztés %-ra nézve)",
				   namespaces, selectedAllPercentNamespaces))
			{
				if (nf.ShowDialog() == DialogResult.OK)
				{
					selectedAllPercentNamespaces = nf.SelectedNamespaces;
					allNsPcInfoLabel.Text = GenerateSelectedNamespacesLabelText(selectedAllPercentNamespaces);
				}
			}
		}

		private void SelectPeriodPcNsButtonClick(object sender, EventArgs e)
		{
			using (NamespacesForm nf = new NamespacesForm(
				   "Válaszd ki azokat a névtereket, melyet szeretnéd, hogy megjelenjenek a statisztikában (a megadott időszakban végzett szerkesztések %-ra nézve)",
				   namespaces, selectedPeriodPercentNamespaces))
			{
				if (nf.ShowDialog() == DialogResult.OK)
				{
					selectedPeriodPercentNamespaces = nf.SelectedNamespaces;
					periodNsPcInfoLabel.Text = GenerateSelectedNamespacesLabelText(selectedPeriodPercentNamespaces);
				}
			}
		}

		private void UpdateStatus(string text, int progressPosition, bool finished)
		{
			this.BeginInvoke(new Action(( ) => {
				progressText.Text = text;
				if ((bool)finished)
				{
					TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
					progressBar.Visible = false;
				}
				else
				{
					TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
					TaskbarManager.Instance.SetProgressValue(progressPosition, 100);
					progressBar.Value = progressPosition;
				}
			}));
		}

		void DumpBackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker worker = sender as BackgroundWorker;

			var statisticsData = new StatisticsData()
			{
				FirstEditInWiki = DateTime.MaxValue,
				PeriodEndDate = endDatePicker.Value.Date,
				PeriodStartDate = startDateCheckBox.Checked ? startDatePicker.Value.Date : new DateTime?()
			};

			bool abortAfterSomePages = processedPagesCount.Value > 0;
			int processedArticles = Convert.ToInt32(processedPagesCount.Value);

			//var fileStream = new FileStream("e:\\Work\\reverts.txt", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
			//TextWriter tw = new StreamWriter(fileStream);

			string cacheFile = Path.Combine(
				Path.GetDirectoryName(smhDump.FilePath),
				Path.GetFileNameWithoutExtension(smhDump.FilePath)
				+ (startDateCheckBox.Checked ? "-" + startDatePicker.Value.ToString("yyyyMMdd") : "")
				+  "-" + endDatePicker.Value.ToString("yyyyMMdd")
				+ ".cache"
			);

			if (createCache.Checked && File.Exists(cacheFile))
			{
				using (FileStream fs = new FileStream(cacheFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					statisticsData = (StatisticsData)ProtoBuf.Serializer.Deserialize(typeof(StatisticsData), fs);
				}
			}
			else
			{
				foreach (DumpArticle article in smhDump)
				{
					if (worker.CancellationPending)
						break;

					int articleNamespace = smhDump.GetNamespace(article.Title);

					Dictionary<string, DumpArticleRevision> knownHashes = new Dictionary<string, DumpArticleRevision>();
					foreach (DumpArticleRevision currentArticleRevision in article.Revisions)
					{
						if (articleNamespace != 0)
							break;

						if (currentArticleRevision.ContentHash == null || currentArticleRevision.ContentHash == "phoiac9h4m842xq45sp7s6u21eteeq1")
							continue;

						if (knownHashes.ContainsKey(currentArticleRevision.ContentHash) == true)
						{
							var previousArticleRevision = knownHashes[currentArticleRevision.ContentHash];
							var prevArtIndex = article.Revisions.IndexOf(previousArticleRevision);
							var curArtIndex = article.Revisions.IndexOf(currentArticleRevision);
							int revertedEdits = curArtIndex - prevArtIndex - 1;

							if (prevArtIndex + 1 != curArtIndex && revertedEdits < 100)
							{
								//bool isNotable = revertedEdits > 1;

								//if (isNotable)
								//{
								//	tw.WriteLine($"{article.Title} [reverted: {revertedEdits:000}]");
								//	tw.WriteLine($"{previousArticleRevision.Timestamp:yyyy-MM-dd HH:mm:ss} {previousArticleRevision.UserUniqueIdentifier} | " +
								//		$"IsRR: {previousArticleRevision.IsReverterRevision} | " +
								//		$"Rev: {previousArticleRevision.IsReverted} | " +
								//		$"C: {previousArticleRevision.RevisionComment ?? "-------"}");
								//}

								currentArticleRevision.IsReverterRevision = true;
								for (int i = prevArtIndex + 1; i < curArtIndex; i++)
								{
									//if (isNotable)
									//{
									//	tw.WriteLine($"\t\t{article.Revisions[i].Timestamp:yyyy-MM-dd HH:mm:ss} {article.Revisions[i].UserUniqueIdentifier} | " +
									//		$"IsRR[R]: {article.Revisions[i].IsReverterRevision} | " +
									//		$"Rev: {article.Revisions[i].IsReverted} | " +
									//		$"C: {article.Revisions[i].RevisionComment ?? "-------"}");
									//}

									article.Revisions[i].IsReverted = true;

									if (article.Revisions[i].IsReverterRevision)
									{

									}
								}

								//if (isNotable)
								//{
								//	tw.WriteLine($"{currentArticleRevision.Timestamp:yyyy-MM-dd HH:mm:ss} {currentArticleRevision.UserUniqueIdentifier} | " +
								//		$"IsRR: {currentArticleRevision.IsReverterRevision} | " +
								//		$"Rev: {currentArticleRevision.IsReverted} | " +
								//		$"C: {currentArticleRevision.RevisionComment ?? "-------"}");

								//	tw.WriteLine();
								//	tw.WriteLine();
								//}
							}
						}

						knownHashes[currentArticleRevision.ContentHash] = currentArticleRevision;
					}

					statisticsData.ArticleCount++;
					if (statisticsData.ArticleCount % 100 == 0)
					{
						var progress = (double)smhDump.GetPosition() / (double)smhDump.GetFileLength() * 100d;
						UpdateStatus(string.Format("Feldolgozás folyamatban, {0} lap kész. ({1:0.00}%)", statisticsData.ArticleCount, progress),
							Convert.ToInt32(progress),
							false);
					}

					foreach (DumpArticleRevision articleRev in article.Revisions)
					{
						// az anonok és jövőbeli események kihagyása
						if (articleRev.Timestamp.Value.Date > statisticsData.PeriodEndDate.Date)
							continue;
						if (articleRev.Timestamp.Value < statisticsData.FirstEditInWiki)
							statisticsData.FirstEditInWiki = articleRev.Timestamp.Value;

						if (articleRev.UserUniqueIdentifier == null)
							continue;

						User cur = null;
						if (statisticsData.Users.ContainsKey(articleRev.UserUniqueIdentifier))
						{
							cur = statisticsData.Users[articleRev.UserUniqueIdentifier];
						}
						else
						{
							cur = User.CreateFromDumpArticleRevision(articleRev);
							cur.Id = articleRev.UserId;
							statisticsData.Users.Add(articleRev.UserUniqueIdentifier, cur);
							cur.AddRights(ugDump.GetUserRights(cur.Id));
						}

						bool isBeforePeriod = statisticsData.PeriodStartDate != null && articleRev.Timestamp.Value.Date < statisticsData.PeriodStartDate.Value.Date;
						cur.AddEdit(articleNamespace, isBeforePeriod, articleRev.IsReverted);

						if (!cur.LastEditTimestamp.HasValue || cur.LastEditTimestamp.Value < articleRev.Timestamp)
							cur.LastEditTimestamp = articleRev.Timestamp;
						if (!cur.FirstEditTimestamp.HasValue || cur.FirstEditTimestamp.Value > articleRev.Timestamp)
							cur.FirstEditTimestamp = articleRev.Timestamp;

						cur.AddEditDay(articleRev.Timestamp.Value);
					}
					if (abortAfterSomePages && processedArticles == statisticsData.ArticleCount)
						break;
				}

				if (createCache.Checked)
				{
					using (FileStream fs = new FileStream(cacheFile, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
					{
						fs.SetLength(0);
						ProtoBuf.Serializer.Serialize(fs, statisticsData);
					}
				}
			}

			//tw.Flush();
			//tw.Close();

			if (worker.CancellationPending == true)
			{
				e.Cancel = true;
			}
			else
			{
				this.BeginInvoke(new Action(() =>
				{
					GenerateStatisticsOutput(statisticsData);
				}));
			}
		}

		void DumpBackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				MessageBox.Show("Hiba történt a feldolgozás közben:\n" +
					e.Error.Message + "\n\n" + e.Error.GetType().Name + "\n" + e.Error.StackTrace);
			}
		}

		private void GenerateStatisticsOutput(StatisticsData statisticsData)
		{
			DateTime? start = null;
			if (startDateCheckBox.Checked) start = startDatePicker.Value;
			doubleFormat = "0";
			if (doubleCountBox.Value > 0)
			{
				doubleFormat += ".";
				for (int i = 0; i < doubleCountBox.Value; i++)
					doubleFormat += showDoubleZerosCheckBox.Checked ? "#" : "0";
			}
			percentFormat = "0.";
			for (int i = 0; i < percentCountBox.Value; i++)
				percentFormat += showPercentZerosCheckBox.Checked ? "#" : "0";
			percentFormat += "%";

			if (useBotListCheckBox.Checked)
			{
				foreach (string s in botsReader.Items)
				{
					if (statisticsData.Users.ContainsKey(s) && !statisticsData.Users[s].HasRight(qcz.Dump.Right.Bot))
					{
						statisticsData.Users[s].AddRight(qcz.Dump.Right.UnflaggedBot);
					}
				}
			}

			if (mergeAliasEdits.Checked && Aliases != null)
			{
				foreach (var aliasKvp in Aliases)
				{
					if (statisticsData.Users.ContainsKey(aliasKvp.Key) == false)
						continue;

					var user = statisticsData.Users[aliasKvp.Key];

					foreach (var mergedUserName in aliasKvp.Value)
					{
						if (statisticsData.Users.ContainsKey(mergedUserName) == false
							|| mergedUserName == aliasKvp.Key)
							continue;

						user.Merge(statisticsData.Users[mergedUserName]);
						statisticsData.Users.Remove(mergedUserName);
					}
				}
			}

			// Determine user rank
			if (statisticsData.PeriodStartDate != null)
			{
				foreach (var user in statisticsData.Users.Values)
				{
					if (user.IsBot || user.UserType != UserType.Registered)
						continue;

					user.RankBeforePeriod = ServiceRankRequirements.LastOrDefault(x =>
						user.TotalEditCountBeforePeriod > x.Edits
						&& user.GetActiveDaysBeforePeriod(statisticsData.PeriodStartDate) > x.ActiveDays);

					user.RankAfterPeriod = ServiceRankRequirements.LastOrDefault(x =>
						user.TotalEditCount > x.Edits
						&& user.TotalActiveDays > x.ActiveDays);

					double rankPosition = user.RankAfterPeriod?.Level ?? 0;

					var nextRank = ServiceRankRequirements.FirstOrDefault(x => x.Level == (user.RankAfterPeriod?.Level ?? 0) + 1);
					if (nextRank != null && user.IsBot == false)
					{
						var editDaysRatio = (double)user.TotalEditCount / (double)user.TotalActiveDays;
						double ratio;
						if (editDaysRatio > 20)
							ratio = (double)(user.TotalActiveDays - (user.RankAfterPeriod?.ActiveDays ?? 0)) / (double)(nextRank.ActiveDays - (user.RankAfterPeriod?.ActiveDays ?? 0));
						else
							ratio = (double)(user.TotalEditCount - (user.RankAfterPeriod?.Edits ?? 0)) / (double)(nextRank.Edits - (user.RankAfterPeriod?.Edits ?? 0));

						rankPosition += ratio;
						user.NextRank = nextRank;
					}

					user.RankPosition = rankPosition;
				}
			}

			List<string> anons = anonsReader.Items;

			IQueryable<User> baseUserList = statisticsData.Users.Values.AsQueryable();
			IEnumerable<OrderedItem> keylist;

			if (rankListOutputRadioButton.Checked)
			{
				baseUserList = baseUserList
					.Where(user => user.RankAfterPeriod != null)
					.SmartOrderBy(user => user.RankAfterPeriod.Level);
			}

			switch (order)
			{
				case "all":
					keylist = baseUserList.SmartOrderByDescending(user => user.TotalEditCount)
						.Select(user => new OrderedItem() { UserId = user.Name, Key = user.TotalEditCount });
					break;
				case "allRev":
					keylist = baseUserList.SmartOrderByDescending(user => user.TotalRevertedEditCount)
						.Select(user => new OrderedItem() { UserId = user.Name, Key = user.TotalRevertedEditCount });
					break;
				case "allRev%":
					keylist = baseUserList.SmartOrderByDescending(user => user.TotalRevertedEditPercentage)
						.Select(user => new OrderedItem() { UserId = user.Name, Key = user.TotalRevertedEditPercentage });
					break;
				case "period":
					keylist = baseUserList.SmartOrderByDescending(user => user.TotalEditCountInPeriod)
						.Select(user => new OrderedItem() { UserId = user.Name, Key = user.TotalEditCountInPeriod });
					break;
				case "periodRev":
					keylist = baseUserList.SmartOrderByDescending(user => user.TotalRevertedEditCountInPeriod)
						.Select(user => new OrderedItem() { UserId = user.Name, Key = user.TotalRevertedEditCountInPeriod });
					break;
				case "periodRev%":
					keylist = baseUserList.SmartOrderByDescending(user => user.TotalRevertedEditPercentageInPeriod)
						.Select(user => new OrderedItem() { UserId = user.Name, Key = user.TotalRevertedEditPercentageInPeriod });
					break;
				case "name":
					keylist = baseUserList.SmartOrderBy(x => x.Name)
						.Select(u => new OrderedItem() { UserId = u.Name, Key = u.Name });
					break;
				case "rank":
					keylist = baseUserList.SmartOrderByDescending(x => x.RankPosition)
						.Select(u => new OrderedItem() { UserId = u.Name, Key = u.RankPosition });
					break;
				case "firstedit":
					keylist = baseUserList.SmartOrderByDescending(user => user.FirstEditTimestamp.Value)
						.Select(user => new OrderedItem() { UserId = user.Name, Key = user.FirstEditTimestamp.Value });
					break;
				case "lastedit":
					keylist = baseUserList.SmartOrderByDescending(x => x.LastEditTimestamp.Value)
						.Select(user => new OrderedItem() { UserId = user.Name, Key = user.LastEditTimestamp.Value });
					break;
				case "days":
					keylist = baseUserList.SmartOrderByDescending(user => user.TotalDays)
						.Select(user => new OrderedItem() { UserId = user.Name, Key = user.TotalDays });
					break;
				case "activedays":
					keylist = baseUserList.SmartOrderByDescending(user => user.TotalActiveDays)
						.Select(user => new OrderedItem() { UserId = user.Name, Key = user.TotalActiveDays });
					break;
				case "meanedits":
					keylist = baseUserList.SmartOrderByDescending(user => user.MeanEditsPerDay)
						.Select(user => new OrderedItem() { UserId = user.Name, Key = user.MeanEditsPerDay });
					break;
				case "periodactivedays":
					keylist = baseUserList.SmartOrderByDescending(user => user.GetActiveDaysInPeriod(start, endDatePicker.Value))
						.Select(user => new OrderedItem() { UserId = user.Name, Key = user.GetActiveDaysInPeriod(start, endDatePicker.Value) });
					break;
				case "periodmeanedits":
					keylist = baseUserList.SmartOrderByDescending(user => user.GetMeanEditsPerDayInPeriod(startDatePicker.Value, endDatePicker.Value))
						.Select(user => new OrderedItem() { UserId = user.Name, Key = user.GetMeanEditsPerDayInPeriod(startDatePicker.Value, endDatePicker.Value) });
					break;
				default:
					if (order.StartsWith("allns"))
					{
						int nsId = Convert.ToInt32(order.Substring(5));
						keylist = baseUserList.SmartOrderByDescending(user => user.GetAllEditsByNamespace(nsId))
							.Select(user => new OrderedItem() { UserId = user.Name, Key = user.GetAllEditsByNamespace(nsId) });
					}
					else if (order.StartsWith("periodns"))
					{
						int nsId = Convert.ToInt32(order.Substring(8));
						keylist = baseUserList.SmartOrderByDescending(user => user.GetEditsInPeriodByNamespace(nsId))
							.Select(user => new OrderedItem() { UserId = user.Name, Key = user.GetEditsInPeriodByNamespace(nsId) });
					}
					else if (order.StartsWith("allpcns"))
					{
						int nsId = Convert.ToInt32(order.Substring(7));
						keylist = baseUserList.SmartOrderByDescending(user => user.GetAllEditPercentageByNamespace(nsId))
							.Select(user => new OrderedItem() { UserId = user.Name, Key = user.GetAllEditPercentageByNamespace(nsId) });
					}
					else if (order.StartsWith("periodpcns"))
					{
						int nsId = Convert.ToInt32(order.Substring(10));
						keylist = baseUserList.SmartOrderByDescending(user => user.GetEditPercentageInPeriodByNamespace(nsId))
							.Select(user => new OrderedItem() { UserId = user.Name, Key = user.GetEditPercentageInPeriodByNamespace(nsId) });
					}
					else
					{
						throw new Exception();
					}
					break;
			}

			if (reverseOrderCheckbox.Checked == true)
				keylist = keylist.Reverse();

			if (rankListOutputRadioButton.Checked || statisticsOutputRadioButton.Checked)
			{
				GenerateStandardStatisticsOrRankList(statisticsData, start, anons, keylist);
			}
			else if (templateDataOutputRadioButton.Checked)
			{
				GenerateTemplateData(statisticsData, start, anons, keylist);
			}

			UpdateStatus("Kész.", 0, true);
			cancelButton.Text = "OK";
		}

		private void GenerateStandardStatisticsOrRankList(StatisticsData statisticsData, DateTime? start, List<string> anons, IEnumerable<OrderedItem> keylist)
		{
			using (TextWriter tw = new StreamWriter(outputFileTextBox.Text))
			{
				int actuserCounter = 0;
				object lastEditCount = null;

				if (rankListOutputRadioButton.Checked == false)
				{
					if (startDateCheckBox.Checked)
					{
						//tw.WriteLine(s)
						var startDateDisplayed = startDatePicker.Value.ToString("yyyy. MMMM d.", CultureInfo.GetCultureInfo("hu-HU"));
						var endDateDisplayed = endDatePicker.Value.ToString("yyyy. MMMM d.", CultureInfo.GetCultureInfo("hu-HU"));
						var dailyAverageEdits = ((double)statisticsData.AllRevisionsInPeriod / Convert.ToDouble(endDatePicker.Value.Date.DaysBetween(startDatePicker.Value.Date)));

						tw.WriteLine(
							$"Az adott időszakban ({startDateDisplayed}–{endDateDisplayed}) " +
							$"a magyar Wikipédiában eddig átlagosan napi {DoubleToHungarifiedNumberString(dailyAverageEdits)} szerkesztés történt. " +
							$"{LongToHungarifiedNumberString(statisticsData.AllRegisteredUsersInPeriod)} regisztrált szerkesztő {LongToHungarifiedNumberString(statisticsData.AllRegisteredUserEditsInPeriod)} szerkesztést, " +
							$"{LongToHungarifiedNumberString(statisticsData.AllBotUsersInPeriod)} bot {LongToHungarifiedNumberString(statisticsData.AllBotUserEditsInPeriod)} szerkesztést és " +
							$"{LongToHungarifiedNumberString(statisticsData.AllNonRegisteredUsersInPeriod)} nem regisztrált szerkesztő {LongToHungarifiedNumberString(statisticsData.AllNonRegisteredUserEditsInPeriod)} szerkesztést végzett.\n"
						);
					}
					else
					{
						var dailyAverageEdits = ((double)statisticsData.AllRevisions / Convert.ToDouble(endDatePicker.Value.Date.DaysBetween(statisticsData.FirstEditInWiki.Date)));

						tw.WriteLine(
							$"A magyar Wikipédiában eddig átlagosan napi {DoubleToHungarifiedNumberString(dailyAverageEdits)} szerkesztés történt. " +
							$"{LongToHungarifiedNumberString(statisticsData.AllRegisteredUsers)} regisztrált szerkesztő {LongToHungarifiedNumberString(statisticsData.AllRegisteredUserEdits)} szerkesztést, " +
							$"{LongToHungarifiedNumberString(statisticsData.AllBotUsers)} bot {LongToHungarifiedNumberString(statisticsData.AllBotUserEdits)} szerkesztést és " +
							$"{LongToHungarifiedNumberString(statisticsData.AllNonRegisteredUsers)} nem regisztrált szerkesztő {LongToHungarifiedNumberString(statisticsData.AllNonRegisteredUserEdits)} szerkesztést végzett.\n"
						);
					}
				}

				StringBuilder header = GetOutputTableHeader();
				StringBuilder tableContent = new StringBuilder();

				if (rankListOutputRadioButton.Checked)
				{
					tableContent.AppendLine("{| class=\"sortable wikitable\"\n! Rang !! Felhasználók");
					tableContent.AppendLine("|-");
				}

				int listUserEdits = 0;
				int listUserEditsInPeriod = 0;
				int maxUsersInList = Convert.ToInt32(userCountBox.Value);
				ServiceRankRequirement previousRank = null;

				int userCounter = 0;
				foreach (OrderedItem oitem in keylist)
				{
					string currentUserId = oitem.UserId;
					User u = statisticsData.Users[currentUserId];

					if (useAnonListCheckBox.Checked && anons.Contains(currentUserId))
						continue;

					if (showRegisteredUsersCheckbox.Checked == false
						&& u.IsBot == false
						&& u.UserType == UserType.Registered)
						continue;

					if (showBotsCheckBox.Checked == false
						&& u.IsBot)
						continue;

					if (showUnregisteredUsersCheckbox.Checked == false
						&& u.UserType == UserType.Anonymous)
						continue;

					if (allEditsAtLeastBox.Value > 0 && u.TotalEditCount < allEditsAtLeastBox.Value)
						continue;

					if (allEditsAtMostBox.Value > 0 && u.TotalEditCount > allEditsAtMostBox.Value)
						continue;

					if (startDateCheckBox.Checked &&
						allEditsInPeriodAtLeastBox.Value > 0 &&
						u.TotalEditCountInPeriod < allEditsInPeriodAtLeastBox.Value)
						continue;

					if (startDateCheckBox.Checked &&
						allEditsInPeriodAtMostBox.Value > 0 &&
						u.TotalEditCountInPeriod < allEditsInPeriodAtMostBox.Value)
						continue;

					if (activeDaysAtLeastBox.Value > 0 && u.TotalActiveDays < activeDaysAtLeastBox.Value)
						continue;

					if (activeDaysAtMostBox.Value > 0 && u.TotalActiveDays > activeDaysAtMostBox.Value)
						continue;

					if (startDateCheckBox.Checked &&
						activePeriodDaysAtLeastBox.Value > 0 &&
						u.GetActiveDaysInPeriod(start.Value, endDatePicker.Value) < activePeriodDaysAtLeastBox.Value)
						continue;

					if (startDateCheckBox.Checked &&
						activePeriodDaysAtMostBox.Value > 0 &&
						u.GetActiveDaysInPeriod(start.Value, endDatePicker.Value) > activePeriodDaysAtMostBox.Value)
						continue;

					if (showOnlyRankChanges.Checked && u.RankBeforePeriod == u.RankAfterPeriod)
						continue;

					if (showUsersWithAGivenRankCheckbox.Checked
						&& Object.Equals(u.RankAfterPeriod, rankListComboBox.SelectedItem) == false)
					{
						continue;
					}

					if (rankListOutputRadioButton.Checked)
					{
						if (u.RankAfterPeriod == null)
							continue;

						if (previousRank != u.RankAfterPeriod)
						{
							if (previousRank != null)
							{
								tableContent.AppendLine("\n|-");
							}

							tableContent.AppendLine($"| {u.RankAfterPeriod.RankName}");
							tableContent.Append("| ");
							previousRank = u.RankAfterPeriod;
							actuserCounter = 0;
							userCounter = 0;
							lastEditCount = null;
						}
					}

					if (!u.IsBot)
						actuserCounter++;

					if (order == "firstedit")
					{
						if (lastEditCount == null ||
							(reverseOrderCheckbox.Checked == false && (DateTime)lastEditCount < (DateTime)oitem.Key) ||
							(reverseOrderCheckbox.Checked == true && (DateTime)lastEditCount > (DateTime)oitem.Key))
						{

							if (maxUsersInList > 0 && actuserCounter > maxUsersInList)
								break;
							if (!u.IsBot)
							{
								userCounter = actuserCounter;
								lastEditCount = oitem.Key;
							}
						}
					}
					else if (order == "lastedit")
					{
						if (lastEditCount == null ||
							(reverseOrderCheckbox.Checked == false && (DateTime)lastEditCount > (DateTime)oitem.Key) ||
							(reverseOrderCheckbox.Checked == true && (DateTime)lastEditCount < (DateTime)oitem.Key))
						{
							if (maxUsersInList > 0 && actuserCounter > maxUsersInList)
								break;
							if (!u.IsBot)
							{
								userCounter = actuserCounter;
								lastEditCount = oitem.Key;
							}
						}
					}
					else if (order == "name")
					{
						if (maxUsersInList > 0 && actuserCounter > maxUsersInList)
							break;

						userCounter = actuserCounter;
					}
					else
					{
						if (lastEditCount == null ||
							(reverseOrderCheckbox.Checked == false && (double)lastEditCount > Convert.ToDouble(oitem.Key)) ||
							(reverseOrderCheckbox.Checked == true && (double)lastEditCount < Convert.ToDouble(oitem.Key)))
						{
							if (maxUsersInList > 0 && actuserCounter > maxUsersInList)
								break;

							if (!u.IsBot)
							{
								userCounter = actuserCounter;
								lastEditCount = Convert.ToDouble(oitem.Key);
							}
						}
					}

					if (!u.IsBot)
					{
						listUserEdits += u.TotalEditCount;
						listUserEditsInPeriod += u.TotalEditCountInPeriod;
					}

					if (rankListOutputRadioButton.Checked)
					{
						tableContent.Append("[[User:" + u.Name + "|" + u.Name + "]], ");
						continue;
					}

					tableContent.Append("|-\n| ");

					if (!u.IsBot)
						tableContent.Append(userCounter + ". ");
					tableContent.Append("|| {{user2|" + u.Name + "}}");
					if (showPrivilegesCheckBox.Checked)
					{
						string rAppend = string.Empty;
						if (u.HasRight(qcz.Dump.Right.Sysop))
							rAppend = rAppend.AppendWithComma("adminisztrátor");
						if (u.HasRight(qcz.Dump.Right.Bureaucrat))
							rAppend = rAppend.AppendWithComma("bürokrata");
						if (u.HasRight(qcz.Dump.Right.Editor))
							rAppend = rAppend.AppendWithComma("járőr");
						if (u.HasRight(qcz.Dump.Right.Trusted))
							rAppend = rAppend.AppendWithComma("megerősített&nbsp;szerk.");
						if (u.HasRight(qcz.Dump.Right.Checkuser))
							rAppend = rAppend.AppendWithComma("IP-ellenőr");
						if (u.HasRight(qcz.Dump.Right.Bot))
							rAppend = rAppend.AppendWithComma("bot");
						if (u.HasRight(qcz.Dump.Right.UnflaggedBot))
							rAppend = rAppend.AppendWithComma("flag&nbsp;nélküli&nbsp;bot");
						if (privilegesUnderCheckBox.Checked)
						{
							if (rAppend != "")
								tableContent.Append("<br/><small>(" + rAppend + ")</small>");
						}
						else
						{
							tableContent.Append(" || ");
							if (rAppend != "")
								tableContent.Append("<small>" + rAppend + "</small>");
						}
					}
					if (showRankBeforePeriodCheckBox.Checked)
					{
						tableContent.Append(" || " + (u.RankBeforePeriod?.RankName ?? "''nincs''"));
					}

					if (showRankInPeriodCheckBox.Checked)
					{
						tableContent.Append(" || {{Rrk|" + u.RankPosition.ToString("0.0##", CultureInfo.InvariantCulture) + "}}"
							+ (u.RankAfterPeriod?.RankName ?? "''nincs''"));
					}
					if (showRankChangeInPeriodCheckBox.Checked)
					{
						var changeMarker = u.RankAfterPeriod != null && u.RankAfterPeriod != u.RankBeforePeriod ? " {{Szintlépés}}" : "";
						tableContent.Append(" || {{Rrk|" + u.RankPosition.ToString("0.0##", CultureInfo.InvariantCulture) + "}}"
							+ changeMarker
							+ (u.RankAfterPeriod?.RankName ?? "''nincs''"));
					}

					if (allEditsCheckBox.Checked)
						tableContent.Append(" || " + u.TotalEditCount);
					if (revertedEditsCheckBox.Checked)
						tableContent.Append(" || " + u.TotalRevertedEditCount);
					if (revertedEditsPercentageCheckBox.Checked)
						tableContent.Append(" || " + u.TotalRevertedEditPercentage.ToString("0.00%", CultureInfo.GetCultureInfo("hu-HU")));
					foreach (int i in selectedAllNamespaces)
						tableContent.Append(" || " + u.GetAllEditsByNamespace(i));
					foreach (int i in selectedAllPercentNamespaces)
						tableContent.Append(" || " + u.GetAllEditPercentageByNamespace(i).ToString(percentFormat));
					if (startDateCheckBox.Checked)
					{
						if (periodEditsCheckBox.Checked)
							tableContent.Append(" || " + u.TotalEditCountInPeriod);
						if (periodRevertedEditsCheckBox.Checked)
							tableContent.Append(" || " + u.TotalRevertedEditCountInPeriod);
						if (periodRevertedEditsPercentageCheckBox.Checked)
							tableContent.Append(" || " + u.TotalRevertedEditPercentageInPeriod.ToString("0.00%", CultureInfo.GetCultureInfo("hu-HU")));
						foreach (int i in selectedPeriodNamespaces)
							tableContent.Append(" || " + u.GetEditsInPeriodByNamespace(i));
						foreach (int i in selectedPeriodPercentNamespaces)
							tableContent.Append(" || " + u.GetEditPercentageInPeriodByNamespace(i).ToString(percentFormat));
					}
					if (firstEditCheckBox.Checked)
						tableContent.Append(" || " + u.FirstEditTimestamp.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
					if (lastEditCheckBox.Checked)
						tableContent.Append(" || " + u.LastEditTimestamp.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
					if (daysCheckBox.Checked)
						tableContent.Append(" || " + u.TotalDays);
					if (activeDaysCheckBox.Checked)
						tableContent.Append(" || " + u.TotalActiveDays);
					if (startDateCheckBox.Checked && activePeriodDaysCheckBox.Checked)
						tableContent.Append(" || " + u.GetActiveDaysInPeriod(start, endDatePicker.Value));
					if (meanEditsCheckBox.Checked)
						tableContent.Append(" || " + u.MeanEditsPerDay.ToString(doubleFormat));
					if (startDateCheckBox.Checked && periodMeanEditsCheckBox.Checked)
						tableContent.Append(" || " + u.GetMeanEditsPerDayInPeriod(startDatePicker.Value.Date, endDatePicker.Value.Date).ToString(doubleFormat));
					tableContent.Append("\n");
				}

				tableContent.Append("|}");

				if (startDateCheckBox.Checked)
				{
					tw.WriteLine(String.Format(
						"A listában szereplő {0} szerkesztő összesen {1} szerkesztést tett az adott időszakban, ami szerkesztőnként átlagosan {2} szerkesztést jelent. Ez a magyar Wikipédia adott időszakban végzett {3} szerkesztésének {4}-a.",
						actuserCounter - 1,
						LongToHungarifiedNumberString(listUserEditsInPeriod),
						DoubleToHungarifiedNumberString((double)listUserEditsInPeriod / ((double)actuserCounter - 1.0)),
						LongToHungarifiedNumberString(statisticsData.AllRevisionsInPeriod),
						((double)listUserEditsInPeriod / (double)statisticsData.AllRevisionsInPeriod).ToString(percentFormat)
					));
				}
				else
				{
					tw.WriteLine(String.Format(
						"A listában szereplő {0} szerkesztő összesen {1} szerkesztést tett, ami szerkesztőnként átlagosan {2} szerkesztést jelent. Ez a magyar Wikipédia összes, {3} szerkesztésének {4}-a.",
						actuserCounter - 1,
						LongToHungarifiedNumberString(listUserEdits),
						DoubleToHungarifiedNumberString((double)listUserEdits / ((double)actuserCounter - 1.0)),
						LongToHungarifiedNumberString(statisticsData.AllRevisions),
						((double)listUserEdits / (double)statisticsData.AllRevisions).ToString(percentFormat)
					));
				}

				if (rankListOutputRadioButton.Checked == false)
					tw.WriteLine(header.ToString());

				tw.Write(tableContent.ToString());

				GenerateFooter(tw);

				tw.Flush();
			}
		}

		private string LongToHungarifiedNumberString(long number)
		{
			return number.ToString("#,0", hungarianCulture).Replace(" ", "&nbsp;");
		}

		private string DoubleToHungarifiedNumberString(double number)
		{
			return number.ToString(doubleFormat, hungarianCulture).Replace(" ", "&nbsp;");
		}

		private void GenerateFooter(TextWriter tw)
		{
			var smhNameMatcher = new Regex(@"(\d{8})-stub-meta-history");

			var dateMatch = smhNameMatcher.Match(StubMetHistoryDumpFilePath);
			DateTime dumpDate = DateTime.MinValue;
			string footerIntro;

			if (dateMatch.Success)
			{
				var rawDumpDate = dateMatch.Groups[1].Value;
				DateTime.TryParseExact(rawDumpDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dumpDate);

			}
			
			if (dumpDate != DateTime.MinValue)
			{
				var dumpDateDisplayed = dumpDate.ToString(NICE_DATETIME_FORMAT_STRING, hungarianCulture);

				footerIntro = $"\n\nEz a statisztika a {dumpDateDisplayed}-i adatbázisdump " +
					$"<tt>{Path.GetFileName(StubMetHistoryDumpFilePath)}</tt> és " +
					$"<tt>{Path.GetFileName(UserGroupsDumpFilePath)}</tt> állományai alapján és ''qczWikiStat'' segítségével készült";
			}
			else
			{
				footerIntro = $"\nEz a statisztika a " +
					$"<tt>{Path.GetFileName(StubMetHistoryDumpFilePath)}</tt> és " +
					$"<tt>{Path.GetFileName(UserGroupsDumpFilePath)}</tt> állományok alapján és ''qczWikiStat'' segítségével készült";
			}

			var endDateDisplayed = endDatePicker.Value.ToString(NICE_DATETIME_FORMAT_STRING, hungarianCulture);
			if (startDateCheckBox.Checked)
			{
				var startDateDisplayed = startDatePicker.Value.ToString(NICE_DATETIME_FORMAT_STRING, hungarianCulture);

				tw.Write($"{footerIntro} a {startDateDisplayed}–{endDateDisplayed} időszakra.");
			}
			else
			{
				tw.Write($"{footerIntro} a {endDateDisplayed}-ig keletkezett adatokból.");
			}
		}

		private void GenerateTemplateData(StatisticsData statisticsData, DateTime? start, List<string> anons, IEnumerable<OrderedItem> keylist)
		{
			using (TextWriter tw = new StreamWriter(outputFileTextBox.Text))
			{
				var firstRank = ServiceRankRequirements[0];
				var requiredActiveDays = firstRank.ActiveDays / 2;
				var requiredTotalEdits = firstRank.Edits / 2;

				//string prevStartingCharacter = null;
				tw.WriteLine("ranks = {\n");
				foreach (var rank in ServiceRankRequirements)
				{
					tw.WriteLine("\t{ "
						+ $"{rank.Level}, "
						+ $"\"{rank.RankName}\", "
						+ $"{rank.ActiveDays}, "
						+ $"{rank.Edits}, "
						+ "},");
				}
				tw.WriteLine("}\n");

				tw.WriteLine("statistics = {\n");

				foreach (var userKvp in statisticsData.Users
					.Where(x => x.Value.UserType == UserType.Registered
						&& x.Value.IsBot == false
						&& x.Value.TotalEditCount >= requiredTotalEdits
						&& x.Value.TotalEditCount >= requiredActiveDays)
					.OrderBy(x => x.Key))
				{
					if (string.IsNullOrEmpty(userKvp.Key))
						continue;

					var userData = userKvp.Value;
					tw.WriteLine($"\t[\"{userKvp.Key}\"] = {{ "
						+ $"{userData.RankAfterPeriod?.Level ?? -1}, "
						+ $"{userData.TotalActiveDays}, "
						+ $"{userData.TotalEditCount}, "
						+ $"{userData.NextRank?.Level ?? -1} "
						+ "}");
					//var currentStartingCharacter = userKvp.Key.Substring(0, 1);
					//if (prevStartingCharacter != currentStartingCharacter)
					//{

					//}
				}
				tw.WriteLine("}\n");
			}
		}
		private StringBuilder GetOutputTableHeader()
		{
			StringBuilder header = new StringBuilder("{| class=\"sortable wikitable\"\n! # !! Név");
			if (showPrivilegesCheckBox.Checked && privilegesInNewColumnCheckBix.Checked)
				header.Append(" !! Jogosultságok");
			if (showRankBeforePeriodCheckBox.Checked)
				header.Append(" !! Előző rang");
			if (showRankInPeriodCheckBox.Checked)
				header.Append(" !! Aktuális rang");
			if (showRankChangeInPeriodCheckBox.Checked)
				header.Append(" !! Rang");

			if (allEditsCheckBox.Checked)
				header.Append(" !! Összes szerk.");
			if (revertedEditsCheckBox.Checked)
				header.Append(" !! Visszavont szerk.");
			if (revertedEditsPercentageCheckBox.Checked)
				header.Append(" !! Visszavont %");
			foreach (int i in selectedAllNamespaces)
				if (i == 0)
					header.Append(" !! Ö:Szócikk névtér");
				else
					header.Append(" !! Ö:" + smhDump.GetNamespace(i));
			foreach (int i in selectedAllPercentNamespaces)
				if (i == 0)
					header.Append(" !! Ö%:Szócikk névtér");
				else
					header.Append(" !! Ö%:" + smhDump.GetNamespace(i));
			if (startDateCheckBox.Checked)
			{
				if (periodEditsCheckBox.Checked)
					header.Append(" !! Összes szerk. az időszakban");
				if (periodRevertedEditsCheckBox.Checked)
					header.Append(" !! Visszavont szerk. az időszakban");
				if (periodRevertedEditsPercentageCheckBox.Checked)
					header.Append(" !! Visszavont % az időszakban");
				foreach (int i in selectedPeriodNamespaces)
					if (i == 0)
						header.Append(" !! I:Szócikk névtér");
					else
						header.Append(" !! I:" + smhDump.GetNamespace(i));
				foreach (int i in selectedPeriodPercentNamespaces)
					if (i == 0)
						header.Append(" !! I%:Szócikk névtér");
					else
						header.Append(" !! I%:" + smhDump.GetNamespace(i));
			}
			if (firstEditCheckBox.Checked)
				header.Append(" !! Első szerk.");
			if (lastEditCheckBox.Checked)
				header.Append(" !! Utolsó szerk.");
			if (daysCheckBox.Checked)
				header.Append(" !! Napok");
			if (activeDaysCheckBox.Checked)
				header.Append(" !! Aktív napok");
			if (startDateCheckBox.Checked && activePeriodDaysCheckBox.Checked)
				header.Append(" !! Aktív napok az időszakban");
			if (meanEditsCheckBox.Checked)
				header.Append(" !! Átlagos szerk./nap");
			if (startDateCheckBox.Checked && periodMeanEditsCheckBox.Checked)
				header.Append(" !! Átlagos szerk./nap az időszakban");
			return header;
		}

		private void CancelButtonClick(object sender, EventArgs e)
		{
			AbortBackgroundWorker();
			cancelButton.Visible = false;
			cancelButton.Text = "Mégse";
			exitButton.Visible = false;
			doStatisticsButton.Visible = true;
			progressText.Visible = false;
			progressBar.Visible = false;
			settingsTabControl.Enabled = true;
		}

		private void showUsersWithAGivenRankCheckboxCheckedChanged(object sender, EventArgs e)
		{
			rankListComboBox.Enabled = showUsersWithAGivenRankCheckbox.Checked;
		}

		private void rankListOutputRadioButton_CheckedChanged(object sender, EventArgs e)
		{
		}
	}
}
