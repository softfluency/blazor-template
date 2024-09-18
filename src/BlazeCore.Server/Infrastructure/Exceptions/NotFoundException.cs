namespace BlazeCore.Server.Infrastructure.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : this(message, [])
    {
    }

    public NotFoundException(string message, IEnumerable<AppError> errors) : base(message)
    {
        Errors = errors;
    }

    public NotFoundException(IEnumerable<AppError> errors)
    {
        Errors = errors;
    }

    public IEnumerable<AppError> Errors { get; private set; }
}