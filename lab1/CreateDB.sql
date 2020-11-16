use master
Drop database car_sharing
go
create database car_sharing
GO
ALTER DATABASE car_sharing SET RECOVERY SIMPLE
GO
use car_sharing

create table Employees
(
  EmployeeId INT PRIMARY KEY IDENTITY(1,1),
  Post varchar(20),
  Name varchar(20),
  Surname varchar(20),
  Patronymic varchar(20),
  EmploymentDate datetime
)
create table CarModels
(
  CarModelId INT PRIMARY KEY IDENTITY(1,1),
  Name varchar(20),
  Description varchar(1000)
)
create table Cars
(
  CarId INT PRIMARY KEY IDENTITY(1,1),
  CarModelId int references CarModels(CarModelId),
  RegNum int,
  VINCode varchar(20),
  EngineNum int,
  Price money,
  RentalPrice money,
  IssueDate datetime,
  Specs varchar(200),
  TechnicalMaintenanceDate datetime,
  SpecMark bit,
  ReturnMark bit,
  EmployeeId int references Employees(EmployeeId)
)
create table Customers
(
  CustomerId INT PRIMARY KEY IDENTITY(1,1),
  Name varchar(20),
  Surname varchar(20),
  Patronymic varchar(20),
  PhoneNum varchar(13),
  Address varchar (60),
  BirthDate datetime,
  PassportInfo varchar(20),
  Gender bit
)

create table Rents
(
  RentId INT PRIMARY KEY IDENTITY(1,1),
  ReturnDate datetime,
  DeliveryDate datetime,
  CarId int references Cars(CarId),
  CustomerId int references Customers(CustomerId),
  EmployeeId int references Employees(EmployeeId),
  Price money
)
create table Services
(
  ServiceId INT PRIMARY KEY IDENTITY(1,1),
  Name varchar(20),
  Price money,
  Description varchar(100)
)
create table AdditionalServices
(
  Id INT PRIMARY KEY IDENTITY(1,1),
  RentId  int references  Rents(RentId),
  ServiceId int references Services(ServiceId)
)
