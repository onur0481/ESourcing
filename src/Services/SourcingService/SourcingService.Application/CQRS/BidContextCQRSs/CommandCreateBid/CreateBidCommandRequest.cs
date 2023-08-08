using MediatR;

namespace SourcingService.Application.CQRS.BidContextCQRSs.CommandCreateBid
{
    public class CreateBidCommandRequest : IRequest<CreateBidCommandResponse>
    {
        public string AuctionId { get; set; }

        public string ProductId { get; set; }

        public string SellerUserName { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; }

        public CreateBidCommandRequest(string auctionId, string productId, string sellerUserName, decimal price, DateTime createdAt)
        {
            AuctionId = auctionId;
            ProductId = productId;
            SellerUserName = sellerUserName;
            Price = price;
            CreatedAt = createdAt;
        }
    }
}
