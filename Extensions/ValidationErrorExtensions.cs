using FluentValidation.Results;

namespace MarketMgr.Extensions
{
	public static class ValidationErrorExtensions
	{
		public static string GetErrors(this List<ValidationFailure> errors)
		{
			var errorMessages = "";
			errors.ForEach(err => errorMessages += err.ErrorMessage + " ");

			return errorMessages;
		}
	}
}
