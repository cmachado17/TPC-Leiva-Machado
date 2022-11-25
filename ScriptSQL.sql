CREATE DATABASE CALLCENTER 
GO
USE CALLCENTER
GO
CREATE TABLE TipoIncidencias(
	ID INT PRIMARY KEY IDENTITY (1,1),
	Descripcion VARCHAR(100) NOT NULL,
	Estado bit NOT NULL
)
GO
CREATE TABLE PrioridadIncidencias(
	ID INT PRIMARY KEY IDENTITY (1,1),
	Descripcion VARCHAR(100) NOT NULL,
	Estado bit NOT NULL
)
GO
CREATE TABLE EstadoIncidencias(
	ID INT PRIMARY KEY IDENTITY (1,1),
	Descripcion VARCHAR(100) NOT NULL
)
GO
CREATE TABLE Clientes(
	ID INT PRIMARY KEY IDENTITY (1,1),
	Nombres VARCHAR(50) NOT NULL,
	Apellidos VARCHAR(50) NOT NULL,
	DNI VARCHAR(25) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	Telefono VARCHAR(50) NOT NULL,
	FechaDeAlta datetime NOT NULL,
	FechaDeBaja datetime,
	Activo bit NOT NULL
)
GO
CREATE TABLE Perfiles(
	ID INT PRIMARY KEY IDENTITY (1,1),
	Descripcion VARCHAR(100) NOT NULL
)
GO
CREATE TABLE Empleados(
	ID INT PRIMARY KEY IDENTITY (1,1),
	Nombres VARCHAR(50) NOT NULL,
	Apellidos VARCHAR(50) NOT NULL,
	DNI VARCHAR(50) NOT NULL,
	URLImagen VARCHAR(100) NULL,
	Email VARCHAR(50) NOT NULL,
	Telefono VARCHAR(50) NOT NULL,
	IdPerfil INT NOT NULL FOREIGN KEY REFERENCES Perfiles (ID),
	FechaDeAlta datetime NOT NULL,
	FechaDeBaja datetime NULL,
	Clave int NOT NULL,
	Activo bit NOT NULL
)
GO
CREATE TABLE Motivos(
	ID INT PRIMARY KEY IDENTITY (1,1),
	Descripcion VARCHAR(100) NOT NULL,
	Estado bit NOT NULL
)
GO
CREATE TABLE Incidentes(
	ID INT PRIMARY KEY IDENTITY (1,1),
	IdTipoIncidencia INT NOT NULL FOREIGN KEY REFERENCES TipoIncidencias (ID),
	IdPrioridad INT NOT NULL FOREIGN KEY REFERENCES PrioridadIncidencias (ID),
	Problematica TEXT NOT NULL,
	IdEstado INT NOT NULL FOREIGN KEY REFERENCES EstadoIncidencias (ID),
	IdCliente INT NOT NULL FOREIGN KEY REFERENCES Clientes (ID),
	IdEmpleado INT NOT NULL FOREIGN KEY REFERENCES Empleados (ID),
	Comentario VARCHAR(100),
	IdMotivo INT NULL FOREIGN KEY REFERENCES Motivos (ID),
	FechaDeAlta datetime NOT NULL,
	FechaDeBaja datetime,
	Activo bit NOT NULL
)

USE CALLCENTER
GO

insert into CALLCENTER.dbo.Clientes(Nombres, Apellidos, DNI, Email, Telefono, FechaDeAlta,Activo) 
VALUES 
('Juan', 'Perez', '123','juanperez@gmail.com', '011445566',getdate(),1),
('Carlos', 'Gomez', '345','carlosgomez@gmail.com', '011557788', getdate(),1),
('Pedro', 'Martinez', '678','pedromartinez@gmail.com', '011778899', getdate(),1)

insert into CALLCENTER.dbo.EstadoIncidencias(Descripcion) 
VALUES 
('Abierto'),
('En analisis'),
('Cerrado'),
('Reabierto'),
('Asignado'),
('Resuelto')

insert into CALLCENTER.dbo.Perfiles(Descripcion) 
VALUES 
('Administrador'),
('Telefonista'),
('Supervisor')

insert into CALLCENTER.dbo.PrioridadIncidencias(Descripcion, Estado) 
VALUES 
('Alta',1),
('Media',1),
('Baja',1)

insert into CALLCENTER.dbo.TipoIncidencias(Descripcion, Estado) 
VALUES 
('Error',1),
('Consulta',1),
('Reclamo',1),
('Sugerencia',1)

insert into CALLCENTER.dbo.Empleados(Nombres, Apellidos, DNI, Email, Telefono, IdPerfil, FechaDeAlta,Clave,  Activo) 
VALUES 
('Antonio', 'Ramirez', '11222333','antonioramirez@gmail.com','1120204040', 1, getdate(), 123,1),
('Manuel', 'Giordano', '22445550', 'manuelgiordano@gmail.com','1130303030',2, getdate(), 123,1),
('Cecilia', 'Ledesma', '20304050', 'cecilialedesma@gmail.com','1150502020',3, getdate(), 123,1)

insert into CALLCENTER.dbo.Motivos(Descripcion, Estado) 
VALUES 
('Cancelado',1),
('Vencido',1),
('Otros',1)

use CALLCENTER
GO

CREATE PROCEDURE sp_listar_Clientes
as begin
Select Id, Nombres, Apellidos,DNI, Email, Telefono, FechaDeAlta, FechaDeBaja, Activo
from Clientes
end

go
CREATE PROCEDURE sp_listar_Estados
as begin
select Id, Descripcion from EstadoIncidencias
end

go
CREATE PROCEDURE sp_listar_Prioridad
as begin
select Id, Descripcion, Estado from PrioridadIncidencias
end

go
CREATE PROCEDURE sp_listar_TiposInc
as begin
select Id, Descripcion, Estado from TipoIncidencias
end

go
CREATE PROCEDURE sp_listar_Motivos
as begin
select Id, Descripcion, Estado from Motivos
end

go
CREATE PROCEDURE sp_listar_Perfiles
as begin
select Id, Descripcion from Perfiles
end

go
CREATE PROCEDURE sp_listar_Empleados
as begin
select E.Id, Nombres, Apellidos, DNI, Email,Telefono, P.ID as 'IdPerfil', P.Descripcion as 'Perfil',
FechaDeAlta, FechaDeBaja, Activo
from Empleados as E
inner join Perfiles as P on E.IdPerfil = P.Id
end


go
CREATE PROCEDURE sp_Agregar_Cliente (@Nombres varchar(50), @Apellidos varchar(50),
@DNI varchar(25), @Email varchar(50), @Telefono varchar(50))
as begin
insert into Clientes values (@Nombres, @Apellidos,@DNI, @Email, @Telefono, getdate(), null, 1)
end

go
CREATE PROCEDURE sp_modificar_cliente 
(@id int, @nombre VARCHAR(50), @apellido VARCHAR(50), @dni VARCHAR(50), @email VARCHAR(50),
@telefono varchar(50))
AS
BEGIN
	UPDATE Clientes set Nombres = @nombre,
	Apellidos = @apellido,
	DNI = @dni,
	email = @email,
	Telefono = @telefono
	WHERE ID = @id
END
GO

CREATE PROCEDURE sp_Agregar_Empleado
(@Nombres varchar(50), @Apellidos varchar(50),
@DNI varchar(25), @Email varchar(50), @Telefono int, @Perfil INT, @Clave int)
AS
BEGIN
	insert into Empleados values (@Nombres, @Apellidos,@DNI,NULL, @Email, @Telefono, @Perfil, getdate(),null, @Clave, 1)
END
GO

CREATE PROCEDURE SP_Modificar_Empleados
(@Id INT,@Email varchar(50), @Telefono varchar(50), @Perfil INT)
AS
BEGIN
	UPDATE Empleados set 
	email = @Email,
	Telefono = @Telefono,
	IdPerfil = @Perfil
	WHERE ID = @id
END


go
CREATE PROCEDURE SP_ListarEmpleado_PorId (@Id int) as
Select E.Id, Nombres, Apellidos,DNI,URLImagen,Email,Telefono, IdPerfil, FechaDeAlta, FechaDeBaja, Activo, Descripcion from Empleados E
INNER JOIN Perfiles P ON P.ID = E.IdPerfil where E.Id = @Id

GO
CREATE PROCEDURE sp_Login (@user varchar(50), @pass int) as
Select Id, Email, Clave from Empleados
where email = @user and Clave = @pass

GO
CREATE PROCEDURE sp_Agregar_Incidencia
(@IdTipo INT,
@Prioridad INT,
@Problematica TEXT,
@Cliente int, 
@Empleado INT)
AS
BEGIN
	INSERT INTO Incidentes (IdTipoIncidencia, 
	IdPrioridad, 
	Problematica, 
	IdEstado, 
	IdCliente, 
	IdEmpleado, 
	FechaDeAlta, 
	Activo)
	OUTPUT Inserted.Id
	VALUES
	(@IdTipo, @Prioridad,@Problematica, 1, @Cliente, @Empleado, getdate(), 1)
END

GO
CREATE PROCEDURE sp_listar_Incidentes
as begin
select INC.Id,
INC.IdTipoIncidencia,
TI.Descripcion 'Tipo', 
INC.IdPrioridad,
PRI.descripcion 'Prioridad',
INC.Problematica,
INC.IdEstado, 
EI.Descripcion 'Estado', 
INC.IdCliente,
concat(CL.Nombres, ', ', CL.Apellidos) as 'Cliente', 
CL.DNI 'DNICliente',
CL.Email 'EmailCliente', 
CL.Telefono 'TelefonoCliente', 
INC.IdEmpleado,
concat(E.Apellidos, ', ', E.Nombres) as 'EmpleadoAsignado',
INC.Comentario,
M.Descripcion as 'Motivo',
INC.FechaDeAlta,
INC.FechaDeBaja,
INC.Activo
from Incidentes INC 
LEFT JOIN TipoIncidencias TI ON TI.ID = INC.IdTipoIncidencia 
LEFT JOIN PrioridadIncidencias PRI ON PRI.Id = INC.IdPrioridad 
LEFT JOIN EstadoIncidencias EI ON EI.ID = INC.IdEstado 
LEFT JOIN Clientes CL ON CL.id = INC.idCliente 
LEFT JOIN Empleados as E ON E.ID = INC.IdEmpleado
LEFT JOIN Motivos as M ON M.ID = INC.IdMotivo
end

go
CREATE PROCEDURE sp_modifica_incidente_analisis
(@Id INT, @Problematica TEXT)
as begin
UPDATE Incidentes 
SET Problematica = @Problematica,
IdEstado = 2
WHERE ID = @ID
end

GO
CREATE PROCEDURE sp_Resolver_Incidencia
(@Id INT, @Comentario VARCHAR(100))
as begin
UPDATE Incidentes 
SET Comentario = @Comentario,
IdEstado = 6
WHERE ID = @ID
end

GO
CREATE PROCEDURE sp_Cerrar_Incidencia
(@Id INT, @Motivo INT)
as begin
UPDATE Incidentes 
SET 
IdEstado = 3,
IdMotivo = @Motivo
WHERE ID = @ID
end

GO
CREATE PROCEDURE sp_Detalle_Incidentes(@id int) as
select INC.ID, TI.ID 'IdTipo', TI.Descripcion 'Tipo', PRI.ID 'IdPrioridad', PRI.Descripcion 'Prioridad', CL.ID 'IdCliente', 
concat(CL.Nombres, ', ', CL.Apellidos) as 'Cliente', INC.Problematica, INC.FechaDeAlta, INC.FechaDeBaja,
EI.ID 'IdEstado', EI.Descripcion 'Estado', M.ID 'IdMotivo', M.Descripcion 'Motivo',INC.Comentario
FROM Incidentes INC 
LEFT JOIN TipoIncidencias TI ON TI.ID = INC.IdTipoIncidencia 
LEFT JOIN PrioridadIncidencias PRI ON PRI.Id = INC.IdPrioridad 
LEFT JOIN EstadoIncidencias EI ON EI.ID = INC.IdEstado 
LEFT JOIN Clientes CL ON CL.id = INC.idCliente 
LEFT JOIN Empleados as E ON E.ID = INC.IdEmpleado 
LEFT JOIN Motivos as M ON M.ID = INC.IdMotivo 
Where INC.ID = @id

go
CREATE PROCEDURE sp_listar_Telefonistas
as begin
SELECT E.Id, concat(E.Nombres, ', ', E.Apellidos) 'Nombre'
from Empleados as E
WHERE E.IdPerfil = 2
AND E.Activo = 1
end

go
CREATE PROCEDURE sp_reasignar_Incidencia
(@Id INT, @Empleado INT)
as begin
UPDATE Incidentes 
SET 
IdEstado = 5,
IdEmpleado = @Empleado
WHERE ID = @ID
end
