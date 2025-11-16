-- Endel Rafael Urbaez 20242053

CREATE DATABASE ParkingDB;
GO

USE ParkingDB;
GO

CREATE TABLE Sector (
    SectorId INT IDENTITY(1,1) PRIMARY KEY,
    Codigo NVARCHAR(50) NOT NULL UNIQUE,
    Nombre NVARCHAR(100) NOT NULL,
    Municipio NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE Tarifa (
    TarifaId INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(100) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    HoraInicio TIME NOT NULL,
    HoraFin TIME NOT NULL
);
GO

CREATE TABLE Vehiculo (
    VehiculoId INT IDENTITY(1,1) PRIMARY KEY,
    Placa NVARCHAR(20) NOT NULL UNIQUE,
    Marca NVARCHAR(50) NOT NULL,
    Modelo NVARCHAR(50) NOT NULL,
    Color NVARCHAR(30),
    SectorId INT NOT NULL,
    FOREIGN KEY (SectorId) REFERENCES Sector(SectorId)
);
GO

CREATE TABLE Ticket (
    TicketId INT IDENTITY(1,1) PRIMARY KEY,
    VehiculoId INT NOT NULL,
    FechaEntrada DATETIME NOT NULL DEFAULT GETDATE(),
    FechaSalida DATETIME NULL,
    TarifaId INT NOT NULL,
    Total DECIMAL(10,2) NULL,
    FOREIGN KEY (VehiculoId) REFERENCES Vehiculo(VehiculoId),
    FOREIGN KEY (TarifaId) REFERENCES Tarifa(TarifaId)
);
GO


-- Sectores
INSERT INTO Sector (Codigo, Nombre, Municipio)
VALUES 
('SEC001','Sector Norte','Santo Domingo'),
('SEC002','Sector Sur','Santo Domingo');

-- Tarifas
INSERT INTO Tarifa (Descripcion, Precio, HoraInicio, HoraFin)
VALUES 
('Tarifa Diurna', 50.00, '08:00', '20:00'),
('Tarifa Nocturna', 30.00, '20:00', '08:00');

-- Vehiculos
INSERT INTO Vehiculo (Placa, Marca, Modelo, Color, SectorId)
VALUES 
('ABC123','Toyota','Corolla','Rojo',1),
('XYZ987','Honda','Civic','Azul',2);

-- Tickets
INSERT INTO Ticket (VehiculoId, FechaEntrada, FechaSalida, TarifaId, Total)
VALUES 
(1, GETDATE(), NULL, 1, NULL),
(2, GETDATE(), NULL, 2, NULL);
GO

