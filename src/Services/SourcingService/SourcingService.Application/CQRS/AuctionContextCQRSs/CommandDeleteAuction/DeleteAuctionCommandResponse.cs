using SourcingService.Application.DTOs.CQRSDTOs;
using SourcingService.Domain.Models.ConstantModels;

namespace SourcingService.Application.CQRS.AuctionContextCQRSs.CommandDeleteAuction
{
    public class DeleteAuctionCommandResponse : BaseCommandResponseDTO
    {
        public DeleteAuctionCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
