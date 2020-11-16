use car_sharing
go

create procedure sp_InsertCars
	@CarModelId int,
	@RegNum int,
	@EngineNum int,
	@EmployeeId int,
	@VINCode varchar(20),
	@Price money,
	@RentalPrice money,
	@IssueDate datetime,
	@Specs varchar(200),
	@TechnicalMaintenanceDate datetime,
	@SpecMark bit,
	@ReturnMark bit
as 
	INSERT INTO dbo.Cars (CarModelId, RegNum, VINCode, EngineNum, Price, RentalPrice, IssueDate, Specs, TechnicalMaintenanceDate, SpecMark, ReturnMark, EmployeeId)
	select
		@CarModelId ,
		@RegNum ,
		@EngineNum ,
		@VINCode ,
		@Price ,
		@RentalPrice ,
		@IssueDate ,
		@Specs ,
		@TechnicalMaintenanceDate ,
		@SpecMark ,
		@ReturnMark ,
		@EmployeeId
go

create procedure sp_UpdateCars
	@CarModelId int,
	@RegNum int,
	@EngineNum int,
	@EmployeeId int,
	@VINCode varchar(20),
	@Price money,
	@RentalPrice money,
	@IssueDate datetime,
	@Specs varchar(200),
	@TechnicalMaintenanceDate datetime,
	@SpecMark bit,
	@ReturnMark bit,
	@CarId int
as 
update dbo.Cars
	set 
	dbo.Cars.CarModelId = @CarModelId,
	dbo.Cars.RegNum =	@RegNum ,
	dbo.Cars.EngineNum = @EngineNum ,
	dbo.Cars.EmployeeId = @EmployeeId ,
	dbo.Cars.VINCode =	@VINCode ,
	dbo.Cars.Price = @Price ,
	dbo.Cars.RentalPrice = @RentalPrice ,
	dbo.Cars.IssueDate = @IssueDate ,
	dbo.Cars.Specs = @Specs,
	dbo.Cars.TechnicalMaintenanceDate = @TechnicalMaintenanceDate ,
	dbo.Cars.SpecMark = @SpecMark ,
	dbo.Cars.ReturnMark =  @ReturnMark 
	where dbo.Cars.CarId = @CarId
go

create procedure sp_InsertCarModels
	@CarModelName varchar(20),
	@CarModelDescription varchar(1000)
as
	INSERT INTO dbo.CarModels(Name,Description)
	select
		@CarModelName,
		@CarModelDescription
go

