using AutoMapper;
using MediatR;
using ProductService.Application.ViewModels.ProductContextViewModels;
using ProductService.Domain.Constants;
using ProductService.Domain.Entites;
using ProductService.Domain.Models.ConstantModels;
using ProductService.Domain.Repositories.ProductContextRepositories;

namespace ProductService.Application.CQRS.ProductContextCQRSs.QueryGetByIDProduct
{
    public class GetByIDProductQueryHandler : IRequestHandler<GetByIDProductQueryRequest, GetByIDProductQueryResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetByIDProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public Task<GetByIDProductQueryResponse> Handle(GetByIDProductQueryRequest request, CancellationToken cancellationToken)
        {
            ProductEntity productEntity = _productRepository.FindById(request.ID);
            if (productEntity == null) return Task.FromResult(new GetByIDProductQueryResponse(ResponseConstants.ProductNotAvailable));

            ProductViewModel productViewModel = _mapper.Map<ProductViewModel>(productEntity);

            return Task.FromResult(new GetByIDProductQueryResponse(productViewModel));
        }
    }
}
