using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Lab5_WebApp.Models;
using Lab5_WebApp.ViewModels.Filters;

namespace Lab5_WebApp.ViewModels.Entities
{
    public class CarMarkViewModel : IEntitiesViewModel<CarMark>
    {
        [Display(Name = "CarMarks")]
        public IEnumerable<CarMark> Entities { get; set; }
        [Display(Name = "CarMark")]
        public CarMark Entity { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public DeleteViewModel DeleteViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
        public CarMarksFilterViewModel CarMarksFilterViewModel { get; set; }
    }
}
