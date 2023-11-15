Create table Employee
(
	code varchar(20) primary key,
	[password] varchar(20),
	[name] varchar(50),
	phone varchar(20),
	salary decimal(15,2),
	roles varchar(10)
)
insert into Employee values('E202201','123','Mai','0907698874', 500, 'admins')
insert into Employee values('E202202','123','Thuy','0907698844', 750, 'users')
insert into Employee values('E202203','123','Thu','0907698822', 800, 'users')
insert into Employee values('E202204','123','Thu','0907698822', 800, 'users')
insert into Employee values('E202205','123','Thu','0907698822', 800, 'users')
----------
select * from Employee