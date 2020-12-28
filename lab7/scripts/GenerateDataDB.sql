use car_sharing
go


DECLARE @Letters CHAR(52) = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz',
		@VINLetters char(62) = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890',
		@i int,
		@Position int,
		@RowCount int,
		@RowIndex int,
		@MinLetters int,
		@MaxLetters int,
		@LettersLimit int,

		-- ������� "CarModels".
		@CarModelName varchar(20),
		@CarModelDescription varchar(1000),
		
		-- ������� "Cars".
		@CarModelId int,
		@CarRegNum int,
		@CarEngineNum int,
		@CarEmployeeId int,
		@CarVINCode varchar(20),
		@CarPrice money,
		@CarRentalPrice money,
		@CarIssueDate datetime,
		@CarSpecs varchar(200),
		@CarTechnicalMaintenanceDate datetime,
		@CarSpecMark bit,
		@CarReturnMark bit,


		-- ������� "Employees".
		@EmployeePost varchar(20),
		@EmployeeName varchar(20),
		@EmployeeSurname varchar(20),
		@EmployeePatronymic varchar(20),
		@EmployeeEmploymentDate datetime
		
SET NOCOUNT ON

-- ������� "CarModels".
SET @RowCount = 500
SET @RowIndex = 1

WHILE @RowIndex <= @RowCount
BEGIN
	-- �������� ������ ����.
	SET @MaxLetters = 20
	SET @MinLetters = 4

	SET @LettersLimit = @MinLetters + RAND()*(@MaxLetters - @MinLetters)
	SET @i = 1
	SET @CarModelName = ''
	WHILE @i <= @LettersLimit
	BEGIN
		SET @Position = RAND()*52
		SET @CarModelName = @CarModelName + SUBSTRING(@Letters, @Position, 1)
		SET @i += 1
	END

	-- �������� ������ ����
	SET @MaxLetters = 1000
	SET @MinLetters = 50

	SET @LettersLimit = @MinLetters + RAND()*(@MaxLetters - @MinLetters)
	SET @i = 1
	SET @CarModelDescription = ''
	WHILE @i <= @LettersLimit
	BEGIN
		SET @Position = RAND()*52
		SET @CarModelDescription = @CarModelDescription + SUBSTRING(@Letters, @Position, 1)
		SET @i += 1
	END
	--������� ������ � �������
	INSERT INTO CarModels (Name, Description) VALUES (@CarModelName, @CarModelDescription)

	SET @RowIndex += 1
END

-- ������� "Employees".
SET @RowCount = 500
SET @RowIndex = 1

WHILE @RowIndex <= @RowCount
BEGIN
	--��������� ����������.
	SET @MaxLetters = 20
	SET @MinLetters = 2

	SET @LettersLimit = @MinLetters + RAND()*(@MaxLetters - @MinLetters)
	SET @i = 1
	SET @EmployeePost = ''
	WHILE @i <= @LettersLimit
	BEGIN
		SET @Position = RAND()*52
		SET @EmployeePost = @EmployeePost + SUBSTRING(@Letters, @Position, 1)
		SET @i += 1
	END

	--��� ����������
	SET @MaxLetters = 20
	SET @MinLetters = 2

	SET @LettersLimit = @MinLetters + RAND()*(@MaxLetters - @MinLetters)
	SET @i = 1
	SET @EmployeeName = ''
	WHILE @i <= @LettersLimit
	BEGIN
		SET @Position = RAND()*52
		SET @EmployeeName = @EmployeeName + SUBSTRING(@Letters, @Position, 1)
		SET @i += 1
	END
	--������� ����������
	SET @MaxLetters = 20
	SET @MinLetters = 2

	SET @LettersLimit = @MinLetters + RAND()*(@MaxLetters - @MinLetters)
	SET @i = 1
	SET @EmployeeSurname = ''
	WHILE @i <= @LettersLimit
	BEGIN
		SET @Position = RAND()*52
		SET @EmployeeSurname = @EmployeeSurname + SUBSTRING(@Letters, @Position, 1)
		SET @i += 1
	END

	--�������� ����������
	SET @MaxLetters = 20
	SET @MinLetters = 2

	SET @LettersLimit = @MinLetters + RAND()*(@MaxLetters - @MinLetters)
	SET @i = 1
	SET @EmployeePatronymic = ''
	WHILE @i <= @LettersLimit
	BEGIN
		SET @Position = RAND()*52
		SET @EmployeePatronymic = @EmployeePatronymic + SUBSTRING(@Letters, @Position, 1)
		SET @i += 1
	END


	--��������� ��� ���������������
	-- ���� ������.
	SET @EmployeeEmploymentDate = dateadd(DAY, -(RAND()*(1000 - 100)+100), GETDATE())
	

	--������� ������ � �������
	INSERT INTO Employees(Post, Name, Surname, Patronymic, EmploymentDate) VALUES (@EmployeePost, @EmployeeName, @EmployeeSurname, @EmployeePatronymic, @EmployeeEmploymentDate)

	SET @RowIndex += 1
END

-- ������� "CarModels".
SET @RowCount = 20000
SET @RowIndex = 1
WHILE @RowIndex <= @RowCount
BEGIN
	--ID ����
	SET @CarModelId = RAND()*(501-1)+1
	--��������������� �����
	SET @CarRegNum = RAND()*(2000000000-1000000000)+1000000000
	--VIN-���
	SET @MaxLetters = 20
	SET @MinLetters = 4

	SET @LettersLimit = @MinLetters + RAND()*(@MaxLetters - @MinLetters)
	SET @i = 1
	SET @CarVINCode = ''
	WHILE @i <= @LettersLimit
	BEGIN
		SET @Position = RAND()*62
		SET @CarVINCode = @CarVINCode + SUBSTRING(@VINLetters, @Position, 1)
		SET @i += 1
	END
	--����� ���������
	SET @CarEngineNum = RAND()*(100000000-10000000)+10000000
	--����
	SET @CarPrice=CONVERT(MONEY,RAND()*(2000000 - 150000)+150000)
	--���� ������
	SET @CarRentalPrice=CONVERT(MONEY,RAND()*(10000 - 1500)+1500)
	--��� �������(Issue date)
	SET @CarIssueDate = dateadd(DAY, -(RAND()*(10000 - 200)+200), GETDATE())
	--��������������
	SET @MaxLetters = 200
	SET @MinLetters = 21

	SET @LettersLimit = @MinLetters + RAND()*(@MaxLetters - @MinLetters)
	SET @i = 1
	SET @CarSpecs = ''
	WHILE @i <= @LettersLimit
	BEGIN
		SET @Position = RAND()*62
		SET @CarSpecs = @CarSpecs + SUBSTRING(@Letters, @Position, 1)
		SET @i += 1
	END
	--���� ���������� ��
	SET @CarTechnicalMaintenanceDate = dateadd(DAY, -(RAND()*(1000 - 100)+100), GETDATE())
	--����������� �����
	SET @CarSpecMark=CONVERT(bit,round(1*rand(),0))
	--����� � ���������
	SET @CarReturnMark=CONVERT(bit,round(1*rand(),0))
	--ID ����������
	SET @CarEmployeeId = RAND()*(501-1)+1
	INSERT INTO Cars (CarModelId, RegNum, VINCode, EngineNum, Price, RentalPrice, IssueDate, Specs, TechnicalMaintenanceDate, SpecMark, ReturnMark, EmployeeId) VALUES (@CarModelId, @CarRegNum, @CarVINCode, @CarEngineNum, @CarPrice, @CarRentalPrice, @CarIssueDate, @CarSpecs, @CarTechnicalMaintenanceDate, @CarSpecMark, @CarReturnMark, @CarEmployeeId)

	SET @RowIndex += 1
END
