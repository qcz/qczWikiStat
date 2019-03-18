using System.Collections;
using System.Collections.Generic;

namespace qcz.Dump
{
	public class DumpArticle : IEnumerable<DumpArticleRevision>
	{
		private List<DumpArticleRevision> revs = new List<DumpArticleRevision>();

		public string Title { get; set; }
		public int Id { get; set; }
		public bool IsRedirect { get; set; }

		public void AddRevision(DumpArticleRevision dr)
		{
			revs.Add(dr);
		}

		public IEnumerator<DumpArticleRevision> GetEnumerator()
		{
			return revs.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return revs.GetEnumerator();
		}
	}
}
