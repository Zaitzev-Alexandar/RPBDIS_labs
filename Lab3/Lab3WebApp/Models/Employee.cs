using System;
using System.Collections.Generic;

namespace Lab3WebApp.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Cars = new HashSet<Car>();
        }

        public int EmployeeId { get; set; }
        public string Post { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime? EmploymentDate { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
        public override string ToString()
        {
            return $"Должность: {Post}, Имя: {Name}, Фамилия: {Surname}, Отчество: {Patronymic}, Дата трудоустройства: {EmploymentDate.ToString()}";
        }
    }
}
