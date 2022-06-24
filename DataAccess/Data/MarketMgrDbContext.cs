using MarketMgr.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketMgr.DataAccess.Data
{
	public class MarketMgrDbContext : DbContext
	{
		public MarketMgrDbContext(DbContextOptions<MarketMgrDbContext> options)
			: base(options) { }

		public DbSet<Product> Products => Set<Product>();
	}
}
