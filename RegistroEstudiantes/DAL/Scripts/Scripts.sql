create database EstudiantesDb
USE EstudiantesDb
GO
CREATE TABLE Estudiantes
(
	EstudianteId int primary key identity(1,1), 
	Matricula varchar(9), 
	Nombres varchar(30), 
	Apellidos varchar (30), 
	Cedula varchar(13),
	Telefono varchar(13),
	Celular varchar(13),
	Email varchar(50), 
	FechaNacimiento date,  
	Sexo int, 
	Balance float(12)
);
Go

CREATE TABLE Inscripciones
(
	IncripcionId int primary key identity(1,1), 
	Fecha date, 
	EstudianteId int, 
	Comentarios varchar(max), 
	Monto float(7),
	Deposito float(7), 
	Balance float(7)
	CONSTRAINT fk_EstudianteID FOREIGN KEY (EstudianteId) REFERENCES Estudiantes(EstudianteId) 
)



