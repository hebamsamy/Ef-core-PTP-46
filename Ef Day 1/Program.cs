using Ef_Day_1.Context;
using Ef_Day_1.Entities;

Console.WriteLine("Hello, World!");


CompanyDBContest dBContest  = new CompanyDBContest();

dBContest.Database.EnsureCreated();


dBContest.Departments.Add(new Department()
{
    Name = "IT",
    Address = "Cairo"
});

dBContest.SaveChanges();

