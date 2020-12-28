using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace lab7.Models
{
    public class Employee
    {
        [Key]
        [Display(Name = "Employee id")]
        public int EmployeeId { get; set; }
        [Display(Name = "Employee post")]
        public string Post { get; set; }
        [Display(Name = "Employee name")]
        public string Name { get; set; }
        [Display(Name = "Employee surname")]
        public string Surname { get; set; }
        [Display(Name = "Employee patronymic")]
        public string Patronymic { get; set; }
        [Display(Name = "Employee employment date")]
        public DateTime EmploymentDate { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
