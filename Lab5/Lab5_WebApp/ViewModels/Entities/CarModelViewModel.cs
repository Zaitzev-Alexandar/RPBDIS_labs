﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Lab5_WebApp.Models;
using Lab5_WebApp.ViewModels.Filters;

namespace Lab5_WebApp.ViewModels.Entities
{
    public class CarModelViewModel : IEntitiesViewModel<CarModel>
    {
        [Display(Name = "CarModels")]
        public IEnumerable<CarModel> Entities { get; set; }
        [Display(Name = "CarModel")]
        public CarModel Entity { get; set; }
        [Display(Name = "CarMarks")]
        public IEnumerable<CarMark> SelectList { get; set; }
        [Display(Name = "CarMarkName")]
        public string CarMarkName { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public DeleteViewModel DeleteViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
        public CarModelsFilterViewModel CarModelsFilterViewModel { get; set; }
    }
}
