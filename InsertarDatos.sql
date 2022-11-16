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

insert into CALLCENTER.dbo.Usuarios(Nombres, Apellidos, DNI, Email, IdPerfil, FechaDeAlta, Activo) 
VALUES 
('Antonio', 'Ramirez', '11222333','antonioramirez@gmail.com', 1, getdate(), 1),
('Manuel', 'Giordano', '22445550', 'manuelgiordano@gmail.com',2, getdate(), 1),
('Cecilia', 'Ledesma', '20304050', 'cecilialedesma@gmail.com',3, getdate(), 1)

insert into CALLCENTER.dbo.Motivos(Descripcion, Estado) 
VALUES 
('Cancelado',1),
('Vencido',1),
('Otros',1)

insert into CALLCENTER.dbo.UsuarioLogin(IdUsuario, Usuario, Clave) 
VALUES 
(1, 'admin', 'admin'),
(2, 'tel', 'tel'),
(3, 'sup', 'sup')