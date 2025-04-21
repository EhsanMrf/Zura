using Zura.Application.Common.Exception;

namespace Zura.Domain.Model.Todo.Exception;

internal class TodoStatusCheckerModeArchiveException() : BaseException("Change to archive is not allowed.");
internal class TodoStatusCheckerModeCompleteException() : BaseException("Change to complete  ve is not allowed.");
internal class TodoStatusCheckerModePendingException() : BaseException("Change to pending  ve is not allowed.");
internal class TodoStatusCheckerModeInProgressException() : BaseException("Change to progress  ve is not allowed.");
internal class TodoStatusInvalidException() : BaseException("Not Null");
