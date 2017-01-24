
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/23/2017 11:03:12
-- Generated from EDMX file: C:\work\Rotal\Rotal calibration\project\RotalCalib\DP_dashboard\RIT_QA\RIT_Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [RIT_QA];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Calibration_Batches]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Devices] DROP CONSTRAINT [FK_Calibration_Batches];
GO
IF OBJECT_ID(N'[dbo].[FK_CalibrationDatas_Devices]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalibrationDatas] DROP CONSTRAINT [FK_CalibrationDatas_Devices];
GO
IF OBJECT_ID(N'[dbo].[FK_CalibrationDatas_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalibrationDatas] DROP CONSTRAINT [FK_CalibrationDatas_Users];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Batches]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Batches];
GO
IF OBJECT_ID(N'[dbo].[CalibrationDatas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CalibrationDatas];
GO
IF OBJECT_ID(N'[dbo].[Devices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Devices];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Batches'
CREATE TABLE [dbo].[Batches] (
    [Id] int  NOT NULL,
    [BatchNumber] nchar(15)  NULL,
    [Date] datetime  NULL
);
GO

-- Creating table 'CalibrationDatas'
CREATE TABLE [dbo].[CalibrationDatas] (
    [SerialNo] nchar(20)  NOT NULL,
    [UserID] int  NULL,
    [StationID] int  NULL,
    [PressureSP] float  NULL,
    [PressurePLC] float  NULL,
    [TempSP] float  NULL,
    [TempDP] float  NULL,
    [RightA2D] int  NULL,
    [LeftA2D] int  NULL,
    [id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Devices'
CREATE TABLE [dbo].[Devices] (
    [SerialNo] nchar(20)  NOT NULL,
    [MAC] nchar(12)  NULL,
    [Date] datetime  NULL,
    [BatchId] int  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nchar(30)  NULL,
    [Password] nchar(30)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Batches'
ALTER TABLE [dbo].[Batches]
ADD CONSTRAINT [PK_Batches]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'CalibrationDatas'
ALTER TABLE [dbo].[CalibrationDatas]
ADD CONSTRAINT [PK_CalibrationDatas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [SerialNo] in table 'Devices'
ALTER TABLE [dbo].[Devices]
ADD CONSTRAINT [PK_Devices]
    PRIMARY KEY CLUSTERED ([SerialNo] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BatchId] in table 'Devices'
ALTER TABLE [dbo].[Devices]
ADD CONSTRAINT [FK_Calibration_Batches]
    FOREIGN KEY ([BatchId])
    REFERENCES [dbo].[Batches]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Calibration_Batches'
CREATE INDEX [IX_FK_Calibration_Batches]
ON [dbo].[Devices]
    ([BatchId]);
GO

-- Creating foreign key on [SerialNo] in table 'CalibrationDatas'
ALTER TABLE [dbo].[CalibrationDatas]
ADD CONSTRAINT [FK_CalibrationDatas_Devices]
    FOREIGN KEY ([SerialNo])
    REFERENCES [dbo].[Devices]
        ([SerialNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalibrationDatas_Devices'
CREATE INDEX [IX_FK_CalibrationDatas_Devices]
ON [dbo].[CalibrationDatas]
    ([SerialNo]);
GO

-- Creating foreign key on [UserID] in table 'CalibrationDatas'
ALTER TABLE [dbo].[CalibrationDatas]
ADD CONSTRAINT [FK_CalibrationDatas_Users]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalibrationDatas_Users'
CREATE INDEX [IX_FK_CalibrationDatas_Users]
ON [dbo].[CalibrationDatas]
    ([UserID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------