﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class CarModel
    {
        public int CarModelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public CarModel()
        {
            Cars = new List<Car>();
        }
    }
}
