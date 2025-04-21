using FluentAssertions;
using Zura.Application.Enum;
using Zura.Domain.Model.Todo.Entity;
using Zura.Domain.Model.Todo.Exception;
using Zura.Domain.Model.Todo.ValueObject;

namespace Zura.Domain.Test
{
    public sealed class TodoTest
    {
        [Fact]
        public void CreateTodo_WithValidData_ShouldCreateSuccessfully()
        {
            var status = new StatusChecker(Status.Pending, Status.InProgress);
      
            var todo = new Todo("Write Tests", "Use FluentAssertions", Priority.High, status);
            
            todo.Title.Should().Be("Write Tests");
            todo.Description.Should().Be("Use FluentAssertions");
            todo.Priority.Should().Be(Priority.High);
            todo.Status.Should().NotBeNull();
        }

        [Fact]
        public void CreateTodo_WithNullTitle_ShouldThrowTodoTitleException()
        {
            var status = new StatusChecker(Status.Pending, Status.InProgress);

            var act = () =>
            {
                var todo = new Todo(null!, "desc", Priority.Low, status);
            };

            act.Should().Throw<TodoTitleException>();
        }

        [Fact]
        public void CreateTodo_WithNullStatus_ShouldThrowTodoStatusInvalidException()
        {
            var act = () =>
            {
                var todo = new Todo("Test", "desc", Priority.Medium, null!);
            };

            act.Should().Throw<TodoStatusInvalidException>();
        }


    }
}
