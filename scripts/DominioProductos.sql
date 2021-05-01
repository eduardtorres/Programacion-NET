CREATE DATABASE [Productos];

GO

USE [Productos]

GO

drop table Productos
create table Productos
(
    Id int,
    Codigo nvarchar(100),
    Fabricante nvarchar(100),
    TipoProveedor nvarchar(100),
    CodigoProveedor nvarchar(100),
    Nombre nvarchar(100),
    Descripcion nvarchar(100),
    Categoria nvarchar(100),
    Precio float,
    Inventario int
);

GO

insert into productos values
    (   1,
        'NS',
        'NINTENDO',
        'Local',
        'Local',
        'Nintendo Switch',
        'Portable',
        'Consolas',
        900000,
        0);

GO

select * from productos;