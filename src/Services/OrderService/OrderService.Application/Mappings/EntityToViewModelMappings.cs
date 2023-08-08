using AutoMapper;
using OrderService.Application.ViewModels.OrderContextViewModels;
using OrderService.Domain.Entities;

namespace OrderService.Application.Mappings
{
    public class EntityToViewModelMappings : Profile
    {
        public EntityToViewModelMappings() 
        {
            CreateMap<Order, OrderViewModel>();
        }
    }
}
