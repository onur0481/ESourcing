using Amazon.Auth.AccessControlPolicy;
using SourcingService.Application.ViewModels.AuctionContextViewModels;
using SourcingService.Domain.Models.ConstantModels;
using System.Text.Json.Serialization;

namespace SourcingService.Application.CQRS.AuctionContextCQRSs.QueryGetAuctions
{
    public class GetAuctionsQueryResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ResponseConstantModel? Response { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<AuctionViewModel>? Auctions { get; set; }

        public GetAuctionsQueryResponse(List<AuctionViewModel>? auctions)
        {
            Auctions = auctions;
        }

        public GetAuctionsQueryResponse(ResponseConstantModel? response)
        {
            Response = response;
        }
    }
}
