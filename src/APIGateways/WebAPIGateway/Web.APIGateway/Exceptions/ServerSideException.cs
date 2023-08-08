using Web.APIGateway.Models.ConstantModels;

namespace Web.APIGateway.Exceptions
{
    public class ServerSideException : BaseException
    {
        public ServerSideException(ExceptionConstantModel exceptionConstant) : base(exceptionConstant)
        {
        }
    }
}
