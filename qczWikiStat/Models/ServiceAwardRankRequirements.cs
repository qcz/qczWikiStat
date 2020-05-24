using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qczWikiStat.Models
{
	public class ServiceRankRequirement
	{
		public string RankName { get; set; }
		public int ActiveDays { get; set; }
		public int Edits { get; set; }
		public int Level { get; set; }
	}
}
