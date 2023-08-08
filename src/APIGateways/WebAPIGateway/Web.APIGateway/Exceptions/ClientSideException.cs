using Web.APIGateway.Models.ConstantModels;

namespace Web.APIGateway.Exceptions
{
    public class ClientSideException : BaseException
    {
        public ClientSideException(ExceptionConstantModel exceptionConstant) : base(exceptionConstant)
        {
        }
    }
}
