using BlazeCore.Server.Domain;
using BlazeCore.Server.Persistance;
using BlazeCore.Shared.TodoItem;
using MediatR;

namespace BlazeCore.Server.Features;

public class GetAllTodoItems
{
    public record Query() : IRequest<List<TodoItemResponse>>;
    
    internal class Handler : IRequestHandler<Query, List<TodoItemResponse>>
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public Handler(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public async Task<List<TodoItemResponse>> Handle(Query request, CancellationToken cancellationToken)
        {
            List<TodoItem> todoItems = await _todoItemRepository.GetAllAsync();
            
            return todoItems.Select(x => new TodoItemResponse(x.Id, x.Name, x.Description, x.CreatedAt)).ToList();
        }
    }
}