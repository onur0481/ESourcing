using OrderService.Domain.Models.ConstantModels;

namespace OrderService.Domain.Constants
{
    /*
     * Validation message codes are between 32001 and 32999
     */

    public static class ValidationConstants
    {
        public static readonly ValidationConstantModel UserNameFieldNotNullNotEmpty = new("32001", "The user name field must not be left blank!");

        public static readonly ValidationConstantModel UserNameFieldOnlyEmail = new("32002", "The user name field must be in e-mail format!");

        public static readonly ValidationConstantModel ProductIDNotNullNotEmpty = new("32003", "The product id field must not be left blank!");

        public static readonly ValidationConstantModel AuctionIDNotNullNotEmpty = new("32004", "The auction id field must not be left blank!");

        public static readonly ValidationConstantModel UnitPriceNotNullNotEmpty = new("32005", "The unit price field must not be left blank!");

        public static readonly ValidationConstantModel TotalPriceNotNullNotEmpty = new("32006", "The total price field must not be left blank!");

        public static readonly ValidationConstantModel OnlyNumberRegex = new("32007", "This field must contain numbers only!");

    }
}
