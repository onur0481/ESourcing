using ProductService.Application.DTOs.CQRSDTOs;
using ProductService.Domain.Models.ConstantModels;

namespace ProductService.Application.CQRS.ProductContextCQRSs.CommandUpdateProduct
{
    public class UpdateProductCommandResponse : BaseCommandResponseDTO
    {
        public UpdateProductCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
