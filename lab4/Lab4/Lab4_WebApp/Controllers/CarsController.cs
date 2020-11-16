using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab4_WebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab4_WebApp.Controllers
{
    public class CarsController : Controller
    {
        private Lab4_CarSharingContext db;
        public CarsController(Lab4_CarSharingContext context)
        {
            db = context;
        }
        [ResponseCache(CacheProfileName = "CacheProfile")]
        public IActionResult Index()
        {
            return View(db.Cars.Include(s => s.CarModel).Take(20).ToList());
        }
    }
}
