using BlazeCore.Server.Domain;
using BlazeCore.Server.Infrastructure;
using BlazeCore.Server.Persistance;
using BlazeCore.Shared.TodoItem;
using MediatR;

namespace BlazeCore.Server.Features;

public class FindTodoItem
{
    public record Query(string Id) : IRequest<TodoItemResponse>;
    
    internal class Handler : IRequestHandler<Query, TodoItemResponse>
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public Handler(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public async Task<TodoItemResponse> Handle(Query request, CancellationToken cancellationToken)
        {
            TodoItem todoItem = await _todoItemRepository.FindAsync(request.Id);
            Guard.AgainstNotFound(todoItem, Errors.NotFoundById(request.Id));
            
            return new TodoItemResponse(todoItem.Id, todoItem.Name, todoItem.Description, todoItem.CreatedAt);
        }
    }
}