using MediatR;

namespace SourcingService.Application.CQRS.BidContextCQRSs.QueryGetBidAuctionID
{
    public class GetBidAuctionIDQueryRequest : IRequest<GetBidAuctionIDQueryResponse>
    {
        public string AuctionID { get; set; }

        public GetBidAuctionIDQueryRequest(string auctionID)
        {
            AuctionID = auctionID;
        }
    }
}
