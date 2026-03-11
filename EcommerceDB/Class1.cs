using EcommerceDB.Context;
using EcommerceDB.Entites;
using EcommerceDB.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceDB
{
    public  class Class1
    {

        public record PrductPrice(decimal Price, string Name, int Id)
        {
            public override string ToString()
            {
                return $"{Name}";
            }
        }
    


    //public class Amr(int Age, string Name)
    //{
    //    public override string ToString()
    //    {
    //        return base.ToString();
    //    }
    //}

    public record FullName(string Fname, string LName);
        public IQueryable<Product> GetAll( 
            string? name = null, decimal price = 1, 
            string sort = "Id", int pageSize = 2, int paganumber = 1)
        {

            EcommerceDBContext dBContext = new EcommerceDBContext();
            var Query = dBContext.Products.AsQueryable();

            if(!string.IsNullOrEmpty(name))
            {
                Query = Query.Where(x => x.Name.Contains(name));
            }
            if (price>1)
            {
                Query = Query.Where(x => x.Price >= price);
            }


            Query =  Query.OrderBy(sort);

            //page 2 size 2
            //34  

            return Query.Skip((paganumber-1)* pageSize).Take(pageSize);

        }
    }
}
