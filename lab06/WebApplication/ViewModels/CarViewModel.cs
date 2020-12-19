using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public int RegNum { get; set; }
        public string VINcode { get; set; }
        public int EngineNum { get; set; }
        public decimal Price { get; set; }
        public decimal RentalPrice { get; set; }
        public DateTime IssueDate { get; set; }
        public string Specs { get; set; }
        public DateTime TechnicalMaintenanceDate { get; set; }
        public bool SpecMark { get; set; }
        public bool ReturnMark { get; set; }
        public int EmployeeId { get; set; }
        public string Employee { get; set; }
        public int CarModelId { get; set; }
        public string CarModel { get; set; }
    }
}
