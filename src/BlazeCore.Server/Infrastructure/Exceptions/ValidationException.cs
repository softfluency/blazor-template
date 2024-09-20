namespace BlazeCore.Server.Infrastructure.Exceptions;

public class ValidationException : Exception
{
    public ValidationException(string message) : this(message, [])
    {
    }

    public ValidationException(string message, IEnumerable<AppError> errors) : base(message)
    {
        Errors = errors;
    }

    public ValidationException(IEnumerable<AppError> errors)
    {
        Errors = errors;
    }

    public IEnumerable<AppError> Errors { get; private set; }
}

