CREATE DATABASE TravelDB
GO
USE TravelDB
GO

CREATE TABLE FlightTypes(
[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(50) NOT NULL,
)
GO
CREATE TABLE Cities(
[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(50) NOT NULL,
[Distance] MONEY NOT NULL,
)
GO
CREATE TABLE Schedules(  
[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[CityId] INT FOREIGN KEY REFERENCES Cities(Id) ON DELETE SET NULL,
[StartDateTime] DATE NOT NULL,
)
GO
CREATE TABLE Pilots(
[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(50) NOT NULL,
[Surname] NVARCHAR(50) NOT NULL,
)
GO
CREATE TABLE Airplanes(
[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(50) NOT NULL,
[PilotId] INT FOREIGN KEY REFERENCES Pilots(Id) ON DELETE SET NULL,
[ScheduleId] INT FOREIGN KEY REFERENCES Schedules(Id) ON DELETE SET NULL,
)
GO
CREATE TABLE Tickets(
[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[AirplaneId] INT FOREIGN KEY REFERENCES Airplanes(Id) ON DELETE SET NULL,
[FlightTypeId] INT FOREIGN KEY REFERENCES FlightTypes(Id) ON DELETE SET NULL,
[ScheduleId] INT FOREIGN KEY REFERENCES Schedules(Id) ON DELETE SET NULL,
)

GO

INSERT INTO FlightTypes([Name])
VALUES('Economic'),('Business'),('Premium')
GO
INSERT INTO Cities([Name],[Distance])
VALUES('Baku',2000),('Koln',3000),('Berlin',4000),('Antalya',5000),('Gence',3500)
GO
INSERT INTO Schedules([CityId],[StartDateTime])
VALUES(1,'01-01-2023'),(2,'10-03-2023'),(3,'03-04-2023'),(2,'05-05-2023'),(2,'03-12-2023'),(3,'12-05-2023'),(4,'04-07-2023'),(5,'05-09-2023'),(5,'03-23-2023')
GO
INSERT INTO Pilots([Name],[Surname])
VALUES('Vusal','Haciyev'),('Umid','Agayev'),('Yaver','Ismayilov')
GO
INSERT INTO Airplanes([Name],[PilotId],[ScheduleId])
VALUES('Azal',1,1),('Turk hava yollari',2,1),('Airfloat',2,2),('Azal',1,2),('Turk hava yollari',3,3),('Azal',2,4),('Airfloat',3,5),('Turk hava yollari',1,9),('Airfloat',2,6),('Azal',3,7),('Turk hava yollari',2,8),('Azal',2,8)
GO
INSERT INTO Tickets([AirplaneId],[FlightTypeId],[ScheduleId])
VALUES(1,1,1),(2,1,3),(3,2,2)
