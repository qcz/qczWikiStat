using Microsoft.WindowsAPICodePack.Taskbar;
using qcz.Dump;
using qcz.Dump.StubMetaHistory;
using qcz.Dump.UserGroups;
using qcz.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace qczWikiStat
{
	public partial class MainForm : Form
	{
		private StubMetaHistoryDumpReader smhDump = null;
		private UserGroupsDumpReader ugDump = null;
		private BackgroundWorker dumpBackgroundWorker;
		private List<OrderItem> orderItems = null;
		private string order = "all";
		private FileStringListReader botsReader;
		private FileStringListReader anonsReader;

		private Dictionary<int, string> namespaces;
		private List<int> selectedAllNamespaces;
		private List<int> selectedPeriodNamespaces;
		private List<int> selectedAllPercentNamespaces;
		private List<int> selectedPeriodPercentNamespaces;
		private Dictionary<string, User> users;
		private DateTime endDay;
		private DateTime? firstDay;
		private DateTime firstEditInWiki;
		private int articles = 0;
		private int allRevs = 0;
		private int allRevsByLoggedIn = 0;
		private int allRevsInPeriod = 0;
		private int allRevsInPeriodByLoggedIn = 0;
		private HashSet<string> allUsersInPeriod;
		private string doubleFormat = "0.00";
		private string percentFormat = "0.##%";

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainFormLoad(object sender, EventArgs e)
		{
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
			settingsTabControl.TabPages.Remove(generalDataTab);
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
			if (startDateCheckBox.Checked)
			{
				foreach (Control c in userDataTab.Controls)
					if (c.Tag != null && c.Tag.GetType() == String.Empty.GetType() &&
						((string)c.Tag) == "startDateDef")
						c.Enabled = true;
				startDatePicker.Enabled = true;
				UpdateOrderList();
			}
			else
			{
				foreach (Control c in userDataTab.Controls)
					if (c.Tag != null && c.Tag.GetType() == String.Empty.GetType() &&
						((string)c.Tag) == "startDateDef")
						c.Enabled = false;
				startDatePicker.Enabled = false;
				UpdateOrderList();
			}
		}

		private void ShowPrivilegesCheckBoxCheckedChanged(object sender, EventArgs e)
		{
			if (showPrivilegesCheckBox.Checked)
			{
				privilegesUnderCheckBox.Enabled = true;
				privilegesInNewColumnCheckBix.Enabled = true;
			}
			else
			{
				privilegesUnderCheckBox.Enabled = false;
				privilegesInNewColumnCheckBix.Enabled = false;
			}
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
			smhDump = new StubMetaHistoryDumpReader(smhDumpTextBox.Text, XmlDumpReaderBase.NONE);
			ugDump = new UserGroupsDumpReader(ugDumpTextBox.Text);
			orderItems = new List<OrderItem>();

			orderItems.Add(new OrderItem() { OrderId = "all", Desc = "Összes szerkesztés" });
			orderItems.Add(new OrderItem() { OrderId = "period", Desc = "Szerkesztés az adott időszakban", Type = OrderItemType.Period });

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

			allUsersInPeriod = new HashSet<string>();
			firstEditInWiki = DateTime.MaxValue;
			users = new Dictionary<string, User>();
			endDay = endDatePicker.Value.Date;
			firstDay = null;
			if (startDateCheckBox.Checked)
				firstDay = startDatePicker.Value.Date;
			articles = 0;
			allRevs = 0;
			allRevsInPeriod = 0;
			allRevsInPeriodByLoggedIn = 0;

			bool exitAtAC = processedPagesCount.Value > 0;
			int processedArticles = Convert.ToInt32(processedPagesCount.Value);

			foreach (DumpArticle article in smhDump)
			{
				if (worker.CancellationPending)
					break;

				articles++;
				if (articles % 100 == 0)
				{
					var progress = (double)smhDump.GetPosition() / (double)smhDump.GetFileLength() * 100d;
					UpdateStatus(string.Format("Feldolgozás folyamatban, {0} lap kész. ({1:0.00}%)", articles, progress),
						Convert.ToInt32(progress),
						false);
				}

				int artNs = smhDump.GetNamespace(article.Title);

				foreach (DumpArticleRevision articleRev in article)
				{
					// az anonok és jövőbeli események kihagyása
					if (articleRev.TimeStamp.Value.Date > endDay.Date)
						continue;
					if (articleRev.TimeStamp.Value < firstEditInWiki)
						firstEditInWiki = articleRev.TimeStamp.Value;
					allRevs++;
					if (firstDay != null && articleRev.TimeStamp.Value.Date >= firstDay.Value.Date)
						allRevsInPeriod++;
					if (articleRev.UserId == 0)
						continue;
					allRevsByLoggedIn++;

					if (articleRev.UserName == null)
						continue;

					User cur = null;
					if (users.ContainsKey(articleRev.UserName))
						cur = users[articleRev.UserName];
					else
					{
						cur = new User(articleRev.UserName);
						cur.Id = articleRev.UserId;
						users.Add(articleRev.UserName, cur);
						cur.AddRights(ugDump.GetUserRights(cur.Id));
					}

					cur.IncAllEdits(artNs);
					if (!cur.LastEdit.HasValue || cur.LastEdit.Value < articleRev.TimeStamp)
						cur.LastEdit = articleRev.TimeStamp;
					if (!cur.FirstEdit.HasValue || cur.FirstEdit.Value > articleRev.TimeStamp)
					{
						if (cur.Name == "TurkászBot" && articleRev.TimeStamp.HasValue && articleRev.TimeStamp.Value.Year < 2015)
						{

						}
						cur.FirstEdit = articleRev.TimeStamp;
					}
					cur.AddEditDay(articleRev.TimeStamp.Value);

					if (firstDay != null && articleRev.TimeStamp.Value.Date < firstDay.Value.Date)
						continue;

					/* TODO: remove? */
					if (!allUsersInPeriod.Contains(articleRev.UserName))
						allUsersInPeriod.Add(articleRev.UserName);
					allRevsInPeriodByLoggedIn++;
					cur.IncCurEdits(artNs);
				}
				if (exitAtAC && processedArticles == articles)
					break;
			}

			if (worker.CancellationPending == true)
				e.Cancel = true;
			else
				this.BeginInvoke(new Action(( ) => {
					GenerateStatisticsOutput();
				}));
		}

		void DumpBackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				MessageBox.Show("Hiba történt a feldolgozás közben:\n" +
					e.Error.Message + "\n\n" + e.Error.GetType().Name + "\n" + e.Error.StackTrace);
			}
		}

		private void GenerateStatisticsOutput()
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
				foreach (string s in botsReader.Items)
					if (users.ContainsKey(s) && !users[s].HasRight(qcz.Dump.Right.Bot))
						users[s].AddRights(qcz.Dump.Right.UnflaggedBot);
			List<string> anons = anonsReader.Items;

			IEnumerable<OrderedItem> keylist;
			switch (order)
			{
				case "all":
					keylist = from s in users.Keys
							  orderby users[s].AllEdits descending
							  select new OrderedItem() { UserId = s, Key = users[s].AllEdits };
					break;
				case "period":
					keylist = from s in users.Keys
							  orderby users[s].PeriodEdits descending
							  select new OrderedItem() { UserId = s, Key = users[s].PeriodEdits };
					break;
				case "firstedit":
					keylist = from s in users.Keys
							  orderby users[s].FirstEdit.Value ascending
							  select new OrderedItem() { UserId = s, Key = users[s].FirstEdit.Value };
					break;
				case "lastedit":
					keylist = from s in users.Keys
							  orderby users[s].LastEdit.Value descending
							  select new OrderedItem() { UserId = s, Key = users[s].LastEdit.Value };
					break;
				case "days":
					keylist = from s in users.Keys
							  orderby users[s].AllDays descending
							  select new OrderedItem() { UserId = s, Key = users[s].AllDays };
					break;
				case "activedays":
					keylist = from s in users.Keys
							  orderby users[s].ActiveDays descending
							  select new OrderedItem() { UserId = s, Key = users[s].ActiveDays };
					break;
				case "meanedits":
					keylist = from s in users.Keys
							  orderby users[s].MeanEditsPerDay descending
							  select new OrderedItem() { UserId = s, Key = users[s].MeanEditsPerDay };
					break;
				case "periodactivedays":
					keylist = from s in users.Keys
							  orderby users[s].PeriodActiveDays(start, endDatePicker.Value) descending
							  select new OrderedItem() { UserId = s, Key = users[s].PeriodActiveDays(start, endDatePicker.Value) };
					break;
				case "periodmeanedits":
					keylist = from s in users.Keys
							  orderby users[s].PeriodMeanEditsPerDay(startDatePicker.Value, endDatePicker.Value) descending
							  select new OrderedItem() { UserId = s, Key = users[s].PeriodMeanEditsPerDay(startDatePicker.Value, endDatePicker.Value) };
					break;
				default:
					if (order.StartsWith("allns"))
					{
						int nsId = Convert.ToInt32(order.Substring(5));
						keylist = from s in users.Keys
								  orderby users[s].GetAllEditsByNs(nsId) descending
								  select new OrderedItem() { UserId = s, Key = users[s].GetAllEditsByNs(nsId) };
					}
					else if (order.StartsWith("periodns"))
					{
						int nsId = Convert.ToInt32(order.Substring(8));
						keylist = from s in users.Keys
								  orderby users[s].GetPeriodEditsByNs(nsId) descending
								  select new OrderedItem() { UserId = s, Key = users[s].GetPeriodEditsByNs(nsId) };
					}
					else if (order.StartsWith("allpcns"))
					{
						int nsId = Convert.ToInt32(order.Substring(7));
						keylist = from s in users.Keys
								  orderby users[s].GetAllPcEditsByNs(nsId) descending
								  select new OrderedItem() { UserId = s, Key = users[s].GetAllPcEditsByNs(nsId) };
					}
					else if (order.StartsWith("periodpcns"))
					{
						int nsId = Convert.ToInt32(order.Substring(10));
						keylist = from s in users.Keys
								  orderby users[s].GetPeriodPcEditsByNs(nsId) descending
								  select new OrderedItem() { UserId = s, Key = users[s].GetPeriodPcEditsByNs(nsId) };
					}
					else
					{
						throw new Exception();
					}
					break;
			}

			if (reverseOrderCheckbox.Checked == true)
				keylist = keylist.Reverse();

			using (TextWriter tw = new StreamWriter(outputFileTextBox.Text))
			{
				int actuserCounter = 0;
				int userCounter = 0;
				object lastEditCount = null;

				if (startDateCheckBox.Checked)
				{
					tw.WriteLine(String.Format(
						"Az adott időszakban ({0}–{1}) a magyar Wikipédiában átlagosan napi {2} szerkesztés történt, botokkal együtt pedig {3} regisztrált felhasználó szerkesztett.\n",
						startDatePicker.Value.ToString("yyyy. MMMM d.", CultureInfo.GetCultureInfo("hu-HU")),
						endDatePicker.Value.ToString("yyyy. MMMM d.", CultureInfo.GetCultureInfo("hu-HU")),
						((double)allRevsInPeriod / Convert.ToDouble(endDatePicker.Value.Date.DaysBetween(startDatePicker.Value.Date))).ToString(doubleFormat),
						allUsersInPeriod.Count
					));
				}
				else
				{
					tw.WriteLine(String.Format(
						"A magyar Wikipédiában átlagosan napi {0} szerkesztés történt, botokkal együtt pedig {1} regisztrált felhasználó szerkesztett.\n",
						((double)allRevs / Convert.ToDouble(endDatePicker.Value.Date.DaysBetween(firstEditInWiki.Date))).ToString(doubleFormat),
						users.Keys.Count
					));
				}



				StringBuilder header = new StringBuilder("{| class=\"sortable wikitable\"\n! # !! Név");
				if (showPrivilegesCheckBox.Checked && privilegesInNewColumnCheckBix.Checked)
					header.Append(" !! Jogosultságok");
				if (allEditsCheckBox.Checked)
					header.Append(" !! Összes szerk.");
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

				StringBuilder newLine = new StringBuilder();

				int listUserEdits = 0;
				int listUserEditsInPeriod = 0;

				foreach (OrderedItem oitem in keylist)
				{
					string currentUserId = oitem.UserId;
					User u = users[currentUserId];

					if (useAnonListCheckBox.Checked && anons.Contains(currentUserId))
						continue;

					if (!showBotsCheckBox.Checked && (u.HasRight(qcz.Dump.Right.Bot) ||
						u.HasRight(qcz.Dump.Right.UnflaggedBot)))
						continue;

					if (allEditsAtLeastBox.Value > 0 && u.AllEdits < allEditsAtLeastBox.Value)
						continue;

					if (startDateCheckBox.Checked &&
						allEditsInPeriodAtLeastBox.Value > 0 &&
						u.PeriodEdits < allEditsInPeriodAtLeastBox.Value)
						continue;

					if (activeDaysAtLeastBox.Value > 0 && u.ActiveDays < activeDaysAtLeastBox.Value)
						continue;

					if (startDateCheckBox.Checked &&
						activePeriodDaysAtLeastBox.Value > 0 &&
						u.PeriodActiveDays(start.Value, endDatePicker.Value) < activePeriodDaysAtLeastBox.Value)
						continue;

					bool isBot = u.HasRight(qcz.Dump.Right.Bot) || u.HasRight(qcz.Dump.Right.UnflaggedBot);

					if (!isBot)
						actuserCounter++;
					if (order == "firstedit")
					{
						if (lastEditCount == null ||
							(reverseOrderCheckbox.Checked == false && (DateTime)lastEditCount < (DateTime)oitem.Key) ||
							(reverseOrderCheckbox.Checked == true && (DateTime)lastEditCount > (DateTime)oitem.Key))
						{
							if (actuserCounter > Convert.ToInt32(userCountBox.Value))
								break;
							if (!isBot)
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
							if (actuserCounter > Convert.ToInt32(userCountBox.Value))
								break;
							if (!isBot)
							{
								userCounter = actuserCounter;
								lastEditCount = oitem.Key;
							}
						}
					}
					else
					{
						if (lastEditCount == null ||
							(reverseOrderCheckbox.Checked == false && (double)lastEditCount > Convert.ToDouble(oitem.Key)) ||
							(reverseOrderCheckbox.Checked == true && (double)lastEditCount < Convert.ToDouble(oitem.Key)))
						{
							if (actuserCounter > Convert.ToInt32(userCountBox.Value))
								break;
							if (!isBot)
							{
								userCounter = actuserCounter;
								lastEditCount = Convert.ToDouble(oitem.Key);
							}
						}
					}

					if (!isBot)
					{
						listUserEdits += u.AllEdits;
						listUserEditsInPeriod += u.PeriodEdits;
					}

					newLine.Append("|-\n| ");

					if (!isBot)
						newLine.Append(userCounter + ". ");
					newLine.Append("|| {{user2|" + u.Name + "}}");
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
								newLine.Append("<br/><small>(" + rAppend + ")</small>");
						}
						else
						{
							newLine.Append(" || ");
							if (rAppend != "")
								newLine.Append("<small>" + rAppend + "</small>");
						}
					}
					if (allEditsCheckBox.Checked)
						newLine.Append(" || " + u.AllEdits);
					foreach (int i in selectedAllNamespaces)
						newLine.Append(" || " + u.GetAllEditsByNs(i));
					foreach (int i in selectedAllPercentNamespaces)
						newLine.Append(" || " + u.GetAllPcEditsByNs(i).ToString(percentFormat));
					if (startDateCheckBox.Checked)
					{
						if (periodEditsCheckBox.Checked)
							newLine.Append(" || " + u.PeriodEdits);
						foreach (int i in selectedPeriodNamespaces)
							newLine.Append(" || " + u.GetPeriodEditsByNs(i));
						foreach (int i in selectedPeriodPercentNamespaces)
							newLine.Append(" || " + u.GetPeriodPcEditsByNs(i).ToString(percentFormat));
					}
					if (firstEditCheckBox.Checked)
						newLine.Append(" || " + u.FirstEdit.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
					if (lastEditCheckBox.Checked)
						newLine.Append(" || " + u.LastEdit.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
					if (daysCheckBox.Checked)
						newLine.Append(" || " + u.AllDays);
					if (activeDaysCheckBox.Checked)
						newLine.Append(" || " + u.ActiveDays);
					if (startDateCheckBox.Checked && activePeriodDaysCheckBox.Checked)
						newLine.Append(" || " + u.PeriodActiveDays(start, endDatePicker.Value));
					if (meanEditsCheckBox.Checked)
						newLine.Append(" || " + u.MeanEditsPerDay.ToString(doubleFormat));
					if (startDateCheckBox.Checked && periodMeanEditsCheckBox.Checked)
						newLine.Append(" || " + u.PeriodMeanEditsPerDay(startDatePicker.Value.Date, endDatePicker.Value.Date).ToString(doubleFormat));
					newLine.Append("\n");
				}

				newLine.Append("|}");

				if (startDateCheckBox.Checked)
				{
					tw.WriteLine(String.Format(
						"A listában szereplő {0} szerkesztő összesen {1} szerkesztést tett az adott időszakban, ami szerkesztőnként átlagosan {2} szerkesztést jelent. Ez a magyar Wikipédia adott időszakban végzett {3} szerkesztésének {4}-a.",
						actuserCounter - 1,
						listUserEditsInPeriod,
						((double)listUserEditsInPeriod / ((double)actuserCounter - 1.0)).ToString(doubleFormat),
						allRevsInPeriod,
						((double)listUserEditsInPeriod / (double)allRevsInPeriod).ToString(percentFormat)
					));
				}
				else
				{
					tw.WriteLine(String.Format(
						"A listában szereplő {0} szerkesztő összesen {1} szerkesztést tett, ami szerkesztőnként átlagosan {2} szerkesztést jelent. Ez a magyar Wikipédia összes, {3} szerkesztésének {4}-a.",
						actuserCounter - 1,
						listUserEdits,
						((double)listUserEdits / ((double)actuserCounter - 1.0)).ToString(doubleFormat),
						allRevs,
						((double)listUserEdits / (double)allRevs).ToString(percentFormat)
					));
				}

				tw.WriteLine(header.ToString());
				tw.Write(newLine.ToString());

				tw.Flush();
			}

			UpdateStatus("Kész.", 0, true);
			cancelButton.Text = "OK";
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
	}
}
