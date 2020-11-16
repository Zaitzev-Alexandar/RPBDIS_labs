using Lab3WebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab3WebApp.Models;

namespace Lab3WebApp.Services
{
    public class CachedCarsService : ICachedCarsService
    {
        private car_sharingContext db;
        private IMemoryCache cache;
        public CachedCarsService(car_sharingContext context, IMemoryCache memoryCache)
        {
            db = context;
            cache = memoryCache;
        }
        public void AddCars(string cacheKey, int rowsCount = 20)
        {
            IEnumerable<Car> cars = null;
            cars = db.Cars.Include(c => c.CarModel).Include(c => c.Employee).Take(rowsCount).ToList();

            if (cars != null)
            {
                cache.Set(cacheKey, cars, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(298)
                });
            }
        }
        public IEnumerable<Car> GetCars(int rowsCount = 20)
        {
            return db.Cars.Include(c => c.CarModel).Include(c => c.Employee).Take(rowsCount).ToList();
        }
        public IEnumerable<Car> GetCars(string cacheKey, int rowsCount = 20)
        {
            IEnumerable<Car> cars = null;

            if (!cache.TryGetValue(cacheKey, out cars))
            {
                cars = db.Cars.Include(c => c.CarModel).Include(c => c.Employee).Take(rowsCount).ToList();

                if (cars != null)
                {
                    cache.Set(cacheKey, cars, new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(298)
                    });
                }
            }

            return cars;
        }
    }
}
