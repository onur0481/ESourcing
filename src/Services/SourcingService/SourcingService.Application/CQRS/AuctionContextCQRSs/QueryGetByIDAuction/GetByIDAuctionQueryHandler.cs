using AutoMapper;
using MediatR;
using SourcingService.Application.ViewModels.AuctionContextViewModels;
using SourcingService.Domain.Constants;
using SourcingService.Domain.Entities;
using SourcingService.Domain.Repositories.AuctionContextRepositories;

namespace SourcingService.Application.CQRS.AuctionContextCQRSs.QueryGetByIDAuction
{
    public class GetByIDAuctionQueryHandler : IRequestHandler<GetByIDAuctionQueryRequest, GetByIDAuctionQueryResponse>
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IMapper _mapper;

        public GetByIDAuctionQueryHandler(IAuctionRepository auctionRepository, IMapper mapper)
        {
            _auctionRepository = auctionRepository;
            _mapper = mapper;
        }

        public Task<GetByIDAuctionQueryResponse> Handle(GetByIDAuctionQueryRequest request, CancellationToken cancellationToken)
        {
            AuctionEntity auctionEntity = _auctionRepository.FindById(request.ID);
            if (auctionEntity == null) return Task.FromResult(new GetByIDAuctionQueryResponse(ResponseConstants.AuctionNotAvailable));

            AuctionViewModel auctionViewModel = _mapper.Map<AuctionViewModel>(auctionEntity);

            return Task.FromResult(new GetByIDAuctionQueryResponse(auctionViewModel));
        }
    }
}
