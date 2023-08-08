using SourcingService.Domain.Models.ConstantModels;

namespace SourcingService.Domain.Exceptions;

public class ClientSideException : BaseException
{
    public ClientSideException(ExceptionConstantModel exceptionConstant) : base(exceptionConstant)
    {
    }
}
