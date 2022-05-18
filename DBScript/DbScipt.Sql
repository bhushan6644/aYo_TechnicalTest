USE [master]
GO
/****** Object:  Database [ConversionDB]    Script Date: 5/18/2022 2:38:34 PM ******/
CREATE DATABASE [ConversionDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ConversionDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ConversionDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ConversionDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ConversionDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ConversionDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ConversionDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ConversionDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ConversionDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ConversionDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ConversionDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ConversionDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ConversionDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ConversionDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ConversionDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ConversionDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ConversionDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ConversionDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ConversionDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ConversionDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ConversionDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ConversionDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ConversionDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ConversionDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ConversionDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ConversionDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ConversionDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ConversionDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ConversionDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ConversionDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ConversionDB] SET  MULTI_USER 
GO
ALTER DATABASE [ConversionDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ConversionDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ConversionDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ConversionDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ConversionDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ConversionDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ConversionDB] SET QUERY_STORE = OFF
GO
USE [ConversionDB]
GO
/****** Object:  Table [dbo].[ConversionDetail]    Script Date: 5/18/2022 2:38:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConversionDetail](
	[ConversionId] [int] IDENTITY(1,1) NOT NULL,
	[MeasurementId] [int] NULL,
	[ConversionRate] [decimal](18, 10) NULL,
	[MetricUnit] [varchar](50) NULL,
	[ImperialUnit] [varchar](50) NULL,
	[Active] [varchar](1) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Measurement]    Script Date: 5/18/2022 2:38:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Measurement](
	[MeasurementId] [int] IDENTITY(1,1) NOT NULL,
	[MeasurementName] [varchar](50) NULL,
	[Active] [varchar](1) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ConversionDetail] ON 
GO
INSERT [dbo].[ConversionDetail] ([ConversionId], [MeasurementId], [ConversionRate], [MetricUnit], [ImperialUnit], [Active]) VALUES (1, 1, CAST(25.4000000000 AS Decimal(18, 10)), N'Milimeter', N'Inch', N'Y')
GO
INSERT [dbo].[ConversionDetail] ([ConversionId], [MeasurementId], [ConversionRate], [MetricUnit], [ImperialUnit], [Active]) VALUES (12, 3, CAST(0.5556000000 AS Decimal(18, 10)), N'Fahrenheit', N'Celsius ', N'Y')
GO
INSERT [dbo].[ConversionDetail] ([ConversionId], [MeasurementId], [ConversionRate], [MetricUnit], [ImperialUnit], [Active]) VALUES (13, 1, CAST(1.8000000000 AS Decimal(18, 10)), N'Celsius', N'Fahrenheit', N'Y')
GO
INSERT [dbo].[ConversionDetail] ([ConversionId], [MeasurementId], [ConversionRate], [MetricUnit], [ImperialUnit], [Active]) VALUES (10, 2, CAST(28350.0000000000 AS Decimal(18, 10)), N'MiliGram', N'Ounce', N'Y')
GO
SET IDENTITY_INSERT [dbo].[ConversionDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Measurement] ON 
GO
INSERT [dbo].[Measurement] ([MeasurementId], [MeasurementName], [Active]) VALUES (1, N'Length', N'Y')
GO
INSERT [dbo].[Measurement] ([MeasurementId], [MeasurementName], [Active]) VALUES (2, N'Mass', N'Y')
GO
INSERT [dbo].[Measurement] ([MeasurementId], [MeasurementName], [Active]) VALUES (3, N'Tempature', N'Y')
GO
SET IDENTITY_INSERT [dbo].[Measurement] OFF
GO
ALTER TABLE [dbo].[Measurement] ADD  CONSTRAINT [DF_Measurement_Active]  DEFAULT ('Y') FOR [Active]
GO
USE [master]
GO
ALTER DATABASE [ConversionDB] SET  READ_WRITE 
GO
