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
    public class CachedEmployeesService : ICachedEmployeesService
    {
        private car_sharingContext db;
        private IMemoryCache cache;
        public CachedEmployeesService(car_sharingContext context, IMemoryCache memoryCache)
        {
            db = context;
            cache = memoryCache;
        }
        public void AddEmployees(string cacheKey, int rowsCount = 20)
        {
            IEnumerable<Employee> employees = null;
            employees = db.Employees.Take(rowsCount).ToList();

            if (employees != null)
            {
                cache.Set(cacheKey, employees, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(298)
                });
            }
        }
        public IEnumerable<Employee> GetEmployees(int rowsCount = 20)
        {
            return db.Employees.Take(rowsCount).ToList();
        }
        public IEnumerable<Employee> GetEmployees(string cacheKey, int rowsCount = 20)
        {
            IEnumerable<Employee> employees = null;

            if (!cache.TryGetValue(cacheKey, out employees))
            {
                employees = db.Employees.Take(rowsCount).ToList();

                if (employees != null)
                {
                    cache.Set(cacheKey, employees, new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(298)
                    });
                }
            }

            return employees;
        }
    }
}
