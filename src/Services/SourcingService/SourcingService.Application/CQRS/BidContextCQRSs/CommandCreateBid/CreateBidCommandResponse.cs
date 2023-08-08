using SourcingService.Application.DTOs.CQRSDTOs;
using SourcingService.Domain.Models.ConstantModels;

namespace SourcingService.Application.CQRS.BidContextCQRSs.CommandCreateBid
{
    public class CreateBidCommandResponse : BaseCommandResponseDTO
    {
        public CreateBidCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
