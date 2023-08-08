using SourcingService.Application.ViewModels.BidContextViewModels;
using SourcingService.Domain.Models.ConstantModels;
using System.Text.Json.Serialization;

namespace SourcingService.Application.CQRS.BidContextCQRSs.QueryGetWinnerBid
{
    public class GetWinnerBidQueryResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ResponseConstantModel? Response { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BidViewModel? Bids { get; set; }

        public GetWinnerBidQueryResponse(BidViewModel? bids)
        {
            Bids = bids;
        }

        public GetWinnerBidQueryResponse(ResponseConstantModel? response)
        {
            Response = response;
        }
    }
}
