using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.CQRS.OrderContextCQRSs.CommandCreateOrder;
using OrderService.Application.CQRS.OrderContextCQRSs.QueryGetOrderByUserName;

namespace OrderService.API.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetOrdersByUserName/{userName}")]
        public async Task<IActionResult> GetOrdersByUserName(string userName)
        {
            GetOrderByUserNameQueryResponse queryResponse = await _mediator.Send(new GetOrderByUserNameQueryRequest(userName));

            if(queryResponse.Response != null) return CreateActionResult(queryResponse.Response);

            return CreateActionResult(queryResponse.Orders);
        }

        [HttpPost]
        [Route("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommandRequest request)
        {
            CreateOrderCommandResponse commandResponse = await _mediator.Send(request);

            return CreateActionResult(commandResponse.Response);
        }
    }
}
