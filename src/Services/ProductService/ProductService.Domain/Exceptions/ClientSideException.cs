using ProductService.Domain.Models.ConstantModels;

namespace ProductService.Domain.Exceptions;

public class ClientSideException : BaseException
{
    public ClientSideException(ExceptionConstantModel exceptionConstant) : base(exceptionConstant)
    {
    }
}
