using MediatR;

namespace SourcingService.Application.CQRS.AuctionContextCQRSs.CommandCreateAuction
{
    public class CreateAuctionCommandRequest : IRequest<CreateAuctionCommandResponse>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ProductId { get; set; }

        public int Quantity { get; set; }

        public DateTime StartedAt { get; set; }

        public DateTime FinishedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public int Status { get; set; }

        public List<string> IncludedSellers { get; set; }

        public CreateAuctionCommandRequest(string name, string description, string productId, int quantity, DateTime startedAt, DateTime finishedAt, DateTime createdAt, int status, List<string> includedSellers)
        {
            Name = name;
            Description = description;
            ProductId = productId;
            Quantity = quantity;
            StartedAt = startedAt;
            FinishedAt = finishedAt;
            CreatedAt = createdAt;
            Status = status;
            IncludedSellers = includedSellers;
        }
    }
}
