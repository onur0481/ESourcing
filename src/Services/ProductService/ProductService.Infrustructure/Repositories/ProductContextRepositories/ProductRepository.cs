using MongoDB.Driver;
using ProductService.Domain.Configurations;
using ProductService.Domain.Entites;
using ProductService.Domain.Repositories.ProductContextRepositories;

namespace ProductService.Infrustructure.Repositories.ProductContextRepositories
{
    public class ProductRepository : Repository<ProductEntity>, IProductRepository
    {
        public ProductRepository(DataBaseConfiguration configuration) : base(configuration)
        {
        }

        public bool IsExistByName(string name)
        {
            return _collection.Find(x => x.Name == name).Any();
        }
    }
}
 