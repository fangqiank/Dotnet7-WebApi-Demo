using MarketMgr.DataAccess.Data;
using MarketMgr.DataAccess.Entities;
using MarketMgr.Filters;
using Microsoft.EntityFrameworkCore;

namespace MarketMgr.Endpoints
{
	public static class ProductsEndpoints
	{
		public static void MapProductEndpoints(this WebApplication app)
		{
			app.MapGet("/products", List);
			app.MapGet("/products/{id}", Get);
			app.MapPost("/products", Create).AddFilter<ValidationFilter<Product>>();
			app.MapPut("/products", Update).AddFilter<ValidationFilter<Product>>();
			app.MapDelete("/products/{id}", Delete);
		}

		public static async Task<IResult> List(MarketMgrDbContext db)
		{
			var result = await db.Products.ToListAsync();
			return Results.Ok(result);
		}

		public static async Task<IResult> Get(MarketMgrDbContext db, int id)
		{
			return await db.Products.FindAsync(id) is Product product
				? Results.Ok(product)
				: Results.NotFound();
		}

		public static async Task<IResult> Create(MarketMgrDbContext db, Product product)
		{
			db.Products.Add(product);
			await db.SaveChangesAsync();

			return Results.Created($"/products/{product.Id}", product);
		}

		public static async Task<IResult> Update(MarketMgrDbContext db, Product updatedProduct)
		{
			var product = await db.Products.FindAsync(updatedProduct.Id);

			if (product is null) return Results.NotFound();

			product.Name = updatedProduct.Name;
			product.Price = updatedProduct.Price;
			product.Weight = updatedProduct.Weight;
			product.IsInStock = updatedProduct.IsInStock;

			await db.SaveChangesAsync();

			return Results.NoContent();
		}

		public static async Task<IResult> Delete(MarketMgrDbContext db, int id)
		{
			if (await db.Products.FindAsync(id) is Product product)
			{
				db.Products.Remove(product);
				await db.SaveChangesAsync();
				return Results.Ok(product);
			}

			return Results.NotFound();
		}
	}
}
