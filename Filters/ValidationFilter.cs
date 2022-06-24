using FluentValidation;
using MarketMgr.Extensions;

namespace MarketMgr.Filters
{
	public class ValidationFilter<T> : IRouteHandlerFilter where T : class
	{
		private readonly IValidator<T> _validator;

		public ValidationFilter(IValidator<T> validator)
		{
			_validator = validator;
		}

		public async ValueTask<object> InvokeAsync(RouteHandlerInvocationContext context, 
			RouteHandlerFilterDelegate next)
		{
			var argument = context
				.Arguments
				.SingleOrDefault(p => p.GetType() == typeof(T));

			if (argument is null) 
				return Results.BadRequest("The parameter is invalid.");

			var result = await _validator.ValidateAsync((T)argument);
			if (!result.IsValid)
			{
				var errors = result.Errors.GetErrors();
				return Results.Problem(errors);
			}

			return await next(context);
		}
	}
}
