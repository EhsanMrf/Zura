using MediatR;
using Zura.Application.Common.UnitOfWork;
using TodoModel = Zura.Domain.Model.Todos.Entity.Todo;
namespace Zura.Application.Todo.Commands.Create;

public sealed class CreateTodoCommandHandler(IApplicationUnitOfWork unitOfWork)
    : IRequestHandler<CreateTodoCommand, int>
{
    private readonly IApplicationUnitOfWork _unitOfWork = unitOfWork;

    public async Task<int> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var model = TodoModel.Create(request.Title, request.Description, request.Priority);
        _unitOfWork.Todos.Add(model);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return model.Id;
    }
}