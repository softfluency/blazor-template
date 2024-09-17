namespace BlazeCore.Shared.TodoItem;

public interface ITodoItem
{
    public string Name { get; init; }

    public string Description { get; init; }
    
    public DateTime CreatedAt { get; init; }
}