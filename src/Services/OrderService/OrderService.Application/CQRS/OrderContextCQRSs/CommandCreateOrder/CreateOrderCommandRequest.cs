using MediatR;

namespace OrderService.Application.CQRS.OrderContextCQRSs.CommandCreateOrder
{
    public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
    {
        public string AuctionID { get; set; }

        public string SellerUserName { get; set; }

        public string ProductID { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }

        public CreateOrderCommandRequest(string auctionID, string sellerUserName, string productID, decimal unitPrice, decimal totalPrice)
        {
            AuctionID = auctionID;
            SellerUserName = sellerUserName;
            ProductID = productID;
            UnitPrice = unitPrice;
            TotalPrice = totalPrice;
        }
    }
}
