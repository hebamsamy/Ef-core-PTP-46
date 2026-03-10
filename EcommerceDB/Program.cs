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




    #region DML with DBCONTEXT
    //var data = dbContext.Products.Where(p=> p.Name.Contains("t"));

    //var re = data.ToList();
    //re[0].Price = 100;


    //Console.WriteLine($" re[0]: {dbContext.Entry(re[0]).State}"); 
    //Console.WriteLine($" re[1]: {dbContext.Entry(re[1]).State}"); 
    //Console.WriteLine($" re[2]: {dbContext.Entry(re[2]).State}");


    //var p = new Product { Name = "hh", Description = "oo", CategoryID = 1, Price = 90, ProviderID = 1 };
    //dbContext.Products.Add(p);

    //Console.WriteLine($" p: {dbContext.Entry(p).State}");


    //dbContext.Entry(re[1]).State = EntityState.Deleted;
    //re.Remove(re[0]); 
    #endregion

    ///////////////////
    ///

    #region NO Track
    //Read only list
    //var data = dbContext.Products.AsNoTracking()
    //    .Where(p => p.Name.Contains("t"));

    //var re = data.ToList();

    //foreach (var product in re)
    //{
    //    Console.WriteLine($"{product.Name} ");
    //} 
    #endregion


    #region Query  Fillter
    ////var query = dbContext.Products.Where(p=>p.Name.Contains("t"));
    //var query = dbContext.Products
    //    .IgnoreQueryFilters().Where(p=>p.ProviderID == 1);

    ////dbContext.Remove(query.First());
    ////query[0].

    //foreach (var product in query)
    //{
    //    Console.WriteLine(product.Name);
    //}

    //int row = dbContext.SaveChanges();
    //Console.WriteLine($"Accefted Rows {row}");

    #endregion




    string column = "Price";
    string value = "100";
    int id = 1;
    var query = dbContext.Products
        .FromSqlRaw($"Select * from [Sales].[Product] where {column} = {value}")
        .Where(p => p.Name.Contains("t"));


    var Quary = dbContext.Products.FromSqlRaw($"exec SP_GetProductByProviderID {id}").AsEnumerable();

    Console.WriteLine(Quary.ToList().Count);



    



}

