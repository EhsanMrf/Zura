using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Zura.Application.Common.Exceptions;
using Zura.Domain.Common.Exception;

namespace Zura.Presentation.API.Filter;

public class CatchExceptionFilterAttribute : ExceptionFilterAttribute
{
    private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

    public CatchExceptionFilterAttribute()
    {
        _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
        {
            { typeof(ValidationException), HandleValidationException },
            { typeof(BaseException), HandleBaseException},

        };
    }

    private void HandleBaseException(ExceptionContext context)
    {
        if (context.Exception is not BaseException exception)
            return;


        var details = new ProblemDetails
        {
            Title = "Application Error",
            Detail = exception.Message,
            Status = StatusCodes.Status400BadRequest,
            Type = string.Empty
        };

        context.Result = new BadRequestObjectResult(details);
        context.ExceptionHandled = true;
    }

    private void HandleException(ExceptionContext context)
    {
        Type type = context.Exception.GetType();
        if (_exceptionHandlers.TryGetValue(type, out Action<ExceptionContext>? value))
        {
            value.Invoke(context);
            return;
        }
    }

    private void HandleValidationException(ExceptionContext context)
    {
        var exception = (ValidationException)context.Exception;

        var details = new ValidationProblemDetails(exception.Errors)
        {
            Type = string.Empty
        };
        context.Result = new BadRequestObjectResult(details);
        context.ExceptionHandled = true;
    }

    public override void OnException(ExceptionContext context)
    {
        HandleBaseException(context);
        HandleException(context);
        base.OnException(context);
    }
}