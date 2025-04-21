using MediatR;
using Microsoft.EntityFrameworkCore;
using Zura.Application.Common;
using Zura.Application.Common.UnitOfWork;
using Zura.Application.Todo.Commands.Exception;

namespace Zura.Application.Todo.Commands.Delete;

public record DeleteTodoCommand(int Id) : IRequest<Result>;

public class DeleteTodoCommandHandler(IApplicationUnitOfWork unitOfWork) : IRequestHandler<DeleteTodoCommand, Result>
{
    public async Task<Result> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await unitOfWork.Todos
            .Where(s => s.Id == request.Id && !s.IsDeleted).FirstOrDefaultAsync(cancellationToken);

        if (todo == null)
            throw new TodoNotFoundException();

        todo.Deleted();
        unitOfWork.Todos.Update(todo!);
        return await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}