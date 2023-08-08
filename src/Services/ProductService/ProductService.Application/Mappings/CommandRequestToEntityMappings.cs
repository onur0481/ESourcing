using AutoMapper;
using ProductService.Application.CQRS.ProductContextCQRSs.CommandCreateProduct;
using ProductService.Application.CQRS.ProductContextCQRSs.CommandUpdateProduct;
using ProductService.Domain.Entites;

namespace ProductService.Application.Mappings
{
    public class CommandRequestToEntityMappings : Profile
    {
        public CommandRequestToEntityMappings()
        {
           CreateMap<CreateProductCommandRequest, ProductEntity>();
           CreateMap<UpdateProductCommandRequest, ProductEntity>();
        }
    }
}
