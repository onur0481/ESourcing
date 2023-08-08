using AutoMapper;
using MediatR;
using SourcingService.Application.CQRS.BidContextCQRSs.QueryGetBidAuctionID;
using SourcingService.Application.ViewModels.BidContextViewModels;
using SourcingService.Domain.Constants;
using SourcingService.Domain.Entities;
using SourcingService.Domain.Repositories.BidContextRepositories;

namespace SourcingService.Application.CQRS.BidContextCQRSs.QueryGetWinnerBid
{
    public class GetWinnerBidQueryHandler : IRequestHandler<GetWinnerBidQueryRequest, GetWinnerBidQueryResponse>
    {
        private readonly IBidRepository _bidRepository;
        private readonly IMapper _mapper;

        public GetWinnerBidQueryHandler(IBidRepository bidRepository, IMapper mapper)
        {
            _bidRepository = bidRepository;
            _mapper = mapper;
        }

        public async Task<GetWinnerBidQueryResponse> Handle(GetWinnerBidQueryRequest request, CancellationToken cancellationToken)
        {
            BidEntity bidEntity = await _bidRepository.GetWinnerBid(request.AuctionID);

            if (bidEntity == null) return await Task.FromResult(new GetWinnerBidQueryResponse(ResponseConstants.BidNotAvailable));

            BidViewModel bidViewModel = _mapper.Map<BidViewModel>(bidEntity);

            return await Task.FromResult(new GetWinnerBidQueryResponse(bidViewModel));
        }
    }
}
