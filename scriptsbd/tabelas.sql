CREATE TABLE Person
(
	Id int identity(1,1),
	Name varchar(50), 
	Document varchar(20),
	Phone varchar(20),
	DateBirthday datetime
)
GO

CREATE TABLE PersonAddress
(
	Id int identity(1,1),
	PersonId int,
	Street varchar(150),
	Neighborhood varchar(50),
	City varchar(100),
	PostalCode varchar(20),
	Country varchar(50)
) 