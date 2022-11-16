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
CREATE TABLE Usuarios(
	ID INT PRIMARY KEY IDENTITY (1,1),
	Nombres VARCHAR(50) NOT NULL,
	Apellidos VARCHAR(50) NOT NULL,
	DNI VARCHAR(50) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	IdPerfil INT NOT NULL FOREIGN KEY REFERENCES Perfiles (ID),
	FechaDeAlta datetime NOT NULL,
	FechaDeBaja datetime NULL,
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
	IdUsuario INT NOT NULL FOREIGN KEY REFERENCES Usuarios (ID),
	Comentario VARCHAR(100),
	IdMotivo INT NULL FOREIGN KEY REFERENCES Motivos (ID),
	FechaDeAlta datetime NOT NULL,
	FechaDeBaja datetime,
	Activo bit NOT NULL
)

GO
create table UsuarioLogin (
IdUsuario int primary key foreign key references Usuarios (ID) not null,
Usuario varchar(10) not null, 
Clave varchar(10) not null
)