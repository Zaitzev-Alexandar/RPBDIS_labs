using System;
using System.Collections.Generic;

namespace Lab2ConsoleApp
{
    public partial class CarModels
    {
        public CarModels()
        {
            Cars = new HashSet<Cars>();
        }

        public int CarModelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Cars> Cars { get; set; }
    }
}
