using FluentValidation;

namespace BlazeCore.Shared.TodoItem;

public class TodoItemValidator<T> : AbstractValidator<T>
    where T : ITodoItem
{
    public TodoItemValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
        RuleFor(x => x.Description)
            .NotEmpty();
        RuleFor(x => x.CreatedAt)
            .NotEmpty();
    }
}