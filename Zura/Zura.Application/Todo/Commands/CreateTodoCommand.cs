using MediatR;
using Zura.Application.Enum;

namespace Zura.Application.Todo.Commands;

public class CreateTodoCommand(string title, string? description, Priority priority, Status status)
    : IRequest<int>
{
    public string Title { get; set; } = title;
    public string? Description { get; set; } = description;
    public Priority Priority { get; set; } = priority;
    public Status Status { get; set; } = status;
}