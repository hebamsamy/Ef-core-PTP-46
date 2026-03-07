using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ef_Day_1.Entities
{
    public class WorksOn
    {
        [Key]
        public int Id { get; set; }

        public decimal HoursPerWeek { get; set; }

        public int EmployeeID { get; set; }
        [ForeignKey(nameof(EmployeeID))]
        public Employee Employee { get; set; }


        public int ProjectID { get; set; }
        [ForeignKey(nameof(ProjectID))]
        public Project Project { get; set; }
    }
}
