using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using lab7.Models;

namespace lab7.Data
{
    public class CarSharingContext : DbContext
    {
        public CarSharingContext() : base("name=CarSharingConnectionString") { }
        public virtual DbSet<CarModel> CarModels { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
    }
}