using SourcingService.Domain.Entities;

namespace SourcingService.Domain.Repositories.AuctionContextRepositories
{
    public interface IAuctionRepository : IRepository<AuctionEntity>
    {
        AuctionEntity GetAuctionByName(string name);
        bool IsExistByName(string name);
    }
}
