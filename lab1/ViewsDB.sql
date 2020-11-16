use car_sharing
go



CREATE VIEW [dbo].[View_Cars]
AS
select
	Name,
	Description,
	RegNum,
	VINCode,
	EngineNum,
	Specs,
	TechnicalMaintenanceDate,
	IssueDate
from  CarModels join Cars on Cars.CarModelId = CarModels.CarModelId
GO

CREATE VIEW [dbo].[View_Employees_Cars_CarModels]
AS
select 
	Post,
	Employees.Name as EmployeesName,
	Surname,
	Patronymic,
	CarModels.Name as CarModelName,
	Description,
	RegNum,
	VINCode,
	EngineNum,
	Specs,
	TechnicalMaintenanceDate,
	IssueDate
from Employees join Cars on Employees.EmployeeId = Cars.EmployeeId join CarModels on Cars.CarModelId = CarModels.CarModelId
go

create view [dbo].[View_Rents_Services]
AS
select
	Rents.Price as RentsPrice,
	Services.Price as ServicePrice,
	ReturnDate ,
	DeliveryDate,
	Description,
	Name
	from Rents inner join AdditionalServices on Rents.RentId = AdditionalServices.RentId inner join Services on AdditionalServices.ServiceId = Services.ServiceId
go