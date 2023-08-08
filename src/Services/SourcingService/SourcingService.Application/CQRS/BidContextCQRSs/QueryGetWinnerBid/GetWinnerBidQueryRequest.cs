using MediatR;

namespace SourcingService.Application.CQRS.BidContextCQRSs.QueryGetWinnerBid
{
    public class GetWinnerBidQueryRequest : IRequest<GetWinnerBidQueryResponse>
    {
        public string AuctionID { get; set; }

        public GetWinnerBidQueryRequest(string auctionID)
        {
            AuctionID = auctionID;
        }
    }
}
