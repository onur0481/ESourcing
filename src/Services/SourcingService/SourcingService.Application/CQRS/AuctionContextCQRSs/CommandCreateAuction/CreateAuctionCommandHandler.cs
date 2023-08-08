using AutoMapper;
using MediatR;
using SourcingService.Domain.Constants;
using SourcingService.Domain.Entities;
using SourcingService.Domain.Repositories.AuctionContextRepositories;

namespace SourcingService.Application.CQRS.AuctionContextCQRSs.CommandCreateAuction
{
    public class CreateAuctionCommandHandler : IRequestHandler<CreateAuctionCommandRequest, CreateAuctionCommandResponse>
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IMapper _mapper;

        public CreateAuctionCommandHandler(IAuctionRepository auctionRepository, IMapper mapper)
        {
            _auctionRepository = auctionRepository;
            _mapper = mapper;
        }

        public Task<CreateAuctionCommandResponse> Handle(CreateAuctionCommandRequest request, CancellationToken cancellationToken)
        {
            if(_auctionRepository.IsExistByName(request.Name)) return Task.FromResult(new CreateAuctionCommandResponse(ResponseConstants.CreatingProcessUnsuccessful));

            AuctionEntity auctionEntity = _mapper.Map<AuctionEntity>(request);
            _auctionRepository.InsertOne(auctionEntity);

            return Task.FromResult(new CreateAuctionCommandResponse(ResponseConstants.CreatingProcessSuccessful));

        }
    }
}
