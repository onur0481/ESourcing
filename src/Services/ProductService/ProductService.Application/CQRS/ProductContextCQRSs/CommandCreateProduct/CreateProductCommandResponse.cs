using ProductService.Application.DTOs.CQRSDTOs;
using ProductService.Domain.Models.ConstantModels;

namespace ProductService.Application.CQRS.ProductContextCQRSs.CommandCreateProduct
{
    public class CreateProductCommandResponse : BaseCommandResponseDTO
    {
        public CreateProductCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
