using System;
using System.Collections.Generic;

namespace Lab2ConsoleApp
{
    public partial class Rents
    {
        public Rents()
        {
            AdditionalServices = new HashSet<AdditionalServices>();
        }

        public int RentId { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? CarId { get; set; }
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public decimal? Price { get; set; }

        public Cars Car { get; set; }
        public Customers Customer { get; set; }
        public Employees Employee { get; set; }
        public ICollection<AdditionalServices> AdditionalServices { get; set; }
    }
}
