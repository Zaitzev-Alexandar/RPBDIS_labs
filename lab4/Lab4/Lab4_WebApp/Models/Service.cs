using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab4_WebApp.Models
{
    public class Service
    {
        public Service()
        {
            AdditionalServices = new HashSet<AdditionalService>();
        }

        public int ServiceId { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public string Description { get; set; }

        public ICollection<AdditionalService> AdditionalServices { get; set; }
    }
}
