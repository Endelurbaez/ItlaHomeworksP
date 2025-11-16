


USE ParkingDB1;
GO

CREATE TABLE Clientes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20) NULL,
    Cedula VARCHAR(20) NULL
);
GO


CREATE TABLE Vehiculos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Placa VARCHAR(20) NOT NULL,
    Marca VARCHAR(50) NULL,
    Modelo VARCHAR(50) NULL,
    ClienteId INT NOT NULL,
    FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);
GO


CREATE TABLE Tarifas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Tipo VARCHAR(50) NOT NULL,            
    PrecioPorHora DECIMAL(10,2) NOT NULL
);
GO

CREATE TABLE Tickets (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    VehiculoId INT NOT NULL,
    FechaEntrada DATETIME NOT NULL,
    FechaSalida DATETIME NULL,
    Total DECIMAL(10,2) NULL,
    FOREIGN KEY (VehiculoId) REFERENCES Vehiculos(Id)
);
GO


-- CLIENTES
INSERT INTO Clientes (Nombre, Apellido, Telefono, Cedula) VALUES
('Juan', 'Perez', '809-555-1111', '001-1234567-8'),
('Maria', 'Lopez', '829-222-3333', '002-9876543-1'),
('Carlos', 'Gomez', '849-444-5555', '003-5689741-2');

-- VEHICULOS
INSERT INTO Vehiculos (Placa, Marca, Modelo, ClienteId) VALUES
('A123456', 'Toyota', 'Corolla', 1),
('B789123', 'Honda', 'Civic', 2),
('C456789', 'Hyundai', 'Sonata', 3);

-- TARIFAS
INSERT INTO Tarifas (Tipo, PrecioPorHora) VALUES
('Carro', 100.00),
('Motor', 50.00),
('Camioneta', 150.00);

-- TICKETS
INSERT INTO Tickets (VehiculoId, FechaEntrada, FechaSalida, Total) VALUES
(1, '2024-11-10 08:00:00', '2024-11-10 10:00:00', 200.00),
(2, '2024-11-10 09:30:00', '2024-11-10 12:30:00', 300.00),
(3, '2024-11-10 07:00:00', NULL, NULL);
GO