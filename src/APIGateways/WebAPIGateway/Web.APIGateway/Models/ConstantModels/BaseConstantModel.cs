namespace Web.APIGateway.Models.ConstantModels
{
    public abstract class BaseConstantModel
    {
        public string Code { get; private set; }

        public string Message { get; private set; }

        public BaseConstantModel(string code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
