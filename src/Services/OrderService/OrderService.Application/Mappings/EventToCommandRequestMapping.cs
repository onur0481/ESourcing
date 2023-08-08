using AutoMapper;
using EventBus.Events.OrderServiceEvents;
using OrderService.Application.CQRS.OrderContextCQRSs.CommandCreateOrder;

namespace OrderService.Application.Mappings
{
    public class EventToCommandRequestMapping : Profile
    {
        public EventToCommandRequestMapping()
        {
            CreateMap<OrderCreateEvent, CreateOrderCommandRequest>()
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Quantity * src.Quantity))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Price));
                
        }
    }
}
