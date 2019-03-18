using System;

namespace qcz.Util
{
	public static class ExtensionMethods
	{
		public static string AppendWithComma(this String b, string s) {
			if (b == string.Empty) return s;
			return b + ", " + s;
		}
		public static int DaysBetween(this DateTime a, DateTime b)
		{
			return Math.Abs(Convert.ToInt32((a.Date - b.Date).TotalDays)) + 1;
		}
	}
}
