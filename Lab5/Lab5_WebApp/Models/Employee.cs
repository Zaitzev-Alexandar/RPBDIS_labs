﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lab5_WebApp.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Post { get; set; }
        [Display(Name = "EmployeeName")]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime EmploymentDate { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public Employee()
        {
            Cars = new List<Car>();
        }
    }
}
