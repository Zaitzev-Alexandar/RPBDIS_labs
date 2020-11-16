using System;
using System.Collections.Generic;

namespace Lab2ConsoleApp
{
    public partial class Services
    {
        public Services()
        {
            AdditionalServices = new HashSet<AdditionalServices>();
        }

        public int ServiceId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }

        public ICollection<AdditionalServices> AdditionalServices { get; set; }
    }
}
