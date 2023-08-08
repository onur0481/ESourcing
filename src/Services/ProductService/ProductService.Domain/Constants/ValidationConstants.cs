using ProductService.Domain.Models.ConstantModels;

namespace ProductService.Domain.Constants
{
    /*
     * Validation message codes are between 32001 and 32999
     */

    public static class ValidationConstants
    {
        public static readonly ValidationConstantModel NameFieldNotNullNotEmpty = new("32001", "The name field must not be left blank!");

        public static readonly ValidationConstantModel DocumentTypeFieldNotNullNotEmpty = new("32002", "The document type field must not be left blank!");

        public static readonly ValidationConstantModel UniqueFieldIDFieldNotNullNotEmpty = new("32003", "The unique field id field must not be left blank!");

        public static readonly ValidationConstantModel ContentsFieldNotNullNotEmpty = new("32004", "The contents field must not be left blank!");

        public static readonly ValidationConstantModel FieldNameFieldCannotContainsDot = new("32005", "The field name field of any of the elements in contents cannot contain a dot character!");
    }
}
