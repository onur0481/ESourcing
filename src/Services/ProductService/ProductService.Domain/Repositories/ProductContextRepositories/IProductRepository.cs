using ProductService.Domain.Entites;

namespace ProductService.Domain.Repositories.ProductContextRepositories
{
    public interface IProductRepository : IRepository<ProductEntity>
    {
        bool IsExistByName(string name);
        
    }
}
