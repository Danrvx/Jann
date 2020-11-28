
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/28/2020 02:58:02
-- Generated from EDMX file: C:\Users\DanRh\source\repos\BuscarDatos\BuscarDatos\EntitiModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DatosClientes];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Clientes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clientes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Clientes'
CREATE TABLE [dbo].[Clientes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombre] varchar(255)  NULL,
    [apellidop] nvarchar(max)  NOT NULL,
    [apellidom] nvarchar(max)  NOT NULL,
    [telefono] varchar(100)  NULL,
    [direccion] varchar(255)  NULL,
    [asesor] varchar(255)  NULL,
    [fraccionamiento] varchar(100)  NULL,
    [financiamiento] varchar(255)  NULL,
    [estatus] varchar(max)  NULL,
    [ultimo_seguimiento] varchar(255)  NULL,
    [ver_expediente] varchar(255)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Clientes'
ALTER TABLE [dbo].[Clientes]
ADD CONSTRAINT [PK_Clientes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------