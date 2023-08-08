using OrderService.Domain.Models.ConstantModels;

namespace OrderService.Domain.Exceptions
{
    public class ServerSideException : BaseException
    {
        public ServerSideException(ExceptionConstantModel exceptionConstant) : base(exceptionConstant)
        {
        }
    }
}
