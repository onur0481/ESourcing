using AutoMapper;
using OrderService.Application.CQRS.OrderContextCQRSs.CommandCreateOrder;
using OrderService.Domain.Entities;

namespace OrderService.Application.Mappings
{
    public class CommandRequestToEntityMappings : Profile
    {
        public CommandRequestToEntityMappings() 
        {
            CreateMap<CreateOrderCommandRequest, Order>();
        }
    }
}
