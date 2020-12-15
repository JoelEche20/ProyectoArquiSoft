using AutoMapper;
using Orders.Data;
using Orders.Data.Entity;
using Orders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            var orderEntity = _mapper.Map<OrderEntity>(order);
            _orderRepository.CreateOrder(orderEntity);
            if (await _orderRepository.SaveChanges())
            {
                return _mapper.Map<Order>(orderEntity);
            }
            throw new Exception("there where and error with the DB");
        }

        public async Task<bool> DeleteOrder(int id)
        {
            await _orderRepository.DeleteOrder(id);
            if (await _orderRepository.SaveChanges())
                return true;

            return false;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            var ordersEntity = await _orderRepository.GetAllOrders();
            return _mapper.Map<IEnumerable<Order>>(ordersEntity);
        }

        public async Task<Order> GetOrder(int id)
        {
            var orderEntity = await _orderRepository.GetOrder(id);
            if (orderEntity == null)
                throw new Exception("there where and error with the DB");
            return _mapper.Map<Order>(orderEntity);
        }

        public async Task<Order> UpdateOrder(int id, Order order)
        {
            var validate = await _orderRepository.GetOrder(id);
            if (validate == null)
                throw new Exception();
            order.Id = id;
            var orderEntity = _mapper.Map<OrderEntity>(order);
            _orderRepository.UpdateOrder(orderEntity);
            if (await _orderRepository.SaveChanges())
            {
                return _mapper.Map<Order>(orderEntity);
            }
            throw new Exception("there were an error with DB");
        }
    }
}
