using MediatR;

namespace SourcingService.Application.CQRS.AuctionContextCQRSs.CommandUpdateAuction
{
    public class UpdateAuctionCommandRequest : IRequest<UpdateAuctionCommandResponse>
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string ProductId { get; set; }

        public int Quantity { get; set; }

        public DateTime StartedAt { get; set; }

        public DateTime FinishedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public int Status { get; set; }

        public List<string> IncludedSellers { get; set; }

        public UpdateAuctionCommandRequest(string id, string name, string description, string productId, int quantity, DateTime startedAt, DateTime finishedAt, DateTime createdAt, int status, List<string> includedSellers)
        {
            ID = id;
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
