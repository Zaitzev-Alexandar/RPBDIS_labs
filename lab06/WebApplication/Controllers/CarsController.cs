using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data;
using WebApplication.Models;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarSharingContext _db;

        public CarsController(CarSharingContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<CarViewModel>>> Get()
        {
            var result = _db.Cars.Include(s => s.CarModel).Include(g => g.Employee).Select(s => new CarViewModel
            {
                Id = s.CarId,
                RegNum = s.RegNum,
                EngineNum = s.EngineNum,
                Price = s.Price,
                RentalPrice = s.RentalPrice,
                VINcode = s.VINcode,
                IssueDate = s.IssueDate,
                TechnicalMaintenanceDate = s.TechnicalMaintenanceDate,
                SpecMark = s.SpecMark,
                ReturnMark = s.ReturnMark,
                EmployeeId = s.EmployeeId,
                Employee = s.Employee.Name,
                CarModelId = s.CarModelId,
                CarModel = s.CarModel.Name,
                Specs = s.Specs

            })
                .Take(20).ToListAsync();
            return await result;
        }
        [HttpGet("cars")]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            return await _db.Cars.OrderBy(g => g.CarId).ToListAsync();
        }
        [HttpGet("carModels")]
        public async Task<ActionResult<IEnumerable<CarModel>>> GetCarModels()
        {
            return await _db.CarModels.OrderBy(g => g.CarModelId).ToListAsync();
        }
        [HttpGet("employees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _db.Employees.OrderBy(g => g.EmployeeId).ToListAsync();
        }
        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarViewModel>> Get(int id)
        {
            Car car = await _db.Cars.Include(s => s.Employee).Include( g => g.CarModel).FirstOrDefaultAsync(s => s.CarId == id);
            if (car == null)
                return NotFound();

            return new ObjectResult(new CarViewModel
            {
                Id = car.CarId,
                RegNum = car.RegNum,
                EngineNum = car.EngineNum,
                Price = car.Price,
                RentalPrice = car.RentalPrice,
                VINcode = car.VINcode,
                IssueDate = car.IssueDate,
                TechnicalMaintenanceDate = car.TechnicalMaintenanceDate,
                SpecMark = car.SpecMark,
                ReturnMark = car.ReturnMark,
                EmployeeId = car.EmployeeId,
                Employee = car.Employee.Name,
                CarModelId = car.CarModelId,
                CarModel = car.CarModel.Name,
                Specs = car.Specs
            });
        }
        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<CarViewModel>> Post(CarViewModel model)
        {
            if (model == null)
                return BadRequest();

            Car car = new Car
            {
                RegNum = model.RegNum,
                EngineNum = model.EngineNum,
                Price = model.Price,
                RentalPrice = model.RentalPrice,
                VINcode = model.VINcode,
                IssueDate = model.IssueDate,
                TechnicalMaintenanceDate = model.TechnicalMaintenanceDate,
                SpecMark = model.SpecMark,
                ReturnMark = model.ReturnMark,
                EmployeeId = model.EmployeeId,
                CarModelId = model.CarModelId,
                Specs = model.Specs
            };

            _db.Cars.Add(car);
            await _db.SaveChangesAsync();

            model.Id = _db.Cars.ToList().LastOrDefault().CarId;
            model.CarModel = _db.CarModels.FirstOrDefault(g => g.CarModelId == model.CarModelId + 1).Name;
            model.Employee = _db.Employees.FirstOrDefault(g => g.EmployeeId == model.EmployeeId + 1).Name;
            return Ok(model);
        }
        //comment
        // PUT api/<ValuesController>/5
        [HttpPut]
        public async Task<ActionResult<CarViewModel>> Put(CarViewModel model)
        {
            if (model == null)
                return BadRequest();
            Car car = _db.Cars.FirstOrDefault(s => s.CarId == model.Id);
            if (car == null)
                return NotFound();

            car.RegNum = model.RegNum;
            car.EngineNum = model.EngineNum;
            car.Price = model.Price;
            car.RentalPrice = model.RentalPrice;
            car.VINcode = model.VINcode;
            car.IssueDate = model.IssueDate;
            car.TechnicalMaintenanceDate = model.TechnicalMaintenanceDate;
            car.SpecMark = model.SpecMark;
            car.ReturnMark = model.ReturnMark;
            car.EmployeeId = model.EmployeeId;
            car.CarModelId = model.CarModelId;
            car.Specs = model.Specs;

            _db.Update(car);
            await _db.SaveChangesAsync();

            model.Employee = _db.Employees.FirstOrDefault(g => g.EmployeeId == car.EmployeeId).Name;
            model.CarModel = _db.CarModels.FirstOrDefault(g => g.CarModelId == model.CarModelId).Name;
            return Ok(model);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> Delete(int id)
        {
            Car car = _db.Cars.Include(s => s.Employee).Include(g => g.CarModel).FirstOrDefault(s => s.CarId == id);
            if (car == null)
                return NotFound();

            _db.Cars.Remove(car);
            await _db.SaveChangesAsync();

            return Ok(new CarViewModel
            {
                Id = car.CarId,
                RegNum = car.RegNum,
                EngineNum = car.EngineNum,
                Price = car.Price,
                RentalPrice = car.RentalPrice,
                VINcode = car.VINcode,
                IssueDate = car.IssueDate,
                TechnicalMaintenanceDate = car.TechnicalMaintenanceDate,
                
                SpecMark = car.SpecMark,
                ReturnMark = car.ReturnMark,
                EmployeeId = car.EmployeeId,
                Employee = car.Employee.Name,
                CarModelId = car.CarModelId,
                CarModel = car.CarModel.Name,
                Specs = car.Specs
            });
        }
    }
}
