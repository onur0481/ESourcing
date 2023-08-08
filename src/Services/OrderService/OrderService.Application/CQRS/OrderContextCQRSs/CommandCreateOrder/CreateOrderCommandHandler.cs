using AutoMapper;
using MediatR;
using OrderService.Domain.Constants;
using OrderService.Domain.Entities;
using OrderService.Domain.Repositories.OrderContextRepositories;

namespace OrderService.Application.CQRS.OrderContextCQRSs.CommandCreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            Order order = _mapper.Map<Order>(request);
            if (order == null) return Task.FromResult(new CreateOrderCommandResponse(ResponseConstants.CreatingProcessUnsuccessful));

            _orderRepository.Add(order);

            int effectedRows = _orderRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new CreateOrderCommandResponse(ResponseConstants.CreatingProcessUnsuccessful)); 

            return Task.FromResult(new CreateOrderCommandResponse(ResponseConstants.CreatingProcessSuccessful));
        }
    }
}
