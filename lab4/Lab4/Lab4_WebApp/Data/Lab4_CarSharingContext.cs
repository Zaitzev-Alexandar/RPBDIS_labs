using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab4_WebApp.Models;

namespace Lab4_WebApp.Data
{
    public class Lab4_CarSharingContext : DbContext
    {
        public Lab4_CarSharingContext(DbContextOptions<Lab4_CarSharingContext> options) : base(options)
        {
        }
        public DbSet<Service> Services { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public  DbSet<AdditionalService> AdditionalServices { get; set; }
        public  DbSet<Car> Cars { get; set; }
        public  DbSet<Rent> Rents { get; set; }
        
    }
}
