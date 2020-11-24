using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5_WebApp.ViewModels.Filters
{
    public class EmployeesFilterViewModel
    {
        [Display(Name = "Post")]
        public string EmployeePost { get; set; } = null!;
        [Display(Name = "Name")]
        public string EmployeeName { get; set; } = null!;
        [Display(Name = "Surname")]
        public string EmployeeSurname { get; set; } = null!;
        [Display(Name = "Patronymic")] 
        public string EmployeePatronymic { get; set; } = null!;
        public DateTime EmployeeEmploymentDate { get; set; } = default!;

    }
}
