using FluentValidation;

namespace Zura.Application.Todo.Commands;

internal class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
{

    public CreateTodoCommandValidator()
    {
        RuleFor(u => u.Title)
            .NotEmpty().WithMessage("this field is required")
            .MaximumLength(50).WithMessage("first name must be less than 50");

    }
}