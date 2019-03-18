namespace qczWikiStat
{
	class OrderItem
	{
		public string Desc { get; set; }
		public string OrderId { get; set; }
		public OrderItemType Type { get; set; }

		public override string ToString()
		{
			return Desc;
		}
	}

	public enum OrderItemType
	{
		Normal,
		Period
	}
}
