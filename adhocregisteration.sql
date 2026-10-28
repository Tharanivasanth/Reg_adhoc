create database register

create table tbl_reg(
Id int primary key identity(1000,1),
Name varchar(100) Not null,
Qualification varchar(100),
Age int,
Mobile varchar(100) unique,
Email varchar(100))

create procedure sp_GetAll
as 
begin
select * from tbl_reg
end

create procedure sp_GetId
@Id int
as 
begin
select * from tbl_reg where Id=@Id
end

create procedure sp_Delete
@Id int
as 
begin
Delete from tbl_reg where Id=@Id
end

create procedure sp_Insert
(@Name varchar(100) ,
@Qualification varchar(100),
@Age int,
@Mobile varchar(100),
@Email varchar(100))
as 
begin
insert into tbl_reg(Name ,
Qualification ,
Age ,
Mobile ,
Email ) values(@Name ,
@Qualification ,
@Age ,
@Mobile ,
@Email)
end


create procedure sp_Update
(@Id int,@Name varchar(100) ,
@Qualification varchar(100),
@Age int,
@Mobile varchar(100),
@Email varchar(100))
as 
begin
Update tbl_reg set 
Name = @Name,
Qualification =@Qualification,
Age = @Age,
Mobile = @Mobile,
Email = @Email  where Id=@Id
end
