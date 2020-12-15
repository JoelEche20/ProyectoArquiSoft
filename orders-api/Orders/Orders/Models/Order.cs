using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Models
{
    public class Order
    {
        public int Id { get; set; }
        public long Price { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string IdUser { get; set; }
        public string IdBook { get; set; }
    }
}
