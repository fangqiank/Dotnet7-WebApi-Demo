using FluentValidation;
using MarketMgr.DataAccess.Entities;

namespace MarketMgr.Validators
{
	public class ProductValidator : AbstractValidator<Product>
	{
		public ProductValidator()
		{
			RuleFor(o => o.Name).NotNull().NotEmpty().MinimumLength(3);
			RuleFor(o => o.Price).NotNull().NotEmpty().NotEqual(0);
			RuleFor(o => o.Weight).NotNull().NotEmpty().NotEqual(0);
			RuleFor(o => o.IsInStock).NotNull();
		}
	}
}
