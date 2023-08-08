using MongoDB.Driver;
using SourcingService.Domain.Entities;
using SourcingService.Domain.SeedWorks;

namespace SourcingService.Infrastructure.Seeds
{
    public static class AuctionSeedData
    {
        public static void SeedAuctionData<T>(IMongoCollection<T> collection) where T : BaseEntity 
        {
            bool existAuction = collection.Find(x => true).Any();

            if (!existAuction)
            {
                
                    collection.InsertManyAsync((IEnumerable<T>)GetConfigureAuctions());
                
                    
            }
        }
        private static ICollection<AuctionEntity> GetConfigureAuctions()
        {
            return new List<AuctionEntity>()
            {
                new AuctionEntity
                (
                    name: "Auction 1",
                    description: "Auction Desc 1",
                    productId: "64c26874f15103d2a4da51b2",
                    quantity: 5,
                    startedAt: DateTime.Now,
                    finishedAt: DateTime.Now.AddDays(10),
                    createdAt: DateTime.Now,
                    status: (int)Status.Active,
                    includeSellers: new List<string>
                    {
                        "seller1@test.com",
                        "seller2@test.com",
                        "seller3@test.com"
                    }
                ),

                new AuctionEntity
                (
                    name: "Auction 2",
                    description: "Auction Desc 2",
                    productId: "64c26874f15103d2a4da51b4",
                    quantity: 5,
                    startedAt: DateTime.Now,
                    finishedAt: DateTime.Now.AddDays(10),
                    createdAt: DateTime.Now,
                    status: (int)Status.Active,
                    includeSellers: new List<string>
                    {
                        "seller1@test.com",
                        "seller2@test.com",
                        "seller3@test.com"
                    }
                ),

                new AuctionEntity
                (
                    name: "Auction 3",
                    description: "Auction Desc 3",
                    productId: "64c26874f15103d2a4da51b5",
                    quantity: 5,
                    startedAt: DateTime.Now,
                    finishedAt: DateTime.Now.AddDays(10),
                    createdAt: DateTime.Now,
                    status: (int)Status.Active,
                    includeSellers: new List<string>
                    {
                        "seller1@test.com",
                        "seller2@test.com",
                        "seller3@test.com"
                    }
                ),


            };
        }
    }
}
