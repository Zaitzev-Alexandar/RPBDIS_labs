using System;
using System.Collections.Generic;

namespace Lab2ConsoleApp
{
    public partial class AdditionalServices
    {
        public int Id { get; set; }
        public int? RentId { get; set; }
        public int? ServiceId { get; set; }

        public Rents Rent { get; set; }
        public Services Service { get; set; }
    }
}
