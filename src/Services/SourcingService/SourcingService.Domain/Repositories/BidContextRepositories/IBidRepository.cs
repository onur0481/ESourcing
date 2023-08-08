using SourcingService.Domain.Entities;

namespace SourcingService.Domain.Repositories.BidContextRepositories
{
    public interface IBidRepository : IRepository<BidEntity>
    {
        Task<List<BidEntity>> GetBidsAuctionId(string id);
        Task<BidEntity> GetWinnerBid(string id);
    }
}
