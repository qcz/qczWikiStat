using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace qcz.Util
{
	class FileStringListReader: IEnumerable<string>
	{
		private string fileName;
		private List<string> items;
		private bool valid;

		public List<string> Items
		{
			get {
				List<string> ret = new List<string>();
				foreach (string s in items) ret.Add(s);
				return ret;
			}
		}
		public int Count
		{
			get
			{
				return items.Count; 
			}
		}
		public string FileName
		{
			get { return fileName; }
			set {
				fileName = value;
				ReadFile();
			}
		}
		public bool Valid
		{
			get { return valid; }
			set { valid = value; }
		}

		public FileStringListReader(string fileName)
		{
			this.fileName = fileName;
			ReadFile();
		}

		private void ReadFile()
		{
			items = new List<string>();
			try
			{
				TextReader tr = new StreamReader(fileName);
				string line;
				while ((line = tr.ReadLine()) != null)
				{
					if (line == "") continue;
					items.Add(line);
				}
				tr.Close();
				valid = true;
			}
			catch
			{
				valid = false;
			}
		}

		public IEnumerator<string> GetEnumerator()
		{
			return items.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return items.GetEnumerator();
		}
	}
}
