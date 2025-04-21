using MediatR;
using Zura.Application.Enum;

namespace Zura.Application.Todo.Commands.Create;

public class CreateTodoCommand(string title, string? description, Priority priority)
    : IRequest<int>
{
    public string Title { get; set; } = title;
    public string? Description { get; set; } = description;
    public Priority Priority { get; set; } = priority;
}