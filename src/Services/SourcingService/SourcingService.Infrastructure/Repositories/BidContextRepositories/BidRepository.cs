using MongoDB.Driver;
using SourcingService.Domain.Configurations;
using SourcingService.Domain.Entities;
using SourcingService.Domain.Repositories.BidContextRepositories;

namespace SourcingService.Infrastructure.Repositories.BidContextRepositories
{
    public class BidRepository : Repository<BidEntity>, IBidRepository
    {
        public BidRepository(DataBaseConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<BidEntity>> GetBidsAuctionId(string id)
        {
            FilterDefinition<BidEntity> filter = Builders<BidEntity>.Filter.Eq(x => x.AuctionId, id);

            List<BidEntity> bids = await _collection.Find(filter).ToListAsync();

            bids = bids.OrderByDescending(x => x.CreatedAt)
                       .GroupBy(x => x.SellerUserName)
                       .Select(x => new BidEntity(
                           auctionId: x.FirstOrDefault()?.AuctionId!,
                           productId: x.FirstOrDefault()?.ProductId!,
                           sellerUserName: x.FirstOrDefault()?.SellerUserName!,
                           price: (decimal)(x.FirstOrDefault()?.Price)!,
                           createdAt: (DateTime)(x.FirstOrDefault()?.CreatedAt)!

                           ))
                       .ToList();

            return bids;
        }

        public async Task<BidEntity> GetWinnerBid(string id)
        {
            List<BidEntity> bids = await GetBidsAuctionId(id);

            return bids.OrderByDescending(x => x.Price).FirstOrDefault()! ;
        }
    }
}
