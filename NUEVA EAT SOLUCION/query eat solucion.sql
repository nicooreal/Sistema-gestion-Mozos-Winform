
USE EATSOLUCION;
GO




CREATE TABLE Persona (
    IdPersona INT IDENTITY(1,1) PRIMARY KEY ,
    Dni BIGINT,
	Nombre VARCHAR(100),
    Apellido VARCHAR(100),
    Cuil BIGINT,
    FechaNacimiento DATE,
    Correo VARCHAR(100),
    Telefono VARCHAR(20)
);
GO



CREATE TABLE Mozo (
    Legajo INT PRIMARY KEY IDENTITY(1,1),
    IdPersona INT,
	Activado BIT,
    Disponible BIT,
    Categoria VARCHAR(50),
    Tarea VARCHAR(100),
    FechaAlta DATE,
    AltaEventual VARCHAR(20),
    FOREIGN KEY (IdPersona) REFERENCES Persona(IdPersona)
);
GO



CREATE TABLE Cliente (
    IdCliente INT PRIMARY KEY IDENTITY(1,1),
    IdPersona INT NOT NULL,
    Observacion varchar(200)

    CONSTRAINT FK_Cliente_Persona FOREIGN KEY (IdPersona) REFERENCES Persona(IdPersona)
);
GO


CREATE TABLE Evento (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Estado VARCHAR(15),
	Nombre VARCHAR(100),
    FechaInicio DATETIME,
    FechaFinalizacion DATETIME,
    CantidadInvitados INT,
    Direccion VARCHAR(150),
    Observacion VARCHAR(500),
    Presupuesto FLOAT,
    ClienteId INT,
    PagaPorHora FLOAT,
	Lugar VARCHAR(150),
	tipoDeEvento VARCHAR (150),

	FOREIGN KEY (ClienteId) REFERENCES Cliente(IdCliente)
);
GO


CREATE TABLE EventoMozo (
    EventoId INT,
    LegajoMozo INT,
    PRIMARY KEY (EventoId, LegajoMozo),
    FOREIGN KEY (EventoId) REFERENCES Evento(Id),
    FOREIGN KEY (LegajoMozo) REFERENCES Mozo(Legajo)
);
GO




select * from Cliente




select P.Nombre, P.Apellido, P.Correo,P.IdPersona,C.IdCliente, P.Cuil,  P.Dni, P.FechaNacimiento, P.Telefono, C.Observacion from Cliente C inner join Persona P on C.IdPersona = P.IdPersona






SELECT C.IdCliente, C.Observacion, P.Apellido, P.Correo, P.Cuil, P.Dni, P.FechaNacimiento, P.Nombre FROM Cliente C inner join Persona P on C.IdPersona = P.IdPersona

delete  from Cliente

SELECT * FROM Evento
SELECT * FROM Cliente
delete from Cliente where IdCliente = 3


select * from Mozo
select * from Persona
delete from Persona where IdPersona = 3


INSERT INTO Persona (Dni, Nombre, Apellido, Cuil, FechaNacimiento, Correo, Telefono)
VALUES
(12345678, 'Juan', 'Pérez', 20323456789, '1985-03-20', 'juan.perez@mail.com', '123-456-7890'),
(23456789, 'Ana', 'García', 20334567890, '1990-07-15', 'ana.garcia@mail.com', '098-765-4321');

INSERT INTO Mozo (IdPersona, Activado, Disponible, Categoria, Tarea, FechaAlta, AltaEventual)
VALUES
(1, 1, 1, 'Senior', 'Servicio en mesa', '2024-05-01', 'No'),
(2, 1, 0, 'Junior', 'Recepción', '2024-05-10', 'Sí');



INSERT INTO Cliente (Nombre, Apellido, Telefono, Correo)
VALUES
('Carlos', 'López', '555-111-2222', 'carlos.lopez@mail.com'),
('Laura', 'Martínez', '555-333-4444', 'laura.martinez@mail.com');


INSERT INTO Evento (Estado, Nombre, FechaInicio, FechaFinalizacion, CantidadInvitados, Direccion, Observacion, Presupuesto, ClienteId, PagaPorHora, Lugar, tipoDeEvento)
VALUES
('Activo', 'Boda de Carlos', '2025-05-10 18:00', '2025-05-10 23:00', 100, 'Av. Siempre Viva 123', 'Evento formal', 20000, 1, 500, 'Salón El Paraíso', 'Boda'),
('Activo', 'Fiesta de Laura', '2025-06-05 20:00', '2025-06-05 01:00', 150, 'Calle Ficticia 456', 'Cumpleaños con amigos', 15000, 2, 400, 'Salón Fiesta', 'Cumpleaños');

select * from Evento
select * from Mozo
select * from Persona

INSERT INTO EventoMozo (EventoId, LegajoMozo)
VALUES
(1, 1),  -- Juan Pérez (Legajo 1) en la boda de Carlos
(2, 2),  -- Ana García (Legajo 2) en la boda de Carlos
(2, 1);  -- Juan Pérez (Legajo 1) en la fiesta de Laura




UPDATE Mozo 
SET Tarea = 'Test desde SSMS' 
WHERE Legajo = 1;


-- 1. Borrar todas las FOREIGN KEYS
DECLARE @sql NVARCHAR(MAX) = N'';

SELECT @sql += 'ALTER TABLE ' + QUOTENAME(OBJECT_SCHEMA_NAME(parent_object_id)) + '.' + QUOTENAME(OBJECT_NAME(parent_object_id)) +
               ' DROP CONSTRAINT ' + QUOTENAME(name) + ';' + CHAR(13)
FROM sys.foreign_keys;

EXEC sp_executesql @sql;

-- 2. Borrar todas las tablas
DECLARE @sqlDrop NVARCHAR(MAX) = N'';

SELECT @sqlDrop += 'DROP TABLE ' + QUOTENAME(OBJECT_SCHEMA_NAME(object_id)) + '.' + QUOTENAME(name) + ';' + CHAR(13)
FROM sys.tables;

EXEC sp_executesql @sqlDrop;

SELECT m.Legajo, m.Activado, m.Disponible, m.Categoria, m.Tarea, m.FechaAlta, m.AltaEventual, p.Dni, p.Nombre, p.Apellido, p.Cuil, p.FechaNacimiento, p.Correo, p.Telefono FROM Mozo m JOIN Persona p ON m.IdPersona = p.IdPersona


INSERT INTO Evento (
    Estado,
    Nombre,
    FechaInicio,
    FechaFinalizacion,
    CantidadInvitados,
    Direccion,
    Observacion,
    Presupuesto,
    ClienteId,
    PagaPorHora,
    Lugar,
    tipoDeEvento
)
VALUES (
    'Confirmado',
    'Fiesta de casamiento',
    '2025-11-15 18:00:00',
    '2025-11-16 03:00:00',
    150,
    'Av. Siempre Viva 123, Springfield',
    'Los novios pidieron ambientación temática',
    500000.00,
    4,
    2500.00,
    'Salón Primavera',
    'Casamiento'
);
