using OrderService.Domain.Models.ConstantModels;

namespace OrderService.Application.DTOs.CQRSDTOs
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
