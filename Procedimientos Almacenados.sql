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
CREATE PROCEDURE sp_listar_Incidentes
as begin
select INC.Id, INC.IdTipoIncidencia, TI.Descripcion 'Tipo', INC.IdPrioridad, PRI.descripcion 
'Prioridad', INC.Problematica,INC.IdEstado, EI.Descripcion 'Estado', INC.IdCliente, CL.Nombres 
'NombreCliente', CL.Apellidos 'ApellidoCliente',CL.DNI 'DNICliente', CL.Email 'EmailCliente', 
CL.Telefono 'TelefonoCliente', concat(U.Apellidos, ',', U.Nombres) as 'UsuarioAsignado',
INC.Comentario, M.Descripcion as 'Motivo', INC.FechaDeAlta, INC.FechaDeBaja, INC.Activo
from Incidentes INC 
LEFT JOIN TipoIncidencias TI ON TI.ID = INC.IdTipoIncidencia 
LEFT JOIN PrioridadIncidencias PRI ON PRI.Id = INC.IdPrioridad 
LEFT JOIN EstadoIncidencias EI ON EI.ID = INC.IdEstado 
LEFT JOIN Clientes CL ON CL.id = INC.idCliente 
LEFT JOIN Usuarios as U ON U.ID = INC.IdUsuario
LEFT JOIN Motivos as M ON M.ID = INC.IdMotivo
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
CREATE PROCEDURE sp_listar_Usuarios
as begin
select U.Id, Nombres, Apellidos, DNI, Email, P.ID as 'IdPerfil', P.Descripcion as 'Perfil',
FechaDeAlta, FechaDeBaja, Activo
from Usuarios as U
inner join Perfiles as P on U.IdPerfil = P.Id
end


go
CREATE PROCEDURE sp_Agregar_Cliente (@Nombres varchar(50), @Apellidos varchar(50),
@DNI varchar(25), @Email varchar(50), @Telefono varchar(50))
as begin
insert into Clientes values (@Nombres, @Apellidos,@DNI, @Email, @Telefono, getdate(), null, 1)
end

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

CREATE PROCEDURE sp_Agregar_Usuario
(@Nombres varchar(50), @Apellidos varchar(50),
@DNI varchar(25), @Email varchar(50), @Perfil INT)
AS
BEGIN
	insert into Usuarios values (@Nombres, @Apellidos,@DNI, @Email, @Perfil, getdate(), null, 1)
END
GO

CREATE PROCEDURE SP_Modificar_Usuario
(@id int, @Nombres VARCHAR(50), @Apellidos varchar(50),
@DNI varchar(25), @Email varchar(50), @Perfil INT)
AS
BEGIN
	UPDATE Usuarios set Nombres = @Nombres,
	Apellidos = @Apellidos,
	DNI = @DNI,
	email = @Email,
	IdPerfil = @Perfil
	WHERE ID = @id
END
GO