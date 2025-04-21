using MediatR;

namespace Zura.Application.Todo.Queries;

public record GetTodoQuery(int Id) : IRequest<GetTodoDto>;
public record GetListTodoQuery :  IRequest<IEnumerable<GetTodoDto>>;