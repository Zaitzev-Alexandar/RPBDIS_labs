using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab4_WebApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace Lab4_WebApp.Controllers
{
    public class EmployeesController : Controller
    {
        private Lab4_CarSharingContext db;
        public EmployeesController(Lab4_CarSharingContext context)
        {
            db = context;
        }
        [ResponseCache(CacheProfileName = "CacheProfile")]
        public IActionResult Index()
        {
            return View(db.Employees.Take(20).ToList());
        }
    }
}
