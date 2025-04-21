using MediatR;
using Zura.Application.Common.UnitOfWork;
namespace Zura.Application.Todo.Commands;

public sealed class CreateTodoCommandHandler(IApplicationUnitOfWork unitOfWork)
    : IRequestHandler<CreateTodoCommand, int>
{
    private readonly IApplicationUnitOfWork _unitOfWork = unitOfWork;

    public Task<int> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        


        throw new NotImplementedException();
    }
}