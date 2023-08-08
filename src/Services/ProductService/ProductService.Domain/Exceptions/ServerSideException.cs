

using ProductService.Domain.Models.ConstantModels;

namespace ProductService.Domain.Exceptions
{
    public class ServerSideException : BaseException
    {
        public ServerSideException(ExceptionConstantModel exceptionConstant) : base(exceptionConstant)
        {
        }
    }
}
