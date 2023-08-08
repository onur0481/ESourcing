using Amazon.Auth.AccessControlPolicy;
using SourcingService.Application.ViewModels.AuctionContextViewModels;
using SourcingService.Domain.Models.ConstantModels;
using System.Text.Json.Serialization;

namespace SourcingService.Application.CQRS.AuctionContextCQRSs.QueryGetByIDAuction
{
    public class GetByIDAuctionQueryResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ResponseConstantModel? Response { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AuctionViewModel? Auction { get; set; }

        public GetByIDAuctionQueryResponse(AuctionViewModel? auction)
        {
            Auction = auction;
        }

        public GetByIDAuctionQueryResponse(ResponseConstantModel? response)
        {
            Response = response;
        }
    }
}
