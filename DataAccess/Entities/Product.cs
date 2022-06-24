namespace MarketMgr.DataAccess.Entities
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int Weight { get; set; }
		public bool IsInStock { get; set; }
	}
}
