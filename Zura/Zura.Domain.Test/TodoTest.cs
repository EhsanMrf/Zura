using FluentAssertions;
using Zura.Application.Enum;
using Zura.Domain.Model.Todos.Entity;
using Zura.Domain.Model.Todos.Exception;

namespace Zura.Domain.Test
{
    public sealed class TodoTest
    {
        [Fact]
        public void CreateTodo_WithValidData_ShouldCreateSuccessfully()
        {
      
            var todo =  Todo.Create("Write Tests", "Use FluentAssertions", Priority.High);
            
            todo.Title.Should().Be("Write Tests");
            todo.Description.Should().Be("Use FluentAssertions");
            todo.Priority.Should().Be(Priority.High);
            todo.Status.Should().NotBeNull();
        }

        [Fact]
        public void CreateTodo_WithNullTitle_ShouldThrowTodoTitleException()
        {
            var act = () =>
            {
                var todo = Todo.Create(null!, "desc", Priority.Low);
            };

            act.Should().Throw<TodoTitleException>();
        }
    }
}
