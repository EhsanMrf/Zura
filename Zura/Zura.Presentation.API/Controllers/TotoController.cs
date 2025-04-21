using Microsoft.AspNetCore.Mvc;
using Zura.Application.Common;
using Zura.Application.Todo.Commands.Create;
using Zura.Application.Todo.Commands.Delete;
using Zura.Application.Todo.Commands.Update;
using Zura.Application.Todo.Queries;

namespace Zura.Presentation.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TotoController : BaseController
{

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateTodoCommand command) => await Mediator.Send(command);

    [HttpPut]
    public async Task<ActionResult<int>> Update(UpdateTodoCommand command) => await Mediator.Send(command);

    [HttpGet("/{id}")]
    public async Task<ActionResult<GetTodoDto>> Get(int id) => await Mediator.Send(new GetTodoQuery(id));

    [HttpGet("get-list")]
    public async Task<IEnumerable<GetTodoDto>> GetList() => await Mediator.Send(new GetListTodoQuery());

    [HttpDelete("/{id}")]
    public async Task<ActionResult<Result>> Delete(int id) => await Mediator.Send(new DeleteTodoCommand(id));
}