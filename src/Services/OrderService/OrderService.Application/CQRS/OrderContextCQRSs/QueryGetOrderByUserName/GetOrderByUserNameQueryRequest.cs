using MediatR;

namespace OrderService.Application.CQRS.OrderContextCQRSs.QueryGetOrderByUserName
{
    public class GetOrderByUserNameQueryRequest : IRequest<GetOrderByUserNameQueryResponse>
    {
        public string UserName { get; set; }

        public GetOrderByUserNameQueryRequest(string userName)
        {
            UserName = userName;
        }
    }
}
