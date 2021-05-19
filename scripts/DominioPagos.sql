CREATE DATABASE PAGOS;
GO

USE PAGOS

GO
CREATE TABLE MediosPago (
Id INT IDENTITY,
DesMedioPago NVARCHAR(50),
IndEstadoMedioPago BIT 
);

GO
CREATE TABLE Pago (
Id INT IDENTITY,
MedioPago INT,
Valor DECIMAL (12,2),
CodMoneda NVARCHAR(3),
NumeroTarjeta NVARCHAR(16),
MesExpiracion NVARCHAR(2),
AnoExpiracion NVARCHAR(4),
CodCV NVARCHAR(3),
TipoTarjeta NVARCHAR(2),
NombreTItular NVARCHAR(80),
EMail NVARCHAR(50),
FechaPago DATETIME,
IndEstadoPago BIT
);

GO
INSERT INTO MediosPago VALUES ('PSE',1)
INSERT INTO MediosPago VALUES ('TARJETA DE CRÉDITO',2)

GO
INSERT INTO Pago VALUES (1,356000,'COP','4000000000000002','02','2025','155','VI','Alberto Rafael Algarin Marino','alberto.algarin@javeriana.edu.co',DATEADD(hh,-5,DATEADD(yy,-1,GETDATE())),1)
INSERT INTO Pago VALUES (2,1445454.1,'COP','4000000000000003','03','2027','888','MC','Carlos Alberto Arango Buitrago','carlos.arango@javeriana.edu.co',DATEADD(hh,-5,DATEADD(mm,-1,GETDATE())),1)
INSERT INTO Pago VALUES (3,15000,'COP','4000000000000004','04','2026','987','MC','Eduard Rafael Torres Cueto','eduard.torres@javeriana.edu.co',DATEADD(hh,-5,DATEADD(yy,-2,GETDATE())),1)
INSERT INTO Pago VALUES (4,99000000,'COP','4000000000000005','05','2027','232','VI','Carolina Jimenez Arboleda','carolina.jimenez@javeriana.edu.co',DATEADD(hh,-5,DATEADD(mm,-10,GETDATE())),1)
INSERT INTO Pago VALUES (5,999000000,'COP','4000000000000006','06','2029','555','AE','Jhon Alexander Pineda Arias','jhon.pineda@javeriana.edu.co',DATEADD(hh,-5,DATEADD(mm,-2,GETDATE())),1)

GO
SELECT * FROM MediosPago
SELECT * FROM Pago