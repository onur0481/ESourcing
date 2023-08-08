using SourcingService.Application.ViewModels.BidContextViewModels;
using SourcingService.Domain.Models.ConstantModels;
using System.Text.Json.Serialization;

namespace SourcingService.Application.CQRS.BidContextCQRSs.QueryGetBidAuctionID
{
    public class GetBidAuctionIDQueryResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ResponseConstantModel? Response { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<BidViewModel>? Bids { get; set; }

        public GetBidAuctionIDQueryResponse(List<BidViewModel>? bids)
        {
            Bids = bids;
        }

        public GetBidAuctionIDQueryResponse(ResponseConstantModel? response)
        {
            Response = response;
        }

    }
}
