using Zura.Application.Common.Mark;
using Zura.Application.Common.Validator;
using Zura.Application.Enum;
using Zura.Domain.Model.Todos.Exception;

namespace Zura.Domain.Model.Todos.ValueObject;

public class StatusChecker : IValueObject
{
    /// <summary>
    /// current status
    /// </summary>
    public Status Status { get; set; }

    private StatusChecker() { }

    public static StatusChecker Create()
    {
        return new StatusChecker()
        {
            Status = Status.InProgress
        };
    }

    public void Update(Status statusOld, Status statusNew)
    {
        Status= statusOld;
        GuardAssessmentForModeChange(statusNew);
    }

    private void GuardAssessmentForModeChange(Status statusNew)
    {
        ObjectValidator.Instance
            .Must(Status, x => x is Status.Pending && statusNew is Status.Completed or Status.Archived
                , new TodoStatusCheckerModePendingException())
            .Must(Status, x => x is Status.InProgress && statusNew is Status.Pending or Status.Archived
                , new TodoStatusCheckerModeInProgressException())
            .Must(Status, x => x is Status.Completed && statusNew is Status.Pending or Status.InProgress
                , new TodoStatusCheckerModeCompleteException())
            .Must(Status, x => x is Status.Archived && statusNew is Status.Pending or Status.InProgress or Status.Completed
                , new TodoStatusCheckerModeCompleteException());
    }

}