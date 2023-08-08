using FluentValidation;
using OrderService.Domain.Constants;

namespace OrderService.Application.Validations.Validators
{
    // TODO: Verilen mesajlar dil desteği olacak şekilde kurgulanmalı
    public static partial class OrderValidators
    {
        public static IRuleBuilderOptions<T, string> NameValidation<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotNull().NotEmpty().WithMessage(ValidationConstants.UserNameFieldNotNullNotEmpty.ToString())
                .Matches(RegexConstants.EmailFormatRegex()).WithMessage(ValidationConstants.UserNameFieldOnlyEmail.ToString());
        }

        public static IRuleBuilderOptions<T, string> ProductIDValidation<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotNull().NotEmpty().WithMessage(ValidationConstants.ProductIDNotNullNotEmpty.ToString());             
        }

        public static IRuleBuilderOptions<T, decimal> UnitPriceValidation<T>(this IRuleBuilder<T, decimal> ruleBuilder)
        {
            return ruleBuilder
                .NotNull().NotEmpty().WithMessage(ValidationConstants.UnitPriceNotNullNotEmpty.ToString());
        }

        public static IRuleBuilderOptions<T, decimal> TotalPriceValidation<T>(this IRuleBuilder<T, decimal> ruleBuilder)
        {
            return ruleBuilder
               .NotNull().NotEmpty().WithMessage(ValidationConstants.TotalPriceNotNullNotEmpty.ToString());

        }


    }
}
