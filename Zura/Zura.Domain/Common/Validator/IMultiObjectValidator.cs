using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zura.Domain.Common.Exception;

namespace Zura.Application.Common.Validator;

public interface IMultiObjectValidator
{
    public IMultiObjectValidator NotNullOrEmptyList(BaseException exception);
}