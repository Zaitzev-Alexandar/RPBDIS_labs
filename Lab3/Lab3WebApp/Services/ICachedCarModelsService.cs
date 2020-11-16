using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab3WebApp.Models;

namespace Lab3WebApp.Services
{
    public interface ICachedCarModelsService
    {
        public IEnumerable<CarModel> GetCarModels(int rowCount = 20);
        public void AddCarModels(string cacheKey, int rowCount = 20);
        public IEnumerable<CarModel> GetCarModels(string cacheKey, int rowCount = 20);
    }
}
