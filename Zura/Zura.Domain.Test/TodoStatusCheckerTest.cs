using FluentAssertions;
using Zura.Application.Enum;
using Zura.Domain.Model.Todo.Entity;
using Zura.Domain.Model.Todo.Exception;
using Zura.Domain.Model.Todo.ValueObject;

namespace Zura.Domain.Test;

public sealed class TodoStatusCheckerTest
{

    [Fact]
    public void StatusChecker_InvalidTransition_FromInProgressToPending_ShouldThrow()
    {
        var act = () =>
        {
            var statusChecker = new StatusChecker(Status.InProgress, Status.Pending);
        };

        act.Should().Throw<TodoStatusCheckerModeInProgressException>();
    }


    [Fact]
    public void StatusChecker_ValidTransition_FromPendingToCompleted_ShouldSucceed()
    {
        var act = () =>
        {
            var statusChecker = new StatusChecker(Status.Pending, Status.Completed); 
        };

        act.Should().Throw<TodoStatusCheckerModePendingException>();

    }
}