create database NewsDB
use NewsDB
------
create table tbNews
(
	NewsId varchar(10) primary key,
	NewsContent varchar(356),
	DateOfPublish varchar(20),
)

insert into tbNews values('N01','Microsoft Windows 7','2009-10-22')
insert into tbNews values('N02','Mac OS X Snow Leopard','2009-08-28')
insert into tbNews values('N03','Windows 11','2021-10-05')
----------
select * from tbNews