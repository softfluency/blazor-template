namespace BlazeCore.Server.Infrastructure;

public static class Errors
{
    public static AppError NotFoundById(string todoItemId) => new ("Items.NotFound",
        $"The item with the Id: '{todoItemId}' was not found");
}