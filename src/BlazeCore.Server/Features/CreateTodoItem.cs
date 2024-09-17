using BlazeCore.Server.Persistance;
using BlazeCore.Shared.TodoItem;
using MediatR;

namespace BlazeCore.Server.Features;

public class CreateTodoItem
{
    public record Command : ITodoItem, IRequest<string>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    
    public class Validator : TodoItemValidator<Command>
    {
        public Validator()
        {
        }
    }
    
    internal class Handler : IRequestHandler<Command, string>
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public Handler(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public async Task<string> Handle(Command command, CancellationToken cancellationToken)
        {
            Domain.TodoItem todoItem = Domain.TodoItem.Create(
                Utils.GenerateId(),
                command.Name,
                command.Description,
                command.CreatedAt);
            
            await _todoItemRepository.AddAsync(todoItem);
            return todoItem.Id;
        }
    }
}