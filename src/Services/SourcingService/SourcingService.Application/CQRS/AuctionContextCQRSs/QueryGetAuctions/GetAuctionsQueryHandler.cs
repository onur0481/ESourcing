using AutoMapper;
using MediatR;
using SourcingService.Application.ViewModels.AuctionContextViewModels;
using SourcingService.Domain.Constants;
using SourcingService.Domain.Entities;
using SourcingService.Domain.Repositories.AuctionContextRepositories;

namespace SourcingService.Application.CQRS.AuctionContextCQRSs.QueryGetAuctions
{
    public class GetAuctionsQueryHandler : IRequestHandler<GetAuctionsQueryRequest, GetAuctionsQueryResponse>
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IMapper _mapper;

        public GetAuctionsQueryHandler(IAuctionRepository auctionRepository, IMapper mapper)
        {
            _auctionRepository = auctionRepository;
            _mapper = mapper;
        }

        public Task<GetAuctionsQueryResponse> Handle(GetAuctionsQueryRequest request, CancellationToken cancellationToken)
        {
            List<AuctionEntity> auctionEntities = _auctionRepository.AsQueryable().ToList();
            if (auctionEntities.Count == 0) return Task.FromResult(new GetAuctionsQueryResponse(ResponseConstants.AuctionNotAvailable));

            List<AuctionViewModel> auctionViewModels = _mapper.Map<List<AuctionViewModel>>(auctionEntities);
            return Task.FromResult(new GetAuctionsQueryResponse(auctionViewModels));
        }
    }
}
