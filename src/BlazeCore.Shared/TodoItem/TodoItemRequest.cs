namespace BlazeCore.Shared.TodoItem;

public class TodoItemRequest : ITodoItem
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.Today;
    
    public class TodoItemDtoValidator : TodoItemValidator<TodoItemRequest>
    {
        public TodoItemDtoValidator()
        {
        }
    }
}