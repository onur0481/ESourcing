using Web.APIGateway.Models.ConstantModels;

namespace Web.APIGateway.Constants;

/*
 * Exception message codes are between 29001 and 29999
 */
public static class ExceptionConstants
{
    public static readonly ExceptionConstantModel ServerSideError = new("29001", "An error has occurred with the server!");

    public static readonly ExceptionConstantModel TokenError = new("29002", "Please login, then try again!");
}
