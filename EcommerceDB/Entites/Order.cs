using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceDB.Entites
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public int? Status { get; set; }
        public ICollection<OrderItem> Items { get; set; }

    }
}
