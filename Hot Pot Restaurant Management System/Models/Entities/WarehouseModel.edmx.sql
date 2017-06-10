
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/09/2017 23:44:18
-- Generated from EDMX file: C:\Users\Elizabeth\Desktop\Hot-Pot-Restaurant-Management-System-master\Hot-Pot-Restaurant-Management-System-master\Hot Pot Restaurant Management System\Models\Entities\WarehouseModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Warehouse];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Category]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Category];
GO
IF OBJECT_ID(N'[dbo].[CODetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CODetails];
GO
IF OBJECT_ID(N'[dbo].[CreditOrder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CreditOrder];
GO
IF OBJECT_ID(N'[dbo].[InventoryList]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InventoryList];
GO
IF OBJECT_ID(N'[dbo].[MaterialsRequisition]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MaterialsRequisition];
GO
IF OBJECT_ID(N'[dbo].[MaterialsReturnOrder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MaterialsReturnOrder];
GO
IF OBJECT_ID(N'[dbo].[MRDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MRDetails];
GO
IF OBJECT_ID(N'[dbo].[MRODetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MRODetails];
GO
IF OBJECT_ID(N'[dbo].[PODetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PODetails];
GO
IF OBJECT_ID(N'[dbo].[Product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product];
GO
IF OBJECT_ID(N'[dbo].[PurchaseOrder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PurchaseOrder];
GO
IF OBJECT_ID(N'[dbo].[SLDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SLDetails];
GO
IF OBJECT_ID(N'[dbo].[StocktakingList]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StocktakingList];
GO
IF OBJECT_ID(N'[dbo].[TODetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TODetails];
GO
IF OBJECT_ID(N'[dbo].[TransferOrder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransferOrder];
GO
IF OBJECT_ID(N'[dbo].[Warehouse]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Warehouse];
GO
IF OBJECT_ID(N'[WarehouseModelStoreContainer].[VInventoryList]', 'U') IS NOT NULL
    DROP TABLE [WarehouseModelStoreContainer].[VInventoryList];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Category'
CREATE TABLE [dbo].[Category] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ShortID] int  NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [SuperiorID] int  NOT NULL
);
GO

-- Creating table 'CreditOrder'
CREATE TABLE [dbo].[CreditOrder] (
    [ID] varchar(50)  NOT NULL,
    [SupplierName] varchar(50)  NULL,
    [WarehouseName] varchar(50)  NOT NULL,
    [OperatorID] int  NOT NULL,
    [OperatorName] varchar(50)  NOT NULL,
    [UserID] int  NOT NULL,
    [UserName] varchar(50)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Remark] varchar(max)  NULL
);
GO

-- Creating table 'MaterialsRequisition'
CREATE TABLE [dbo].[MaterialsRequisition] (
    [ID] varchar(50)  NOT NULL,
    [WarehouseName] varchar(50)  NOT NULL,
    [OperatorID] int  NOT NULL,
    [OperatorName] varchar(50)  NOT NULL,
    [UserID] int  NOT NULL,
    [UserName] varchar(50)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Remark] varchar(max)  NULL
);
GO

-- Creating table 'MaterialsReturnOrder'
CREATE TABLE [dbo].[MaterialsReturnOrder] (
    [ID] varchar(50)  NOT NULL,
    [WarehouseName] varchar(50)  NOT NULL,
    [OperatorID] int  NOT NULL,
    [OperatorName] varchar(50)  NOT NULL,
    [UserID] int  NOT NULL,
    [UserName] varchar(50)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Remark] varchar(max)  NULL
);
GO

-- Creating table 'PurchaseOrder'
CREATE TABLE [dbo].[PurchaseOrder] (
    [ID] varchar(50)  NOT NULL,
    [SupplierName] varchar(50)  NULL,
    [WarehouseName] varchar(50)  NOT NULL,
    [OperatorID] int  NOT NULL,
    [OperatorName] varchar(50)  NOT NULL,
    [UserID] int  NOT NULL,
    [UserName] varchar(50)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Remark] varchar(max)  NULL
);
GO

-- Creating table 'StocktakingList'
CREATE TABLE [dbo].[StocktakingList] (
    [ID] varchar(50)  NOT NULL,
    [WarehouseName] varchar(50)  NOT NULL,
    [OperatorID] int  NOT NULL,
    [OperatorName] varchar(50)  NOT NULL,
    [UserID] int  NOT NULL,
    [UserName] varchar(50)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Remark] varchar(max)  NULL
);
GO

-- Creating table 'TransferOrder'
CREATE TABLE [dbo].[TransferOrder] (
    [ID] varchar(50)  NOT NULL,
    [OutName] varchar(50)  NOT NULL,
    [InName] varchar(50)  NOT NULL,
    [OperatorID] int  NOT NULL,
    [OperatorName] varchar(50)  NOT NULL,
    [UserID] int  NOT NULL,
    [UserName] varchar(50)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Remark] varchar(max)  NULL
);
GO

-- Creating table 'Warehouse'
CREATE TABLE [dbo].[Warehouse] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ShortID] int  NOT NULL,
    [Name] varchar(50)  NOT NULL
);
GO

-- Creating table 'Product'
CREATE TABLE [dbo].[Product] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ShortID] int  NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [ShortName] varchar(50)  NOT NULL,
    [CategoryID] int  NOT NULL,
    [Unit] varchar(50)  NOT NULL
);
GO

-- Creating table 'CODetails'
CREATE TABLE [dbo].[CODetails] (
    [ID] varchar(50)  NOT NULL,
    [ProductName] varchar(50)  NOT NULL,
    [Unit] varchar(50)  NOT NULL,
    [Amount] float  NOT NULL,
    [Price] decimal(19,4)  NOT NULL,
    [OrderID] varchar(50)  NOT NULL,
    [POID] varchar(50)  NOT NULL
);
GO

-- Creating table 'InventoryList'
CREATE TABLE [dbo].[InventoryList] (
    [ProductID] int  NOT NULL,
    [WarehouseID] int  NOT NULL,
    [Amount] float  NOT NULL,
    [POID] varchar(50)  NOT NULL
);
GO

-- Creating table 'MRDetails'
CREATE TABLE [dbo].[MRDetails] (
    [ID] varchar(50)  NOT NULL,
    [ProductName] varchar(50)  NOT NULL,
    [Unit] varchar(50)  NOT NULL,
    [Amount] float  NOT NULL,
    [OrderID] varchar(50)  NOT NULL,
    [POID] varchar(50)  NOT NULL
);
GO

-- Creating table 'MRODetails'
CREATE TABLE [dbo].[MRODetails] (
    [ID] varchar(50)  NOT NULL,
    [ProductName] varchar(50)  NOT NULL,
    [Unit] varchar(50)  NOT NULL,
    [Amount] float  NOT NULL,
    [OrderID] varchar(50)  NOT NULL,
    [POID] varchar(50)  NOT NULL
);
GO

-- Creating table 'PODetails'
CREATE TABLE [dbo].[PODetails] (
    [ID] varchar(50)  NOT NULL,
    [ProductName] varchar(50)  NOT NULL,
    [Unit] varchar(50)  NOT NULL,
    [Amount] float  NOT NULL,
    [Price] decimal(19,4)  NOT NULL,
    [OrderID] varchar(50)  NOT NULL
);
GO

-- Creating table 'SLDetails'
CREATE TABLE [dbo].[SLDetails] (
    [ID] varchar(50)  NOT NULL,
    [ProductName] varchar(50)  NOT NULL,
    [Unit] varchar(50)  NOT NULL,
    [Amount] float  NOT NULL,
    [OrderID] varchar(50)  NOT NULL,
    [POID] varchar(50)  NOT NULL
);
GO

-- Creating table 'TODetails'
CREATE TABLE [dbo].[TODetails] (
    [ID] varchar(50)  NOT NULL,
    [ProductName] varchar(50)  NOT NULL,
    [Unit] varchar(50)  NOT NULL,
    [Amount] float  NOT NULL,
    [OrderID] varchar(50)  NOT NULL,
    [POID] varchar(50)  NOT NULL
);
GO

-- Creating table 'VInventoryList'
CREATE TABLE [dbo].[VInventoryList] (
    [POID] varchar(50)  NOT NULL,
    [ProductID] int  NOT NULL,
    [ProductShortID] int  NOT NULL,
    [ProductName] varchar(50)  NOT NULL,
    [ProductShortName] varchar(50)  NOT NULL,
    [WarehouseID] int  NOT NULL,
    [WarehouseShortID] int  NOT NULL,
    [WarehouseName] varchar(50)  NOT NULL,
    [Amount] float  NOT NULL,
    [Unit] varchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Category'
ALTER TABLE [dbo].[Category]
ADD CONSTRAINT [PK_Category]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'CreditOrder'
ALTER TABLE [dbo].[CreditOrder]
ADD CONSTRAINT [PK_CreditOrder]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'MaterialsRequisition'
ALTER TABLE [dbo].[MaterialsRequisition]
ADD CONSTRAINT [PK_MaterialsRequisition]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'MaterialsReturnOrder'
ALTER TABLE [dbo].[MaterialsReturnOrder]
ADD CONSTRAINT [PK_MaterialsReturnOrder]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PurchaseOrder'
ALTER TABLE [dbo].[PurchaseOrder]
ADD CONSTRAINT [PK_PurchaseOrder]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'StocktakingList'
ALTER TABLE [dbo].[StocktakingList]
ADD CONSTRAINT [PK_StocktakingList]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TransferOrder'
ALTER TABLE [dbo].[TransferOrder]
ADD CONSTRAINT [PK_TransferOrder]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Warehouse'
ALTER TABLE [dbo].[Warehouse]
ADD CONSTRAINT [PK_Warehouse]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [PK_Product]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'CODetails'
ALTER TABLE [dbo].[CODetails]
ADD CONSTRAINT [PK_CODetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [WarehouseID], [POID] in table 'InventoryList'
ALTER TABLE [dbo].[InventoryList]
ADD CONSTRAINT [PK_InventoryList]
    PRIMARY KEY CLUSTERED ([WarehouseID], [POID] ASC);
GO

-- Creating primary key on [ID] in table 'MRDetails'
ALTER TABLE [dbo].[MRDetails]
ADD CONSTRAINT [PK_MRDetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'MRODetails'
ALTER TABLE [dbo].[MRODetails]
ADD CONSTRAINT [PK_MRODetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PODetails'
ALTER TABLE [dbo].[PODetails]
ADD CONSTRAINT [PK_PODetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'SLDetails'
ALTER TABLE [dbo].[SLDetails]
ADD CONSTRAINT [PK_SLDetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TODetails'
ALTER TABLE [dbo].[TODetails]
ADD CONSTRAINT [PK_TODetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [POID], [ProductID], [ProductShortID], [ProductName], [ProductShortName], [WarehouseID], [WarehouseShortID], [WarehouseName], [Amount], [Unit] in table 'VInventoryList'
ALTER TABLE [dbo].[VInventoryList]
ADD CONSTRAINT [PK_VInventoryList]
    PRIMARY KEY CLUSTERED ([POID], [ProductID], [ProductShortID], [ProductName], [ProductShortName], [WarehouseID], [WarehouseShortID], [WarehouseName], [Amount], [Unit] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------