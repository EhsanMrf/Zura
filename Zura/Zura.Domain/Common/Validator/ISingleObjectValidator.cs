using Zura.Domain.Common.Exception;

namespace Zura.Application.Common.Validator;

public interface ISingleObjectValidator
{
    public IObjectValidator NotNullOrEmpty(BaseException exception);
}