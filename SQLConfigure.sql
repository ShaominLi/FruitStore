USE [master]
GO
/****** Object:  Database [FruitsShop]    Script Date: 3/17 星期四 16:36:38 ******/
CREATE DATABASE [FruitsShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FruitsShop', FILENAME = N'D:\SQL\MSSQL11.MSSQLSERVER\MSSQL\DATA\FruitsShop.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FruitsShop_log', FILENAME = N'D:\SQL\MSSQL11.MSSQLSERVER\MSSQL\DATA\FruitsShop_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FruitsShop] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FruitsShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FruitsShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FruitsShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FruitsShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FruitsShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FruitsShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [FruitsShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FruitsShop] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [FruitsShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FruitsShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FruitsShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FruitsShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FruitsShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FruitsShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FruitsShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FruitsShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FruitsShop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FruitsShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FruitsShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FruitsShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FruitsShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FruitsShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FruitsShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FruitsShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FruitsShop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FruitsShop] SET  MULTI_USER 
GO
ALTER DATABASE [FruitsShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FruitsShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FruitsShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FruitsShop] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [FruitsShop]
GO
/****** Object:  Table [dbo].[AdminInfo]    Script Date: 3/17 星期四 16:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminInfo](
	[AdminId] [int] IDENTITY(1,1) NOT NULL,
	[AdminName] [nchar](10) NOT NULL,
	[AdminPsw] [nchar](10) NOT NULL,
 CONSTRAINT [PK_AdminInfo] PRIMARY KEY CLUSTERED 
(
	[AdminId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FruitGroupInfo]    Script Date: 3/17 星期四 16:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FruitGroupInfo](
	[FGroupId] [int] IDENTITY(1,1) NOT NULL,
	[FGroupName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_FruitGroupInfo] PRIMARY KEY CLUSTERED 
(
	[FGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FruitInfo]    Script Date: 3/17 星期四 16:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FruitInfo](
	[FruitId] [int] IDENTITY(1,1) NOT NULL,
	[FruitGroupId] [int] NOT NULL,
	[FruitName] [nchar](10) NOT NULL,
	[FruitImage] [nvarchar](50) NULL,
	[FruitComment] [nvarchar](200) NULL,
	[FruitOPrice] [numeric](10, 2) NULL,
	[FruitNPrice] [numeric](10, 2) NULL,
 CONSTRAINT [PK_FruitInfo] PRIMARY KEY CLUSTERED 
(
	[FruitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderInfo]    Script Date: 3/17 星期四 16:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderInfo](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderPrice] [nchar](10) NOT NULL,
	[OrderUserName] [nchar](10) NOT NULL,
	[OrderUserAdress] [nvarchar](200) NOT NULL,
	[OrderUserPhone] [nvarchar](50) NOT NULL,
	[OrderTime] [nvarchar](50) NOT NULL,
	[OrderState] [int] NOT NULL,
	[OrderComment] [nvarchar](300) NOT NULL,
	[OrderUserComment] [nvarchar](300) NULL,
	[OrderAssessByUser] [nvarchar](300) NULL,
	[OrderAssessByAdm] [nvarchar](300) NULL,
 CONSTRAINT [PK_OrderInfo] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ShopCar]    Script Date: 3/17 星期四 16:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ShopCar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[FruitId] [int] NOT NULL,
	[FruitNum] [int] NOT NULL,
	[FruitPrice] [numeric](10, 2) NOT NULL,
	[FruitSumPrice]  AS ([FruitNum]*[FruitPrice]) PERSISTED,
 CONSTRAINT [PK_ShopCar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 3/17 星期四 16:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserVName] [nchar](10) NOT NULL,
	[UserPsw] [nchar](10) NOT NULL,
	[UserTName] [nchar](10) NOT NULL,
	[UserAdress] [nvarchar](50) NULL,
	[UserPhone] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[FruitInfo] ADD  CONSTRAINT [DF_FruitInfo_FruitOPrice]  DEFAULT ((0)) FOR [FruitOPrice]
GO
ALTER TABLE [dbo].[FruitInfo] ADD  CONSTRAINT [DF_FruitInfo_FruitNPrice]  DEFAULT ((0)) FOR [FruitNPrice]
GO
ALTER TABLE [dbo].[OrderInfo] ADD  CONSTRAINT [DF_OrderInfo_OrderState]  DEFAULT ((0)) FOR [OrderState]
GO
ALTER TABLE [dbo].[OrderInfo] ADD  CONSTRAINT [DF_OrderInfo_OrderAssessByUser]  DEFAULT (N'默认好评！') FOR [OrderAssessByUser]
GO
ALTER TABLE [dbo].[OrderInfo] ADD  CONSTRAINT [DF_OrderInfo_OrderAssessByAdm]  DEFAULT (N'默认好评！') FOR [OrderAssessByAdm]
GO
ALTER TABLE [dbo].[ShopCar] ADD  CONSTRAINT [DF_ShopCar_FruitNum]  DEFAULT ((0)) FOR [FruitNum]
GO
ALTER TABLE [dbo].[ShopCar] ADD  CONSTRAINT [DF_ShopCar_FruitPrice]  DEFAULT ((0.00)) FOR [FruitPrice]
GO
ALTER TABLE [dbo].[FruitInfo]  WITH CHECK ADD  CONSTRAINT [FK_FruitInfo_FruitGroupInfo] FOREIGN KEY([FruitGroupId])
REFERENCES [dbo].[FruitGroupInfo] ([FGroupId])
GO
ALTER TABLE [dbo].[FruitInfo] CHECK CONSTRAINT [FK_FruitInfo_FruitGroupInfo]
GO
ALTER TABLE [dbo].[ShopCar]  WITH CHECK ADD  CONSTRAINT [FK_ShopCar_FruitInfo] FOREIGN KEY([FruitId])
REFERENCES [dbo].[FruitInfo] ([FruitId])
GO
ALTER TABLE [dbo].[ShopCar] CHECK CONSTRAINT [FK_ShopCar_FruitInfo]
GO
ALTER TABLE [dbo].[ShopCar]  WITH CHECK ADD  CONSTRAINT [FK_ShopCar_UserInfo] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserInfo] ([UserId])
GO
ALTER TABLE [dbo].[ShopCar] CHECK CONSTRAINT [FK_ShopCar_UserInfo]
GO
USE [master]
GO
ALTER DATABASE [FruitsShop] SET  READ_WRITE 
GO
