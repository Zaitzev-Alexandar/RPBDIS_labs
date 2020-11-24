﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5_WebApp.ViewModels.Filters
{
    public class CarsFilterViewModel
    {
        [Display(Name = "Car")]
        public int CarRegNum { get; set; } = default!;
        public string CarVINcode { get; set; } = null!;
        public int CarEngineNum { get; set; } = default!;
        public decimal CarPrice { get; set; } = default!;
        public decimal CarRentalPrice { get; set; } = default!;
        public DateTime CarIssueDate { get; set; } = default!;
        public string CarSpecs { get; set; } = null!;
        public DateTime CarTechnicalMaintenanceDate { get; set; } = default!;
        public bool CarSpecMark { get; set; } = default!;
        public bool CarReturnMark { get; set; } = default!;

    }
}
