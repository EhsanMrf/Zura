using Microsoft.AspNetCore.Mvc;
using Zura.Application.Todo.Commands.Create;
using Zura.Application.Todo.Commands.Update;

namespace Zura.Presentation.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TotoController : BaseController
{

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateTodoCommand command) => await Mediator.Send(command);

    [HttpPut]
    public async Task<ActionResult<int>> Update(UpdateTodoCommand command) => await Mediator.Send(command);
}