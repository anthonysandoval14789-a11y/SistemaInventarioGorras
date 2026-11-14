
---Por aqui creamos nuesta base de datos-------
CREATE DATABASE InventarioGorrasBD;
GO

---Create table-----
CREATE TABLE Marca
(
    IdMarca INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL
);
GO


CREATE TABLE Color
(
    IdColor INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL
);
GO

-- Create the Cap table
CREATE TABLE Gorra
(
    Codigo INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    IdMarca INT NOT NULL,
    IdColor INT NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Cantidad INT NOT NULL,

    FOREIGN KEY (IdMarca) REFERENCES Marca(IdMarca),
    FOREIGN KEY (IdColor) REFERENCES Color(IdColor),

     CHECK (Precio > 0),
    CHECK (Cantidad >= 0)
);
GO


USE InventarioGorrasBD;
GO

SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE';
GO
SELECT * FROM Color;


USE InventarioGorrasBD;
GO
-- Insertamos las marcas que estarán disponibles para registrar las gorras en el inventario.
INSERT INTO Marca (Nombre)
VALUES
('Nike'),
('Adidas'),
('New Era');
GO

INSERT INTO Color (Nombre)
VALUES
('Negro'),
('Blanco'),
('Azul');
GO

SELECT * FROM Marca;

SELECT * FROM Color;

USE InventarioGorrasBD;
GO

SELECT * FROM Gorra;