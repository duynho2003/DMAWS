create database EmployeeDB
use EmployeeDB
------
create table tblEmp
(
	EmpID varchar(10) primary key,
	FirstName varchar(20),
	LastName varchar(20),
	[Password] varchar(20),
	Salary float
)

insert into tblEmp values('E01','Tommy','Nguyen','123','8000')
insert into tblEmp values('E02','Mi','Nguyen','123','6000')
insert into tblEmp values('E03','Na','Nguyen','123','4000')
----------
select * from tblEmp