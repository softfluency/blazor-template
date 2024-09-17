namespace BlazeCore.Server.Persistance;

public interface ITodoItemRepository
{
    Task AddAsync(Domain.TodoItem todoItem);
    Task<List<Domain.TodoItem>> GetAllAsync();
}