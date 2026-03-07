using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ef_Day_1.Entities
{
    [Index(nameof(Email),IsUnique = true)]
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; }
        [StringLength(11, MinimumLength = 10)]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public DateTime HireDate { get; set; }

        [Column(TypeName = "money")]
        public decimal Salary { get; set; }

        public int DeptID { get; set; }


        //// Navigation Properties

        [ForeignKey(nameof(DeptID))]
        public Department Department { get; set; }

        //public ICollection<WorksOn> WorksOns { get; set; }

    }
}
