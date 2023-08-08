using AutoMapper;
using MediatR;
using ProductService.Domain.Constants;
using ProductService.Domain.Entites;
using ProductService.Domain.Repositories.ProductContextRepositories;

namespace ProductService.Application.CQRS.ProductContextCQRSs.CommandUpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            ProductEntity productEntity = _productRepository.FindById(request.ID);
            if (productEntity == null) return Task.FromResult(new UpdateProductCommandResponse(ResponseConstants.UpdatingProcessUnsuccessful));

            bool isExist = productEntity.Name.Equals(request.Name.Trim()) == false && _productRepository.IsExistByName(request.Name);
            if (isExist) return Task.FromResult(new UpdateProductCommandResponse(ResponseConstants.UpdatingProcessExistProductWithSameName));

            _mapper.Map(request, productEntity);
            _productRepository.ReplaceOne(productEntity);

            return Task.FromResult(new UpdateProductCommandResponse(ResponseConstants.UpdatingProcessSuccessful));
        }
    }
}
