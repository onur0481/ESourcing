using ProductService.Application.ViewModels.ProductContextViewModels;
using ProductService.Domain.Models.ConstantModels;
using System.Text.Json.Serialization;

namespace ProductService.Application.CQRS.ProductContextCQRSs.QueryGetProducts
{
    public class GetProductsQueryResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ResponseConstantModel? Response { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ICollection<ProductViewModel>? Products { get; set; }

        public GetProductsQueryResponse(ICollection<ProductViewModel> products)
        {
            Products = products;
        }


        public GetProductsQueryResponse(ResponseConstantModel response)
        {
            Response = response;
        }
    }
}
