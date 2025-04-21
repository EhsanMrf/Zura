using Zura.Application.Common;
using Zura.Application.Common.Validator;
using Zura.Application.Enum;
using Zura.Domain.Model.Todo.Exception;
using Zura.Domain.Model.Todo.ValueObject;

namespace Zura.Domain.Model.Todo.Entity;

public sealed class Todo : BaseEntity<int>
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public Priority Priority { get; set; }
    public StatusChecker Status { get; set; }


    public Todo(string title, string? description, Priority priority, StatusChecker status)
    {
        Title = title;
        Description = description;
        Priority = priority;
        Status = status;
        GuardAssessmentForValidation();
    }

    private void GuardAssessmentForValidation()
    {
        ObjectValidator.Instance
            .RuleFor(Status).NotNullOrEmpty(new TodoStatusInvalidException())
            .RuleFor(Title).NotNullOrEmpty(new TodoTitleException());
    }
}