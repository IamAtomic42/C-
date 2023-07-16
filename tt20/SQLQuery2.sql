create database TaiKhoan
go
use TaiKhoan
go



	create table Member
(
	MemberID int identity(1,001) primary key,
	AccountName varchar(30),
	Password varchar(30),
	GroupUser nvarchar(30) ,
	CurrentTime time,
	CurrentMoney float,
	StatusAccount nvarchar(30)
)
create table TK
(
	AccountName varchar(30) primary key,
	Password varchar(30),
	MoneyT float,
)
insert into TK values ('DragonSilver','1230410',20000)
insert into TK  values ('Seraphim','123', 28000)
insert into TK  values ('0961563202','123',12000)
insert into TK  values ('heavenhell8899','123',40000)
insert into TK  values ('abc','123',0)
insert into TK  values ('xyz','123',60000)
insert into TK  values ('tikitaka','123',0)
insert into TK  values ('barca','123',0)
insert into TK  values ('realmadrid','123',0)
insert into TK  values ('Calomama','123',36000)
insert into TK  values ('haivl','123',48000)
insert into TK  values ('xemvn','123',32000)
insert into TK  values ('facebook','123',28000)

insert into Member values ('DragonSilver','1230410',N'Hội viên','5:00',20000,N'Cho Phép')
insert into Member values ('Seraphim','123',N'Hội viên','7:00',28000,N'Cho Phép')
insert into Member values ('0961563202','123',N'Hội viên','3:00',12000,N'Cho Phép')
insert into Member values ('heavenhell8899','123',N'Hội viên','10:00',40000,N'Cho Phép')
insert into Member values ('abc','123',N'Hội viên','0:00',0,N'Hết Thời Gian')
insert into Member values ('xyz','123',N'Hội viên','15:00',60000,N'Cho Phép')
insert into Member values ('tikitaka','123',N'Hội viên','0:00',0,N'Hết Thời Gian')
insert into Member values ('barca','123',N'Hội viên','0:00',0,N'Hết Thời Gian')
insert into Member values ('realmadrid','123',N'Hội viên','0:00',0,N'Hết Thời Gian')
insert into Member values ('Calomama','123',N'Hội viên','9:00',36000,N'Cho Phép')
insert into Member values ('haivl','123',N'Hội viên','12:00',48000,N'Cho Phép')
insert into Member values ('xemvn','123',N'Hội viên','8:00',32000,N'Cho Phép')
insert into Member values ('facebook','123',N'Hội viên','7:00',28000,N'Cho Phép')



