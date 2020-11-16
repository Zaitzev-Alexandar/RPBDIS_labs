using System;
using System.Collections.Generic;

namespace Lab2ConsoleApp
{
    public partial class Customers
    {
        public Customers()
        {
            Rents = new HashSet<Rents>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNum { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PassportInfo { get; set; }
        public bool? Gender { get; set; }

        public ICollection<Rents> Rents { get; set; }
    }
}
