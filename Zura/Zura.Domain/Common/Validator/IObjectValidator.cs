using Zura.Domain.Common.Exception;

namespace Zura.Application.Common.Validator;

public interface IObjectValidator
{
    public ISingleObjectValidator RuleFor(object data);
    public IMultiObjectValidator RuleFor(params object[] objects);
    public IObjectValidator Must<T>(T ob, Func<T, bool> expression, BaseException exception);
    IObjectValidator Must<T>(T ob, Func<T, bool> expression, BaseException exception, bool defaultReturn);

}