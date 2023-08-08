using SourcingService.Domain.Models.ConstantModels;

namespace SourcingService.Domain.Exceptions
{
    public class ServerSideException : BaseException
    {
        public ServerSideException(ExceptionConstantModel exceptionConstant) : base(exceptionConstant)
        {
        }
    }
}
