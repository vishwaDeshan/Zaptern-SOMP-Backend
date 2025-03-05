using FluentValidation;
using MediatR;

namespace Application.Common.Behaviors
{
	public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
		where TRequest : IRequest<TResponse>
	{
		private readonly IEnumerable<IValidator<TRequest>> _validators;

		public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
		{
			_validators = validators;
		}

		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			if(!_validators.Any())
			{
				return await next();
			}

			var context = new ValidationContext<TRequest>(request);

			var errorsDictionary = _validators
				.Select(v => v.Validate(context))
				.SelectMany(result => result.Errors)
				.Where(failure => failure != null)
				.GroupBy(
				v => v.PropertyName.Substring(v.PropertyName.IndexOf('.') + 1),
				v => v.ErrorMessage, (PropertyName, errorMessage) => new {
					Key = PropertyName,
					Values = errorMessage }).ToDictionary(v => v.Key, v => v.Values);

			return await next();
		}
	}
}
