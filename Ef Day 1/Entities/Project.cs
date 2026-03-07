using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ef_Day_1.Entities
{
    [Table("Projects", Schema ="Prodaction")]
    public class Project
    {
        [Key]
        public int Id { get; set; }
      
        [StringLength(10 ,MinimumLength =3)]
        [Required]
        public string Name { get; set; }
        [StringLength(10, MinimumLength = 3)]
        public string Address { get; set; }

        public int DeptID { get; set; }
        [ForeignKey(nameof(DeptID))]
        public Department Department { get; set; }
        //public ICollection<WorksOn> WorksOns { get; set; }

    }
}
