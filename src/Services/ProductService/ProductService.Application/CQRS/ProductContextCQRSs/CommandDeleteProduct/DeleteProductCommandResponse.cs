using ProductService.Application.DTOs.CQRSDTOs;
using ProductService.Domain.Models.ConstantModels;

namespace ProductService.Application.CQRS.ProductContextCQRSs.CommandDeleteProduct
{
    public class DeleteProductCommandResponse : BaseCommandResponseDTO
    {
        public DeleteProductCommandResponse(ResponseConstantModel response) : base(response)
        {
        }
    }
}
