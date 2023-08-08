using MediatR;

namespace SourcingService.Application.CQRS.AuctionContextCQRSs.QueryGetAuctions
{
    public class GetAuctionsQueryRequest : IRequest<GetAuctionsQueryResponse>
    {
    }
}
