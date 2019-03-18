using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace qczWikiStat
{
	public partial class NamespacesForm : Form
	{
		public List<int> SelectedNamespaces
		{
			get
			{
				List<int> ret = new List<int>();
				foreach (ListViewItem lvi in namespacesListView.Items)
					if (lvi.Checked)
						ret.Add((int)lvi.Tag);
				return ret;
			}
		}

		public NamespacesForm(string labelText, Dictionary<int, string> namespaces, List<int> selectedNamespaces)
		{
			InitializeComponent();
			namespacesListView.Clear();
			IEnumerable<int> keylist = from int i in namespaces.Keys
									   orderby i ascending
									   select i;
			introLabel.Text = labelText;
			foreach (int i in keylist)
			{
				if (i < 0) continue;
				ListViewItem lvi = new ListViewItem(namespaces[i]);
				lvi.Tag = i;
				if (selectedNamespaces.Contains(i))
					lvi.Checked = true;
				namespacesListView.Items.Add(lvi);
			}
		}

		private void selectAllLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			foreach (ListViewItem lvi in namespacesListView.Items)
				lvi.Checked = true;
		}

		private void selectNoneLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			foreach (ListViewItem lvi in namespacesListView.Items)
				lvi.Checked = false;
		}

		private void invertLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			foreach (ListViewItem lvi in namespacesListView.Items)
				lvi.Checked = !lvi.Checked;
		}

		private void contentLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			foreach (ListViewItem lvi in namespacesListView.Items)
				lvi.Checked = (int)lvi.Tag % 2 == 0;
		}

		private void discussionLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			foreach (ListViewItem lvi in namespacesListView.Items)
				lvi.Checked = (int)lvi.Tag % 2 == 1;
		}
	}
}
