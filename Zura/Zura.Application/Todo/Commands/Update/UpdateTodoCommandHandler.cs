using MediatR;
using Microsoft.EntityFrameworkCore;
using Zura.Application.Common.UnitOfWork;
using Zura.Application.Todo.Commands.Exception;

namespace Zura.Application.Todo.Commands.Update;

public sealed class UpdateTodoCommandHandler(IApplicationUnitOfWork unitOfWork)
    : IRequestHandler<UpdateTodoCommand, int>
{
    public async Task<int> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await unitOfWork.Todos
            .FirstOrDefaultAsync(x=>x.Id ==request.Id, 
                cancellationToken: cancellationToken);
        
        if (todo is null)
            throw new TodoNotFoundException();

        todo.Update(request.Title,request.Description,request.Priority,request.Status);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return todo.Id;
    }
}