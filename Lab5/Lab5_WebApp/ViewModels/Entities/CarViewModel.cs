using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Lab5_WebApp.Models;
using Lab5_WebApp.ViewModels.Filters;

namespace Lab5_WebApp.ViewModels.Entities
{
    public class CarViewModel : IEntitiesViewModel<Car>
    {
        [Display(Name = "Cars")]
        public IEnumerable<Car> Entities { get; set; }
        [Display(Name = "Car")]
        public Car Entity { get; set; }
        [Display(Name = "CarModels")]
        public IEnumerable<CarModel> SelectList1 { get; set; }
        [Display(Name = "Employees")]
        public IEnumerable<Employee> SelectList2 { get; set; }

        public string CarModelName { get; set; }
        public string EmplpoyeeName { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public DeleteViewModel DeleteViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
        public CarsFilterViewModel CarsFilterViewModel { get; set; }
    }
}
