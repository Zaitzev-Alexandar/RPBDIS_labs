using System;
using System.Collections.Generic;

namespace Lab2ConsoleApp
{
    public partial class Employees
    {
        public Employees()
        {
            Cars = new HashSet<Cars>();
            Rents = new HashSet<Rents>();
        }

        public int EmployeeId { get; set; }
        public string Post { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime? EmploymentDate { get; set; }

        public ICollection<Cars> Cars { get; set; }
        public ICollection<Rents> Rents { get; set; }
    }
}
