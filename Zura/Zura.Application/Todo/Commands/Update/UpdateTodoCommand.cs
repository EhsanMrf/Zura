using MediatR;
using Zura.Application.Enum;
using Zura.Application.Todo.Commands.Create;

namespace Zura.Application.Todo.Commands.Update;

public sealed class UpdateTodoCommand(string title, string? description, Priority priority, Status status)
    : CreateTodoCommand(title, description, priority, status), IRequest<int>
{
    public int Id { get; set; }
}