using Microsoft.EntityFrameworkCore;
using OrderService.Domain.Entities;
using OrderService.Domain.Repositories.OrderContextRepositories;
using OrderService.Infrastructure.Context;

namespace OrderService.Infrastructure.Repositories.OrderRepositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(OrderDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Order>> GetOrdersBySellerUserName(string userName)
        {
            return await _context.Orders.Where(x => x.SellerUserName == userName).ToListAsync();
        }
    }
}
