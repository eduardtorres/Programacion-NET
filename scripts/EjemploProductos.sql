CREATE DATABASE PICA;

GO

USE [PICA];

GO

create table productos
(
    Id int,
    Nombre nvarchar(100)
);

GO


insert into productos values(1,'Nintendo Switch');
insert into productos values(2,'Play station 5');
insert into productos values(3,'Xbox One');

GO

select * from productos;