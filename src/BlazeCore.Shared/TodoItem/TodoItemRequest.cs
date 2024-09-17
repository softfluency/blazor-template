namespace BlazeCore.Shared.TodoItem;

public class TodoItemRequest : ITodoItem
{
    public string Name { get; init; }
    public string Description { get; init; }
    public DateTime CreatedAt { get; init; }
    
    public class TodoItemDtoValidator : TodoItemValidator<TodoItemRequest>
    {
        public TodoItemDtoValidator()
        {
        }
    }
}