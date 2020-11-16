using System;
using System.Collections.Generic;

namespace Lab3WebApp.Models
{
    public partial class CarModel
    {
        public CarModel()
        {
            Cars = new HashSet<Car>();
        }

        public int CarModelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
        public override string ToString()
        {
            return $"Название: {Name}, Описание: {Description}";
        }
    }
}
