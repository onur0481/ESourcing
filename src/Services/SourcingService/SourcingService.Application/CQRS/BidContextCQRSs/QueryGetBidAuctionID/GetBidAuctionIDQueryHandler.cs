using AutoMapper;
using MediatR;
using SourcingService.Application.CQRS.AuctionContextCQRSs.QueryGetAuctions;
using SourcingService.Application.ViewModels.BidContextViewModels;
using SourcingService.Domain.Constants;
using SourcingService.Domain.Entities;
using SourcingService.Domain.Repositories.BidContextRepositories;

namespace SourcingService.Application.CQRS.BidContextCQRSs.QueryGetBidAuctionID
{
    public class GetBidAuctionIDQueryHandler : IRequestHandler<GetBidAuctionIDQueryRequest, GetBidAuctionIDQueryResponse>
    {
        private readonly IBidRepository _bidRepository;
        private readonly IMapper _mapper;

        public GetBidAuctionIDQueryHandler(IBidRepository bidRepository, IMapper mapper)
        {
            _bidRepository = bidRepository;
            _mapper = mapper;
        }

        public async Task<GetBidAuctionIDQueryResponse> Handle(GetBidAuctionIDQueryRequest request, CancellationToken cancellationToken)
        {
            List<BidEntity> bidEntites = await _bidRepository.GetBidsAuctionId(request.AuctionID);

            if (bidEntites.Count == 0) return await Task.FromResult(new GetBidAuctionIDQueryResponse(ResponseConstants.BidNotAvailable));

            List<BidViewModel> bidViewModels = _mapper.Map<List<BidViewModel>>(bidEntites);

            return await Task.FromResult(new GetBidAuctionIDQueryResponse(bidViewModels));
        }
    }
}
