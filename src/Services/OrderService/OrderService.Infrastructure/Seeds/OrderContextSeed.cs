using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.Domain.Entities;
using OrderService.Infrastructure.Context;

namespace OrderService.Infrastructure.Seeds
{
    public class OrderContextSeed : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(
                
                new Order(Guid.NewGuid().ToString(), "test@test.com", Guid.NewGuid().ToString(), 10, 1000)
                {
                    ID = 1
                },

                new Order(Guid.NewGuid().ToString(), "test@test.com", Guid.NewGuid().ToString(), 10, 1000)
                {
                    ID = 2
                },

                new Order(Guid.NewGuid().ToString(), "test@test.com", Guid.NewGuid().ToString(), 10, 1000)
                {
                    ID = 3
                }
                );
        }
    }
}
