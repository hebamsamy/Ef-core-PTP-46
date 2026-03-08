using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceDB.Entites
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }


        ///Relation
        public int ProviderID { get; set; }
        public Provider Provider { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public ICollection<OrderItem> Items { get; set; }


    }
}
