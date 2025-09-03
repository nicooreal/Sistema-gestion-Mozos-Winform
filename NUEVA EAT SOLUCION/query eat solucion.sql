
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
ALTER TABLE Cliente DROP COLUMN Activo;


ALTER TABLE Cliente ADD Activo BIT NOT NULL DEFAULT 1;

CREATE TABLE Cliente (
    IdCliente INT PRIMARY KEY IDENTITY(1,1),
    IdPersona INT NOT NULL,
    Activado BIT NOT NULL DEFAULT 1,
	Observacion varchar(200),

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
    HorarioEntrada DATETIME NULL,
    HorarioSalida DATETIME NULL,
    Plus DECIMAL(10,2) NULL,
    NombreDelPLus VARCHAR(20),
	RolDelPersonal VARCHAR(40) NULL

    PRIMARY KEY (EventoId, LegajoMozo),
    FOREIGN KEY (EventoId) REFERENCES Evento(Id),
    FOREIGN KEY (LegajoMozo) REFERENCES Mozo(Legajo)
);
GO




select P.Nombre, P.Apellido, P.Correo,P.IdPersona,C.IdCliente, P.Cuil,  P.Dni, P.FechaNacimiento, P.Telefono, C.Observacion from Cliente C inner join Persona P on C.IdPersona = P.IdPersona

select  from evento E inner join Cliente C on E.ClienteId = C.IdCliente


SELECT 
    E.Id,
    E.Nombre,
    E.Estado,
    P.Nombre AS NombreCliente,
    P.Apellido AS ApellidoCliente,
    P.Correo,
    P.Telefono,
    E.FechaInicio,
    E.FechaFinalizacion,
    E.CantidadInvitados,
    E.Direccion,
    E.Observacion,
    E.Lugar,
    E.TipoDeEvento,
    E.Presupuesto,
    E.PagaPorHora
FROM Evento E
INNER JOIN Cliente C ON E.ClienteId = C.IdCliente
INNER JOIN Persona P ON C.IdPersona = P.IdPersona;



SELECT C.IdCliente, C.Observacion, P.Apellido, P.Correo, P.Cuil, P.Dni, P.FechaNacimiento, P.Nombre FROM Cliente C inner join Persona P on C.IdPersona = P.IdPersona



select * from Evento
select * from Cliente
select * from Mozo
select * from Persona

delete from Cliente
delete from Persona
delete from Mozo


DBCC CHECKIDENT ('Persona', RESEED, 0);
DBCC CHECKIDENT ('Mozo', RESEED, 0);
DBCC CHECKIDENT ('Cliente', RESEED, 0);
DBCC CHECKIDENT ('Evento', RESEED, 0);
-- EventoMozo no necesita, porque no tiene columna IDENTITY

select P.Nombre, C.IdCliente, C.Activado, P.Apellido, P.Correo, P.Cuil,  P.Dni, P.FechaNacimiento, P.Telefono, C.Observacion from Cliente C inner join Persona P on C.IdPersona = P.IdPersona



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



INSERT INTO Persona (Dni, Nombre, Apellido, Cuil, FechaNacimiento, Correo, Telefono) VALUES
(30123456, 'Juan', 'Pérez', 20301234567, '1990-05-15', 'juanperez@mail.com', '1145671234'),
(31234567, 'María', 'Gómez', 27312345678, '1988-08-22', 'mariagomez@mail.com', '1167894561'),
(32345678, 'Lucía', 'Martínez', 27323456789, '1995-12-01', 'luciam@mail.com', '1156712457'),
(33456789, 'Carlos', 'Díaz', 20334567890, '1982-07-10', 'carlosd@mail.com', '1178234512'),
(34567890, 'Sofía', 'López', 27345678901, '1993-03-29', 'sofia@mail.com', '1132145876');


INSERT INTO Mozo (IdPersona, Activado, Disponible, Categoria, Tarea, FechaAlta, AltaEventual) VALUES
(1, 1, 1, 'Senior', 'Atención en mesa', '2023-01-01', 'No'),
(2, 1, 0, 'Junior', 'Ayudante de barra', '2023-03-15', 'Sí'),
(3, 1, 1, 'Intermedio', 'Montaje de salón', '2023-05-10', 'No'),
(4, 1, 1, 'Senior', 'Coordinador de mozos', '2023-06-20', 'No'),
(5, 1, 0, 'Junior', 'Atención en barra', '2023-07-25', 'Sí');


INSERT INTO Cliente (IdPersona, Observacion) VALUES
(4, 'Cliente frecuente para eventos corporativos.'),
(5, 'Solicita mozos con experiencia en eventos familiares.'),
(1, 'Atención especial: vegano.'),
(2, 'Prefiere ambientación temática.'),
(3, 'Cliente nuevo, sin observaciones.');


INSERT INTO Evento (Estado, Nombre, FechaInicio, FechaFinalizacion, CantidadInvitados, Direccion, Observacion, Presupuesto, ClienteId, PagaPorHora, Lugar, tipoDeEvento) VALUES
('Confirmado', 'Casamiento Lucía & Juan', '2024-11-10 18:00', '2024-11-11 02:00', 150, 'Salón Los Robles', 'Evento formal', 500000, 1, 2000, 'Salón A', 'Casamiento'),
('Pendiente', 'Cumpleaños de 50 Carlos', '2024-09-15 20:00', '2024-09-16 01:00', 80, 'Av. Libertador 1450', 'Cumpleaños familiar', 200000, 2, 1800, 'Salón B', 'Cumpleaños'),
('Confirmado', 'Evento corporativo TechCo', '2024-08-20 08:00', '2024-08-20 18:00', 100, 'Hotel Intercontinental', 'Requiere proyector y sonido', 300000, 3, 2500, 'Salón C', 'Corporativo'),
('Cancelado', 'Despedida de año', '2024-12-15 21:00', '2024-12-16 02:00', 200, 'Quinta San Isidro', 'Cancelado por clima', 0, 4, 2200, 'Quinta X', 'Fiesta de fin de año'),
('Confirmado', 'Bautismo Sofía', '2024-10-01 12:00', '2024-10-01 16:00', 60, 'Iglesia San Cayetano', 'Menú infantil', 120000, 5, 1700, 'Salón infantil', 'Bautismo');


INSERT INTO EventoMozo (EventoId, LegajoMozo) VALUES
(1, 1),
(1, 2),
(2, 3),
(3, 4),
(5, 5);
