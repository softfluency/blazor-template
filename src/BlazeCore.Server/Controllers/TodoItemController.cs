using BlazeCore.Server.Features;
using BlazeCore.Shared.TodoItem;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlazeCore.Server.Controllers;

[ApiController]
[Route("api/todo-items")]
public class TodoItemController : ControllerBase
{
    private readonly IMediator _mediator;

    public TodoItemController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<TodoItemResponse> todoItems = await _mediator.Send(new GetAllTodoItems.Query());
        return Ok(todoItems);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateTodoItem(TodoItemRequest request)
    {
        string todoItemId = await _mediator
            .Send(new CreateTodoItem.Command
            {
                Name = request.Name,
                Description = request.Description,
                CreatedAt = request.CreatedAt
            });
        return Ok(todoItemId);
    }
}