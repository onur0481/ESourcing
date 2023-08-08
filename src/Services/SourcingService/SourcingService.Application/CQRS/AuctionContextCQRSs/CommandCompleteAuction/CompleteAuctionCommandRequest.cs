using MediatR;

namespace SourcingService.Application.CQRS.AuctionContextCQRSs.CommandCompleteAuction
{
    public class CompleteAuctionCommandRequest : IRequest<CompleteAuctionCommandResponse>
    {
        public string ID { get; set; }

        public CompleteAuctionCommandRequest(string id)
        {
            ID = id;
        }
    }
}
