using BlazeCore.Server.Domain;
using BlazeCore.Server.Infrastructure;
using BlazeCore.Server.Persistance;
using BlazeCore.Shared.TodoItem;
using MediatR;

namespace BlazeCore.Server.Features;

public class UpdateTodoItem
{
    public record Command : ITodoItem, IRequest<string>
    {
        public string Id { get; set; }
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
            TodoItem todoItem = await _todoItemRepository.FindAsync(command.Id);
            Guard.AgainstNotFound(todoItem, Errors.NotFoundById(command.Id));
            
            todoItem.Update(command.Name, command.Description, command.CreatedAt);
            await _todoItemRepository.UpdateAsync(todoItem);
            
            return todoItem.Id;
        }
    }
}