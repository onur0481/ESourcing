using MediatR;
using SourcingService.Domain.Constants;
using SourcingService.Domain.Entities;
using SourcingService.Domain.Repositories.AuctionContextRepositories;

namespace SourcingService.Application.CQRS.AuctionContextCQRSs.CommandDeleteAuction
{
    public class DeleteAuctionCommandHandler : IRequestHandler<DeleteAuctionCommandRequest, DeleteAuctionCommandResponse>
    {
        private readonly IAuctionRepository _auctionRepository;

        public DeleteAuctionCommandHandler(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

        public Task<DeleteAuctionCommandResponse> Handle(DeleteAuctionCommandRequest request, CancellationToken cancellationToken)
        {
            AuctionEntity auctionEntity = _auctionRepository.FindById(request.ID);
            if (auctionEntity == null) return Task.FromResult(new DeleteAuctionCommandResponse(ResponseConstants.DeletingProcessUnsuccessful));

            _auctionRepository.DeleteById(request.ID);

            return Task.FromResult(new DeleteAuctionCommandResponse(ResponseConstants.DeletingProcessSuccessful));
        }
    }
}
