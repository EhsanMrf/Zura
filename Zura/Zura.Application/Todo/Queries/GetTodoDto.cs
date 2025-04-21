using Zura.Application.Enum;

namespace Zura.Application.Todo.Queries;

public record GetTodoDto(int Id, string Title, Status Status, Priority Priority);