using OrderService.Domain.Entities;

namespace OrderService.Domain.Repositories.OrderContextRepositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersBySellerUserName(string userName);
    }
}
