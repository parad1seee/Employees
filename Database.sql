CREATE DATABASE EmployeesDB;
USE EmployeesDB;

CREATE TABLE Employees (
	 Id INT PRIMARY KEY IDENTITY (1, 1),
	 Name VARCHAR(70) NOT NULL,
	 ManagerId INT,
	 Enabled BIT
);

INSERT INTO Employees (Name, ManagerId, Enabled)
VALUES 
	('Danil', 1, 1),
	('Andrey', 1, 0),
	('Artur', NULL, 1),
	('Egor', 1, 1),
	('Valera', 2, 0),
	('Artem', 4, 1),
	('Nik', NULL, 1),
	('Dima', 3, 0),
	('Sasha', 5, 0),
	('Vlad', 6, 0),
	('Pasha', 2, 1),
	('Misha', 7, 0)
