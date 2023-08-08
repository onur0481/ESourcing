using MongoDB.Bson.Serialization.Attributes;
using SourcingService.Domain.Attributes;
using SourcingService.Domain.SeedWorks;

namespace SourcingService.Domain.Entities
{
    [BsonCollection("AuctionCollection")]
    public class AuctionEntity : BaseEntity, IAggregateRoot
    {
        [BsonElement("Name")]
        public string Name { get; set; }

        public string Description { get; set; }

        public string ProductId { get; set; }

        public int Quantity { get; set; }

        public DateTime StartedAt { get; set; }

        public DateTime FinishedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public int Status { get; set; }

        public List<string> IncludedSellers { get; set; }

        public AuctionEntity(string name, string description, string productId, int quantity, DateTime startedAt, DateTime finishedAt, DateTime createdAt, int status, List<string> includeSellers)
        {
            Name = name;
            Description = description;
            ProductId = productId;
            Quantity = quantity;
            StartedAt = startedAt;
            FinishedAt = finishedAt;
            CreatedAt = createdAt;
            Status = status;
            IncludedSellers = includeSellers;
        }


        public AuctionEntity()
        {
            
        }
    }
    

    public enum Status
    {
        Active = 0,
        Closed = 1,
        Passive = 2
    }
}
