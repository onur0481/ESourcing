using ProductService.Domain.Models.ConstantModels;

namespace ProductService.Application.DTOs.CQRSDTOs
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
