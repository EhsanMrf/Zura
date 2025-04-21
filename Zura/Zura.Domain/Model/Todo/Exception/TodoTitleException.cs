using Zura.Application.Common.Exception;

namespace Zura.Domain.Model.Todo.Exception;

internal class TodoTitleException() : BaseException("Title Not Null");
