using MediatR;

namespace SourcingService.Application.CQRS.AuctionContextCQRSs.QueryGetByIDAuction
{
    public class GetByIDAuctionQueryRequest : IRequest<GetByIDAuctionQueryResponse>
    {
        public string ID { get; set; }

        public GetByIDAuctionQueryRequest(string id)
        {
            ID = id;
        }
    }
}
