using AutoMapper;
using ProductService.Application.ViewModels.ProductContextViewModels;
using ProductService.Domain.Entites;

namespace ProductService.Application.Mappings
{
    public class EntityToViewModelMappings : Profile
    {
        public EntityToViewModelMappings()
        {
            CreateMap<ProductEntity, ProductViewModel>();
        }
    }
}
