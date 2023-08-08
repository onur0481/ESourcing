using AutoMapper;
using MediatR;
using SourcingService.Domain.Constants;
using SourcingService.Domain.Entities;
using SourcingService.Domain.Repositories.AuctionContextRepositories;

namespace SourcingService.Application.CQRS.AuctionContextCQRSs.CommandUpdateAuction
{
    public class UpdateAuctionCommandHandler : IRequestHandler<UpdateAuctionCommandRequest, UpdateAuctionCommandResponse>
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IMapper _mapper;

        public UpdateAuctionCommandHandler(IAuctionRepository auctionRepository, IMapper mapper)
        {
            _auctionRepository = auctionRepository;
            _mapper = mapper;
        }

        public Task<UpdateAuctionCommandResponse> Handle(UpdateAuctionCommandRequest request, CancellationToken cancellationToken)
        {
            AuctionEntity auctionEntity = _auctionRepository.FindById(request.ID);
            if (auctionEntity == null) return Task.FromResult(new UpdateAuctionCommandResponse(ResponseConstants.UpdatingProcessUnsuccessful));

            bool isExist = auctionEntity.Name.Equals(request.Name) && _auctionRepository.IsExistByName(request.Name);
            if (isExist) return Task.FromResult(new UpdateAuctionCommandResponse(ResponseConstants.UpdatingProcessExistAuctionWithSameName));

            _mapper.Map(request, auctionEntity);
            _auctionRepository.ReplaceOne(auctionEntity);

            return Task.FromResult(new UpdateAuctionCommandResponse(ResponseConstants.UpdatingProcessSuccessful));
        }
    }
}
