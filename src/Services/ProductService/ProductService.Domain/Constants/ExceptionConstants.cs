using ProductService.Domain.Models.ConstantModels;

namespace ProductService.Domain.Constants
{
    /*
     * Exception message codes are between 22001 and 22999
     */
    public static class ExceptionConstants
    {
        public static readonly ExceptionConstantModel ServerSideError = new("22001", "An error has occurred with the server!");

        public static readonly ExceptionConstantModel QueryStringError = new("22002", "The query you entered is incorrect!");

        public static readonly ExceptionConstantModel NoDataFrame = new("22003", "No data frame of the entered id was found!");

        public static readonly ExceptionConstantModel TokenError = new("22004", "Please login, then try again!");
    }
}
