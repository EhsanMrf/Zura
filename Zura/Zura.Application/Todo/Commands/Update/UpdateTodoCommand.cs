using MediatR;
using Zura.Application.Enum;
using Zura.Application.Todo.Commands.Create;

namespace Zura.Application.Todo.Commands.Update;

public sealed class UpdateTodoCommand(string title, string? description, Priority priority)
    : CreateTodoCommand(title, description, priority), IRequest<int>
{
    public int Id { get; set; }
    public Status Status { get; set; }
}