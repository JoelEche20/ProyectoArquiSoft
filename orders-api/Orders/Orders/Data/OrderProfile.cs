using Orders.Data.Entity;
using Orders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Orders.Data
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            this.CreateMap<OrderEntity, Order>()
                .ReverseMap();
        }
    }
}
