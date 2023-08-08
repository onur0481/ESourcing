using AutoMapper;
using MediatR;
using ProductService.Domain.Constants;
using ProductService.Domain.Entites;
using ProductService.Domain.Repositories.ProductContextRepositories;

namespace ProductService.Application.CQRS.ProductContextCQRSs.CommandCreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            if (_productRepository.IsExistByName(request.Name)) return Task.FromResult(new CreateProductCommandResponse(ResponseConstants.CreatingProcessUnsuccessful));

            ProductEntity productEntity = _mapper.Map<ProductEntity>(request);
            _productRepository.InsertOne(productEntity);

            return Task.FromResult(new CreateProductCommandResponse(ResponseConstants.CreatingProcessSuccessful));
        }
    }
}
