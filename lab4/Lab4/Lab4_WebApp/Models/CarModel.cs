using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4_WebApp.Models
{
    public class CarModel
    {
        public int CarModelId { get; set; }
        /// <summary>
        /// Марка авто-производителя
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// Название модели авто
        /// </summary>
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public CarModel()
        {
            Cars = new List<Car>();
        }
    }
}
