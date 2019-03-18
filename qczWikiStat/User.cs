using qcz.Dump;
using qcz.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace qczWikiStat
{
	class User
	{
		private Dictionary<int, int> allEdits;
		private Dictionary<int, int> periodEdits;
		private List<DateTime> editDays;
		private List<Right> rights;

		public int AllDays =>
			Convert.ToInt32(Math.Floor((LastEdit.Value.Date - FirstEdit.Value.Date).TotalDays));
		public int AllEdits => allEdits.Count > 0 ? allEdits.Values.Sum() : 0;
		public int PeriodEdits => periodEdits.Count > 0 ? periodEdits.Values.Sum() : 0;
		public int ActiveDays => editDays.Count();
		public DateTime? FirstEdit { get; set; }
		public int Id { get; set; }
		public DateTime? LastEdit { get; set; }
		public double MeanEditsPerDay => AllDays == 0
			? AllEdits
			: Convert.ToDouble(AllEdits) / Convert.ToDouble(AllDays);
		public string Name { get; set; }

		public User(string userName)
		{
			allEdits = new Dictionary<int, int>();
			periodEdits = new Dictionary<int, int>();
			Name = userName;
			editDays = new List<DateTime>();
			Id = -1;
			FirstEdit = null;
			LastEdit = null;
			rights = new List<Right>();
		}

		public void AddEditDay(DateTime dt)
		{
			if (!editDays.Contains(dt.Date))
				editDays.Add(dt.Date);
		}
		public void AddRights(List<Right> rights)
		{
			foreach (Right r in rights)
				if (!this.rights.Contains(r))
					this.rights.Add(r);
		}
		public void AddRights(Right r)
		{
			if (!this.rights.Contains(r))
				this.rights.Add(r);
		}
		public int GetAllEditsByNs(int ns)
		{
			return allEdits.ContainsKey(ns) ? allEdits[ns] : 0;
		}
		public double GetAllPcEditsByNs(int ns)
		{
			return allEdits.ContainsKey(ns) ? (double)allEdits[ns] / (double)AllEdits : 0.0;
		}
		public int GetPeriodEditsByNs(int ns)
		{
			return periodEdits.ContainsKey(ns) ? periodEdits[ns] : 0;
		}
		public double GetPeriodPcEditsByNs(int ns)
		{
			return periodEdits.ContainsKey(ns) ? (double)periodEdits[ns] / (double)PeriodEdits : 0.0;
		}
		public void IncAllEdits(int ns)
		{
			if (allEdits.ContainsKey(ns))
				allEdits[ns]++;
			else
				allEdits.Add(ns, 1);
		}
		public void IncCurEdits(int ns)
		{
			if (periodEdits.ContainsKey(ns))
				periodEdits[ns]++;
			else
				periodEdits.Add(ns, 1);
		}
		public bool HasRight(Right r)
		{
			foreach(Right rx in rights)
				if (rx == r)
					return true;
			return false;
		}
		public int PeriodActiveDays(DateTime? start, DateTime end)
		{
			if (!start.HasValue) return 0;
			int ret = 0;
			foreach (DateTime d in editDays)
				if (d >=
					start.Value && d <= end)
					ret++;
			return ret;
		}
		public double PeriodMeanEditsPerDay(DateTime periodStart, DateTime periodEnd)
		{
			if (!FirstEdit.HasValue) return 0.0;
			return (double)PeriodEdits / (double)(periodEnd.DaysBetween(periodStart));
		}
	}
}
