
CREATE DATABASE GestionClientesDB;
GO

USE GestionClientesDB;
GO



CREATE TABLE Usuarios (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario VARCHAR(50) NOT NULL UNIQUE,
    ContrasenaHash VARCHAR(255) NOT NULL,
    NombreCompleto VARCHAR(100) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1,
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE()
);
GO

CREATE TABLE Clientes (
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,
    Nombres VARCHAR(100) NOT NULL,
    Apellidos VARCHAR(100) NOT NULL,
    DUI VARCHAR(10) NOT NULL UNIQUE,
    Telefono VARCHAR(15) NULL,
    Correo VARCHAR(100) NULL,
    Direccion VARCHAR(250) NULL,
    Activo BIT NOT NULL DEFAULT 1,
    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE()
);
GO

CREATE TABLE Bitacora (
    IdBitacora INT IDENTITY(1,1) PRIMARY KEY,
    Accion VARCHAR(20) NOT NULL,
    IdCliente INT NOT NULL,
    Detalle VARCHAR(250) NULL,
    FechaHora DATETIME NOT NULL DEFAULT GETDATE(),
    NombreUsuario VARCHAR(50) NOT NULL
);
GO



INSERT INTO Usuarios (
    NombreUsuario,
    ContrasenaHash,
    NombreCompleto
)
-- Usuario: admin
-- Contraseña: Admin123*
VALUES (
    'admin',
    '0a5bc3e342432f1bad92ffd51b785343ec72906cdba6a26131060b008e786656',
    'Administrador del Sistema'
);
GO



DECLARE @IdCliente INT;

INSERT INTO Clientes (Nombres, Apellidos, DUI, Telefono, Correo, Direccion)
VALUES ('Carlos Alberto', 'Méndez López', '04589632-1', '7845-1234', 'cmendez@email.com', 'Col. Escalón, San Salvador');

SET @IdCliente = SCOPE_IDENTITY();

INSERT INTO Bitacora (Accion, IdCliente, Detalle, NombreUsuario)
VALUES ('INSERTAR', @IdCliente, 'Registro inicial del cliente Carlos Alberto Méndez López', 'admin');


INSERT INTO Clientes (Nombres, Apellidos, DUI, Telefono, Correo, Direccion)
VALUES ('María José', 'Pineda Rivas', '05123489-7', '7123-9876', 'mpineda@email.com', 'Santa Tecla, La Libertad');

SET @IdCliente = SCOPE_IDENTITY();

INSERT INTO Bitacora (Accion, IdCliente, Detalle, NombreUsuario)
VALUES ('INSERTAR', @IdCliente, 'Registro inicial de la cliente María José Pineda Rivas', 'admin');


INSERT INTO Clientes (Nombres, Apellidos, DUI, Telefono, Correo, Direccion)
VALUES ('José Manuel', 'Hernández Flores', '06123456-8', '7654-1234', 'jhernandez@email.com', 'Col. San Benito, San Salvador');

SET @IdCliente = SCOPE_IDENTITY();

INSERT INTO Bitacora (Accion, IdCliente, Detalle, NombreUsuario)
VALUES ('INSERTAR', @IdCliente, 'Registro inicial del cliente José Manuel Hernández Flores', 'admin');


INSERT INTO Clientes (Nombres, Apellidos, DUI, Telefono, Correo, Direccion)
VALUES ('Ana Gabriela', 'Castro Molina', '07234567-9', '7012-3456', 'acastro@email.com', 'Antiguo Cuscatlán, La Libertad');

SET @IdCliente = SCOPE_IDENTITY();

INSERT INTO Bitacora (Accion, IdCliente, Detalle, NombreUsuario)
VALUES ('INSERTAR', @IdCliente, 'Registro inicial de la cliente Ana Gabriela Castro Molina', 'admin');


INSERT INTO Clientes (Nombres, Apellidos, DUI, Telefono, Correo, Direccion)
VALUES ('Roberto Carlos', 'Ramírez Torres', '08345678-0', '7890-1234', 'rramirez@email.com', 'Col. Miramonte, San Salvador');

SET @IdCliente = SCOPE_IDENTITY();

INSERT INTO Bitacora (Accion, IdCliente, Detalle, NombreUsuario)
VALUES ('INSERTAR', @IdCliente, 'Registro inicial del cliente Roberto Carlos Ramírez Torres', 'admin');


INSERT INTO Clientes (Nombres, Apellidos, DUI, Telefono, Correo, Direccion)
VALUES ('Laura Beatriz', 'Gómez Martínez', '09456789-1', '7234-5678', 'lgomez@email.com', 'Santa Ana, Santa Ana');

SET @IdCliente = SCOPE_IDENTITY();

INSERT INTO Bitacora (Accion, IdCliente, Detalle, NombreUsuario)
VALUES ('INSERTAR', @IdCliente, 'Registro inicial de la cliente Laura Beatriz Gómez Martínez', 'admin');


INSERT INTO Clientes (Nombres, Apellidos, DUI, Telefono, Correo, Direccion)
VALUES ('Miguel Ángel', 'López Rivera', '01567890-2', '7456-7890', 'mlopez@email.com', 'Col. Las Delicias, Santa Tecla');

SET @IdCliente = SCOPE_IDENTITY();

INSERT INTO Bitacora (Accion, IdCliente, Detalle, NombreUsuario)
VALUES ('INSERTAR', @IdCliente, 'Registro inicial del cliente Miguel Ángel López Rivera', 'admin');


INSERT INTO Clientes (Nombres, Apellidos, DUI, Telefono, Correo, Direccion)
VALUES ('Sofía Alejandra', 'Vásquez Cruz', '02678901-3', '7567-8901', 'svasquez@email.com', 'Soyapango, San Salvador');

SET @IdCliente = SCOPE_IDENTITY();

INSERT INTO Bitacora (Accion, IdCliente, Detalle, NombreUsuario)
VALUES ('INSERTAR', @IdCliente, 'Registro inicial de la cliente Sofía Alejandra Vásquez Cruz', 'admin');


INSERT INTO Clientes (Nombres, Apellidos, DUI, Telefono, Correo, Direccion)
VALUES ('Fernando José', 'Morales Aguilar', '03789012-4', '7678-9012', 'fmorales@email.com', 'San Miguel, San Miguel');

SET @IdCliente = SCOPE_IDENTITY();

INSERT INTO Bitacora (Accion, IdCliente, Detalle, NombreUsuario)
VALUES ('INSERTAR', @IdCliente, 'Registro inicial del cliente Fernando José Morales Aguilar', 'admin');


INSERT INTO Clientes (Nombres, Apellidos, DUI, Telefono, Correo, Direccion)
VALUES ('Daniela Patricia', 'Reyes Martínez', '04890123-5', '7789-0123', 'dreyes@email.com', 'Col. San Francisco, San Salvador');

SET @IdCliente = SCOPE_IDENTITY();

INSERT INTO Bitacora (Accion, IdCliente, Detalle, NombreUsuario)
VALUES ('INSERTAR', @IdCliente, 'Registro inicial de la cliente Daniela Patricia Reyes Martínez', 'admin');

GO



SELECT * FROM Usuarios;

SELECT * FROM Clientes;

SELECT * FROM Bitacora ORDER BY IdBitacora;
