using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;

namespace Lab3WebApp.Models
{
    public partial class Car
    {
        public Car()
        {

        }

        public int CarId { get; set; }
        public int? CarModelId { get; set; }
        public int? RegNum { get; set; }
        public string Vincode { get; set; }
        public int? EngineNum { get; set; }
        public decimal? Price { get; set; }
        public decimal? RentalPrice { get; set; }
        public DateTime? IssueDate { get; set; }
        public string Specs { get; set; }
        public DateTime? TechnicalMaintenanceDate { get; set; }
        public bool? SpecMark { get; set; }
        public bool? ReturnMark { get; set; }
        public int? EmployeeId { get; set; }

        public virtual CarModel CarModel { get; set; }
        public virtual Employee Employee { get; set; }
        public override string ToString()
        {
            return $"VIN-код: {Vincode}, Цена: {Price.ToString()},Стоимость аренды {RentalPrice.ToString()}";
        }
    }
}
