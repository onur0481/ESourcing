using FluentValidation;
using OrderService.Application.CQRS.OrderContextCQRSs.CommandCreateOrder;
using OrderService.Application.Validations.Validators;

namespace OrderService.Application.Validations.OrderValidators
{
    public class CreateOrderCommandRequestValidator : AbstractValidator<CreateOrderCommandRequest>
    {
        public CreateOrderCommandRequestValidator()
        {
            RuleFor(x => x.SellerUserName).NameValidation();
            RuleFor(x => x.ProductID).ProductIDValidation();
        }
    }
}
