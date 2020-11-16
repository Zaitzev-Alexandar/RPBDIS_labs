using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab4_WebApp.Models
{
    public class Rent
    {
        public Rent()
        {
            AdditionalServices = new HashSet<AdditionalService>();
        }

        public int RentId { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int CarId { get; set; }
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public Car Car { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public ICollection<AdditionalService> AdditionalServices { get; set; }
    }
}
