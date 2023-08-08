using AutoMapper;
using EventBus.Events.OrderServiceEvents;
using MassTransit;
using MediatR;
using OrderService.Application.CQRS.OrderContextCQRSs.CommandCreateOrder;

namespace OrderService.API.EventBusConsumers
{
    public class SourcingConsumer : IConsumer<OrderCreateEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SourcingConsumer(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<OrderCreateEvent> context)
        {
            CreateOrderCommandRequest commandRequest = new(context.Message.AuctionId,context.Message.SellerUserName,context.Message.ProductId,context.Message.Quantity,context.Message.Quantity*context.Message.Price);   
            
            await _mediator.Send(commandRequest);
        }
    }
}
