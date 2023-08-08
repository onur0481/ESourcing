using AutoMapper;
using SourcingService.Application.ViewModels.AuctionContextViewModels;
using SourcingService.Application.ViewModels.BidContextViewModels;
using SourcingService.Domain.Entities;

namespace SourcingService.Application.Mappings
{
    public class EntityToViewModelMappings : Profile
    {
        public EntityToViewModelMappings()
        {
            CreateMap<AuctionEntity, AuctionViewModel>();
            CreateMap<BidEntity, BidViewModel>();
        }
    }
}
