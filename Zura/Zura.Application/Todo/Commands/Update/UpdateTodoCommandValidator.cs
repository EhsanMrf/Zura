using FluentValidation;
using Zura.Application.Todo.Commands.Create;

namespace Zura.Application.Todo.Commands.Update;

public class UpdateTodoCommandValidator : AbstractValidator<UpdateTodoCommand>
{
    public UpdateTodoCommandValidator()
    {
        RuleFor(u => u.Title)
            .NotEmpty().WithMessage("this field is required")
            .MaximumLength(50).WithMessage("first name must be less than 50");
    }
}