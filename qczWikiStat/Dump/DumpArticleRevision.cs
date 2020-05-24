using System;

namespace qcz.Dump
{
	public class DumpArticleRevision
	{
		public int RevisionId { get; set; } = -1;
		public DateTime? Timestamp { get; set; } = null;

		public int UserId { get; set; } = 0;
		public UserType UserType { get; set; } = UserType.Unknown;
		public string UserName { get; set; } = "";
		public string UserIpAddress { get; set; } = "";
		public string UserUniqueIdentifier => UserType == UserType.Anonymous ? UserIpAddress : UserName;

		public string RevisionComment { get; set; }
		public string ContentHash { get; set; }

		public bool IsReverted { get; set; }
		public bool IsReverterRevision { get; set; }
	}
}
