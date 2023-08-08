using AutoMapper;
using MediatR;
using OrderService.Application.ViewModels.OrderContextViewModels;
using OrderService.Domain.Constants;
using OrderService.Domain.Entities;
using OrderService.Domain.Repositories.OrderContextRepositories;

namespace OrderService.Application.CQRS.OrderContextCQRSs.QueryGetOrderByUserName
{
    public class GetOrderByUserNameQueryHandler : IRequestHandler<GetOrderByUserNameQueryRequest, GetOrderByUserNameQueryResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderByUserNameQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<GetOrderByUserNameQueryResponse> Handle(GetOrderByUserNameQueryRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<Order> orders = await _orderRepository.GetOrdersBySellerUserName(request.UserName);
            if (!orders.Any()) return await Task.FromResult(new GetOrderByUserNameQueryResponse(ResponseConstants.OrdersNotAvailable));

            List<OrderViewModel> orderViewModel = _mapper.Map<List<OrderViewModel>>(orders);

            return await Task.FromResult(new GetOrderByUserNameQueryResponse(orderViewModel));
        }
    }
}
