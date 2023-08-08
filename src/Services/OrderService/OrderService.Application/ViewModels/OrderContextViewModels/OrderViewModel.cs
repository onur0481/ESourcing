using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.ViewModels.OrderContextViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        public string AuctionID { get; set; }

        public string SellerUserName { get; set; }

        public string ProductID { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }

        public OrderViewModel(string id, string auctionID, string sellerUserName, string productID, decimal unitPrice, decimal totalPrice) : base(id)
        {
            AuctionID = auctionID;
            SellerUserName = sellerUserName;
            ProductID = productID;
            UnitPrice = unitPrice;
            TotalPrice = totalPrice;
        }
    }
}
