using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Globalization;
using Lab3WebApp.Data;
using Lab3WebApp.Models;
using Lab3WebApp.Services;
using Lab3WebApp.Infrastructure;

namespace Lab3WebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("SQLConnection");

            services.AddDbContext<car_sharingContext>(options => options.UseSqlServer(connectionString));

            services.AddMemoryCache();

            services.AddScoped<ICachedCarModelsService, CachedCarModelsService>();
            services.AddScoped<ICachedEmployeesService, CachedEmployeesService>();
            services.AddScoped<ICachedCarsService, CachedCarsService>();

            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, car_sharingContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();

            app.Map("/info", Info);
            app.Map("/carmodels", CarModels);
            app.Map("/cars", Cars);
            app.Map("/employees", Employees);

            app.Map("/searchform", SearchForm);
            app.Run(async (context) =>
            {
                ICachedCarModelsService cachedCarModels = context.RequestServices.GetService<ICachedCarModelsService>();
                cachedCarModels.GetCarModels("carmodels20");

                ICachedEmployeesService cachedEmployeesService = context.RequestServices.GetService<ICachedEmployeesService>();
                cachedEmployeesService.GetEmployees("employees20");

                ICachedCarsService cachedCarsService = context.RequestServices.GetService<ICachedCarsService>();
                cachedCarsService.GetCars("cars20");

                User user = context.Session.Get<User>("user") ?? new User();

                string htmlString = "<html>" +
                "<head>" +
                "<title>����� ������������</title>" +
                "<style>" +
                "div { font-size: 24; }" +
                "</style>" +
                "</head>" +
                "<meta charset='utf-8'/>" +
                "<body>" +
                "<div align='center'>" +
                "<form action='/'>" +
                "<div>������� �����:</div>";
                htmlString += $"<div><input type='text' name='loginStr' value=" + user.Login + "></div>";
                htmlString += "<div>������� ������:</div>";
                htmlString += $"<div><input type='text' name='passwordStr' value=" + user.Password + "></div>" +
                "<div><input type='submit' value='Enter/Update'></div>" +
                "</form>" +
                "<div><a href='/carmodels'>Table 'CarModels'</a></div>" +
                "<div><a href='/employees'>Table 'Employees'</a></div>" +
                "<div><a href='/cars'>Table 'Cars'</a></div>" +
                "<div><a href='/searchform'>Search Form</a></div>" +
                "</div>" +
                "</body>" +
                "</html>";

                string Login = context.Request.Query["loginStr"];
                string Password = context.Request.Query["passwordStr"];

                if (Login != null && Password != null)
                {
                    user.Login = Login;
                    user.Password = Password;
                    context.Session.Set<User>("user", user);
                }

                await context.Response.WriteAsync(htmlString);
            });
        }
        private static void Info(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                string httpString = "<html>" +
                "<head>" +
                "<title>���������� � �������</title>" +
                "<style>" +
                "div { font-size: 24; }" +
                "</style>" +
                "</head>" +
                "<meta charset='utf-8'/>" +
                "<body align='middle'>" +
                "<div> ������: " + context.Request.Host + "</div>" +
                "<div> ����: " + context.Request.PathBase + "</div>" +
                "<div> ��������: " + context.Request.Protocol + "</div>" +
                "<div><a href='/'>�������</a></div>" +
                "</body>" +
                "</html>";

                await context.Response.WriteAsync(httpString);
            });
        }
        private static void CarModels(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                ICachedCarModelsService cachedCarModelsService = context.RequestServices.GetService<ICachedCarModelsService>();
                IEnumerable<CarModel> carModels = cachedCarModelsService.GetCarModels("carmodels20");

                string httpString = "<html>" +
                "<head>" +
                "<title>������� CarModels</title>" +
                "<style>" +
                "div { font-size: 24; }" +
                "table { font-size: 20; }" +
                "</style>" +
                "</head>" +
                "<meta charset='utf-8'/>" +
                "<body>" +
                "<div align='center'>������� 'CarModels'</div>" +
                "<div align='center'>" +
                "<table border=1>" +
                "<tr>" +
                "<td>�������� ������</td>" +
                "<td>��������</td>" +
                "</tr>";

                foreach (CarModel carModel in carModels)
                {
                    httpString += "<tr>";
                    httpString += $"<td>{carModel.Name}</td>";
                    httpString += $"<td>{carModel.Description}</td>";
                    httpString += "</tr>";
                }
                httpString += "</table>";

                httpString += "<div align='center'><a href='/'>�������</a></div>";
                httpString += "</body>" +
                "</html>";

                await context.Response.WriteAsync(httpString);
            });
        }
        private static void Cars(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                ICachedCarsService cachedCarsService = context.RequestServices.GetService<ICachedCarsService>();
                IEnumerable<Car> cars = cachedCarsService.GetCars("cars20");

                string httpString = "<html>" +
                "<head>" +
                "<title>������� Cars</title>" +
                "<style>" +
                "div { font-size: 24; }" +
                "table { font-size: 14; }" +
                "</style>" +
                "</head>" +
                "<meta charset='utf-8'/>" +
                "<body>" +
                "<div align='center'>������� 'Cars'</div>" +
                "<div align='center'>" +
                "<table border=1>" +
                "<tr>" +
                "<td>�������� ������</td>" +
                "<td>��������</td>" +
                "<td>��������������� �����</td>" +
                "<td>VIN-���</td>" +
                "<td>����� ���������</td>" +
                "<td>����</td>" +
                "<td>������</td>" +
                "<td>��� �������</td>" +
                "<td>��������������</td>" +
                "<td>���� ��</td>" +
                "<td>����. �����</td>" +
                "<td>����� ��������</td>" +
                "<td>��� ����������</td>" +
                "<td>������� ����������</td>" +
                "</tr>";

                foreach (Car car in cars)
                {
                    httpString += "<tr>";
                    httpString += $"<td>{car.CarModel.Name}</td>";
                    httpString += $"<td>{car.CarModel.Description}</td>";
                    httpString += $"<td>{car.RegNum}</td>";
                    httpString += $"<td>{car.Vincode}</td>";
                    httpString += $"<td>{car.EngineNum}</td>";
                    httpString += $"<td>{car.Price}</td>";
                    httpString += $"<td>{car.RentalPrice}</td>";
                    httpString += $"<td>{car.IssueDate}</td>";
                    httpString += $"<td>{car.Specs}</td>";
                    httpString += $"<td>{car.TechnicalMaintenanceDate}</td>";
                    httpString += $"<td>{car.SpecMark}</td>";
                    httpString += $"<td>{car.ReturnMark}</td>";
                    httpString += $"<td>{car.Employee?.Name}</td>";
                    httpString += $"<td>{car.Employee?.Surname}</td>";
                    httpString += "</tr>";
                }
                httpString += "</table>";

                httpString += "<div align='center'><a href='/'>�������</a></div>";
                httpString += "</body>" +
                "</html>";

                await context.Response.WriteAsync(httpString);
            });
        }
        private static void Employees(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                ICachedEmployeesService cachedEmployeesService = context.RequestServices.GetService<ICachedEmployeesService>();
                IEnumerable<Employee> employees = cachedEmployeesService.GetEmployees("employees20");

                string httpString = "<html>" +
                "<head>" +
                "<title>������� Employees</title>" +
                "<style>" +
                "div { font-size: 24; }" +
                "table { font-size: 20; }" +
                "</style>" +
                "</head>" +
                "<meta charset='utf-8'/>" +
                "<body>" +
                "<div align='center'>������� 'Employees'</div>" +
                "<div align='center'>" +
                "<table border=1>" +
                "<tr>" +
                "<td>���������</td>" +
                "<td>���</td>" +
                "<td>�������</td>" +
                "<td>��������</td>" +
                "<td>���� ���������������</td>" +
                "</tr>";

                foreach (Employee employee in employees)
                {
                    httpString += "<tr>";
                    httpString += $"<td>{employee.Post}</td>";
                    httpString += $"<td>{employee.Name}</td>";
                    httpString += $"<td>{employee.Surname}</td>";
                    httpString += $"<td>{employee.Patronymic}</td>";
                    httpString += $"<td>{employee.EmploymentDate}</td>";
                    httpString += "</tr>";
                }
                httpString += "</table>";

                httpString += "<div align='center'><a href='/'>�������</a></div>";
                httpString += "</body>" +
                "</html>";

                await context.Response.WriteAsync(httpString);
            });
        }
        private static void SearchForm(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                ICachedCarModelsService cachedCarModelsService = context.RequestServices.GetService<ICachedCarModelsService>();
                IEnumerable<CarModel> carModels = cachedCarModelsService.GetCarModels("carmodels20");

                ICachedCarsService cachedCarsService = context.RequestServices.GetService<ICachedCarsService>();
                IEnumerable<Car> cars = cachedCarsService.GetCars("cars20");

                ICachedEmployeesService cachedEmployeesService = context.RequestServices.GetService<ICachedEmployeesService>();
                IEnumerable<Employee> employees = cachedEmployeesService.GetEmployees("employees20");

                string httpString = "<html>" +
                "<head>" +
                "<title>����� ������</title>" +
                "<style>" +
                "div { font-size: 24; }" +
                "table { font-size: 20; }" +
                "select {font-size: 20; width=20%; }" +
                "input {font-size: 22; width=20%; }" +
                "</style>" +
                "</head>" +
                "<meta charset='utf-8'/>" +
                "<body>" +
                "<div align='middle' text-align='left'>" +
                "<form action='/searchform'>" +
                "<div width=20%>�������� �������</div>" +
                "<select name='tableName'>" +
                "<option>Choose table</option>" +
                "<option>CarModels</option>" +
                "<option>Employees</option>" +
                "<option>Cars</option>" +
                "</select>" +
                "<input type = 'submit' value = 'Select'>";

                string selectedText = context.Request.Cookies["table"] ?? context.Request.Query["tableName"];

                if (context.Request.Cookies["table"] == "Choose table")
                    context.Response.Cookies.Delete("table");

                if (selectedText != null)
                {
                    if (selectedText != "Choose table" && selectedText != context.Request.Cookies["tableName"])
                    {
                        string querySttring = context.Request.Query["tableName"];
                        if (querySttring != null && querySttring != "Choose table")
                        {
                            context.Response.Cookies.Append("table", querySttring);
                            selectedText = querySttring;
                        }
                    }


                    switch (selectedText)
                    {
                        case "CarModels":
                            httpString += "<ul>";

                            foreach (CarModel carModel in carModels)
                            {
                                httpString += $"<li>{carModel.Name}</li>";
                            }
                            httpString += "</ul>";

                            break;
                        case "Employees":
                            httpString += "<ul>";

                            foreach (Employee employee in employees)
                            {
                                httpString += $"<li>{employee.Name}</li>";
                            }
                            httpString += "</ul>";

                            break;
                        case "Cars":
                            httpString += "<ul>";

                            foreach (Car car in cars)
                            {
                                httpString += $"<li>{car.Vincode}, {car.CarModel?.Name}.</li>";
                            }
                            httpString += "</ul>";
                            break;
                    }

                    httpString += "<div>" +
                    "<input type='text' name='entity'>" +
                    "<input type='submit' value='Input'>" +
                    "</div>";

                    string entityInput;
                    if ((entityInput = context.Request.Query["entity"]) != null && entityInput != "")
                    {
                        switch (selectedText)
                        {
                            case "CarModels":
                                CarModel carModel = carModels.FirstOrDefault(c => c.Name == entityInput);
                                if (carModel != null)
                                {
                                    httpString += "<div>" +
                                    "<p>" +
                                    $"�������� ������: {carModel.Name}, ��������: {carModel.Description}." +
                                    "</p>" +
                                    "</div>";
                                }
                                break;
                            case "Employees":
                                Employee employee = employees.FirstOrDefault(e => e.Name == entityInput);
                                if (employee != null)
                                {
                                    httpString += "<div>" +
                                    "<p>" +
                                    $"���: {employee.Name}, ������� {employee.Surname}, ��������: {employee.Patronymic}, " +
                                    $"���������: {employee.Post}, ���� ���������������: {employee.EmploymentDate}." +
                                    "</p>" +
                                    "</div>";
                                }
                                break;
                            case "Cars":
                                int id;
                                if (int.TryParse(entityInput, out id))
                                {
                                    Car car = cars.FirstOrDefault(c => c.CarId == id);
                                    httpString += "<div><p>";

                                    httpString += $"�������� ������ : {car.CarModel?.Name},";
                                    httpString += $"��������: {car.CarModel?.Description},";
                                    httpString += $"��������������� �����: {car.RegNum},";
                                    httpString += $"VIN-���: {car.Vincode},";
                                    httpString += $"����� ���������: {car.EngineNum},";
                                    httpString += $"����: {car.Price},";
                                    httpString += $"������: {car.RentalPrice},";
                                    httpString += $"��� �������: {car.IssueDate},";
                                    httpString += $"��������������: {car.Specs},";
                                    httpString += $"���� ��: {car.TechnicalMaintenanceDate},";
                                    httpString += $"����. �����: {car.SpecMark},";
                                    httpString += $"����� ��������: {car.ReturnMark},";
                                    httpString += $"��� ����������: {car.Employee?.Name},";
                                    httpString += $"������� ����������: {car.Employee?.Surname},";
                                    httpString += "</p>" +
                                    "</div>";
                                }
                                break;
                        }
                    }
                }

                httpString += "</form>" +
                "<div><a href='/searchform'>��������</a></div>" +
                "<div><a href='/'>�������</a></div>" +
                "</div>" +
                "</body>" +
                "</html>";

                await context.Response.WriteAsync(httpString);
            });
        }
    }
}
