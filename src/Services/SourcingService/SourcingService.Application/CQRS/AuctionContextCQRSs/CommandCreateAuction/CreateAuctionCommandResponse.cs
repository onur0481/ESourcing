using SourcingService.Application.DTOs.CQRSDTOs;
using SourcingService.Domain.Models.ConstantModels;

namespace SourcingService.Application.CQRS.AuctionContextCQRSs.CommandCreateAuction
{
    public class CreateAuctionCommandResponse : BaseCommandResponseDTO
    {
        public CreateAuctionCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
