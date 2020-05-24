using ICSharpCode.SharpZipLib.GZip;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace qcz.Dump
{
	public abstract class XmlDumpReaderBase: IEnumerable
	{
		public const int NONE = 0;
		public const int READ_COMMENTS = 1;
		public const int READ_TEXT = 2;

		protected bool needRewind;
		protected FileStream fs;
		protected GZipInputStream gzStream;
		protected XmlReader xmlReader;
		protected Dictionary<int, string> namespaces;
		private static XmlReaderSettings readerSettings = new XmlReaderSettings()
		{
			IgnoreComments = true,
			IgnoreWhitespace = true
		};

		public string FilePath { get; protected set; }

		public XmlDumpReaderBase(string filePath, int settings)
		{
			this.FilePath = filePath;
			namespaces = new Dictionary<int, string>();
			fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			gzStream = new GZipInputStream(fs);
			xmlReader = XmlReader.Create(gzStream, readerSettings);
			xmlReader.ReadStartElement("mediawiki");
			do
			{
				if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "namespace")
				{
					int key = Convert.ToInt32(xmlReader.GetAttribute("key"));
					if (key != 0)
					{
						xmlReader.Read();
						string name = xmlReader.Value;
						namespaces.Add(key, name);
						Console.WriteLine(key + " " + name);
					}
				}
			}
			while (xmlReader.Read() &&
				!(xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name == "siteinfo"));
			needRewind = false;
		}

		public int GetNamespace(string title)
		{
			if (title.IndexOf(":") == -1) return 0;
			string nsCandidate = title.Split(':')[0];
			foreach (int i in namespaces.Keys)
				if (namespaces[i] == nsCandidate)
					return i;
			return 0;
		}
		public string GetNamespace(int id) {
			if (namespaces.ContainsKey(id))
				return namespaces[id];
			return string.Empty;
		}
		public Dictionary<int, string> GetNamespaces()
		{
			Dictionary<int, string> ret = new Dictionary<int,string>();
			foreach (KeyValuePair<int, string> kw in namespaces)
			{
				ret.Add(kw.Key, kw.Value);
			}
			return ret;
		}
		protected void RewindReader()
		{
			xmlReader.Close();
			gzStream.Close();
			fs.Close();
			fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			gzStream = new GZipInputStream(fs);
			xmlReader = XmlReader.Create(gzStream, readerSettings);

			do {
				xmlReader.Read();
			}
			while (!(xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name == "siteinfo"));
		}
		public abstract IEnumerator GetEnumerator();
	}
}
