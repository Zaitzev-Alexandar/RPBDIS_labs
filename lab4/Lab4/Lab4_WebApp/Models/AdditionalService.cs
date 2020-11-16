using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4_WebApp.Models
{
    public class AdditionalService
    {
        public int Id { get; set; }
        public int RentId { get; set; }
        public int ServiceId { get; set; }

        public Rent Rent { get; set; }
        public Service Service { get; set; }
    }
}
