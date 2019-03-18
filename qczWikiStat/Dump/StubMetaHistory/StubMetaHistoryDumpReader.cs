using System;
using System.Collections;
using System.Globalization;
using System.Xml;

namespace qcz.Dump.StubMetaHistory
{
	public class StubMetaHistoryDumpReader: XmlDumpReaderBase, IEnumerable
	{
		public StubMetaHistoryDumpReader(string filePath, int settings)
			:base(filePath, settings) { }

		public override IEnumerator GetEnumerator()
		{
			if (needRewind || xmlReader.EOF) RewindReader();
			// olvasunk, amíg <page>-ig nem jutunk
			needRewind = true;
			DumpReaderState state = DumpReaderState.SeekNextPage;
			DumpArticle curArticle = null;
			DumpArticleRevision curRevision = null;
			while (xmlReader.Read())
			{
				switch (state)
				{
					case DumpReaderState.SeekNextPage:
						if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "page")
						{
							curArticle = new DumpArticle();
							state = DumpReaderState.PageDataReading;
						}
						break;
					case DumpReaderState.PageDataReading:
						switch (xmlReader.NodeType)
						{
							case XmlNodeType.EndElement:
								if (xmlReader.Name == "page")
								{
									yield return curArticle;
									curArticle = null;
									state = DumpReaderState.SeekNextPage;
								}
								break;
							case XmlNodeType.Element:
								switch (xmlReader.Name)
								{
									case "title":
										xmlReader.Read();
										curArticle.Title = xmlReader.Value;
										// TODO: skip nonMainNamespaceStuff
										break;
									case "id":
										xmlReader.Read();
										curArticle.Id = Convert.ToInt32(xmlReader.Value);
										break;
									case "redirect":
										curArticle.IsRedirect = true;
										break;
									case "revision":
										state = DumpReaderState.RevisionDataReading;
										curRevision = new DumpArticleRevision();
										break;
								}
								break;
						}
						break;
					case DumpReaderState.RevisionDataReading:
						switch (xmlReader.NodeType)
						{
							case XmlNodeType.EndElement:
								if (xmlReader.Name == "revision")
								{
									state = DumpReaderState.PageDataReading;
									curArticle.AddRevision(curRevision);
									curRevision = null;
								}
								break;
							case XmlNodeType.Element:
								switch (xmlReader.Name)
								{
									case "id":
										xmlReader.Read();
										curRevision.Id = Convert.ToInt32(xmlReader.Value);
										break;
									case "timestamp":
										xmlReader.Read();
										curRevision.TimeStamp = DateTime.ParseExact(xmlReader.Value,
											"yyyy-MM-dd'T'HH:mm:ss'Z'", CultureInfo.InvariantCulture);
										break;
									case "contributor":
										if (xmlReader.IsEmptyElement == false)
											state = DumpReaderState.UserDataReading;
										break;
								}
								break;
						}
						break;
					case DumpReaderState.UserDataReading:
						switch (xmlReader.NodeType)
						{
							case XmlNodeType.EndElement:
								if (xmlReader.Name == "contributor")
									state = DumpReaderState.RevisionDataReading;
								break;
							case XmlNodeType.Element:
								switch (xmlReader.Name)
								{
									case "id":
										xmlReader.Read();
										curRevision.UserId = Convert.ToInt32(xmlReader.Value);
										break;
									case "username":
									case "ip":
										xmlReader.Read();
										curRevision.UserName = xmlReader.Value;
										break;
								}
								break;
						}
						break;
				}
			} // while

			needRewind = false;
		} // 

		public long GetPosition( )
		{
			return fs.Position;
		}

		public long GetFileLength( )
		{
			return fs.Length;
		}
	}
}
