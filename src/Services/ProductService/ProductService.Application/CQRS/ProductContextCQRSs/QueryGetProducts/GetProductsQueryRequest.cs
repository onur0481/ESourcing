using MediatR;

namespace ProductService.Application.CQRS.ProductContextCQRSs.QueryGetProducts
{
    public class GetProductsQueryRequest : IRequest<GetProductsQueryResponse>
    {
    }
}
