using OrderService.Domain.Models.ConstantModels;

namespace OrderService.Domain.Exceptions;

public class ClientSideException : BaseException
{
    public ClientSideException(ExceptionConstantModel exceptionConstant) : base(exceptionConstant)
    {
    }
}
