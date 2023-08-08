using AutoMapper;
using MediatR;
using ProductService.Application.ViewModels.ProductContextViewModels;
using ProductService.Domain.Entites;
using ProductService.Domain.Repositories.ProductContextRepositories;

namespace ProductService.Application.CQRS.ProductContextCQRSs.QueryGetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQueryRequest, GetProductsQueryResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public Task<GetProductsQueryResponse> Handle(GetProductsQueryRequest request, CancellationToken cancellationToken)
        {
            ICollection<ProductEntity> productEntities = _productRepository.AsQueryable().ToList();

            List<ProductViewModel> products = _mapper.Map<List<ProductViewModel>>(productEntities);

            return Task.FromResult(new GetProductsQueryResponse(products));
        }
    }
}
