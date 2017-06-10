/*
Navicat SQL Server Data Transfer

Source Server         : .
Source Server Version : 110000
Source Host           : :1433
Source Database       : HotPotRestaurant
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 110000
File Encoding         : 65001

Date: 2016-05-09 14:47:17
*/


-- ----------------------------
-- Table structure for Bill
-- ----------------------------
DROP TABLE [dbo].[Bill]
GO
CREATE TABLE [dbo].[Bill] (
[ID] varchar(50) NOT NULL ,
[TableID] int NOT NULL ,
[Date] datetime NOT NULL ,
[CustomerCount] int NOT NULL ,
[TimePeriod] int NOT NULL ,
[TotalCost] money NOT NULL ,
[Discount] int NULL ,
[DiscountType] varchar(50) NULL ,
[ExactCost] money NOT NULL ,
[Remark] varchar(MAX) NULL ,
[UserID] int NOT NULL ,
[UserName] varchar(50) NOT NULL ,
[MemberID] varchar(50) NULL ,
[ReceivedMoney] money NOT NULL ,
[Change] money NOT NULL 
)


GO

-- ----------------------------
-- Table structure for BillDetails
-- ----------------------------
DROP TABLE [dbo].[BillDetails]
GO
CREATE TABLE [dbo].[BillDetails] (
[ID] varchar(50) NOT NULL ,
[DishName] varchar(50) NOT NULL ,
[Amount] float(53) NOT NULL ,
[OrderID] varchar(50) NOT NULL ,
[WarehouseID] int NULL ,
[POID] varchar(50) NULL 
)


GO

-- ----------------------------
-- Table structure for Category
-- ----------------------------
DROP TABLE [dbo].[Category]
GO
CREATE TABLE [dbo].[Category] (
[ID] int NOT NULL IDENTITY(1,1) ,
[ShortID] int NOT NULL ,
[Name] varchar(50) NOT NULL ,
[SuperiorID] int NOT NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[Category]', RESEED, 33)
GO

-- ----------------------------
-- Table structure for CODetails
-- ----------------------------
DROP TABLE [dbo].[CODetails]
GO
CREATE TABLE [dbo].[CODetails] (
[ID] varchar(50) NOT NULL ,
[ProductName] varchar(50) NOT NULL ,
[Unit] varchar(50) NOT NULL ,
[Amount] float(53) NOT NULL ,
[Price] money NOT NULL ,
[OrderID] varchar(50) NOT NULL ,
[POID] varchar(50) NOT NULL 
)


GO

-- ----------------------------
-- Table structure for CreditOrder
-- ----------------------------
DROP TABLE [dbo].[CreditOrder]
GO
CREATE TABLE [dbo].[CreditOrder] (
[ID] varchar(50) NOT NULL ,
[SupplierName] varchar(50) NULL ,
[WarehouseName] varchar(50) NOT NULL ,
[OperatorID] int NOT NULL ,
[OperatorName] varchar(50) NOT NULL ,
[UserID] int NOT NULL ,
[UserName] varchar(50) NOT NULL ,
[Date] datetime NOT NULL ,
[Remark] varchar(MAX) NULL 
)


GO

-- ----------------------------
-- Table structure for Discount
-- ----------------------------
DROP TABLE [dbo].[Discount]
GO
CREATE TABLE [dbo].[Discount] (
[ID] int NOT NULL IDENTITY(1,1) ,
[DiscountPercent] int NOT NULL ,
[Description] varchar(50) NOT NULL ,
[IgnoredCategories] varchar(MAX) NULL ,
[IsMemberOnly] bit NOT NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[Discount]', RESEED, 4)
GO

-- ----------------------------
-- Table structure for Dish
-- ----------------------------
DROP TABLE [dbo].[Dish]
GO
CREATE TABLE [dbo].[Dish] (
[ID] int NOT NULL IDENTITY(1,1) ,
[ShortID] int NOT NULL ,
[Name] varchar(50) NOT NULL ,
[ShortName] varchar(50) NOT NULL ,
[CategoryID] int NOT NULL ,
[Price] money NOT NULL ,
[Unit] varchar(50) NOT NULL ,
[Image] varchar(MAX) NULL ,
[Description] varchar(MAX) NULL ,
[PriceEditable] bit NOT NULL ,
[InventoryControl] bit NOT NULL ,
[UnitConversion] float(53) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[Dish]', RESEED, 1006)
GO

-- ----------------------------
-- Table structure for InventoryList
-- ----------------------------
DROP TABLE [dbo].[InventoryList]
GO
CREATE TABLE [dbo].[InventoryList] (
[ProductID] int NOT NULL ,
[WarehouseID] int NOT NULL ,
[Amount] float(53) NOT NULL ,
[POID] varchar(50) NOT NULL 
)


GO

-- ----------------------------
-- Table structure for MaterialsRequisition
-- ----------------------------
DROP TABLE [dbo].[MaterialsRequisition]
GO
CREATE TABLE [dbo].[MaterialsRequisition] (
[ID] varchar(50) NOT NULL ,
[WarehouseName] varchar(50) NOT NULL ,
[OperatorID] int NOT NULL ,
[OperatorName] varchar(50) NOT NULL ,
[UserID] int NOT NULL ,
[UserName] varchar(50) NOT NULL ,
[Date] datetime NOT NULL ,
[Remark] varchar(MAX) NULL 
)


GO

-- ----------------------------
-- Table structure for MaterialsReturnOrder
-- ----------------------------
DROP TABLE [dbo].[MaterialsReturnOrder]
GO
CREATE TABLE [dbo].[MaterialsReturnOrder] (
[ID] varchar(50) NOT NULL ,
[WarehouseName] varchar(50) NOT NULL ,
[OperatorID] int NOT NULL ,
[OperatorName] varchar(50) NOT NULL ,
[UserID] int NOT NULL ,
[UserName] varchar(50) NOT NULL ,
[Date] datetime NOT NULL ,
[Remark] varchar(MAX) NULL 
)


GO

-- ----------------------------
-- Table structure for Member
-- ----------------------------
DROP TABLE [dbo].[Member]
GO
CREATE TABLE [dbo].[Member] (
[ID] varchar(50) NOT NULL ,
[Name] varchar(50) NOT NULL ,
[Tele] varchar(25) NOT NULL ,
[Point] int NOT NULL 
)


GO

-- ----------------------------
-- Table structure for MonthlyReport
-- ----------------------------
DROP TABLE [dbo].[MonthlyReport]
GO
CREATE TABLE [dbo].[MonthlyReport] (
[ID] varchar(50) NOT NULL ,
[Date] datetime NOT NULL ,
[WarehouseName] varchar(50) NOT NULL 
)


GO

-- ----------------------------
-- Table structure for MRDetails
-- ----------------------------
DROP TABLE [dbo].[MRDetails]
GO
CREATE TABLE [dbo].[MRDetails] (
[ID] varchar(50) NOT NULL ,
[ProductName] varchar(50) NOT NULL ,
[Unit] varchar(50) NOT NULL ,
[Amount] float(53) NOT NULL ,
[OrderID] varchar(50) NOT NULL ,
[POID] varchar(50) NOT NULL 
)


GO

-- ----------------------------
-- Table structure for MReportDetails
-- ----------------------------
DROP TABLE [dbo].[MReportDetails]
GO
CREATE TABLE [dbo].[MReportDetails] (
[ID] varchar(50) NOT NULL ,
[ProductName] varchar(50) NOT NULL ,
[PurchasePrice] money NOT NULL ,
[PurchaseAmount] float(53) NOT NULL ,
[PurchaseTotalPrice] money NOT NULL ,
[MRequisitionAmount] float(53) NOT NULL ,
[MReturnAmount] float(53) NOT NULL ,
[CreditPrice] money NOT NULL ,
[CreditAmount] float(53) NOT NULL ,
[CreditTotalPrice] money NOT NULL ,
[SListPrice] money NOT NULL ,
[SListAmount] float(53) NOT NULL ,
[SListTotalPrice] money NOT NULL ,
[OrderID] varchar(50) NOT NULL ,
[MRequisitionPrice] money NOT NULL ,
[MRequisitionTotalPrice] money NOT NULL ,
[MReturnPrice] money NOT NULL ,
[MReturnTotalPrice] money NOT NULL ,
[BillPrice] money NOT NULL ,
[BillAmount] float(53) NOT NULL ,
[BillTotalPrice] money NOT NULL 
)


GO

-- ----------------------------
-- Table structure for MRODetails
-- ----------------------------
DROP TABLE [dbo].[MRODetails]
GO
CREATE TABLE [dbo].[MRODetails] (
[ID] varchar(50) NOT NULL ,
[ProductName] varchar(50) NOT NULL ,
[Unit] varchar(50) NOT NULL ,
[Amount] float(53) NOT NULL ,
[OrderID] varchar(50) NOT NULL ,
[POID] varchar(50) NOT NULL 
)


GO

-- ----------------------------
-- Table structure for PODetails
-- ----------------------------
DROP TABLE [dbo].[PODetails]
GO
CREATE TABLE [dbo].[PODetails] (
[ID] varchar(50) NOT NULL ,
[ProductName] varchar(50) NOT NULL ,
[Unit] varchar(50) NOT NULL ,
[Amount] float(53) NOT NULL ,
[Price] money NOT NULL ,
[OrderID] varchar(50) NOT NULL 
)


GO

-- ----------------------------
-- Table structure for Product
-- ----------------------------
DROP TABLE [dbo].[Product]
GO
CREATE TABLE [dbo].[Product] (
[ID] int NOT NULL IDENTITY(1,1) ,
[ShortID] int NOT NULL ,
[Name] varchar(50) NOT NULL ,
[ShortName] varchar(50) NOT NULL ,
[CategoryID] int NOT NULL ,
[Unit] varchar(50) NOT NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[Product]', RESEED, 2008)
GO

-- ----------------------------
-- Table structure for PurchaseOrder
-- ----------------------------
DROP TABLE [dbo].[PurchaseOrder]
GO
CREATE TABLE [dbo].[PurchaseOrder] (
[ID] varchar(50) NOT NULL ,
[SupplierName] varchar(50) NULL ,
[WarehouseName] varchar(50) NOT NULL ,
[OperatorID] int NOT NULL ,
[OperatorName] varchar(50) NOT NULL ,
[UserID] int NOT NULL ,
[UserName] varchar(50) NOT NULL ,
[Date] datetime NOT NULL ,
[Remark] varchar(MAX) NULL 
)


GO

-- ----------------------------
-- Table structure for ServingTable
-- ----------------------------
DROP TABLE [dbo].[ServingTable]
GO
CREATE TABLE [dbo].[ServingTable] (
[ID] int NOT NULL ,
[BillID] varchar(50) NOT NULL 
)


GO

-- ----------------------------
-- Table structure for SLDetails
-- ----------------------------
DROP TABLE [dbo].[SLDetails]
GO
CREATE TABLE [dbo].[SLDetails] (
[ID] varchar(50) NOT NULL ,
[ProductName] varchar(50) NOT NULL ,
[Unit] varchar(50) NOT NULL ,
[Amount] float(53) NOT NULL ,
[OrderID] varchar(50) NOT NULL ,
[POID] varchar(50) NOT NULL 
)


GO

-- ----------------------------
-- Table structure for StartOfTerm
-- ----------------------------
DROP TABLE [dbo].[StartOfTerm]
GO
CREATE TABLE [dbo].[StartOfTerm] (
[ID] varchar(50) NOT NULL ,
[Date] datetime NOT NULL ,
[ProductName] varchar(50) NOT NULL ,
[WarehouseName] varchar(50) NOT NULL ,
[Price] money NOT NULL ,
[Amount] float(53) NOT NULL ,
[TotalPrice] money NOT NULL 
)


GO

-- ----------------------------
-- Table structure for StocktakingList
-- ----------------------------
DROP TABLE [dbo].[StocktakingList]
GO
CREATE TABLE [dbo].[StocktakingList] (
[ID] varchar(50) NOT NULL ,
[WarehouseName] varchar(50) NOT NULL ,
[OperatorID] int NOT NULL ,
[OperatorName] varchar(50) NOT NULL ,
[UserID] int NOT NULL ,
[UserName] varchar(50) NOT NULL ,
[Date] datetime NOT NULL ,
[Remark] varchar(MAX) NULL 
)


GO

-- ----------------------------
-- Table structure for TODetails
-- ----------------------------
DROP TABLE [dbo].[TODetails]
GO
CREATE TABLE [dbo].[TODetails] (
[ID] varchar(50) NOT NULL ,
[ProductName] varchar(50) NOT NULL ,
[Unit] varchar(50) NOT NULL ,
[Amount] float(53) NOT NULL ,
[OrderID] varchar(50) NOT NULL ,
[POID] varchar(50) NOT NULL 
)


GO

-- ----------------------------
-- Table structure for TransferOrder
-- ----------------------------
DROP TABLE [dbo].[TransferOrder]
GO
CREATE TABLE [dbo].[TransferOrder] (
[ID] varchar(50) NOT NULL ,
[OutName] varchar(50) NOT NULL ,
[InName] varchar(50) NOT NULL ,
[OperatorID] int NOT NULL ,
[OperatorName] varchar(50) NOT NULL ,
[UserID] int NOT NULL ,
[UserName] varchar(50) NOT NULL ,
[Date] datetime NOT NULL ,
[Remark] varchar(MAX) NULL 
)


GO

-- ----------------------------
-- Table structure for User
-- ----------------------------
DROP TABLE [dbo].[User]
GO
CREATE TABLE [dbo].[User] (
[ID] int NOT NULL IDENTITY(1,1) ,
[ShortID] int NOT NULL ,
[UserName] varchar(50) NOT NULL ,
[Role] int NOT NULL ,
[Password] varchar(50) NOT NULL ,
[RealName] varchar(50) NOT NULL ,
[RealPost] varchar(50) NOT NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[User]', RESEED, 1007)
GO

-- ----------------------------
-- Table structure for Warehouse
-- ----------------------------
DROP TABLE [dbo].[Warehouse]
GO
CREATE TABLE [dbo].[Warehouse] (
[ID] int NOT NULL IDENTITY(1,1) ,
[ShortID] int NOT NULL ,
[Name] varchar(50) NOT NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[Warehouse]', RESEED, 3032)
GO

-- ----------------------------
-- View structure for VBill
-- ----------------------------
DROP VIEW [dbo].[VBill]
GO
CREATE VIEW [dbo].[VBill] AS 
SELECT
dbo.Bill.ID AS BillID,
dbo.Bill.TableID,
dbo.Bill.[Date],
dbo.Bill.CustomerCount,
dbo.Bill.TimePeriod,
dbo.Bill.TotalCost,
dbo.Bill.Discount,
dbo.Bill.DiscountType,
dbo.Bill.ExactCost,
dbo.Bill.Remark,
dbo.Bill.UserID,
dbo.Bill.UserName,
dbo.BillDetails.ID AS DetailsID,
dbo.BillDetails.DishName,
dbo.BillDetails.Amount,
dbo.Bill.MemberID,
dbo.Bill.ReceivedMoney,
dbo.Bill.Change

FROM
dbo.Bill
INNER JOIN dbo.BillDetails ON dbo.BillDetails.OrderID = dbo.Bill.ID
GO

-- ----------------------------
-- View structure for VCreditOrder
-- ----------------------------
DROP VIEW [dbo].[VCreditOrder]
GO
CREATE VIEW [dbo].[VCreditOrder] AS 
SELECT
dbo.CreditOrder.ID,
dbo.CreditOrder.WarehouseName,
dbo.CreditOrder.[Date],
dbo.CODetails.ProductName,
dbo.CODetails.Amount,
dbo.CODetails.Price,
dbo.CODetails.Price * dbo.CODetails.Amount as TotalPrice

FROM
dbo.CreditOrder
INNER JOIN dbo.CODetails ON dbo.CreditOrder.ID = dbo.CODetails.OrderID
GO

-- ----------------------------
-- View structure for VInventoryList
-- ----------------------------
DROP VIEW [dbo].[VInventoryList]
GO
CREATE VIEW [dbo].[VInventoryList] AS 
SELECT
dbo.InventoryList.POID,
dbo.InventoryList.ProductID,
dbo.Product.ShortID AS ProductShortID,
dbo.Product.Name AS ProductName,
dbo.Product.ShortName AS ProductShortName,
dbo.InventoryList.WarehouseID,
dbo.Warehouse.ShortID AS WarehouseShortID,
dbo.Warehouse.Name AS WarehouseName,
dbo.InventoryList.Amount,
dbo.Product.Unit

FROM
dbo.InventoryList
INNER JOIN dbo.Product ON dbo.Product.ID = dbo.InventoryList.ProductID
INNER JOIN dbo.Warehouse ON dbo.Warehouse.ID = dbo.InventoryList.WarehouseID
GO

-- ----------------------------
-- View structure for VMaterialsRequisition
-- ----------------------------
DROP VIEW [dbo].[VMaterialsRequisition]
GO
CREATE VIEW [dbo].[VMaterialsRequisition] AS 
SELECT
dbo.MaterialsRequisition.ID,
dbo.MaterialsRequisition.WarehouseName,
dbo.MaterialsRequisition.[Date],
dbo.MRDetails.ProductName,
dbo.MRDetails.Amount,
dbo.PODetails.Price,
dbo.PODetails.Price * dbo.MRDetails.Amount as TotalPrice

FROM
dbo.MaterialsRequisition
INNER JOIN dbo.MRDetails ON dbo.MaterialsRequisition.ID = dbo.MRDetails.OrderID
INNER JOIN dbo.PODetails ON dbo.MRDetails.POID = dbo.PODetails.ID
GO

-- ----------------------------
-- View structure for VMaterialsReturnOrder
-- ----------------------------
DROP VIEW [dbo].[VMaterialsReturnOrder]
GO
CREATE VIEW [dbo].[VMaterialsReturnOrder] AS 
SELECT
dbo.MaterialsReturnOrder.ID,
dbo.MaterialsReturnOrder.WarehouseName,
dbo.MaterialsReturnOrder.[Date],
dbo.MRODetails.ProductName,
dbo.MRODetails.Amount,
dbo.PODetails.Price,
dbo.PODetails.Price * dbo.MRODetails.Amount as TotalPrice

FROM
dbo.MaterialsReturnOrder
INNER JOIN dbo.MRODetails ON dbo.MaterialsReturnOrder.ID = dbo.MRODetails.OrderID
INNER JOIN dbo.PODetails ON dbo.MRODetails.POID = dbo.PODetails.ID
GO

-- ----------------------------
-- View structure for VPurchaseOrder
-- ----------------------------
DROP VIEW [dbo].[VPurchaseOrder]
GO
CREATE VIEW [dbo].[VPurchaseOrder] AS 
SELECT
dbo.PurchaseOrder.ID,
dbo.PurchaseOrder.WarehouseName,
dbo.PurchaseOrder.[Date],
dbo.PODetails.ProductName,
dbo.PODetails.Amount,
dbo.PODetails.Price,
dbo.PODetails.Price * dbo.PODetails.Amount as TotalPrice

FROM
dbo.PurchaseOrder
INNER JOIN dbo.PODetails ON dbo.PurchaseOrder.ID = dbo.PODetails.OrderID
GO

-- ----------------------------
-- View structure for VStockingList
-- ----------------------------
DROP VIEW [dbo].[VStockingList]
GO
CREATE VIEW [dbo].[VStockingList] AS 
SELECT
dbo.StocktakingList.ID,
dbo.StocktakingList.WarehouseName,
dbo.StocktakingList.[Date],
dbo.SLDetails.ProductName,
dbo.SLDetails.Amount,
dbo.PODetails.Price,
dbo.PODetails.Price * dbo.SLDetails.Amount as TotalPrice

FROM
dbo.StocktakingList
INNER JOIN dbo.SLDetails ON dbo.StocktakingList.ID = dbo.SLDetails.OrderID
INNER JOIN dbo.PODetails ON dbo.SLDetails.POID = dbo.PODetails.ID
GO

-- ----------------------------
-- Indexes structure for table Bill
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Bill
-- ----------------------------
ALTER TABLE [dbo].[Bill] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table BillDetails
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table BillDetails
-- ----------------------------
ALTER TABLE [dbo].[BillDetails] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table Category
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Category
-- ----------------------------
ALTER TABLE [dbo].[Category] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table CODetails
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table CODetails
-- ----------------------------
ALTER TABLE [dbo].[CODetails] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table CreditOrder
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table CreditOrder
-- ----------------------------
ALTER TABLE [dbo].[CreditOrder] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table Discount
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Discount
-- ----------------------------
ALTER TABLE [dbo].[Discount] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table Dish
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Dish
-- ----------------------------
ALTER TABLE [dbo].[Dish] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table InventoryList
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table InventoryList
-- ----------------------------
ALTER TABLE [dbo].[InventoryList] ADD PRIMARY KEY ([POID], [WarehouseID])
GO

-- ----------------------------
-- Indexes structure for table MaterialsRequisition
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table MaterialsRequisition
-- ----------------------------
ALTER TABLE [dbo].[MaterialsRequisition] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table MaterialsReturnOrder
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table MaterialsReturnOrder
-- ----------------------------
ALTER TABLE [dbo].[MaterialsReturnOrder] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table Member
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Member
-- ----------------------------
ALTER TABLE [dbo].[Member] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table MonthlyReport
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table MonthlyReport
-- ----------------------------
ALTER TABLE [dbo].[MonthlyReport] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table MRDetails
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table MRDetails
-- ----------------------------
ALTER TABLE [dbo].[MRDetails] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table MReportDetails
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table MReportDetails
-- ----------------------------
ALTER TABLE [dbo].[MReportDetails] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table MRODetails
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table MRODetails
-- ----------------------------
ALTER TABLE [dbo].[MRODetails] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table PODetails
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table PODetails
-- ----------------------------
ALTER TABLE [dbo].[PODetails] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table Product
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Product
-- ----------------------------
ALTER TABLE [dbo].[Product] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table PurchaseOrder
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table PurchaseOrder
-- ----------------------------
ALTER TABLE [dbo].[PurchaseOrder] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table ServingTable
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table ServingTable
-- ----------------------------
ALTER TABLE [dbo].[ServingTable] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table SLDetails
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table SLDetails
-- ----------------------------
ALTER TABLE [dbo].[SLDetails] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table StartOfTerm
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table StartOfTerm
-- ----------------------------
ALTER TABLE [dbo].[StartOfTerm] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table StocktakingList
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table StocktakingList
-- ----------------------------
ALTER TABLE [dbo].[StocktakingList] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table TODetails
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table TODetails
-- ----------------------------
ALTER TABLE [dbo].[TODetails] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table TransferOrder
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table TransferOrder
-- ----------------------------
ALTER TABLE [dbo].[TransferOrder] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table User
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table User
-- ----------------------------
ALTER TABLE [dbo].[User] ADD PRIMARY KEY ([ID])
GO

-- ----------------------------
-- Indexes structure for table Warehouse
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Warehouse
-- ----------------------------
ALTER TABLE [dbo].[Warehouse] ADD PRIMARY KEY ([ID])
GO
