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
        public IEnumerable<CarModel> SelectList { get; set; }

        [Display(Name = "CarModelName")]
        public string CarModelName { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public DeleteViewModel DeleteViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
        public CarsFilterViewModel CarsFilterViewModel { get; set; }
    }
}
