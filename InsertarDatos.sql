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