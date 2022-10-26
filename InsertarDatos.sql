
insert into CALLCENTER.dbo.Cliente (Nombre, Apellido, Email) 
VALUES 
('Juan', 'Perez', 'juanperez@gmail.com'),
('Carlos', 'Gomez', 'carlosgomez@gmail.com'),
('Pedro', 'Martinez', 'pedromartinez@gmail.com')

insert into CALLCENTER.dbo.EstadoIncidencia(Descripcion) 
VALUES 
('Abierto'),
('En analisis'),
('Cerrado'),
('Reabierto'),
('Asignado'),
('Resuelto')

insert into CALLCENTER.dbo.Perfil(Descripcion) 
VALUES 
('Administrador'),
('Telefonista'),
('Supervisor')

insert into CALLCENTER.dbo.PrioridadIncidencia(Descripcion) 
VALUES 
('Alta'),
('Media'),
('Baja')

insert into CALLCENTER.dbo.TipoIncidencia(Descripcion) 
VALUES 
('Error'),
('Consulta'),
('Reclamo'),
('Sugerencia')

insert into CALLCENTER.dbo.Usuario (Nombre, Apellido, DNI, Email, IdPerfil) 
VALUES 
('Antonio', 'Ramirez', '11222333','antonioramirez@gmail.com', 1),
('Manuel', 'Giordano', '22445550', 'manuelgiordano@gmail.com',2),
('Cecilia', 'Ledesma', '20304050', 'cecilialedesma@gmail.com',3)