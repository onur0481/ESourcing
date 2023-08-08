using MediatR;
using ProductService.Domain.Constants;
using ProductService.Domain.Entites;
using ProductService.Domain.Repositories.ProductContextRepositories;

namespace ProductService.Application.CQRS.ProductContextCQRSs.CommandDeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            ProductEntity productEntity = _productRepository.FindById(request.ID);
            if (productEntity == null) return Task.FromResult(new DeleteProductCommandResponse(ResponseConstants.DeletingProcessUnsuccessful));

            _productRepository.DeleteById(request.ID);

            return Task.FromResult(new DeleteProductCommandResponse(ResponseConstants.DeletingProcessSuccessful));
        }
    }
}
