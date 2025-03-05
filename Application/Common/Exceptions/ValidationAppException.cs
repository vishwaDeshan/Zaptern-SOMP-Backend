namespace Application.Common.Exceptions
{
	public class ValidationAppException : Exception
	{
		public IReadOnlyDictionary<string, string[]> Errors { get; }
		public ValidationAppException(IReadOnlyDictionary<string, string[]> errors)
			: base("One or more validations occured")
			=> Errors = errors;
	}
}
