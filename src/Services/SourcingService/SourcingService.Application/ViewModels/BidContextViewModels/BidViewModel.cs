namespace SourcingService.Application.ViewModels.BidContextViewModels
{
    public class BidViewModel : BaseViewModel
    {
        public string AuctionId { get; set; }

        public string ProductId { get; set; }

        public string SellerUserName { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public BidViewModel(string id ,string auctionId, string productId, string sellerUserName, decimal price) : base(id)
        {
            AuctionId = auctionId;
            ProductId = productId;
            SellerUserName = sellerUserName;
            Price = price;
        }
    }
}
