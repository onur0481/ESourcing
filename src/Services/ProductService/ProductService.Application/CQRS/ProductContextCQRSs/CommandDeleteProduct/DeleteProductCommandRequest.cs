using MediatR;

namespace ProductService.Application.CQRS.ProductContextCQRSs.CommandDeleteProduct
{
    public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
    {
        public string ID { get; set; }

        public DeleteProductCommandRequest(string id)
        {
            ID = id;
        }
    }
}
