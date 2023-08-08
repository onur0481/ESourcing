using MediatR;

namespace SourcingService.Application.CQRS.AuctionContextCQRSs.CommandDeleteAuction
{
    public class DeleteAuctionCommandRequest : IRequest<DeleteAuctionCommandResponse>
    {
        public string ID { get; set; }

        public DeleteAuctionCommandRequest(string id)
        {
            ID = id;
        }
    }
}
