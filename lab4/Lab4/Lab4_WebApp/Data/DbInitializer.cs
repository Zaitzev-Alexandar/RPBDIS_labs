using Lab4_WebApp.Data;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Lab4_WebApp.Data
{
    public static class DbInitializer
    {
        private static char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
        private static Random random = new Random();
        public static void Initialize(Lab4_CarSharingContext db)
        {
            int rowCount;
            int rowIndex;

            int minStringLength;
            int maxStringLength;

            db.Database.EnsureCreated();
            if (!db.CarModels.Any())
            {
                rowCount = 500;
                string carModelName;
                string carModelDescription;
                string carBrand;
                for(rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    minStringLength = 4;
                    maxStringLength = 20;
                    carModelName = GetString(minStringLength, maxStringLength);
                    carBrand = GetString(minStringLength, maxStringLength);
                    minStringLength = 50;
                    maxStringLength = 1000;
                    carModelDescription = GetString(minStringLength, maxStringLength);
                    db.CarModels.Add(new Models.CarModel { Name = carModelName, Description = carModelDescription, Brand = carBrand });
                }
                db.SaveChanges();
            }
            if (!db.Employees.Any())
            {
                rowCount = 500;
                string employeePost;
                string employeeName;
                string employeeSurname;
                string employeePatronymic;
                DateTime employeeEmploymentDate;

                for (rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    minStringLength = 2;
                    maxStringLength = 20;
                    employeePost = GetString(minStringLength, maxStringLength);
                    employeeName = GetString(minStringLength, maxStringLength);
                    employeeSurname = GetString(minStringLength, maxStringLength);
                    employeePatronymic = GetString(minStringLength, maxStringLength);
                    employeeEmploymentDate = GetDateTime();
                    db.Employees.Add(new Models.Employee { Name = employeeName, Surname = employeeSurname, Patronymic = employeePatronymic, Post = employeePost, EmploymentDate = employeeEmploymentDate });
                }
                db.SaveChanges();
            }
            if (!db.Cars.Any())
            {
                rowCount = 20000;

                int carRegNum;
                string carVINcode;
                int carEngineNum;
                decimal carPrice;
                decimal carRentalPrice;
                DateTime carIssueDate;
                string carSpecs;
                DateTime carTechnicalMaintainceDate;
                bool carSpecMark;
                bool carReturnMark;
                int carEmployeeId;
                int carCarModelId;

                for (rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    carRegNum = random.Next(1000000000, 2000000000);
                    carEngineNum = random.Next(10000000, 100000000);
                    carPrice = Convert.ToDecimal(random.Next(150000, 2000000));
                    carRentalPrice = Convert.ToDecimal(random.Next(1500, 10000));
                    carSpecMark = random.Next(0, 1) == 1 ? true : false;
                    carReturnMark = random.Next(0, 1) == 1 ? true : false;
                    carIssueDate = GetDateTime(2000);
                    carTechnicalMaintainceDate = GetDateTime(2020);
                    carEmployeeId = random.Next(1, 499);
                    carCarModelId = random.Next(1, 499);

                    minStringLength = 21;
                    maxStringLength = 200;
                    carSpecs = GetString(minStringLength, maxStringLength);

                    minStringLength = 4;
                    maxStringLength = 20;
                    carVINcode = GetString(minStringLength, maxStringLength);

                    db.Cars.Add(new Models.Car
                    {
                        CarModelId = carCarModelId,
                        EmployeeId = carEmployeeId,
                        EngineNum = carEngineNum,
                        RegNum = carRegNum,
                        Price = carPrice,
                        RentalPrice = carRentalPrice,
                        SpecMark = carSpecMark,
                        ReturnMark = carReturnMark,
                        IssueDate = carIssueDate,
                        TechnicalMaintenanceDate = carTechnicalMaintainceDate,
                        Specs = carSpecs,
                        VINcode = carVINcode
                    });
                }
                db.SaveChanges();
            }




            




        }
        private static string GetString(int minStringLength, int maxStringLength)
        {
            string result = "";

            int stringLimit = minStringLength + random.Next(maxStringLength - minStringLength);

            int stringPosition;
            for (int i = 0; i < stringLimit; i++)
            {
                stringPosition = random.Next(letters.Length);

                result += letters[stringPosition];
            }

            return result;
        }
        private static DateTime GetDateTime()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;

            return start.AddDays(random.Next(range));
        }
        private static DateTime GetDateTime(int begin)
        {
            DateTime start = new DateTime(begin, 1, 1);
            int range = (DateTime.Today - start).Days;

            return start.AddDays(random.Next(range));
        }
    }
}
