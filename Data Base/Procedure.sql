use Store

go
create procedure Get_ListOfEmployees
as
select Employee.fullName as'���', Employee.jobTitle as'���������', Employee.Id as'��� ����������'
From Employee


go
create procedure Get_ListOfProducts
as

select  [dbo].[Product].productName as'�������� ������', UnitOfMeasurements.unitOfMeasurement as'������� ���������',Storage.countProducts as '���-��',Storage.purchasePrice as'���� �������', Storage.sellingPrice as '���� �������',Product.id as'��� ������',UnitOfMeasurements.id as '��� ������� ���������'
from [dbo].[Product] join Storage 
on product.Id=Storage.productID join  UnitOfMeasurements
on Storage.unitOfMeasurementsID= UnitOfMeasurements.Id


go
create procedure Get_ListOfOrg
as
select Client.id as '��� �����������', Client.clientName as'�������� �����������',ClientData.clientAddress as'�����',ClientData.clientPhone as'�������'
from Client join ClientData 
on Client.Id=ClientData.Id
where client.isOurCompany=0 and Client.isDelete=1;


go
create procedure ADD_org
@orgName nvarchar(100),
@orgAddress nvarchar(100),
@orgPhone nvarchar(100)
as
insert into Client
values(@orgName,0,1)

declare @clientId int
select @clientId= Client.id
from Client
where client.clientName=@orgName

insert into ClientData
values(@orgAddress, @orgPhone, @clientId,1);


go
create procedure DELETE_org
@orgId int
as
update Client
set isDelete=0
where client.id=@orgId;

update ClientData
set isDelete=0
where clientdata.clientID=@orgId

go
create procedure EDIT_org
@orgId int,
@orgName nvarchar(100),
@orgAddress nvarchar(100),
@orgPhone nvarchar(100)
as
update Client
set client.clientName=@orgName
where client.id=@orgId


update ClientData
set clientData.clientAddress=@orgAddress,
    clientData.clientPhone=@orgPhone
	where clientData.clientid=@orgId

go 
create procedure Get_Report
as

Select DealHat.Id as'����� ��������',DealHat.dealDate as'���� ��������',Client.clientName as'��������', Employee.fullName as'��������',DealHat.dealType as'��� ������'
From DealHat join Employee
on dealhat.employeeID = employee.id join client
on client.Id=DealHat.clientID

go
create procedure Get_InfoReport
@dealId int
as

Select  Product.productName as'������������',deal.countProducts as'���-��',UnitOfMeasurements.unitOfMeasurement as '�������� ������� ���������',deal.price as'����',deal.price*deal.countProducts as'C����'
From deal join Product 
on Product.Id=deal.productID join UnitOfMeasurements
on UnitOfMeasurements.Id=deal.unitOfMeasurementsID
where deal.dealId=@dealid 


go
create procedure Fill_DealHat
@dealDate datetime,
@dealType nvarchar(100),
@clientId int,
@employeeId int,
@dealHatId int output
as
begin
set dateformat dmy
insert into DealHat
values(@dealDate,@dealType,@clientId,@employeeId,1);
select @dealHatId=dealHat.id
from DealHat
where DealHat.dealDate=@dealDate

end;

go 
create procedure Fill_Deal
@countProducts int,
@price int,
@productID int,
@dealHatID int,
@unitOfMeasurementsID int
as
insert into deal
values(@countProducts,@price,@productID,@dealHatID,@unitOfMeasurementsID,1);





go
create procedure Get_UnitOfMeasurements

as
select unitOfMeasurements.Id as '��� ������� ���������', unitOfMeasurements.unitOfMeasurement as '�������� ������� ���������'
From UnitOfMeasurements



go
create procedure Get_Product

as
select Product.Id as '��� ��������', Product.productName as '������������ ��������'
From Product


go
create procedure EDIT_countProducts
@productID int,
@countProducts int
as
update Storage
set countProducts = @countProducts
where Storage.Id = @productID






