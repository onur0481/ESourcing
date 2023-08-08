using MongoDB.Bson.Serialization.Attributes;
using SourcingService.Domain.Attributes;
using SourcingService.Domain.SeedWorks;

namespace SourcingService.Domain.Entities
{
    [BsonCollection("BidCollection")]
    public class BidEntity : BaseEntity, IAggregateRoot
    {
        public string AuctionId { get; set; }

        public string ProductId { get; set; }

        public string SellerUserName { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; }

        public BidEntity(string auctionId, string productId, string sellerUserName, decimal price, DateTime createdAt)
        {
            AuctionId = auctionId;
            ProductId = productId;
            SellerUserName = sellerUserName;
            Price = price;
            CreatedAt = createdAt;
        }
    }
}
