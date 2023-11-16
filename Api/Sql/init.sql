-- SQLBook: Code
-- SQL Server
Use [master];

-- Crear base de datos TEST
CREATE DATABASE [TEST];

-- Crear login de SQL Server developer
CREATE LOGIN [developer] WITH PASSWORD = 'abc123ABC';

-- Crear usuario de SQL Server developer
CREATE USER [developer] FOR LOGIN [developer];

-- Asignar rol de db_owner al usuario developer
ALTER ROLE [db_owner] ADD MEMBER [developer];

-- Crear tablas
CREATE TABLE [dbo].[Producto]
(
    [Id] INT NOT NULL IDENTITY,
    [NombreProducto] NVARCHAR (MAX) NOT NULL,
    [ImagenProducto] NVARCHAR (MAX) NOT NULL,
    [Precio] DECIMAL (18, 2) NOT NULL,
    [Ext] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Producto] PRIMARY KEY ([Id])
);
-- Crear procedimiento CRUD para la tabla Producto
-- CREATE
USE [TEST];
GO
CREATE PROCEDURE spCreateProducto
    @NombreProducto NVARCHAR(MAX),
    @ImagenProducto NVARCHAR(MAX),
    @Precio DECIMAL(18,2),
    @Ext NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO Producto
        (NombreProducto, ImagenProducto, Precio, Ext)
    VALUES
        (@NombreProducto, @ImagenProducto, @Precio, @Ext);
END
GO
-- READ
USE [TEST];
GO
CREATE PROCEDURE spGetAllProducto
AS
BEGIN
    SELECT *
    FROM Producto
    WHERE DeletedAt IS NULL;
END
GO
-- UPDATE
USE [TEST];
GO
CREATE PROCEDURE spUpdateProducto
    @Id INT,
    @NombreProducto NVARCHAR(MAX),
    @ImagenProducto NVARCHAR(MAX),
    @Precio DECIMAL(18,2),
    @Ext NVARCHAR(MAX)
AS
BEGIN
    UPDATE Producto
    SET NombreProducto = @NombreProducto,
        ImagenProducto = @ImagenProducto,
        Precio = @Precio,
        Ext = @Ext
    WHERE Id = @Id;
END
GO
-- DELETE
USE [TEST];
GO
CREATE PROCEDURE spDeleteProducto
    @Id INT
AS
BEGIN
    UPDATE Producto
    SET DeletedAt = GETDATE()
    WHERE Id = @Id;
END
GO

CREATE TABLE [dbo].[TipoCliente]
(
    [Id] INT NOT NULL IDENTITY,
    [TipoCliente] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_TipoCliente] PRIMARY KEY ([Id])
);
-- TODO: Crear procedimiento CRUD para la tabla TipoCliente
-- CREATE

USE [TEST];
GO
CREATE PROCEDURE spCreateTipoCliente
    @TipoCliente NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO CatTipoCliente
        (TipoCliente)
    VALUES
        (@TipoCliente);
END
GO

-- READ

USE [TEST];
GO
CREATE PROCEDURE spGetAllTipoCliente
AS
BEGIN
    SELECT *
    FROM CatTipoCliente
    WHERE DeletedAt IS NULL;
END

GO
-- UPDATE

USE [TEST];
GO
CREATE PROCEDURE spUpdateTipoCliente
    @Id INT,
    @TipoCliente NVARCHAR(MAX)
AS
BEGIN
    UPDATE CatTipoCliente
    SET TipoCliente = @TipoCliente
    WHERE Id = @Id;
END
GO

-- DELETE

USE [TEST];
GO
CREATE PROCEDURE spDeleteTipoCliente
    @Id INT
AS
BEGIN
    UPDATE CatTipoCliente
    SET DeletedAt = GETDATE()
    WHERE Id = @Id;
END
GO


CREATE TABLE [dbo].[Cliente]
(
    [Id] INT NOT NULL IDENTITY,
    [RazonSocial] NVARCHAR (MAX) NULL,
    [RFC] NVARCHAR (MAX) NULL,
    [FechaDeCreacion] DATETIME2 (7) NOT NULL,
    [IdTipoCliente] INT NOT NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Cliente_TipoCliente_IdTipoCliente] FOREIGN KEY ([IdTipoCliente]) REFERENCES [dbo].[TipoCliente] ([Id]) ON DELETE CASCADE
);
-- TODO: Crear procedimiento CRUD para la tabla Cliente
-- CREATE

USE [TEST];
GO
CREATE PROCEDURE spCreateCliente
    @RazonSocial NVARCHAR(MAX),
    @RFC NVARCHAR(MAX),
    @FechaDeCreacion DATETIME2(7),
    @IdTipoCliente INT
AS
BEGIN
    INSERT INTO Cliente
        (RazonSocial, RFC, FechaDeCreacion, IdTipoCliente)
    VALUES
        (@RazonSocial, @RFC, @FechaDeCreacion, @IdTipoCliente);
END
GO

-- READ

USE [TEST];
GO
CREATE PROCEDURE spGetAllCliente
AS
BEGIN
    SELECT *
    FROM Cliente
    WHERE DeletedAt IS NULL;
END
GO

-- UPDATE

USE [TEST];
GO
CREATE PROCEDURE spUpdateCliente
    @Id INT,
    @RazonSocial NVARCHAR(MAX),
    @RFC NVARCHAR(MAX),
    @FechaDeCreacion DATETIME2(7),
    @IdTipoCliente INT
AS

BEGIN
    UPDATE Cliente
    SET RazonSocial = @RazonSocial,
        RFC = @RFC,
        FechaDeCreacion = @FechaDeCreacion,
        IdTipoCliente = @IdTipoCliente
    WHERE Id = @Id;
END
GO

-- DELETE

USE [TEST];
GO
CREATE PROCEDURE spDeleteCliente
    @Id INT
AS
BEGIN
    UPDATE Cliente
    SET DeletedAt = GETDATE()
    WHERE Id = @Id;
END
GO

CREATE TABLE [dbo].[Factura]
(
    [Id] INT NOT NULL IDENTITY,
    [FechaEmisionFactura] DATETIME2 (7) NOT NULL,
    [NumeroDeFactura] INT NOT NULL,
    [NumeroDeProductos] INT NOT NULL,
    [SubTotalFactura] DECIMAL (18, 2) NOT NULL,
    [TotalImpuestos] DECIMAL (18, 2) NOT NULL,
    [TotalFactura] DECIMAL (18, 2) NOT NULL,
    [IdCliente] INT NOT NULL,
    CONSTRAINT [PK_Factura] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Factura_Cliente_IdCliente] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Cliente] ([Id]) ON DELETE CASCADE
);
-- TODO: Crear procedimiento CRUD para la tabla Factura
-- CREATE

USE [TEST];
GO
CREATE PROCEDURE spCreateFactura
    @FechaEmisionFactura DATETIME2(7),
    @NumeroDeFactura INT,
    @NumeroDeProductos INT,
    @SubTotalFactura DECIMAL(18,2),
    @TotalImpuestos DECIMAL(18,2),
    @TotalFactura DECIMAL(18,2),
    @IdCliente INT
AS

BEGIN
    INSERT INTO Factura
        (FechaEmisionFactura, NumeroDeFactura, NumeroDeProductos, SubTotalFactura, TotalImpuestos, TotalFactura, IdCliente)
    VALUES
        (@FechaEmisionFactura, @NumeroDeFactura, @NumeroDeProductos, @SubTotalFactura, @TotalImpuestos, @TotalFactura, @IdCliente);
END
GO

-- READ

USE [TEST];
GO
CREATE PROCEDURE spGetAllFactura
AS
BEGIN
    SELECT *
    FROM Factura
    WHERE DeletedAt IS NULL;
END
GO


-- UPDATE

USE [TEST];
GO
CREATE PROCEDURE spUpdateFactura
    @Id INT,
    @FechaEmisionFactura DATETIME2(7),
    @NumeroDeFactura INT,
    @NumeroDeProductos INT,
    @SubTotalFactura DECIMAL(18,2),
    @TotalImpuestos DECIMAL(18,2),
    @TotalFactura DECIMAL(18,2),
    @IdCliente INT
AS
BEGIN
    UPDATE Factura
    SET FechaEmisionFactura = @FechaEmisionFactura,
        NumeroDeFactura = @NumeroDeFactura,
        NumeroDeProductos = @NumeroDeProductos,
        SubTotalFactura = @SubTotalFactura,
        TotalImpuestos = @TotalImpuestos,
        TotalFactura = @TotalFactura,
        IdCliente = @IdCliente
    WHERE Id = @Id;
END
GO


-- DELETE

USE [TEST];
GO
CREATE PROCEDURE spDeleteFactura
    @Id INT
AS
BEGIN
    UPDATE Factura
    SET DeletedAt = GETDATE()
    WHERE Id = @Id;
END
GO


CREATE TABLE [dbo].[DetalleFactura]
(
    [Id] INT NOT NULL IDENTITY,
    [CantidadDeProducto] INT NOT NULL,
    [PrecioUnitario] DECIMAL (18, 2) NOT NULL,
    [SubTotal] DECIMAL (18, 2) NOT NULL,
    [Notas] NVARCHAR (MAX) NULL,
    [IdFactura] INT NOT NULL,
    [IdProducto] INT NOT NULL,
    [DeletedAt] DATETIME2 (7) NULL,
    CONSTRAINT [PK_DetalleFactura] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_DetalleFactura_Producto_IdProducto] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Producto] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_DetalleFactura_Factura_IdFactura] FOREIGN KEY ([IdFactura]) REFERENCES [dbo].[Factura] ([Id]) ON DELETE CASCADE
);
-- TODO: Crear procedimiento CRUD para la tabla DetalleFactura
-- CREATE

USE [TEST];
GO
CREATE PROCEDURE spCreateDetalleFactura
    @CantidadDeProducto INT,
    @PrecioUnitario DECIMAL(18,2),
    @SubTotal DECIMAL(18,2),
    @Notas NVARCHAR(MAX),
    @IdFactura INT,
    @IdProducto INT
AS
BEGIN
    INSERT INTO DetalleFactura
        (CantidadDeProducto, PrecioUnitario, SubTotal, Notas, IdFactura, IdProducto)
    VALUES
        (@CantidadDeProducto, @PrecioUnitario, @SubTotal, @Notas, @IdFactura, @IdProducto);
END
GO

-- READ

USE [TEST];
GO
CREATE PROCEDURE spGetAllDetalleFactura
AS
BEGIN
    SELECT *
    FROM DetalleFactura
    WHERE DeletedAt IS NULL;
END
GO

-- UPDATE

USE [TEST];
GO

CREATE PROCEDURE spUpdateDetalleFactura
    @Id INT,
    @CantidadDeProducto INT,
    @PrecioUnitario DECIMAL(18,2),
    @SubTotal DECIMAL(18,2),
    @Notas NVARCHAR(MAX),
    @IdFactura INT,
    @IdProducto INT
AS
BEGIN
    UPDATE DetalleFactura
    SET CantidadDeProducto = @CantidadDeProducto,
        PrecioUnitario = @PrecioUnitario,
        SubTotal = @SubTotal,
        Notas = @Notas,
        IdFactura = @IdFactura,
        IdProducto = @IdProducto
    WHERE Id = @Id;
END
GO

-- DELETE

USE [TEST];
GO
CREATE PROCEDURE spDeleteDetalleFactura
    @Id INT
AS
BEGIN
    UPDATE DetalleFactura
    SET DeletedAt = GETDATE()
    WHERE Id = @Id;
END
GO



-- SQLBook: Code
