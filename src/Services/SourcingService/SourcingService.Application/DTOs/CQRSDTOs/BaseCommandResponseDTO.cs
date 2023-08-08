using SourcingService.Domain.Models.ConstantModels;

namespace SourcingService.Application.DTOs.CQRSDTOs
{
    public abstract class BaseCommandResponseDTO
    {
        public ResponseConstantModel Response { get; private set; }

        protected BaseCommandResponseDTO(ResponseConstantModel response)
        {
            Response = response;
        }
    }
}
