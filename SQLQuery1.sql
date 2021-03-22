use db
drop table tb_employee
create table tb_employee(empid int identity(1,1),empfirstname nvarchar(50) not null,
emplastname nvarchar(50) not null,
empemail nvarchar(50)unique,empdob nvarchar(50),Gender nvarchar(50) not null,
emppassword nvarchar(50) not null,
empconfirmpassword nvarchar(50)not null,primary key(empid))
select *from tb_employee
insert into tb_employee values('Vishnu','TS','vihnuvts1@gmail.com','14/10/1988','Male','vishnu123','vishnu123')
alter table tb_employee add Isactive bit default(1)
update tb_employee set Isactive=1 where empid=2