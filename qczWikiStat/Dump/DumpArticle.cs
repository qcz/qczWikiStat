using System.Collections;
using System.Collections.Generic;

namespace qcz.Dump
{
	public class DumpArticle
	{
		public List<DumpArticleRevision> Revisions { get; set; } = new List<DumpArticleRevision>();

		public string Title { get; set; }
		public int Id { get; set; }
		public bool IsRedirect { get; set; }
	}
}
