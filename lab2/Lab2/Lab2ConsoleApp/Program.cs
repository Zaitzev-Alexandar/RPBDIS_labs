using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.IO;


namespace Lab2ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using(car_sharingContext db = new car_sharingContext())
            {

                int menu = 1;
                while (menu != 0)
                {
                    Console.WriteLine("Меню:");
                    Console.WriteLine("1. Выборка всех данных из таблицы CarModels");
                    Console.WriteLine("2. Выборка данных из таблицы Employees с ограничением по полю EmploymentDate");
                    Console.WriteLine("3. Выборка данных из таблицы Cars, сгруппированных по полю Price с выводом среднего результата(avg)");
                    Console.WriteLine("4. Выборка данных из двух полей двух таблиц(Cars и CarModels)");
                    Console.WriteLine("5. Выборка данных из двух полей двух таблиц(Cars и CarModels) с фильтром по полю Price");
                    Console.WriteLine("6. Вставка данных в таблицу CarModels");
                    Console.WriteLine("7. Вставка данных в таблицу Cars");
                    Console.WriteLine("8. Удаление данных из таблицы CarModels");
                    Console.WriteLine("9. Удаление данных из таблицы Cars");
                    Console.WriteLine("10. Обновление записей в таблице CarModels");
                    Console.WriteLine("Введите номер пункта");
                    menu = Int32.Parse(Console.ReadLine());
                    switch (menu)
                    {
                        case 1:
                            Select(db, 1);
                            break;
                        case 2:
                            Select(db, 2);
                            break;
                        case 3:
                            Select(db, 3);
                            break;
                        case 4:
                            Select(db, 4);
                            break;
                        case 5:
                            Select(db, 5);
                            break;
                        case 6:
                            Insert(db, 6);
                            break;
                        case 7:
                            Insert(db, 7);
                            break;
                        case 8:
                            Delete(db, 8);
                            break;
                        case 9:
                            Delete(db, 9);
                            break;
                        case 10:
                            Update(db);
                            break;
                        case 0:
                            Console.WriteLine("Осуществление выхода из программы");
                            break;
                        default: Console.WriteLine("Осуществление выхода из программы"); break;
                    }
                }
            }
        }
        static void Print(string sqltext, IEnumerable items)
        {
            Console.WriteLine(sqltext);
            Console.WriteLine("Записи: ");
            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
            Console.ReadKey();
        }
        static void Select(car_sharingContext db, int num)
        {
            string comment = "";
            //для наглядности выводим не более 5 записей
            switch (num)
            {
                case 1:
                    var query1 = from c in db.CarModels
                                 select new
                                 {
                                     Название_модели = c.Name,
                                     Описание = c.Description
                                 };
                    comment = "1. Результат выполнения запроса на выборку всех записей из таблицы, стоящей в схеме базы данных нас стороне отношения «один»: \r\n";
                    

                    Print(comment, query1.Take(200).ToList());
                    break;
                case 2:
                    var query2 = from e in db.Employees
                                 where (e.EmploymentDate > Convert.ToDateTime("01-01-2018"))
                                 select new
                                 {
                                     Пост = e.Post,
                                     Фамилия = e.Surname,
                                     Имя = e.Name,
                                     Отчество = e.Patronymic,
                                     Дата_принятия_на_работу = e.EmploymentDate
                                 };
                    comment = "2. Результат выполнения запроса на выборку записей из таблицы, стоящей в схеме базы данных нас стороне отношения «один», отфильтрованные по определенному условию, налагающему ограничения на одно или несколько полей : \r\n";
                    Print(comment, query2.Take(5).ToList());
                    break;
                case 3:
                    var query3 = from c in db.Cars
                                 select new
                                 {
                                     Цена = c.Price
                                 };
                    comment = "3. Результат выполнения запроса на выборку данных, сгруппированных по любому из полей данных с выводом какого-либо итогового результата (min, max, avg, сount или др.) по выбранному полю из таблицы, стоящей в схеме базы данных нас стороне отношения «многие» : \r\n";
                    Console.WriteLine(comment);
                    Console.WriteLine("Средняя цена автомобилей: " + query3.Take(20000).ToList().Average(n => n.Цена));
                    break;
                case 4:
                    var query4 = from f in db.CarModels
                                      join t in db.Cars
                                      on f.CarModelId equals t.CarModelId
                                      select new
                                      {
                                          Модель_авто = f.Name,
                                          Цена = t.Price
                                      };
                    comment = "4. Результат выполнения запроса на выборку данных из двух полей двух таблиц, связанных между собой отношением «один-ко-многим»: \r\n";
                    Print(comment, query4.Take(5).ToList());
                    break;
                case 5:
                    var query5 = from f in db.CarModels
                                 join t in db.Cars
                                 on f.CarModelId equals t.CarModelId
                                 where t.Price > 600000
                                 select new
                                 {
                                     Модель_авто = f.Name,
                                     Цена = t.Price
                                 };
                    comment = "5. Результат выполнения запроса на выборку данных из двух таблиц, связанных между собой отношением «один-ко-многим» и отфильтрованным по некоторому условию, налагающему ограничения на значения одного или нескольких полей : \r\n";
                    Print(comment, query5.Take(5).ToList());
                    break;
            }

        }
        static void Insert(car_sharingContext db, int num)
        {
            switch (num)
            {
                case 6:
                    Console.WriteLine("Ввод данных нового объекта CarModel");
                    Console.WriteLine("1. Введите имя:");
                    string name = Console.ReadLine();
                    Console.WriteLine("2. Введите описание:");
                    string description = Console.ReadLine();
                    CarModels carModel = new CarModels { Name = name, Description = description };
                    db.CarModels.Add(carModel);
                    db.SaveChanges();
                    Console.ReadKey();
                    break;
                case 7:
                    Console.WriteLine("Ввод данных нового объекта Car");
                    Console.WriteLine("1. Введите CarModelId:");
                    int carModelId = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("2. Введите EmployeeId:");
                    int employeeId = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("3. Введите RegNum:");
                    int regNum = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("4. Введите VINCode:");
                    string vinCode = Console.ReadLine();

                    Console.WriteLine("5. Введите EngineNum:");
                    int engineNum = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("6. Введите Price:");
                    decimal price = decimal.Parse(Console.ReadLine());

                    Console.WriteLine("7. Введите RentalPrice:");
                    decimal rentalPrice = decimal.Parse(Console.ReadLine());

                    Console.WriteLine("8. Введите IssueDate:");
                    DateTime issueDate = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("9. Введите Specs:");
                    string specs = Console.ReadLine();

                    Console.WriteLine("10. Введите TechnicalMaintenanceDate:");
                    DateTime technicalMaintenanceDategNum = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("11. Введите SpecMark:");
                    bool specMark = bool.Parse(Console.ReadLine());

                    Console.WriteLine("12. Введите ReturnMarkMark:");
                    bool returnMark = bool.Parse(Console.ReadLine());

                    Cars car = new Cars
                    {
                        CarModelId = carModelId,
                        EmployeeId = employeeId,
                        RegNum = regNum,
                        Vincode = vinCode,
                        EngineNum = engineNum,
                        Price = price,
                        RentalPrice = rentalPrice,
                        IssueDate = issueDate,
                        Specs = specs,
                        TechnicalMaintenanceDate = technicalMaintenanceDategNum,
                        SpecMark = specMark,
                        ReturnMark = returnMark
                    };
                    db.Cars.Add(car);
                    db.SaveChanges();
                    Console.ReadKey();
                    break;
            }
        }
        static void Delete(car_sharingContext db, int num)
        {
            switch (num)
            {
                case 8:
                    Console.WriteLine("8. Введите наименование марки авто: ");
                    string name = Console.ReadLine();
                    var carModels = db.CarModels.Where(c => c.Name == name);
                    var cars = db.Cars.Include("CarModel").Where(o => (o.CarModel.Name == name));
                    db.CarModels.RemoveRange(carModels);
                    db.SaveChanges();
                    db.Cars.RemoveRange(cars);

                    db.SaveChanges();
                    Console.ReadKey();
                    break;
                case 9:
                    Console.WriteLine("9. Введите VINCode: ");
                    string vinCode = Console.ReadLine();
                    var car = db.Cars.Where(c => c.Vincode == vinCode);
                    db.Cars.RemoveRange(car);
                    db.SaveChanges();
                    Console.ReadKey();
                    break;
            }
        }
        static void Update(car_sharingContext db)
        {
            Console.WriteLine("9. Редактирование данных CarModels");
            Console.WriteLine("9. 1.Введите старое имя: ");
            string oldName = Console.ReadLine();

            Console.WriteLine("9. 2.Введите новое имя: ");
            string newName = Console.ReadLine();

            Console.WriteLine("9. 3.Введите описание: ");
            string description = Console.ReadLine();

            var carModel = db.CarModels.Where(c => c.Name == oldName).FirstOrDefault();
            if(carModel != null)
            {
                carModel.Name = newName;
                carModel.Description = description;
            }
            db.SaveChanges();
            Console.ReadKey();
        }
    }
}
