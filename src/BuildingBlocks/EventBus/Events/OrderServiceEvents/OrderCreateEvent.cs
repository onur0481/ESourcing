namespace EventBus.Events.OrderServiceEvents
{
    public class OrderCreateEvent : BaseIntegrationEvent
    {
        public string AuctionId { get; set; }

        public string ProductId { get; set; }

        public string SellerUserName { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public OrderCreateEvent(string auctionId, string productId, string sellerUserName, decimal price, int quantity)
        {
            AuctionId = auctionId;
            ProductId = productId;
            SellerUserName = sellerUserName;
            Price = price;
            Quantity = quantity;
        }
    }
}
