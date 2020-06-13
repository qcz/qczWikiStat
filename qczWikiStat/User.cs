using ProtoBuf;
using qcz.Dump;
using qcz.Util;
using qczWikiStat.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace qczWikiStat
{
	[ProtoContract]
	public class User
	{
		[ProtoMember(1)]
		public int Id { get; set; } = -1;
		[ProtoMember(2)]
		public string Name { get; private set; }
		[ProtoMember(3)]
		public UserType UserType { get; private set; }

		[ProtoMember(10)]
		private Dictionary<int, int> AllEditsByNamespace = new Dictionary<int, int>();
		[ProtoMember(11)]
		private Dictionary<int, int> AllRevertedEditsByNamespace = new Dictionary<int, int>();


		[ProtoMember(12)]
		private Dictionary<int, int> AllEditsBeforePeriodByNamespace = new Dictionary<int, int>();
		[ProtoMember(13)]
		private Dictionary<int, int> AllRevertedEditsBeforePeriodByNamespace = new Dictionary<int, int>();

		[ProtoMember(14)]
		private Dictionary<int, int> AllEditsInPeriodByNamespace = new Dictionary<int, int>();
		[ProtoMember(15)]
		private Dictionary<int, int> AllRevertedEditsInPeriodByNamespace = new Dictionary<int, int>();

		[ProtoMember(20)]
		private HashSet<DateTime> EditDays = new HashSet<DateTime>();

		[ProtoMember(21)]
		public DateTime? FirstEditTimestamp { get; set; } = null;
		[ProtoMember(22)]
		public DateTime? LastEditTimestamp { get; set; } = null;
		public double MeanEditsPerDay => TotalDays == 0
			? TotalEditCount
			: Convert.ToDouble(TotalEditCount) / Convert.ToDouble(TotalDays);

		public int TotalDays =>
			Convert.ToInt32(Math.Floor((LastEditTimestamp.Value.Date - FirstEditTimestamp.Value.Date).TotalDays));
		public int TotalEditCount => AllEditsByNamespace.Count > 0 ? AllEditsByNamespace.Values.Sum() : 0;
		public int TotalRevertedEditCount => AllRevertedEditsByNamespace.Count > 0 ? AllRevertedEditsByNamespace.Values.Sum() : 0;
		public double TotalRevertedEditPercentage => TotalEditCount > 0 ? (double)TotalRevertedEditCount / (double)TotalEditCount : 0;
		public int TotalEditCountBeforePeriod => AllEditsBeforePeriodByNamespace.Count > 0 ? AllEditsBeforePeriodByNamespace.Values.Sum() : 0;
		public int TotalRevertedEditCountBeforePeriod => AllRevertedEditsBeforePeriodByNamespace.Count > 0 ? AllRevertedEditsBeforePeriodByNamespace.Values.Sum() : 0;
		public int TotalEditCountInPeriod => AllEditsInPeriodByNamespace.Count > 0 ? AllEditsInPeriodByNamespace.Values.Sum() : 0;
		public int TotalRevertedEditCountInPeriod => AllRevertedEditsInPeriodByNamespace.Count > 0 ? AllRevertedEditsInPeriodByNamespace.Values.Sum() : 0;
		public double TotalRevertedEditPercentageInPeriod => TotalEditCountInPeriod > 0 ? (double)TotalRevertedEditCountInPeriod / (double)TotalEditCountInPeriod : 0;
		public int TotalActiveDays => EditDays.Count();

		[ProtoMember(30)]
		private HashSet<Right> Rights { get; set; } = new HashSet<Right>();
		public bool IsBot => Rights.Contains(Right.Bot) || Rights.Contains(Right.UnflaggedBot);

		[ProtoIgnore]
		public ServiceLevelRequirement LevelBeforePeriod { get; set; }
		[ProtoIgnore]
		public ServiceLevelRequirement LevelAfterPeriod { get; set; }
		[ProtoIgnore]
		public double LevelPosition { get; internal set; }
		[ProtoIgnore]
		public ServiceLevelRequirement NextLevel { get; set; }

		private User()
		{
		}

		public void AddEditDay(DateTime dt)
		{
			EditDays.Add(dt.Date);
		}
		public void AddRights(List<Right> rights)
		{
			foreach (Right r in rights)
			{
				Rights.Add(r);
			}
		}

		public void AddRight(Right r)
		{
			Rights.Add(r);
		}

		public int GetAllEditsByNamespace(int ns) => AllEditsByNamespace.ContainsKey(ns)
			? AllEditsByNamespace[ns]
			: 0;

		public double GetAllEditPercentageByNamespace(int ns) => AllEditsByNamespace.ContainsKey(ns)
			? (double)AllEditsByNamespace[ns] / (double)TotalEditCount
			: 0.0;

		public int GetEditsInPeriodByNamespace(int ns) => AllEditsInPeriodByNamespace.ContainsKey(ns)
			? AllEditsInPeriodByNamespace[ns]
			: 0;
		
		public double GetEditPercentageInPeriodByNamespace(int ns) => AllEditsInPeriodByNamespace.ContainsKey(ns)
			? (double)AllEditsInPeriodByNamespace[ns] / (double)TotalEditCountInPeriod
			: 0.0;

		public void AddEdit(int ns, bool isBeforePeriod, bool isReverted)
		{
			if (AllEditsByNamespace.ContainsKey(ns))
				AllEditsByNamespace[ns]++;
			else
				AllEditsByNamespace.Add(ns, 1);

			if (isReverted)
			{
				if (AllRevertedEditsByNamespace.ContainsKey(ns))
					AllRevertedEditsByNamespace[ns]++;
				else
					AllRevertedEditsByNamespace.Add(ns, 1);
			}

			if (isBeforePeriod)
			{
				if (AllEditsBeforePeriodByNamespace.ContainsKey(ns))
					AllEditsBeforePeriodByNamespace[ns]++;
				else
					AllEditsBeforePeriodByNamespace.Add(ns, 1);

				if (isReverted)
				{
					if (AllRevertedEditsBeforePeriodByNamespace.ContainsKey(ns))
						AllRevertedEditsBeforePeriodByNamespace[ns]++;
					else
						AllRevertedEditsBeforePeriodByNamespace.Add(ns, 1);
				}
			}
			else
			{
				if (AllEditsInPeriodByNamespace.ContainsKey(ns))
					AllEditsInPeriodByNamespace[ns]++;
				else
					AllEditsInPeriodByNamespace.Add(ns, 1);

				if (isReverted)
				{
					if (AllRevertedEditsInPeriodByNamespace.ContainsKey(ns))
						AllRevertedEditsInPeriodByNamespace[ns]++;
					else
						AllRevertedEditsInPeriodByNamespace.Add(ns, 1);
				}
			}
		}

		public bool HasRight(Right r) => Rights.Contains(r);

		public int GetActiveDaysBeforePeriod(DateTime? start) => start.HasValue
			? EditDays.Count(editDay => editDay < start.Value)
			: 0;

		public int GetActiveDaysInPeriod(DateTime? start, DateTime end) => start.HasValue
			? EditDays.Count(editDay => editDay >= start.Value && editDay <= end)
			: 0;

		public double GetMeanEditsPerDayInPeriod(DateTime periodStart, DateTime periodEnd) => FirstEditTimestamp.HasValue
			? (double)TotalEditCountInPeriod / (double)(periodEnd.DaysBetween(periodStart))
			: 0.0;

		public void Merge(User otherUser)
		{
			if (otherUser.AllEditsByNamespace != null)
			{
				foreach (var allEditKvp in otherUser.AllEditsByNamespace)
				{
					if (AllEditsByNamespace.ContainsKey(allEditKvp.Key))
						AllEditsByNamespace[allEditKvp.Key] += allEditKvp.Value;
					else
						AllEditsByNamespace[allEditKvp.Key] = allEditKvp.Value;
				}
			}

			if (otherUser.AllRevertedEditsByNamespace != null)
			{
				foreach (var allRevEditKvp in otherUser.AllRevertedEditsByNamespace)
				{
					if (AllRevertedEditsByNamespace.ContainsKey(allRevEditKvp.Key))
						AllRevertedEditsByNamespace[allRevEditKvp.Key] += allRevEditKvp.Value;
					else
						AllRevertedEditsByNamespace[allRevEditKvp.Key] = allRevEditKvp.Value;
				}
			}

			if (otherUser.AllEditsBeforePeriodByNamespace != null)
			{
				foreach (var allBefPeriodEditKvp in otherUser.AllEditsBeforePeriodByNamespace)
				{
					if (AllEditsBeforePeriodByNamespace.ContainsKey(allBefPeriodEditKvp.Key))
						AllEditsBeforePeriodByNamespace[allBefPeriodEditKvp.Key] += allBefPeriodEditKvp.Value;
					else
						AllEditsBeforePeriodByNamespace[allBefPeriodEditKvp.Key] = allBefPeriodEditKvp.Value;
				}
			}

			if (otherUser.AllRevertedEditsBeforePeriodByNamespace != null)
			{
				foreach (var allRevBefPeriodEditKvp in otherUser.AllRevertedEditsBeforePeriodByNamespace)
				{
					if (AllRevertedEditsBeforePeriodByNamespace.ContainsKey(allRevBefPeriodEditKvp.Key))
						AllRevertedEditsBeforePeriodByNamespace[allRevBefPeriodEditKvp.Key] += allRevBefPeriodEditKvp.Value;
					else
						AllRevertedEditsBeforePeriodByNamespace[allRevBefPeriodEditKvp.Key] = allRevBefPeriodEditKvp.Value;
				}
			}

			if (otherUser.AllEditsInPeriodByNamespace != null)
			{
				foreach (var allInPeriodEditKvp in otherUser.AllEditsInPeriodByNamespace)
				{
					if (AllEditsInPeriodByNamespace.ContainsKey(allInPeriodEditKvp.Key))
						AllEditsInPeriodByNamespace[allInPeriodEditKvp.Key] += allInPeriodEditKvp.Value;
					else
						AllEditsInPeriodByNamespace[allInPeriodEditKvp.Key] = allInPeriodEditKvp.Value;
				}
			}

			if (otherUser.AllRevertedEditsInPeriodByNamespace != null)
			{
				foreach (var allRevInPeriodEditKvp in otherUser.AllRevertedEditsInPeriodByNamespace)
				{
					if (AllRevertedEditsInPeriodByNamespace.ContainsKey(allRevInPeriodEditKvp.Key))
						AllRevertedEditsInPeriodByNamespace[allRevInPeriodEditKvp.Key] += allRevInPeriodEditKvp.Value;
					else
						AllRevertedEditsInPeriodByNamespace[allRevInPeriodEditKvp.Key] = allRevInPeriodEditKvp.Value;
				}
			}

			if (otherUser.EditDays != null)
			{
				foreach (var editDay in otherUser.EditDays)
				{
					EditDays.Add(editDay);
				}
			}

			if (otherUser.FirstEditTimestamp.HasValue)
			{
				if (FirstEditTimestamp.HasValue == false)
					FirstEditTimestamp = otherUser.FirstEditTimestamp;
				else if (FirstEditTimestamp > otherUser.FirstEditTimestamp)
					FirstEditTimestamp = otherUser.FirstEditTimestamp;
			}

			if (otherUser.LastEditTimestamp.HasValue)
			{
				if (LastEditTimestamp.HasValue == false)
					LastEditTimestamp = otherUser.LastEditTimestamp;
				else if (LastEditTimestamp < otherUser.LastEditTimestamp)
					LastEditTimestamp = otherUser.LastEditTimestamp;
			}
		}

		public static User CreateFromDumpArticleRevision(DumpArticleRevision rev)
		{
			return new User()
			{
				UserType = rev.UserType,
				Name = rev.UserUniqueIdentifier
			};
		}
	}
}
