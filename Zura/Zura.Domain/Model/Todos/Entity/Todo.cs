using Zura.Application.Common;
using Zura.Application.Common.Validator;
using Zura.Application.Enum;
using Zura.Domain.Common;
using Zura.Domain.Model.Todos.Exception;
using Zura.Domain.Model.Todos.ValueObject;

namespace Zura.Domain.Model.Todos.Entity;

public sealed class Todo : BaseEntity<int>
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public Priority Priority { get; set; }
    public StatusChecker Status { get; set; } = null!;

    
    private Todo() { }

    public static Todo Create(string title, string? description, Priority priority)
    {
        return new Todo(title, description, priority);
        
    }

    public void Update(string title, string? description, Priority priority, Status status)
    {
        SetData(title, description, priority);
        Status.Update(Status.Status, status);
        GuardAssessmentForValidation(Title);
        Updating();
    }

    private Todo(string title, string? description, Priority priority)
    {
        SetData(title, description, priority);
        InitializeStatus();
        GuardAssessmentForValidation(Title);
        Creating();
    }

    

    private void SetData(string title, string? description, Priority priority)
    {
        Title = title;
        Description = description;
        Priority = priority;
    }

    /// <summary>
    /// default InProgress
    /// </summary>
    private void InitializeStatus()
    {
        Status = StatusChecker.Create();
    }
    private void GuardAssessmentForValidation(string title)
    {
        ObjectValidator.Instance
            .RuleFor(Status).NotNullOrEmpty(new TodoStatusInvalidException())
            .RuleFor(title).NotNullOrEmpty(new TodoTitleException());
    }
}