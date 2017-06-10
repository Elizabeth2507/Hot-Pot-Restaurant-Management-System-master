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

Date: 2016-05-09 14:47:25
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
-- Records of Bill
-- ----------------------------
INSERT INTO [dbo].[Bill] ([ID], [TableID], [Date], [CustomerCount], [TimePeriod], [TotalCost], [Discount], [DiscountType], [ExactCost], [Remark], [UserID], [UserName], [MemberID], [ReceivedMoney], [Change]) VALUES (N'000720160328164330', N'2', N'2016-03-28 16:43:30.000', N'1', N'3', N'45.0000', N'80', N'八折（不含肉类，蔬菜）', N'45.0000', null, N'2', N'2', null, N'.0000', N'.0000')
GO
GO
INSERT INTO [dbo].[Bill] ([ID], [TableID], [Date], [CustomerCount], [TimePeriod], [TotalCost], [Discount], [DiscountType], [ExactCost], [Remark], [UserID], [UserName], [MemberID], [ReceivedMoney], [Change]) VALUES (N'000720160328173805', N'1', N'2016-03-28 17:38:05.000', N'1', N'3', N'50.0000', N'80', N'八折（不含肉类，蔬菜）', N'50.0000', null, N'2', N'2', N'1', N'100.0000', N'50.0000')
GO
GO
INSERT INTO [dbo].[Bill] ([ID], [TableID], [Date], [CustomerCount], [TimePeriod], [TotalCost], [Discount], [DiscountType], [ExactCost], [Remark], [UserID], [UserName], [MemberID], [ReceivedMoney], [Change]) VALUES (N'000720160328174149', N'1', N'2016-03-28 17:41:49.000', N'1', N'3', N'10.0000', N'80', N'会员八折（不含酒水）', N'8.0000', null, N'2', N'2', N'1', N'.0000', N'.0000')
GO
GO
INSERT INTO [dbo].[Bill] ([ID], [TableID], [Date], [CustomerCount], [TimePeriod], [TotalCost], [Discount], [DiscountType], [ExactCost], [Remark], [UserID], [UserName], [MemberID], [ReceivedMoney], [Change]) VALUES (N'000720160329114745', N'3', N'2016-03-29 11:47:45.000', N'3', N'2', N'10.0000', N'85', N'八五折（不含酒水）', N'8.5000', null, N'1', N'1', null, N'.0000', N'.0000')
GO
GO
INSERT INTO [dbo].[Bill] ([ID], [TableID], [Date], [CustomerCount], [TimePeriod], [TotalCost], [Discount], [DiscountType], [ExactCost], [Remark], [UserID], [UserName], [MemberID], [ReceivedMoney], [Change]) VALUES (N'000720160419163152', N'14', N'2016-04-19 16:31:52.000', N'1', N'3', N'5.0000', null, null, N'5.0000', null, N'123', N'123', null, N'.0000', N'.0000')
GO
GO
INSERT INTO [dbo].[Bill] ([ID], [TableID], [Date], [CustomerCount], [TimePeriod], [TotalCost], [Discount], [DiscountType], [ExactCost], [Remark], [UserID], [UserName], [MemberID], [ReceivedMoney], [Change]) VALUES (N'000720160426142842', N'3', N'2016-04-26 14:28:42.000', N'1', N'3', N'7.0000', null, null, N'7.0000', null, N'123', N'123', null, N'.0000', N'.0000')
GO
GO
INSERT INTO [dbo].[Bill] ([ID], [TableID], [Date], [CustomerCount], [TimePeriod], [TotalCost], [Discount], [DiscountType], [ExactCost], [Remark], [UserID], [UserName], [MemberID], [ReceivedMoney], [Change]) VALUES (N'000720160509141258', N'3', N'2016-05-09 14:12:58.000', N'3', N'3', N'20.0000', N'90', N'九折', N'18.0000', null, N'123', N'123', null, N'18.0000', N'18.0000')
GO
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
-- Records of BillDetails
-- ----------------------------
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603181633061', N'茄子', N'1', N'000720160318163221', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603211043311', N'茄子', N'1', N'000720160321104326', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603211048001', N'茄子', N'1', N'000720160321104335', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603211048002', N'鸡腿', N'1', N'000720160321104335', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603211108201', N'茄子', N'1', N'000720160321110551', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603211108202', N'鸡腿', N'2', N'000720160321110551', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603211109501', N'茄子', N'1', N'000720160321110932', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603211109502', N'鸡腿', N'2', N'000720160321110932', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603211111051', N'茄子', N'1', N'000720160321111047', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603211111052', N'鸡腿', N'1', N'000720160321111047', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603211111053', N'茄子', N'1', N'000720160321111047', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603211123041', N'鸡腿', N'3', N'000720160321112301', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603211123321', N'鸡腿', N'1', N'000720160321112323', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603211141171', N'茄子', N'1', N'000720160321114018', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603211406011', N'茄子', N'1', N'000720160321140551', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603211429541', N'茄子', N'1', N'000720160321142828', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603211459471', N'茄子', N'1', N'000720160321145938', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603211459472', N'茄子', N'2', N'000720160321145938', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603211631201', N'茄子', N'1', N'000720160321163119', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603221638001', N'茄子', N'2', N'000720160321174223', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603221646121', N'茄子', N'3', N'000720160321175247', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603221646122', N'鸡腿', N'3', N'000720160321175247', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603221649401', N'鸡腿', N'2', N'000720160322164649', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603231607071', N'茄子', N'1', N'000720160323110440', N'2012', N'1001201603181626451')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603231607072', N'鸡腿', N'1', N'000720160323110440', N'2012', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603231607073', N'鸡腿', N'1', N'000720160323110440', N'2012', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603231607074', N'鸡翅', N'1', N'000720160323110440', N'2012', N'1001201603231112081')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603231607075', N'鸡翅', N'1', N'000720160323110440', N'2012', N'1001201603231112081')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603231737461', N'烤鸡翅', N'1', N'000720160323173731', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603231741351', N'烤鸡翅', N'1', N'000720160323174046', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603231741352', N'鸡翅', N'1', N'000720160323174046', N'2012', N'1001201603231112081')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603280927041', N'鸡腿', N'1', N'000720160328092645', N'2012', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603280946281', N'鸡腿', N'1', N'000720160328094155', N'2012', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281117531', N'鸡腿', N'1', N'000720160328111745', N'2012', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281126441', N'鸡腿', N'1', N'000720160328112636', N'2012', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281131391', N'鸡腿', N'1', N'000720160328113130', N'2012', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281132451', N'鸡腿', N'1', N'000720160328113235', N'2012', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281134451', N'鸡腿', N'1', N'000720160328113438', N'2012', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281138481', N'鸡腿', N'1', N'000720160328113838', N'2012', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281448351', N'鸡腿', N'1', N'000720160328144823', N'2012', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281452171', N'鸡腿', N'1', N'000720160328145208', N'2012', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281453021', N'鸡腿', N'1', N'000720160328145253', N'2012', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281454321', N'鸡腿', N'1', N'000720160328145425', N'2012', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281456271', N'鸡腿', N'1', N'000720160328145617', N'2012', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281458241', N'鸡腿', N'1', N'000720160328145809', N'2012', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281458242', N'鸡翅', N'1', N'000720160328145809', N'2012', N'1001201603231112081')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281459421', N'鸡腿', N'1', N'000720160328145933', N'2012', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281537031', N'蔬菜沙拉', N'1', N'000720160328153645', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281537032', N'鸡腿', N'1', N'000720160328153645', N'2012', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281539071', N'鸡腿', N'1', N'000720160328152642', N'2012', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281539072', N'蔬菜沙拉', N'1', N'000720160328152642', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281541001', N'鸡腿', N'1', N'000720160328154045', N'2012', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281541002', N'蔬菜沙拉', N'1', N'000720160328154045', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281542181', N'蔬菜沙拉', N'1', N'000720160328154202', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281542182', N'鸡腿', N'1', N'000720160328154202', N'2012', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281549111', N'鸡腿', N'1', N'000720160328154858', N'2012', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281549112', N'蔬菜沙拉', N'1', N'000720160328154858', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281550291', N'鸡腿', N'1', N'000720160328155021', N'2012', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281643511', N'鸡腿', N'1', N'000720160328164330', N'2012', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281643512', N'蔬菜沙拉', N'1', N'000720160328164330', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281643513', N'鸡翅', N'1', N'000720160328164330', N'2012', N'1001201603231112081')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281738391', N'鸡腿', N'1', N'000720160328173805', N'2012', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281738392', N'蔬菜沙拉', N'1', N'000720160328173805', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281738393', N'烤鸡翅', N'1', N'000720160328173805', null, null)
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603281741581', N'鸡腿', N'1', N'000720160328174149', N'2012', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201603291147551', N'鸡腿', N'1', N'000720160329114745', N'2012', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201604191632071', N'可乐', N'1', N'000720160419163152', N'3024', N'1001201604191020201')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201604261428551', N'茄子', N'1', N'000720160426142842', N'2012', N'1001201604191016151')
GO
GO
INSERT INTO [dbo].[BillDetails] ([ID], [DishName], [Amount], [OrderID], [WarehouseID], [POID]) VALUES (N'1007201605091413081', N'鸡腿', N'2', N'000720160509141258', N'2012', N'1001201603141754101')
GO
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
-- Records of Category
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Category] ON
GO
INSERT INTO [dbo].[Category] ([ID], [ShortID], [Name], [SuperiorID]) VALUES (N'1', N'1', N'菜品', N'0')
GO
GO
INSERT INTO [dbo].[Category] ([ID], [ShortID], [Name], [SuperiorID]) VALUES (N'2', N'2', N'货品', N'0')
GO
GO
INSERT INTO [dbo].[Category] ([ID], [ShortID], [Name], [SuperiorID]) VALUES (N'3', N'101', N'蔬菜', N'1')
GO
GO
INSERT INTO [dbo].[Category] ([ID], [ShortID], [Name], [SuperiorID]) VALUES (N'5', N'201', N'调料', N'2')
GO
GO
INSERT INTO [dbo].[Category] ([ID], [ShortID], [Name], [SuperiorID]) VALUES (N'6', N'102', N'水果', N'1')
GO
GO
INSERT INTO [dbo].[Category] ([ID], [ShortID], [Name], [SuperiorID]) VALUES (N'7', N'20101', N'火锅底料', N'5')
GO
GO
INSERT INTO [dbo].[Category] ([ID], [ShortID], [Name], [SuperiorID]) VALUES (N'8', N'20102', N'火锅蘸料', N'5')
GO
GO
INSERT INTO [dbo].[Category] ([ID], [ShortID], [Name], [SuperiorID]) VALUES (N'13', N'202', N'餐具', N'2')
GO
GO
INSERT INTO [dbo].[Category] ([ID], [ShortID], [Name], [SuperiorID]) VALUES (N'14', N'103', N'肉类', N'1')
GO
GO
INSERT INTO [dbo].[Category] ([ID], [ShortID], [Name], [SuperiorID]) VALUES (N'15', N'104', N'菌菇', N'1')
GO
GO
INSERT INTO [dbo].[Category] ([ID], [ShortID], [Name], [SuperiorID]) VALUES (N'16', N'105', N'水产', N'1')
GO
GO
INSERT INTO [dbo].[Category] ([ID], [ShortID], [Name], [SuperiorID]) VALUES (N'18', N'10502', N'海鲜', N'16')
GO
GO
INSERT INTO [dbo].[Category] ([ID], [ShortID], [Name], [SuperiorID]) VALUES (N'19', N'106', N'副食品', N'1')
GO
GO
INSERT INTO [dbo].[Category] ([ID], [ShortID], [Name], [SuperiorID]) VALUES (N'20', N'10601', N'豆制品', N'19')
GO
GO
INSERT INTO [dbo].[Category] ([ID], [ShortID], [Name], [SuperiorID]) VALUES (N'21', N'203', N'员工制服', N'2')
GO
GO
INSERT INTO [dbo].[Category] ([ID], [ShortID], [Name], [SuperiorID]) VALUES (N'22', N'204', N'单据', N'2')
GO
GO
INSERT INTO [dbo].[Category] ([ID], [ShortID], [Name], [SuperiorID]) VALUES (N'23', N'10501', N'河鲜', N'16')
GO
GO
INSERT INTO [dbo].[Category] ([ID], [ShortID], [Name], [SuperiorID]) VALUES (N'31', N'205', N'酒水', N'2')
GO
GO
INSERT INTO [dbo].[Category] ([ID], [ShortID], [Name], [SuperiorID]) VALUES (N'32', N'20501', N'啤酒', N'31')
GO
GO
INSERT INTO [dbo].[Category] ([ID], [ShortID], [Name], [SuperiorID]) VALUES (N'33', N'20502', N'饮料', N'31')
GO
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
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
-- Records of CODetails
-- ----------------------------
INSERT INTO [dbo].[CODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID], [POID]) VALUES (N'1002201604111139591', N'鸡腿', N'斤', N'2', N'.0000', N'000220160411113955', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[CODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID], [POID]) VALUES (N'1002201605091412361', N'鸡腿', N'斤', N'2', N'9.5000', N'000220160509141228', N'1001201605091150191')
GO
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
-- Records of CreditOrder
-- ----------------------------
INSERT INTO [dbo].[CreditOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000220160411113955', null, N'原料', N'2', N'2', N'1', N'zk', N'2016-04-11 11:39:55.000', null)
GO
GO
INSERT INTO [dbo].[CreditOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000220160509141228', null, N'原料', N'1', N'1', N'123', N'123', N'2016-05-09 14:12:28.000', null)
GO
GO
INSERT INTO [dbo].[CreditOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000320160314141631', null, N'原料', N'1', N'1', N'2', N'2', N'2016-03-14 14:16:31.000', null)
GO
GO
INSERT INTO [dbo].[CreditOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000320160314153219', null, N'原料', N'1', N'1', N'2', N'2', N'2016-03-14 15:32:19.000', null)
GO
GO
INSERT INTO [dbo].[CreditOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000320160314153335', null, N'原料', N'1', N'1', N'2', N'2', N'2016-03-14 15:33:35.000', null)
GO
GO
INSERT INTO [dbo].[CreditOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000320160314161107', null, N'原料', N'1', N'1', N'2', N'2', N'2016-03-14 16:11:07.000', null)
GO
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
-- Records of Discount
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Discount] ON
GO
INSERT INTO [dbo].[Discount] ([ID], [DiscountPercent], [Description], [IgnoredCategories], [IsMemberOnly]) VALUES (N'2', N'80', N'会员八折（不含酒水）', N'酒，饮料', N'1')
GO
GO
INSERT INTO [dbo].[Discount] ([ID], [DiscountPercent], [Description], [IgnoredCategories], [IsMemberOnly]) VALUES (N'3', N'90', N'九折', null, N'0')
GO
GO
INSERT INTO [dbo].[Discount] ([ID], [DiscountPercent], [Description], [IgnoredCategories], [IsMemberOnly]) VALUES (N'4', N'85', N'八五折（不含酒水）', N'酒，饮料', N'0')
GO
GO
SET IDENTITY_INSERT [dbo].[Discount] OFF
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
-- Records of Dish
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Dish] ON
GO
INSERT INTO [dbo].[Dish] ([ID], [ShortID], [Name], [ShortName], [CategoryID], [Price], [Unit], [Image], [Description], [PriceEditable], [InventoryControl], [UnitConversion]) VALUES (N'4', N'1', N'茄子', N'qz', N'3', N'7.0000', N'份', null, null, N'0', N'1', N'0.5')
GO
GO
INSERT INTO [dbo].[Dish] ([ID], [ShortID], [Name], [ShortName], [CategoryID], [Price], [Unit], [Image], [Description], [PriceEditable], [InventoryControl], [UnitConversion]) VALUES (N'1002', N'2', N'鸡腿', N'jt', N'14', N'10.0000', N'份', null, null, N'0', N'1', N'0.5')
GO
GO
INSERT INTO [dbo].[Dish] ([ID], [ShortID], [Name], [ShortName], [CategoryID], [Price], [Unit], [Image], [Description], [PriceEditable], [InventoryControl], [UnitConversion]) VALUES (N'1003', N'3', N'鸡翅', N'jch', N'14', N'10.0000', N'份', null, null, N'0', N'1', N'0.5')
GO
GO
INSERT INTO [dbo].[Dish] ([ID], [ShortID], [Name], [ShortName], [CategoryID], [Price], [Unit], [Image], [Description], [PriceEditable], [InventoryControl], [UnitConversion]) VALUES (N'1004', N'4', N'烤鸡翅', N'kjch', N'14', N'15.0000', N'份', null, null, N'0', N'0', null)
GO
GO
INSERT INTO [dbo].[Dish] ([ID], [ShortID], [Name], [ShortName], [CategoryID], [Price], [Unit], [Image], [Description], [PriceEditable], [InventoryControl], [UnitConversion]) VALUES (N'1005', N'5', N'蔬菜沙拉', N'scsl', N'3', N'25.0000', N'盘', null, null, N'1', N'0', null)
GO
GO
INSERT INTO [dbo].[Dish] ([ID], [ShortID], [Name], [ShortName], [CategoryID], [Price], [Unit], [Image], [Description], [PriceEditable], [InventoryControl], [UnitConversion]) VALUES (N'1006', N'6', N'可乐', N'kl', N'33', N'5.0000', N'瓶', null, null, N'0', N'1', N'1')
GO
GO
SET IDENTITY_INSERT [dbo].[Dish] OFF
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
-- Records of InventoryList
-- ----------------------------
INSERT INTO [dbo].[InventoryList] ([ProductID], [WarehouseID], [Amount], [POID]) VALUES (N'2003', N'2012', N'48', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[InventoryList] ([ProductID], [WarehouseID], [Amount], [POID]) VALUES (N'2002', N'2012', N'47.5', N'1001201603231112081')
GO
GO
INSERT INTO [dbo].[InventoryList] ([ProductID], [WarehouseID], [Amount], [POID]) VALUES (N'1002', N'2012', N'50', N'1001201603281754521')
GO
GO
INSERT INTO [dbo].[InventoryList] ([ProductID], [WarehouseID], [Amount], [POID]) VALUES (N'2003', N'2012', N'25', N'1001201604191013341')
GO
GO
INSERT INTO [dbo].[InventoryList] ([ProductID], [WarehouseID], [Amount], [POID]) VALUES (N'2002', N'2012', N'25', N'1001201604191015401')
GO
GO
INSERT INTO [dbo].[InventoryList] ([ProductID], [WarehouseID], [Amount], [POID]) VALUES (N'1002', N'2012', N'29.5', N'1001201604191016151')
GO
GO
INSERT INTO [dbo].[InventoryList] ([ProductID], [WarehouseID], [Amount], [POID]) VALUES (N'2', N'3024', N'0', N'1001201604191016351')
GO
GO
INSERT INTO [dbo].[InventoryList] ([ProductID], [WarehouseID], [Amount], [POID]) VALUES (N'2005', N'3024', N'100', N'1001201604191020051')
GO
GO
INSERT INTO [dbo].[InventoryList] ([ProductID], [WarehouseID], [Amount], [POID]) VALUES (N'2006', N'3024', N'89', N'1001201604191020201')
GO
GO
INSERT INTO [dbo].[InventoryList] ([ProductID], [WarehouseID], [Amount], [POID]) VALUES (N'2007', N'3025', N'120', N'1001201604191021131')
GO
GO
INSERT INTO [dbo].[InventoryList] ([ProductID], [WarehouseID], [Amount], [POID]) VALUES (N'2008', N'3025', N'5', N'1001201604191022161')
GO
GO
INSERT INTO [dbo].[InventoryList] ([ProductID], [WarehouseID], [Amount], [POID]) VALUES (N'2006', N'3024', N'50', N'1001201604191635171')
GO
GO
INSERT INTO [dbo].[InventoryList] ([ProductID], [WarehouseID], [Amount], [POID]) VALUES (N'2006', N'3024', N'1', N'1001201604251442401')
GO
GO
INSERT INTO [dbo].[InventoryList] ([ProductID], [WarehouseID], [Amount], [POID]) VALUES (N'2003', N'2012', N'20', N'1001201605091147271')
GO
GO
INSERT INTO [dbo].[InventoryList] ([ProductID], [WarehouseID], [Amount], [POID]) VALUES (N'2003', N'2012', N'3', N'1001201605091150191')
GO
GO
INSERT INTO [dbo].[InventoryList] ([ProductID], [WarehouseID], [Amount], [POID]) VALUES (N'2003', N'2012', N'5', N'1001201605091414081')
GO
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
-- Records of MaterialsRequisition
-- ----------------------------
INSERT INTO [dbo].[MaterialsRequisition] ([ID], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000220160314161038', N'原料', N'1', N'1', N'2', N'2', N'2016-03-14 16:10:38.000', null)
GO
GO
INSERT INTO [dbo].[MaterialsRequisition] ([ID], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000320160318154804', N'原料', N'1', N'1', N'2', N'2', N'2016-03-18 15:48:04.000', null)
GO
GO
INSERT INTO [dbo].[MaterialsRequisition] ([ID], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000320160411150514', N'原料', N'1', N'1', N'1', N'zk', N'2016-04-11 15:05:14.000', null)
GO
GO
INSERT INTO [dbo].[MaterialsRequisition] ([ID], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000320160412154453', N'原料', N'1', N'1', N'123', N'123', N'2016-04-12 15:44:53.000', null)
GO
GO
INSERT INTO [dbo].[MaterialsRequisition] ([ID], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000320160419102708', N'酒水', N'1', N'1', N'123', N'123', N'2016-04-19 10:27:08.000', null)
GO
GO
INSERT INTO [dbo].[MaterialsRequisition] ([ID], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000320160419163025', N'酒水', N'1', N'1', N'123', N'123', N'2016-04-19 16:30:25.000', null)
GO
GO
INSERT INTO [dbo].[MaterialsRequisition] ([ID], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'20160314102741', N'原料', N'1', N'1', N'2', N'2', N'2016-03-14 10:27:41.000', null)
GO
GO
INSERT INTO [dbo].[MaterialsRequisition] ([ID], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'20160314102812', N'原料', N'1', N'1', N'2', N'2', N'2016-03-14 10:28:12.000', null)
GO
GO
INSERT INTO [dbo].[MaterialsRequisition] ([ID], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'20160314102844', N'原料', N'1', N'1', N'2', N'2', N'2016-03-14 10:28:44.000', null)
GO
GO
INSERT INTO [dbo].[MaterialsRequisition] ([ID], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'20160314102903', N'原料', N'1', N'1', N'2', N'2', N'2016-03-14 10:29:03.000', null)
GO
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
-- Records of MaterialsReturnOrder
-- ----------------------------
INSERT INTO [dbo].[MaterialsReturnOrder] ([ID], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'20160314160519', N'原料', N'1', N'1', N'2', N'2', N'2016-03-14 16:05:19.000', null)
GO
GO
INSERT INTO [dbo].[MaterialsReturnOrder] ([ID], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'20160314161020', N'原料', N'1', N'1', N'2', N'2', N'2016-03-14 16:10:20.000', null)
GO
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
-- Records of Member
-- ----------------------------
INSERT INTO [dbo].[Member] ([ID], [Name], [Tele], [Point]) VALUES (N'0000001', N'zk', N'110', N'233')
GO
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
-- Records of MonthlyReport
-- ----------------------------

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
-- Records of MRDetails
-- ----------------------------
INSERT INTO [dbo].[MRDetails] ([ID], [ProductName], [Unit], [Amount], [OrderID], [POID]) VALUES (N'1003201603181553401', N'鸡腿', N'斤', N'1', N'000320160318154804', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[MRDetails] ([ID], [ProductName], [Unit], [Amount], [OrderID], [POID]) VALUES (N'1003201604111505191', N'鸡腿', N'斤', N'2', N'000320160411150514', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[MRDetails] ([ID], [ProductName], [Unit], [Amount], [OrderID], [POID]) VALUES (N'1003201604121545001', N'鸡腿', N'斤', N'1', N'000320160412154453', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[MRDetails] ([ID], [ProductName], [Unit], [Amount], [OrderID], [POID]) VALUES (N'1003201604191027351', N'茶叶', N'斤', N'10', N'000320160419102708', N'1001201604191016351')
GO
GO
INSERT INTO [dbo].[MRDetails] ([ID], [ProductName], [Unit], [Amount], [OrderID], [POID]) VALUES (N'1003201604191630341', N'可乐', N'瓶', N'10', N'000320160419163025', N'1001201604191020201')
GO
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
-- Records of MReportDetails
-- ----------------------------

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
-- Records of MRODetails
-- ----------------------------

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
-- Records of PODetails
-- ----------------------------
INSERT INTO [dbo].[PODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID]) VALUES (N'1001201603111023001', N'茄子', N'斤', N'5', N'5.5000', N'000120160311101613')
GO
GO
INSERT INTO [dbo].[PODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID]) VALUES (N'1001201603111124451', N'茄子', N'斤', N'10', N'10.0000', N'000120160311112100')
GO
GO
INSERT INTO [dbo].[PODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID]) VALUES (N'1001201603111126491', N'茄子', N'公斤', N'20', N'20.0000', N'000120160311112602')
GO
GO
INSERT INTO [dbo].[PODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID]) VALUES (N'1001201603111129231', N'茶叶', N'123', N'123', N'123.0000', N'000120160311112916')
GO
GO
INSERT INTO [dbo].[PODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID]) VALUES (N'1001201603111130081', N'茶叶', N'1', N'-123', N'12.0000', N'000120160311112944')
GO
GO
INSERT INTO [dbo].[PODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID]) VALUES (N'1001201603111201221', N'茶叶', N'123', N'2', N'123.0000', N'000120160311120108')
GO
GO
INSERT INTO [dbo].[PODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID]) VALUES (N'1001201603111201541', N'茶叶', N'1', N'12', N'1.0000', N'000120160311120147')
GO
GO
INSERT INTO [dbo].[PODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID]) VALUES (N'1001201603111451261', N'茄子', N'斤', N'100', N'10.0000', N'000120160311145107')
GO
GO
INSERT INTO [dbo].[PODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID]) VALUES (N'1001201603111451521', N'茄子', N'斤', N'-100', N'10.0000', N'000120160311145136')
GO
GO
INSERT INTO [dbo].[PODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID]) VALUES (N'1001201603141132541', N'茄子', N'斤', N'10', N'7.0000', N'000120160314113234')
GO
GO
INSERT INTO [dbo].[PODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID]) VALUES (N'1001201603141133191', N'茄子', N'斤', N'10', N'6.0000', N'000120160314113300')
GO
GO
INSERT INTO [dbo].[PODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID]) VALUES (N'1001201603141524141', N'茄子', N'斤', N'5', N'1.0000', N'000120160314152411')
GO
GO
INSERT INTO [dbo].[PODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID]) VALUES (N'1001201603141527151', N'茄子', N'斤', N'5', N'.0000', N'000120160314152533')
GO
GO
INSERT INTO [dbo].[PODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID]) VALUES (N'1001201603141754101', N'鸡腿', N'斤', N'5', N'10.0000', N'000120160314175022')
GO
GO
INSERT INTO [dbo].[PODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID]) VALUES (N'1001201603181626451', N'茄子', N'斤', N'10', N'7.0000', N'000120160318162625')
GO
GO
INSERT INTO [dbo].[PODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID]) VALUES (N'1001201603231112081', N'鸡翅', N'斤', N'50', N'10.0000', N'000120160323111142')
GO
GO
INSERT INTO [dbo].[PODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID]) VALUES (N'1001201603281754521', N'茄子', N'斤', N'50', N'7.0000', N'000120160328175436')
GO
GO
INSERT INTO [dbo].[PODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID]) VALUES (N'1001201604191013341', N'鸡腿', N'斤', N'25', N'10.3000', N'000120160419101312')
GO
GO
INSERT INTO [dbo].[PODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID]) VALUES (N'1001201604191015401', N'鸡翅', N'斤', N'25', N'12.3000', N'000120160419101521')
GO
GO
INSERT INTO [dbo].[PODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID]) VALUES (N'1001201604191016151', N'茄子', N'斤', N'30', N'7.2000', N'000120160419101552')
GO
GO
INSERT INTO [dbo].[PODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID]) VALUES (N'1001201604191016351', N'茶叶', N'斤', N'10', N'30.0000', N'000120160419101617')
GO
GO
INSERT INTO [dbo].[PODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID]) VALUES (N'1001201604191020051', N'青岛', N'瓶', N'100', N'2.5000', N'000120160419101944')
GO
GO
INSERT INTO [dbo].[PODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID]) VALUES (N'1001201604191020201', N'可乐', N'瓶', N'100', N'1.0000', N'000120160419102006')
GO
GO
INSERT INTO [dbo].[PODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID]) VALUES (N'1001201604191021131', N'川崎', N'盒', N'120', N'3.0000', N'000120160419102053')
GO
GO
INSERT INTO [dbo].[PODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID]) VALUES (N'1001201604191022161', N'豆油', N'桶', N'5', N'60.0000', N'000120160419102154')
GO
GO
INSERT INTO [dbo].[PODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID]) VALUES (N'1001201604191635171', N'可乐', N'瓶', N'50', N'1.2000', N'000120160419163446')
GO
GO
INSERT INTO [dbo].[PODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID]) VALUES (N'1001201604251442401', N'可乐', N'瓶', N'1', N'2.0000', N'000120160425144215')
GO
GO
INSERT INTO [dbo].[PODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID]) VALUES (N'1001201605091147271', N'鸡腿', N'斤', N'20', N'10.0000', N'000120160509114709')
GO
GO
INSERT INTO [dbo].[PODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID]) VALUES (N'1001201605091150191', N'鸡腿', N'斤', N'5', N'9.5000', N'000120160509115000')
GO
GO
INSERT INTO [dbo].[PODetails] ([ID], [ProductName], [Unit], [Amount], [Price], [OrderID]) VALUES (N'1001201605091414081', N'鸡腿', N'斤', N'5', N'8.8000', N'000120160509141353')
GO
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
-- Records of Product
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Product] ON
GO
INSERT INTO [dbo].[Product] ([ID], [ShortID], [Name], [ShortName], [CategoryID], [Unit]) VALUES (N'2', N'1', N'茶叶', N'chy', N'2', N'斤')
GO
GO
INSERT INTO [dbo].[Product] ([ID], [ShortID], [Name], [ShortName], [CategoryID], [Unit]) VALUES (N'1002', N'2', N'茄子', N'qz', N'1', N'斤')
GO
GO
INSERT INTO [dbo].[Product] ([ID], [ShortID], [Name], [ShortName], [CategoryID], [Unit]) VALUES (N'2002', N'3', N'鸡翅', N'jch', N'14', N'斤')
GO
GO
INSERT INTO [dbo].[Product] ([ID], [ShortID], [Name], [ShortName], [CategoryID], [Unit]) VALUES (N'2003', N'4', N'鸡腿', N'jt', N'14', N'斤')
GO
GO
INSERT INTO [dbo].[Product] ([ID], [ShortID], [Name], [ShortName], [CategoryID], [Unit]) VALUES (N'2005', N'5', N'青岛', N'qd', N'32', N'瓶')
GO
GO
INSERT INTO [dbo].[Product] ([ID], [ShortID], [Name], [ShortName], [CategoryID], [Unit]) VALUES (N'2006', N'6', N'可乐', N'kl', N'33', N'瓶')
GO
GO
INSERT INTO [dbo].[Product] ([ID], [ShortID], [Name], [ShortName], [CategoryID], [Unit]) VALUES (N'2007', N'7', N'川崎', N'cq', N'8', N'盒')
GO
GO
INSERT INTO [dbo].[Product] ([ID], [ShortID], [Name], [ShortName], [CategoryID], [Unit]) VALUES (N'2008', N'8', N'豆油', N'dy', N'5', N'桶')
GO
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
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
-- Records of PurchaseOrder
-- ----------------------------
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160310163241', null, N'原料', N'1', N'丁', N'2', N'王', N'2016-03-10 16:32:41.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160310163417', null, N'原料', N'1', N'丁', N'2', N'王', N'2016-03-10 16:34:17.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160310163547', null, N'原料', N'1', N'丁', N'2', N'王', N'2016-03-10 16:35:47.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160310163926', null, N'原料', N'1', N'丁', N'2', N'王', N'2016-03-10 16:39:26.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160311101613', null, N'原料', N'1', N'01', N'2', N'02', N'2016-03-11 10:16:13.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160311112100', null, N'原料', N'1', N'01', N'2', N'02', N'2016-03-11 11:21:00.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160311112602', null, N'原料', N'2', N'02', N'30', N'03', N'2016-03-11 11:26:02.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160311112916', null, N'调料', N'123', N'123', N'123', N'123', N'2016-03-11 11:29:16.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160311112944', null, N'调料', N'1', N'1', N'2', N'2', N'2016-03-11 11:29:44.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160311120108', null, N'原料', N'123', N'123', N'123', N'123', N'2016-03-11 12:01:08.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160311120147', null, N'原料', N'1', N'1', N'1', N'1', N'2016-03-11 12:01:47.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160311145107', null, N'原料', N'1', N'1', N'2', N'2', N'2016-03-11 14:51:07.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160311145136', null, N'原料', N'1', N'1', N'2', N'2', N'2016-03-11 14:51:36.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160314113234', null, N'原料', N'1', N'1', N'3', N'3', N'2016-03-14 11:32:34.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160314113300', null, N'原料', N'1', N'1', N'2', N'2', N'2016-03-14 11:33:00.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160314152411', null, N'原料', N'1', N'1', N'2', N'0', N'2016-03-14 15:24:11.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160314152533', null, N'原料', N'1', N'1', N'2', N'2', N'2016-03-14 15:25:33.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160314175022', null, N'原料', N'1', N'1', N'2', N'2', N'2016-03-14 17:50:22.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160318162625', null, N'原料', N'1', N'1', N'2', N'2', N'2016-03-18 16:26:25.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160323111142', N'1', N'原料', N'1', N'1', N'2', N'2', N'2016-03-23 11:11:42.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160328175436', null, N'原料', N'1', N'1', N'2', N'2', N'2016-03-28 17:54:36.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160419101312', null, N'原料', N'1', N'1', N'123', N'123', N'2016-04-19 10:13:12.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160419101521', null, N'原料', N'1', N'1', N'123', N'123', N'2016-04-19 10:15:21.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160419101552', null, N'原料', N'1', N'1', N'123', N'123', N'2016-04-19 10:15:52.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160419101617', null, N'酒水', N'1', N'1', N'123', N'123', N'2016-04-19 10:16:17.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160419101944', null, N'酒水', N'1', N'1', N'123', N'123', N'2016-04-19 10:19:44.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160419102006', null, N'酒水', N'1', N'1', N'123', N'123', N'2016-04-19 10:20:06.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160419102053', null, N'调料', N'1', N'1', N'123', N'123', N'2016-04-19 10:20:53.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160419102154', null, N'调料', N'1', N'1', N'123', N'123', N'2016-04-19 10:21:54.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160419163446', null, N'酒水', N'1', N'1', N'123', N'123', N'2016-04-19 16:34:46.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160425144215', null, N'酒水', N'1', N'1', N'123', N'123', N'2016-04-25 14:42:15.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160509114709', null, N'原料', N'1', N'1', N'123', N'123', N'2016-05-09 11:47:09.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160509115000', null, N'原料', N'1', N'1', N'123', N'123', N'2016-05-09 11:50:00.000', null)
GO
GO
INSERT INTO [dbo].[PurchaseOrder] ([ID], [SupplierName], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000120160509141353', null, N'原料', N'1', N'1', N'123', N'123', N'2016-05-09 14:13:53.000', null)
GO
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
-- Records of ServingTable
-- ----------------------------
INSERT INTO [dbo].[ServingTable] ([ID], [BillID]) VALUES (N'1', N'1')
GO
GO
INSERT INTO [dbo].[ServingTable] ([ID], [BillID]) VALUES (N'2', N'2')
GO
GO
INSERT INTO [dbo].[ServingTable] ([ID], [BillID]) VALUES (N'4', N'4')
GO
GO
INSERT INTO [dbo].[ServingTable] ([ID], [BillID]) VALUES (N'5', N'55')
GO
GO
INSERT INTO [dbo].[ServingTable] ([ID], [BillID]) VALUES (N'7', N'7')
GO
GO
INSERT INTO [dbo].[ServingTable] ([ID], [BillID]) VALUES (N'12', N'12')
GO
GO
INSERT INTO [dbo].[ServingTable] ([ID], [BillID]) VALUES (N'13', N'13')
GO
GO
INSERT INTO [dbo].[ServingTable] ([ID], [BillID]) VALUES (N'14', N'000720160419163152')
GO
GO
INSERT INTO [dbo].[ServingTable] ([ID], [BillID]) VALUES (N'15', N'15')
GO
GO
INSERT INTO [dbo].[ServingTable] ([ID], [BillID]) VALUES (N'16', N'15')
GO
GO
INSERT INTO [dbo].[ServingTable] ([ID], [BillID]) VALUES (N'22', N'22')
GO
GO
INSERT INTO [dbo].[ServingTable] ([ID], [BillID]) VALUES (N'24', N'24')
GO
GO
INSERT INTO [dbo].[ServingTable] ([ID], [BillID]) VALUES (N'25', N'25')
GO
GO
INSERT INTO [dbo].[ServingTable] ([ID], [BillID]) VALUES (N'26', N'24')
GO
GO
INSERT INTO [dbo].[ServingTable] ([ID], [BillID]) VALUES (N'27', N'26')
GO
GO
INSERT INTO [dbo].[ServingTable] ([ID], [BillID]) VALUES (N'31', N'31')
GO
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
-- Records of SLDetails
-- ----------------------------
INSERT INTO [dbo].[SLDetails] ([ID], [ProductName], [Unit], [Amount], [OrderID], [POID]) VALUES (N'1006201603171427291', N'鸡腿', N'斤', N'4', N'000620160317142706', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[SLDetails] ([ID], [ProductName], [Unit], [Amount], [OrderID], [POID]) VALUES (N'1006201603171427571', N'鸡腿', N'斤', N'1', N'000620160317142740', N'1001201603141754101')
GO
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
-- Records of StartOfTerm
-- ----------------------------

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
-- Records of StocktakingList
-- ----------------------------
INSERT INTO [dbo].[StocktakingList] ([ID], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000620160317142706', N'原料', N'1', N'1', N'2', N'2', N'2016-03-17 14:27:06.000', null)
GO
GO
INSERT INTO [dbo].[StocktakingList] ([ID], [WarehouseName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000620160317142740', N'调料', N'1', N'1', N'2', N'2', N'2016-03-17 14:27:40.000', null)
GO
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
-- Records of TODetails
-- ----------------------------
INSERT INTO [dbo].[TODetails] ([ID], [ProductName], [Unit], [Amount], [OrderID], [POID]) VALUES (N'0005201603171114381', N'鸡腿', N'斤', N'1', N'000520160317111423', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[TODetails] ([ID], [ProductName], [Unit], [Amount], [OrderID], [POID]) VALUES (N'0005201603171129561', N'鸡腿', N'斤', N'1', N'000520160317112535', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[TODetails] ([ID], [ProductName], [Unit], [Amount], [OrderID], [POID]) VALUES (N'0005201603171130441', N'鸡腿', N'斤', N'1', N'000520160317113017', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[TODetails] ([ID], [ProductName], [Unit], [Amount], [OrderID], [POID]) VALUES (N'0005201603171157281', N'鸡腿', N'斤', N'3', N'000520160317115706', N'1001201603141754101')
GO
GO
INSERT INTO [dbo].[TODetails] ([ID], [ProductName], [Unit], [Amount], [OrderID], [POID]) VALUES (N'0005201603281757091', N'鸡腿', N'斤', N'50', N'000520160328175643', N'1001201603141754101')
GO
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
-- Records of TransferOrder
-- ----------------------------
INSERT INTO [dbo].[TransferOrder] ([ID], [OutName], [InName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000520160317111423', N'原料', N'调料', N'1', N'1', N'2', N'2', N'2016-03-17 11:14:23.000', null)
GO
GO
INSERT INTO [dbo].[TransferOrder] ([ID], [OutName], [InName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000520160317112535', N'调料', N'原料', N'1', N'1', N'2', N'2', N'2016-03-17 11:25:35.000', null)
GO
GO
INSERT INTO [dbo].[TransferOrder] ([ID], [OutName], [InName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000520160317113017', N'调料', N'原料', N'1', N'1', N'2', N'2', N'2016-03-17 11:30:17.000', null)
GO
GO
INSERT INTO [dbo].[TransferOrder] ([ID], [OutName], [InName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000520160317115706', N'调料', N'原料', N'1', N'1', N'2', N'2', N'2016-03-17 11:57:06.000', null)
GO
GO
INSERT INTO [dbo].[TransferOrder] ([ID], [OutName], [InName], [OperatorID], [OperatorName], [UserID], [UserName], [Date], [Remark]) VALUES (N'000520160328175643', N'调料', N'原料', N'1', N'1', N'2', N'2', N'2016-03-28 17:56:43.000', null)
GO
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
-- Records of User
-- ----------------------------
SET IDENTITY_INSERT [dbo].[User] ON
GO
INSERT INTO [dbo].[User] ([ID], [ShortID], [UserName], [Role], [Password], [RealName], [RealPost]) VALUES (N'1', N'1', N'DingSa', N'1', N'd209c1040e1a151737726e128fed565be5b3a67a', N'zk', N'it')
GO
GO
INSERT INTO [dbo].[User] ([ID], [ShortID], [UserName], [Role], [Password], [RealName], [RealPost]) VALUES (N'2', N'3', N'wuser', N'2', N'd92c22ce1b430d300662cfb3e1d2f49061d0e440', N'lu', N'WarehouseKeeper')
GO
GO
INSERT INTO [dbo].[User] ([ID], [ShortID], [UserName], [Role], [Password], [RealName], [RealPost]) VALUES (N'5', N'2', N'fuser', N'3', N'afdbb095d30c1f1d5317d26daa1cf86a13bd3d6a', N'ji', N'waiter')
GO
GO
INSERT INTO [dbo].[User] ([ID], [ShortID], [UserName], [Role], [Password], [RealName], [RealPost]) VALUES (N'6', N'4', N'ruser', N'4', N'07ead1e89da1755707fdbc3e25591864a18894e8', N'han', N'ruser')
GO
GO
INSERT INTO [dbo].[User] ([ID], [ShortID], [UserName], [Role], [Password], [RealName], [RealPost]) VALUES (N'1006', N'123', N'123', N'1', N'601f1889667efaebb33b8c12572835da3f027f78', N'123', N'123')
GO
GO
SET IDENTITY_INSERT [dbo].[User] OFF
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
-- Records of Warehouse
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Warehouse] ON
GO
INSERT INTO [dbo].[Warehouse] ([ID], [ShortID], [Name]) VALUES (N'2012', N'1', N'原料')
GO
GO
INSERT INTO [dbo].[Warehouse] ([ID], [ShortID], [Name]) VALUES (N'3024', N'3', N'酒水')
GO
GO
INSERT INTO [dbo].[Warehouse] ([ID], [ShortID], [Name]) VALUES (N'3025', N'2', N'调料')
GO
GO
SET IDENTITY_INSERT [dbo].[Warehouse] OFF
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
