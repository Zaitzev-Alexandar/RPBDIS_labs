using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab5_WebApp.Models;

namespace Lab5_WebApp.Data
{
    public class Lab5_CarSharingContext : DbContext
    {
        public Lab5_CarSharingContext(DbContextOptions<Lab5_CarSharingContext> options) : base(options)
        {
        }
        public DbSet<CarMark> CarMarks { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public  DbSet<Car> Cars { get; set; }
        
    }
}
