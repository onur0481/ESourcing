using SourcingService.Application.DTOs.CQRSDTOs;
using SourcingService.Domain.Models.ConstantModels;

namespace SourcingService.Application.CQRS.AuctionContextCQRSs.CommandCompleteAuction
{
    public class CompleteAuctionCommandResponse : BaseCommandResponseDTO
    {
        public CompleteAuctionCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
