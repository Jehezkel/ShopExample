using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using Shop.Api.DAL;
using Shop.Api.Models;

namespace Shop.Api.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Product> GetProduct([ScopedService] AppDbContext context)
        {
            return context.Products;
        }
        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Order> GetOrders([ScopedService] AppDbContext context)
        {
            return context.Orders;
        }

    }
}