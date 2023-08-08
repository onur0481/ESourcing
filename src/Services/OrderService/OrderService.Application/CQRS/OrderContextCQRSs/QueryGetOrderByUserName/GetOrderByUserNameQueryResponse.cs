using OrderService.Application.ViewModels.OrderContextViewModels;
using OrderService.Domain.Models.ConstantModels;
using System.Text.Json.Serialization;

namespace OrderService.Application.CQRS.OrderContextCQRSs.QueryGetOrderByUserName
{
    public class GetOrderByUserNameQueryResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ResponseConstantModel? Response { get; set; }

        public GetOrderByUserNameQueryResponse(ResponseConstantModel? response)
        {
            Response = response;
        }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<OrderViewModel>? Orders { get; set; }

        public GetOrderByUserNameQueryResponse(List<OrderViewModel>? orders)
        {
            Orders = orders;
        }
    }
}
