using AutoMapper;
using EventBus.Events.OrderServiceEvents;
using SourcingService.Application.CQRS.AuctionContextCQRSs.CommandCreateAuction;
using SourcingService.Application.CQRS.AuctionContextCQRSs.CommandUpdateAuction;
using SourcingService.Application.CQRS.BidContextCQRSs.CommandCreateBid;
using SourcingService.Domain.Entities;

namespace SourcingService.Application.Mappings
{
    public class CommandRequestToEntityMappings : Profile
    {
        public CommandRequestToEntityMappings()
        {
            #region Auction Mappings
            CreateMap<CreateAuctionCommandRequest, AuctionEntity>();
            CreateMap<UpdateAuctionCommandRequest, AuctionEntity>();
            #endregion

            #region Bid Mappings
            CreateMap<CreateBidCommandRequest, BidEntity>(); 
            #endregion

            CreateMap<OrderCreateEvent,BidEntity>().ReverseMap();
        }
    }
}
