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
    public class CachedCarModelsService : ICachedCarModelsService
    {
        private car_sharingContext db;
        private IMemoryCache cache;
        public CachedCarModelsService(car_sharingContext context, IMemoryCache memoryCache)
        {
            db = context;
            cache = memoryCache;
        }
        public void AddCarModels(string cacheKey, int rowsCount = 20)
        {
            IEnumerable<CarModel> carModels = null;
            carModels = db.CarModels.Take(rowsCount).ToList();

            if (carModels != null)
            {
                cache.Set(cacheKey, carModels, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(298)
                });
            }
        }
        public IEnumerable<CarModel> GetCarModels(int rowsCount = 20)
        {
            return db.CarModels.Take(rowsCount).ToList();
        }
        public IEnumerable<CarModel> GetCarModels(string cacheKey, int rowCount = 20)
        {
            IEnumerable<CarModel> carModels = null;

            if (!cache.TryGetValue(cacheKey, out carModels))
            {
                carModels = db.CarModels.Take(rowCount).ToList();

                if (carModels != null)
                {
                    cache.Set(cacheKey, carModels, new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(298)
                    });
                }
            }

            return carModels;
        }
    }
}
