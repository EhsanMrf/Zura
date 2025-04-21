using System.Collections;
using Zura.Domain.Common.Exception;

namespace Zura.Application.Common.Validator;

public class ObjectValidator : IObjectValidator, ISingleObjectValidator, IMultiObjectValidator
{
    private object @Object { get; set; } = null!;
    private object[] @Objects { get; set; } = null!;
    public static IObjectValidator Instance => new ObjectValidator();

    private ObjectValidator()
    {

    }

    public ISingleObjectValidator RuleFor(object data)
    {
        @Object = data;
        return this;
    }
    public IMultiObjectValidator RuleFor(params object[] objects)
    {
        @Objects = objects;
        return this;
    }

    public IObjectValidator Must<T>(T ob, Func<T, bool> expression, BaseException exception)
    {
        if (expression(ob))
            throw exception;

        return this;
    }

    public IObjectValidator Must<T>(T ob, Func<T, bool> expression, BaseException exception, bool defaultReturn)
    {
        if (!expression(ob) && defaultReturn) return default;

        if (expression(ob)) throw exception;

        return this;
    }

    public IObjectValidator NotNullOrEmpty(BaseException exception)
    {
        switch (Object)
        {
            case null:
            case int and (< 0 or 0):
            case byte b when b is < 0 or 0:
            case short s when s is < 0 or 0:
            case string str when string.IsNullOrWhiteSpace(str):
            case ICollection { Count: 0 }:
            case long and (< 0 or 0):
            case float and (< 0 or 0):
            case Array { Length: 0 }:
            case Guid when Object.Equals(Guid.Empty):
            case bool when true:
                //case IEnumerable e when !e.GetEnumerator().MoveNext():
                throw exception;
        }

        return this;
    }

    public IMultiObjectValidator NotNullOrEmptyList(BaseException exception)
    {
        foreach (var o in Objects)
        {
            switch (o)
            {
                case null:
                case int i when i is < 0 or 0:
                case byte b when b is < 0 or 0:
                case short s when s is < 0 or 0:
                case string str when string.IsNullOrWhiteSpace(str):
                case ICollection { Count: 0 }:
                case Array { Length: 0 }:
                case long and (< 0 or 0):
                case float and (< 0 or 0):
                case Guid when o.Equals(Guid.Empty):
                    //case IEnumerable e when !e.GetEnumerator().MoveNext():
                    throw exception;
            }
        }

        return this;
    }
}