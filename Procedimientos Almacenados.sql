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
select Id, Descripcion from EstadoIncidencia
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
	insert into Empleados values (@Nombres, @Apellidos,@DNI, @Email, @Telefono, @Perfil, getdate(),null, @Clave, 1)
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
Select E.Id, Nombres, Apellidos,DNI, Email,Telefono, IdPerfil, FechaDeAlta, FechaDeBaja, Activo, Descripcion from Empleados E
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