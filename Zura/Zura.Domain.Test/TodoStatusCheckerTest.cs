using FluentAssertions;
using Zura.Application.Enum;
using Zura.Domain.Model.Todos.Exception;
using Zura.Domain.Model.Todos.ValueObject;

namespace Zura.Domain.Test;

/// <summary>
/// value object test
/// </summary>
public sealed class TodoStatusCheckerTest
{

    [Fact]
    public void StatusChecker_InvalidTransition_FromInProgressToPending_ShouldThrow()
    {
        var act = () =>
        {
            var statusChecker = StatusChecker.Create();
            statusChecker.Update(Status.InProgress,Status.Pending);
        };

        act.Should().Throw<TodoStatusCheckerModeInProgressException>();
    }


    [Fact]
    public void StatusChecker_ValidTransition_FromPendingToCompleted_ShouldSucceed()
    {
        var act = () =>
        {
            var statusChecker = StatusChecker.Create();
            statusChecker.Update(Status.Pending, Status.Completed);
        };

        act.Should().Throw<TodoStatusCheckerModePendingException>();

    }
}