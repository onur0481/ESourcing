using OrderService.Domain.SeedWorks;

namespace OrderService.Domain.Entities
{
    public class Order : BaseEntity, IAggregateRoot
    {
        public string AuctionID { get; set; }

        public string SellerUserName { get; set; }

        public string ProductID { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }

        public Order(int id, DateTime createdDate, string auctionID, string sellerUserName, string productID, decimal unitPrice, decimal totalPrice)
        {
            ID = id;
            CreatedDate = createdDate;
            AuctionID = auctionID;
            SellerUserName = sellerUserName;
            ProductID = productID;
            UnitPrice = unitPrice;
            TotalPrice = totalPrice;
        }

        public Order(string auctionID, string sellerUserName, string productID, decimal unitPrice, decimal totalPrice)
        {
            AuctionID = auctionID;
            SellerUserName = sellerUserName;
            ProductID = productID;
            UnitPrice = unitPrice;
            TotalPrice = totalPrice;
        }

        public Order CopyWith(string? auctionID = null, string? sellerUserName = null, string? productID = null, decimal? unitPrice = 0, decimal? totalPrice = 0)
        {
            return new Order(
                id: ID,
                createdDate: CreatedDate,
                auctionID: auctionID ?? AuctionID,
                sellerUserName: sellerUserName ?? SellerUserName,
                productID: productID ?? ProductID,
                unitPrice: unitPrice ?? UnitPrice,
                totalPrice: totalPrice ?? TotalPrice
                );
        }
    }
}
