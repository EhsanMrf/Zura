using Zura.Domain.Common.Exception;

namespace Zura.Domain.Model.Todo.Exception;

public class TodoStatusCheckerModeArchiveException() : BaseException("Change to archive is not allowed.");
public class TodoStatusCheckerModeCompleteException() : BaseException("Change to complete  ve is not allowed.");
public class TodoStatusCheckerModePendingException() : BaseException("Change to pending  ve is not allowed.");
public class TodoStatusCheckerModeInProgressException() : BaseException("Change to progress  ve is not allowed.");
public class TodoStatusInvalidException() : BaseException("Not Null");
