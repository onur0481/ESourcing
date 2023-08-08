using MediatR;

namespace ProductService.Application.CQRS.ProductContextCQRSs.QueryGetByIDProduct
{
    public class GetByIDProductQueryRequest : IRequest<GetByIDProductQueryResponse>
    {
        public string ID { get; set; }

        public GetByIDProductQueryRequest(string id)
        {
            ID = id;
        }
    }
}
