
CREATE DATABASE SorteosDB;
GO

USE SorteosDB;
GO

CREATE TABLE Clientes (
    idCliente INT IDENTITY(1,1) PRIMARY KEY,
    nombreCliente NVARCHAR(100) NOT NULL,
    fechaRegistro DATETIME DEFAULT GETDATE(),
);

CREATE TABLE NumerosDisponiblesClientes (
    idNumeroDisponible INT IDENTITY(1,1) PRIMARY KEY,
    idCliente INT NOT NULL,
    numero INT NOT NULL CHECK (numero BETWEEN 1 AND 99999),
    fechaCreacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (idCliente) REFERENCES Clientes(idCliente),
    CONSTRAINT UQ_NumeroDisponible_Cliente_Numero UNIQUE (idCliente, numero)
);

CREATE TABLE Usuarios (
    idUsuario INT IDENTITY(1,1) PRIMARY KEY,
    idCliente INT NOT NULL,
    nombreUsuario NVARCHAR(100) NOT NULL,
    correo NVARCHAR(100),
    fechaRegistro DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (idCliente) REFERENCES Clientes(idCliente)
);

CREATE TABLE Sorteos (
    idSorteo INT IDENTITY(1,1) PRIMARY KEY,
    nombreSorteo NVARCHAR(100) NOT NULL,
    fechaInicio DATE NOT NULL,
    fechaFin DATE NOT NULL
);

CREATE TABLE usuario_sorteo (
    idUsuarioSorteo INT IDENTITY(1,1) PRIMARY KEY,
    idUsuario INT NOT NULL,
    idSorteo INT NOT NULL,
    fechaAsignacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario),
    FOREIGN KEY (idSorteo) REFERENCES Sorteos(idSorteo)
);

CREATE TABLE NumerosAsignados (
    idNumeroAsignado INT IDENTITY(1,1) PRIMARY KEY,
    idUsuario INT NOT NULL,
    idCliente INT NOT NULL,
    idSorteo INT NOT NULL,
    numeroAsignado INT NOT NULL CHECK (numeroAsignado BETWEEN 1 AND 99999),
    fechaAsignacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario),
    FOREIGN KEY (idCliente) REFERENCES Clientes(idCliente),
    FOREIGN KEY (idSorteo) REFERENCES Sorteos(idSorteo),
    CONSTRAINT UQ_NumerosAsignados_Usuario_Cliente_Sorteo_Numero UNIQUE (idUsuario, idCliente, idSorteo, numeroAsignado)
);

-- Al inicio de crear la base de datos, se olvido crear el campo que guardara la representacion del numero asignado
ALTER TABLE NumerosAsignados
ADD representacionNumeroAsignado NVARCHAR(5);

-- Actualizar valores existentes con la representación de 5 dígitos
UPDATE NumerosAsignados
SET representacionNumeroAsignado = RIGHT('00000' + CAST(numeroAsignado AS NVARCHAR(5)), 5);

SELECT
*
FROM
NumerosAsignados;