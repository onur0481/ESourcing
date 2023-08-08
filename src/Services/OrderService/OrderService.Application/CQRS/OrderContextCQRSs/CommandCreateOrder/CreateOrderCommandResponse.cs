using OrderService.Application.DTOs.CQRSDTOs;
using OrderService.Domain.Models.ConstantModels;

namespace OrderService.Application.CQRS.OrderContextCQRSs.CommandCreateOrder
{
    public class CreateOrderCommandResponse : BaseCommandResponseDTO
    {
        public CreateOrderCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
