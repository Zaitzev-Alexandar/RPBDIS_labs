using System;
using System.Collections.Generic;

namespace Lab2ConsoleApp
{
    public partial class Cars
    {
        public Cars()
        {
            Rents = new HashSet<Rents>();
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

        public CarModels CarModel { get; set; }
        public Employees Employee { get; set; }
        public ICollection<Rents> Rents { get; set; }
    }
}
