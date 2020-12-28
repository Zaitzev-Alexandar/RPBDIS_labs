using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lab7.Models
{
    public class Car
    {
        [Key]
        [Display(Name = "Car id")]
        public int CarId { get; set; }
        [Display(Name = "Car RegNum")]
        public int RegNum { get; set; }
        [Display(Name = "Car VINcode")]
        public string VINcode { get; set; }
        [Display(Name = "Car EngineNum")]
        public int EngineNum { get; set; }
        [Column(TypeName = "money")]
        [Display(Name = "Car Price")]
        public decimal Price { get; set; }
        [Column(TypeName = "money")]
        [Display(Name = "Car RentalPrice")]
        public decimal RentalPrice { get; set; }
        [Display(Name = "Car IssueDate")]
        public DateTime IssueDate { get; set; }
        [Display(Name = "Car Specs")]
        public string Specs { get; set; }
        [Display(Name = "Car TechnicalMaintenanceDate")]
        public DateTime TechnicalMaintenanceDate { get; set; }
        [Display(Name = "Car SpecMark")]
        public bool SpecMark { get; set; }
        [Display(Name = "Car ReturnMark")]
        public bool ReturnMark { get; set; }
        [Display(Name = "Employee Id")]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [Display(Name = "Car model Id")]
        [ForeignKey("CarModel")]
        public int CarModelId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual CarModel CarModel { get; set; }

    }
}
