using AutoMapper;
using MediatR;
using SourcingService.Domain.Constants;
using SourcingService.Domain.Entities;
using SourcingService.Domain.Repositories.BidContextRepositories;

namespace SourcingService.Application.CQRS.BidContextCQRSs.CommandCreateBid
{
    public class CreateBidCommandHandler : IRequestHandler<CreateBidCommandRequest, CreateBidCommandResponse>
    {
        private readonly IBidRepository _bidRepository;
        private readonly IMapper _mapper;

        public CreateBidCommandHandler(IBidRepository bidRepository, IMapper mapper)
        {
            _bidRepository = bidRepository;
            _mapper = mapper;
        }

        public Task<CreateBidCommandResponse> Handle(CreateBidCommandRequest request, CancellationToken cancellationToken)
        {
            BidEntity bidEntity = _mapper.Map<BidEntity>(request);

            _bidRepository.InsertOne(bidEntity);

            return Task.FromResult(new CreateBidCommandResponse(ResponseConstants.CreatingProcessSuccessful));
        }
    }
}
