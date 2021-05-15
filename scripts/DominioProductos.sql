CREATE DATABASE [Productos];

GO

USE [Productos]

GO

--drop table Productos
create table Productos
(
    Id int,
    Codigo nvarchar(100),
    Fabricante nvarchar(100),
    TipoProveedor nvarchar(100),
    CodigoProveedor nvarchar(100),
    Nombre nvarchar(100),
    Descripcion nvarchar(max),
    Categoria nvarchar(100),
    UrlImagen nvarchar(100),
    Precio float,
    Moneda nvarchar(3),
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
        '1.png',
        900000,
        'COP',
        0);

GO

insert into productos values
    (   2,
        'XBO',
        'Microsoft',
        'Local',
        'Local',
        'Xbox one',
        'Consla de Mesa',
        'Consolas',
        '2.png',
        1100000,
        'COP',
        0);

GO

insert into productos values
    (   3,
        'PS5',
        'Sony',
        'Local',
        'Local',
        'Play Station 5',
        'Consla de Mesa',
        'Consolas',
        '3.png',
        1100000,
        'COP',
        0);

GO

select * from productos;