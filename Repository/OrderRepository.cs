using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        private User326037777Context _ordersContext;
        public OrderRepository(User326037777Context ordersContext)
        {
            _ordersContext = ordersContext;
        }
        public async Task<Order> CreateOrder(Order order)
        {
            await _ordersContext.Orders.AddAsync(order);
            await _ordersContext.SaveChangesAsync();
            return order;
        }
    }
}
