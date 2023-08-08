using MongoDB.Driver;
using SourcingService.Domain.Configurations;
using SourcingService.Domain.Entities;
using SourcingService.Domain.Repositories.AuctionContextRepositories;
using SourcingService.Infrastructure.Seeds;

namespace SourcingService.Infrastructure.Repositories.AuctionContextRepositories
{
    public class AuctionRepository : Repository<AuctionEntity>, IAuctionRepository
    {
        public AuctionRepository(DataBaseConfiguration configuration) : base(configuration)
        {
            AuctionSeedData.SeedAuctionData(_collection);
        }

        public AuctionEntity GetAuctionByName(string name)
        {
           return _collection.Find(x => x.Name == name).FirstOrDefault();
        }

        public bool IsExistByName(string name)
        {
            return _collection.Find(x => x.Name == name).Any();
        }
    }
}
