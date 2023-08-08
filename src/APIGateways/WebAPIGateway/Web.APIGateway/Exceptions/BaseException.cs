using Web.APIGateway.Models.ConstantModels;

namespace Web.APIGateway.Exceptions;

public class BaseException : Exception
{
    public string Code { get; private set; }

    public BaseException(ExceptionConstantModel exceptionConstant) : base(exceptionConstant.Message)
    {
        Code = exceptionConstant.Code;
    }
}
