using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab3WebApp.Models;

namespace Lab3WebApp.Services
{
    public interface ICachedCarsService
    {
        public IEnumerable<Car> GetCars(int rowCount = 20);
        public void AddCars(string cacheKey, int rowCount = 20);
        public IEnumerable<Car> GetCars(string cacheKey, int rowCount = 20);
    }
}
