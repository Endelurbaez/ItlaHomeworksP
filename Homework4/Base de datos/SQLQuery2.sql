USE ParkingDB;
GO

CREATE TABLE Tarifa
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(100) NOT NULL,
    PrecioHora DECIMAL(10,2) NOT NULL
);

INSERT INTO Tarifa (Descripcion, PrecioHora)
VALUES
('Tarifa por hora', 50.00),
('Tarifa nocturna', 30.00),
('Tarifa día completo', 200.00);
