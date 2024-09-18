using BlazeCore.Server.Infrastructure.Exceptions;

namespace BlazeCore.Server.Infrastructure;

public static class Guard
{
    public static void AgainstNotFound(object argument, AppError error)
    {
        if (argument == null)
            throw new NotFoundException([error]);
    }
}