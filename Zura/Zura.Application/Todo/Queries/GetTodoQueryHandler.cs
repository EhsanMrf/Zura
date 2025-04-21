using MediatR;
using Microsoft.EntityFrameworkCore;
using Zura.Application.Common.UnitOfWork;
using Zura.Application.Enum;
using Zura.Application.Todo.Commands.Exception;

namespace Zura.Application.Todo.Queries;

public class GetTodoQueryHandler(IApplicationUnitOfWork unitOfWork) : IRequestHandler<GetTodoQuery, GetTodoDto>
{

    public async Task<GetTodoDto> Handle(GetTodoQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.Todos
                .Where(s => s.Id == request.Id && !s.IsDeleted)
                .Select(s => new GetTodoDto(
                    s.Id,
                    s.Title,
                    s.Status.Status,
                    s.Priority))
                .FirstOrDefaultAsync(cancellationToken)
               ?? throw new TodoNotFoundException();
    }
}

public class GetListTodoQueryHandler(IApplicationUnitOfWork unitOfWork) : IRequestHandler<GetListTodoQuery, IEnumerable<GetTodoDto>>
{
    public async Task<IEnumerable<GetTodoDto>> Handle(GetListTodoQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.Todos
            .Where(s =>!s.IsDeleted)
            .Select(s => new GetTodoDto(
                s.Id,
                s.Title,
                s.Status.Status,
                s.Priority))
            .ToListAsync(cancellationToken);
    }
}