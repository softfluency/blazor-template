using BlazeCore.Server.Domain;

namespace BlazeCore.Server.Persistance;

public class InMemoryTodoItemRepository : ITodoItemRepository
{
    private static readonly List<Domain.TodoItem> TodoItems = new();

    public Task AddAsync(TodoItem todoItem)
    {
        TodoItems.Add(todoItem);
        return Task.CompletedTask;
    }

    public Task<List<TodoItem>> GetAllAsync()
    {
        return Task.FromResult(TodoItems);
    }
}