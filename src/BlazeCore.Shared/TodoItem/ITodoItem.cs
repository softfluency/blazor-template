namespace BlazeCore.Shared.TodoItem;

public interface ITodoItem
{
    public string Name { get; set; }

    public string Description { get; set; }
    
    public DateTime CreatedAt { get; set; }
}