using Zura.Application.Common.Mark;
using Zura.Application.Common.Validator;
using Zura.Application.Enum;
using Zura.Domain.Model.Todo.Exception;

namespace Zura.Domain.Model.Todo.ValueObject;

public class StatusChecker : IValueObject
{
    /// <summary>
    /// current status
    /// </summary>
    internal Status StatusOld { get; set; }

    internal StatusChecker(Status statusOld, Status statusNew)
    {
        SetConstructor(statusOld, statusNew);
    }

    private void SetConstructor(Status statusOld, Status statusNew)
    {
        StatusOld = statusOld;
        GuardAssessmentForModeChange(statusNew);
    }

    private void GuardAssessmentForModeChange(Status statusNew)
    {
        ObjectValidator.Instance
            .Must(StatusOld, x => x is Status.Pending && statusNew is Status.Completed or Status.Completed
                , new TodoStatusCheckerModePendingException())
            .Must(StatusOld, x => x is Status.InProgress && statusNew is Status.Pending
                , new TodoStatusCheckerModeInProgressException())
            .Must(StatusOld, x => x is Status.Completed && statusNew is Status.Pending or Status.InProgress
                , new TodoStatusCheckerModeCompleteException())
            .Must(StatusOld, x => x is Status.Archived && statusNew is Status.Pending
                , new TodoStatusCheckerModeCompleteException());
    }

}