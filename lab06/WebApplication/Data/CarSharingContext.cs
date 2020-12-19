using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApplication.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebApplication.Data
{
    public partial class CarSharingContext : DbContext
    {
        public CarSharingContext(DbContextOptions<CarSharingContext> options)
            : base(options) 
        {
            Database.EnsureCreated();
        }
        public virtual DbSet<CarModel> CarModels { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
    }
}
