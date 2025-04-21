using Zura.Domain.Common.Exception;

namespace Zura.Application.Todo.Commands.Exception;

internal class TodoNotFoundException(): BaseException("Not Found");