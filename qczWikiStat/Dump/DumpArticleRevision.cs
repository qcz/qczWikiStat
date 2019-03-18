using System;

namespace qcz.Dump
{
	public class DumpArticleRevision
	{
		public int Id { get; set; } = -1;
		public DateTime? TimeStamp { get; set; } = null;
		public string UserName { get; set; } = "";
		public int UserId { get; set; } = 0;
	}
}
