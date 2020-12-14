using Microsoft.EntityFrameworkCore;
using Orders.Data.Entity;
using Orders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private OrderDbContext _orderDbContext;
        private List<Order> _orders = new List<Order>();

        public OrderRepository(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public void CreateOrder(OrderEntity order)
        {
            _orderDbContext.Orders.Add(order);
        }

        public async Task DeleteOrder(int id)
        {
            var orderToDelete = await _orderDbContext.Orders.SingleAsync(a => a.Id == id);
            _orderDbContext.Orders.Remove(orderToDelete);
        }

        public async Task<IEnumerable<OrderEntity>> GetAllOrders()
        {
            IEnumerable<OrderEntity> orders = _orderDbContext.Orders;
            return orders;
        }

        public async Task<OrderEntity> GetOrder(int id)
        {
            IQueryable<OrderEntity> query = _orderDbContext.Orders;
            query = query.AsNoTracking();
            return await query.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _orderDbContext.SaveChangesAsync()) > 0;
        }

        public void UpdateOrder(OrderEntity order)
        {
            _orderDbContext.Orders.Update(order);
        }
    }
}
