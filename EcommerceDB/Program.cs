// See https://aka.ms/new-console-template for more information
using EcommerceDB.Context;
using EcommerceDB.Entites;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

//insert

//EcommerceDBContext dBContext = null;
//try
//{
//    dBContext = new EcommerceDBContext();
//}
//finally
//{
//    //release unmanaged resources
//    dBContext.Dispose();
//}


using (EcommerceDBContext dbContext = new EcommerceDBContext())
{
    //var data2 = new Category { Name = "Cars", Description = "Cars" };
    //var data1 = new Category { Name = "furnature", Description = "furnature" };
    //dbContext.Categories.AddRange(data1,data1);


    //var data = new Provider
    //{
    //    FullName = "AhmedAli",
    //    UserName = "AhmedAli",
    //    Email = "AhmedAli@gamil.com",
    //    Shop = new Shop
    //    {
    //        Image = "elraya.png",
    //        Logo = "elraya.png",
    //        Name = "Alraya"
    //    },


    //};

    //dbContext.Providers.Add(data);



    //Get all Cat name like "%o%"


    //fluent 
    //var query = dbContext.Categories.Where(c => c.Name.Contains("o"));

    //query.First().Description = "test";


    //var datta  = query.ToList();

    //foreach(var  item in query)
    //{
    //    Console.WriteLine($"Category name : {item.Name}");
    //}

    //dbContext.Add(new Category { Name = "ooooooooo", Description = "ooooooooooo" });

    //foreach (var item in query)
    //{
    //    Console.WriteLine($"Category name : {item.Name}");
    //}



    //Query syntex == Sql Statments

    //var query = from cat in dbContext.Categories
    //            where cat.Name.Contains("o")
    //            orderby cat.Name
    //            select cat;

    //foreach (var item in query)
    //{
    //Console.WriteLine($"Category name : {item.Name} number of products {item.Products.Count}");
    //}
    //dbContext.SaveChanges();





    //var query = from cat in dbContext.Categories.Include(c=>c.Products)
    //            where cat.Name.Contains("o")
    //            orderby cat.Name
    //            select cat;

    //foreach (var item in query)
    //{
    //    Console.WriteLine($"Category name : {item.Name} number of products {item.Products.Count}");
    //}

    //var query = from cat in dbContext.Categories
    //            where cat.Name.Contains("o")
    //            orderby cat.Name
    //            select new {
    //                c = cat, 
    //                p = cat.Products};

    //var query = dbContext.Categories.Select(c => new { c, p = c.Products.Select(p=> p) });
    //var query2 = dbContext.Categories.Include(c=>c.Products);


    //foreach (var item in query)
    //{



    //    Console.WriteLine($"Category name : {item.c.Name} ");

    //    foreach (var item1 in item.p)
    //    {
    //        Console.WriteLine($"Product Name {item1.Name}");
    //    }
    //}




    var data = dbContext.Products;
    foreach( var product in data)
    {
        Console.WriteLine($"{product.Name } : {product.Provider.FullName} : {product.Category.Name}");
    }


}






