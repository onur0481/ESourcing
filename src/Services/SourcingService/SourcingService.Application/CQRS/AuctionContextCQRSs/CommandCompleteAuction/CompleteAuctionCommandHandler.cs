using AutoMapper;
using EventBus.Events.OrderServiceEvents;
using MassTransit;
using MediatR;
using SourcingService.Application.CQRS.AuctionContextCQRSs.QueryGetByIDAuction;
using SourcingService.Application.CQRS.BidContextCQRSs.QueryGetWinnerBid;
using SourcingService.Application.ViewModels.AuctionContextViewModels;
using SourcingService.Application.ViewModels.BidContextViewModels;
using SourcingService.Domain.Constants;
using SourcingService.Domain.Entities;
using SourcingService.Domain.Repositories.AuctionContextRepositories;
using SourcingService.Domain.Repositories.BidContextRepositories;

namespace SourcingService.Application.CQRS.AuctionContextCQRSs.CommandCompleteAuction
{
    public class CompleteAuctionCommandHandler : IRequestHandler<CompleteAuctionCommandRequest, CompleteAuctionCommandResponse>
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IBidRepository _bidRepository;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _eventBus;

        public CompleteAuctionCommandHandler(IAuctionRepository auctionRepository, IMapper mapper, IPublishEndpoint eventBus, IBidRepository bidRepository)
        {
            _auctionRepository = auctionRepository;
            _mapper = mapper;
            _eventBus = eventBus;
            _bidRepository = bidRepository;
        }

        public async Task<CompleteAuctionCommandResponse> Handle(CompleteAuctionCommandRequest request, CancellationToken cancellationToken)
        {
            AuctionEntity auctionEntity = _auctionRepository.FindById(request.ID);
            if (auctionEntity == null) return await Task.FromResult(new CompleteAuctionCommandResponse(ResponseConstants.AuctionNotAvailable));

            if(auctionEntity.Status !=(int)Status.Active) return await Task.FromResult(new CompleteAuctionCommandResponse(ResponseConstants.NotCompleted));


            BidEntity bidEntity = await _bidRepository.GetWinnerBid(request.ID);
            if (bidEntity == null) return await Task.FromResult(new CompleteAuctionCommandResponse(ResponseConstants.BidNotAvailable));

            auctionEntity.Status = (int)Status.Closed;
            _auctionRepository.ReplaceOne(auctionEntity);

            await  _eventBus.Publish(new OrderCreateEvent(bidEntity.AuctionId, bidEntity.ProductId, bidEntity.SellerUserName, bidEntity.Price, auctionEntity.Quantity), cancellationToken);

            return await Task.FromResult(new CompleteAuctionCommandResponse(ResponseConstants.AuctionCompletedProcessSuccessful));

        }
    }
}
