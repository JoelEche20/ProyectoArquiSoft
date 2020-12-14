using Orders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> GetOrder(int id);
        Task<Order> UpdateOrder(int id, Order Order);
        Task<Order> CreateOrder(Order order);
        Task<bool> DeleteOrder(int id);
    }
}
