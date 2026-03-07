using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ef_Day_1.Entities
{

    public class Department
    {
        public int ID { get; set; }
        public required string Name { get; set; }
        public string Address { get; set; }

        //[InverseProperty("Department")]
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Project> Projects { get; set; }

    }
}
