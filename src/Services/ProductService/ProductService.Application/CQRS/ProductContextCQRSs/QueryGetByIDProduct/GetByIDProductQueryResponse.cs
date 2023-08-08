using ProductService.Application.ViewModels.ProductContextViewModels;
using ProductService.Domain.Models.ConstantModels;
using System.Text.Json.Serialization;

namespace ProductService.Application.CQRS.ProductContextCQRSs.QueryGetByIDProduct
{
    public class GetByIDProductQueryResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ResponseConstantModel? Response { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ProductViewModel? Product { get; set; }


        public GetByIDProductQueryResponse(ProductViewModel product)
        {
            Product = product;
        }


        public GetByIDProductQueryResponse(ResponseConstantModel? response)
        {
            Response = response;
        }
    }
}
