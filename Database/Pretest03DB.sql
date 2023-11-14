create database NewsDB
use NewsDB
------
create table tbNews
(
	NewsId varchar(10) primary key,
	NewsContent varchar(356),
	DateOfPublish varchar(20),
)

insert into tbNews values('News202301','Microsoft','2023-10-03')
insert into tbNews values('News202302','Microsoft','2023-10-03')
insert into tbNews values('News202303','Microsoft','2023-10-03')
----------
select * from tbNews