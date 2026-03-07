using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Ef_Day_1.Entities;

namespace Ef_Day_1.Context
{
    public class CompanyDBContest : DbContext
    {

        //tables
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        //public DbSet<WorksOn> WorksOns { get; set; }




        //DI
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder
                .UseSqlServer(@"Data Source=.;Initial Catalog=PTPCompanyDB;Integrated Security=True;TrustServerCertificate=True;");
            base.OnConfiguring(builder);
        }

        
    }
}
