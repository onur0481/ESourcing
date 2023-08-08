using ProductService.Domain.Models.ConstantModels;

namespace ProductService.Domain.Exceptions
{
    public class BaseException : Exception
    {
        public string Code { get; private set; }

        public BaseException(ExceptionConstantModel exceptionConstant) : base(exceptionConstant.Message)
        {
            Code = exceptionConstant.Code;
        }
    }
}
