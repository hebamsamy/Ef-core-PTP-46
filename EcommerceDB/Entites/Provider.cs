using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceDB.Entites
{
    public class Provider
    {
        public int ID { get; set; }
        public string FullName { get; set; }
     
        public string UserName { get; set; }
        public string Email { get; set; }
        
        public virtual Shop Shop { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
