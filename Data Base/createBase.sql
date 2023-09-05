use master
drop database Store
create database Store

go 
use Store
go
create table UnitOfMeasurements(
 	[Id] int not null identity(1, 1) primary key,
	unitOfMeasurement nvarchar(100) not null
	);

go
create table Product(
 	[Id] int not null identity(1, 1) primary key,
	productName nvarchar(100) not null
	)

go
create table Client(
 	[Id] int not null identity(1, 1) primary key,
	clientName nvarchar(100) not null,
	isOurCompany bit not null,
	isDelete int not null
	)
go
create table Storage(
 	[Id] int not null identity(1, 1) primary key,
	productID int not null,
	countProducts int not null,
	sellingPrice int not null,
	purchasePrice int not null,
	unitOfMeasurementsID int not null
	foreign key (productID) references Product([Id]),
	foreign key (unitOfMeasurementsID) references UnitOfMeasurements([Id])
	)
go
create table Employee(
 	[Id] int not null identity(1, 1) primary key,
	fullName nvarchar(100) not null,
	jobTitle nvarchar(100) not null
	)
go

go 
create table ClientData(
 	[Id] int not null identity(1, 1) primary key,
	clientAddress nvarchar(100) not null,
	clientPhone nvarchar(100) not null,
	clientID int not null,
	isDelete int not null
	foreign key (clientID) references Client([Id])
	)

	
go
create table DealHat(
 	[Id] int not null identity(1, 1) primary key,
	dealDate DateTime not null,
	dealType nvarchar(100) not null,
	clientID int not null,
	employeeID int not null,
	isdelete int not null
	foreign key (clientID) references Client([Id]),
	foreign key (employeeID) references Employee([Id])
	)
go
create table Deal(

 	[Id] int not null identity(1, 1) primary key,
	countProducts int not null,
	price int not null,
	productID int not null,
	dealID int not null,
	unitOfMeasurementsID int not null,
	isdelete int not null

	foreign key (unitOfMeasurementsID) references UnitOfMeasurements([Id]),
	foreign key (productID) references Product([Id]),
	foreign key(dealID) references DealHat([Id])
	)



