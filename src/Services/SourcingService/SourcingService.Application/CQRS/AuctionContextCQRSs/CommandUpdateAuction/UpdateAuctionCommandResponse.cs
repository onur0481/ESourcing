using SourcingService.Application.DTOs.CQRSDTOs;
using SourcingService.Domain.Models.ConstantModels;

namespace SourcingService.Application.CQRS.AuctionContextCQRSs.CommandUpdateAuction
{
    public class UpdateAuctionCommandResponse : BaseCommandResponseDTO
    {
        public UpdateAuctionCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
