using Orders.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Data
{
    public interface IOrderRepository
    {
        Task<bool> SaveChanges();
        Task<OrderEntity> GetOrder(int id);
        void UpdateOrder(OrderEntity order);
        void CreateOrder(OrderEntity order);
        Task DeleteOrder(int id);
        Task<IEnumerable<OrderEntity>> GetAllOrders();
    }
}
