--USE [Carrito];

CREATE DATABASE [Carrito];

GO

USE [Carrito]

GO

--create SCHEMA carrito;

GO

--drop table carrito.carrito;

--drop table carrito

create table carrito
(
    id int IDENTITY(1,1),
    fecha nvarchar(100),
    usuario nvarchar(100),
    pais nvarchar(3)
);

GO

--drop table carrito_producto

create table carrito_producto
(
    unique_key int identity(1,1),
    carrito_id int,
    id int,
    producto_fabricante nvarchar(100),
    producto_codigo nvarchar(100),
    producto_tipo_proveedor nvarchar(100),
    producto_codigo_proveedor nvarchar(100),
    producto_nombre nvarchar(100),
    producto_descripcion nvarchar(max),
    producto_categoria nvarchar(100),
    cantidad int,
    precio float,
    moneda nvarchar(3)
);

--insert into carrito values (getdate(),'carlosarangob@hotmail.com');

select * from carrito;

select * from carrito_producto;