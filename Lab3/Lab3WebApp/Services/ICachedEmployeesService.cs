using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab3WebApp.Models;

namespace Lab3WebApp.Services
{
    public interface ICachedEmployeesService
    {
        public IEnumerable<Employee> GetEmployees(int rowCount = 20);
        public void AddEmployees(string cacheKey, int rowCount = 20);
        public IEnumerable<Employee> GetEmployees(string cacheKey, int rowCount = 20);
    }
}
