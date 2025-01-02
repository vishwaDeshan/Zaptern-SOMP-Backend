namespace Application.Common
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name)
            : base($"Entity \"{name}\" was/were not found.") { }
    }

    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
    }
}
