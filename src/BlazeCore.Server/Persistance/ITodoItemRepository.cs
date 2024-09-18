using BlazeCore.Server.Domain;

namespace BlazeCore.Server.Persistance;

public interface ITodoItemRepository
{
    Task AddAsync(TodoItem todoItem);
    
    Task UpdateAsync(TodoItem todoItem);
    
    Task<List<TodoItem>> GetAllAsync();
    
    Task<TodoItem> FindAsync(string id);
}