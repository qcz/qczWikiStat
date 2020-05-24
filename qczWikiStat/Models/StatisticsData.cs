using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;

namespace qczWikiStat.Models
{
	[ProtoContract]
	public class StatisticsData
	{
		[ProtoMember(1)]
		public Dictionary<string, User> Users { get; set; } = new Dictionary<string, User>();
		//[ProtoMember(2)]
		//public HashSet<string> AllUsersInPeriod { get; set; } = new HashSet<string>();
		[ProtoMember(3)]
		public DateTime PeriodEndDate { get; set; }
		[ProtoMember(4)]
		public DateTime? PeriodStartDate { get; set; }
		[ProtoMember(5)]
		public DateTime FirstEditInWiki { get; set; }
		[ProtoMember(6)]
		public int ArticleCount { get; set; } = 0;

		public int AllRevisions => Users.Count > 0 ? Users.Values.Sum(x => x.TotalEditCount) : 0;
		public int AllRevisionsInPeriod => Users.Count > 0 ? Users.Values.Sum(x => x.TotalEditCountInPeriod) : 0;

		public int AllRegisteredUsers => Users.Values.Where(x =>
			x.IsBot == false
			&& x.UserType == qcz.Dump.UserType.Registered).Count();

		public int AllRegisteredUserEdits
		{
			get
			{
				var registeredUsers = Users.Values.Where(x =>
					x.IsBot == false
					&& x.UserType == qcz.Dump.UserType.Registered).ToList();

				if (registeredUsers.Count > 0)
					return registeredUsers.Sum(x => x.TotalEditCount);

				return 0;
			}
		}

		public int AllBotUsers => Users.Values.Where(x =>
			x.IsBot
			&& x.TotalEditCount > 0).Count();

		public int AllBotUserEdits
		{
			get
			{
				var botUsers = Users.Values.Where(x =>
					x.IsBot
					&& x.TotalEditCount > 0).ToList();

				if (botUsers.Count > 0)
					return botUsers.Sum(x => x.TotalEditCount);

				return 0;
			}
		}

		public int AllNonRegisteredUsers => Users.Values.Count(x =>
			x.IsBot == false
			&& x.UserType == qcz.Dump.UserType.Anonymous);

		public int AllNonRegisteredUserEdits
		{
			get
			{
				var nonRegisteredUsers = Users.Values.Where(x =>
					x.IsBot == false
					&& x.UserType == qcz.Dump.UserType.Anonymous).ToList();

				if (nonRegisteredUsers.Count > 0)
					return nonRegisteredUsers.Sum(x => x.TotalEditCount);

				return 0;
			}
		}

		public int AllRegisteredUsersInPeriod => Users.Values.Count(x =>
			x.IsBot == false
			&& x.UserType == qcz.Dump.UserType.Registered
			&& x.TotalEditCountInPeriod > 0);

		public int AllRegisteredUserEditsInPeriod
		{
			get
			{
				var registeredUsersWithEditsInPeriod = Users.Values.Where(x =>
					x.IsBot == false
					&& x.UserType == qcz.Dump.UserType.Registered
					&& x.TotalEditCountInPeriod > 0).ToList();

				if (registeredUsersWithEditsInPeriod.Count > 0)
					return registeredUsersWithEditsInPeriod.Sum(x => x.TotalEditCountInPeriod);

				return 0;
			}
		}

		public int AllBotUsersInPeriod => Users.Values.Count(x =>
			x.IsBot
			&& x.TotalEditCountInPeriod > 0);

		public int AllBotUserEditsInPeriod
		{
			get
			{
				var botUsersWithEditsInPeriod = Users.Values.Where(x =>
					x.IsBot
					&& x.TotalEditCountInPeriod > 0).ToList();

				if (botUsersWithEditsInPeriod.Count > 0)
					return botUsersWithEditsInPeriod.Sum(x => x.TotalEditCountInPeriod);

				return 0;
			}
		}

		public int AllNonRegisteredUsersInPeriod => Users.Values.Count(x =>
			x.IsBot == false
			&& x.UserType == qcz.Dump.UserType.Anonymous
			&& x.TotalEditCountInPeriod > 0);

		public int AllNonRegisteredUserEditsInPeriod
		{
			get
			{
				var nonRegisteredUsersWithEditsInPeriod = Users.Values.Where(x =>
					x.IsBot == false
					&& x.UserType == qcz.Dump.UserType.Anonymous
					&& x.TotalEditCountInPeriod > 0).ToList();

				if (nonRegisteredUsersWithEditsInPeriod.Count > 0)
					return nonRegisteredUsersWithEditsInPeriod.Sum(x => x.TotalEditCountInPeriod);

				return 0;
			}
		}
	}
}
