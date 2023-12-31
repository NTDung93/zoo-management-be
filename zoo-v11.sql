USE [master]
GO
/****** Object:  Database [ZooManagementBackup]    Script Date: 11/15/2023 5:30:51 PM ******/
CREATE DATABASE [ZooManagementBackup]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ZooManagementBackup', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ZooManagementBackup.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ZooManagementBackup_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ZooManagementBackup_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ZooManagementBackup] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ZooManagementBackup].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ZooManagementBackup] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ZooManagementBackup] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ZooManagementBackup] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ZooManagementBackup] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ZooManagementBackup] SET ARITHABORT OFF 
GO
ALTER DATABASE [ZooManagementBackup] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ZooManagementBackup] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ZooManagementBackup] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ZooManagementBackup] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ZooManagementBackup] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ZooManagementBackup] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ZooManagementBackup] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ZooManagementBackup] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ZooManagementBackup] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ZooManagementBackup] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ZooManagementBackup] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ZooManagementBackup] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ZooManagementBackup] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ZooManagementBackup] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ZooManagementBackup] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ZooManagementBackup] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ZooManagementBackup] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ZooManagementBackup] SET RECOVERY FULL 
GO
ALTER DATABASE [ZooManagementBackup] SET  MULTI_USER 
GO
ALTER DATABASE [ZooManagementBackup] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ZooManagementBackup] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ZooManagementBackup] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ZooManagementBackup] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ZooManagementBackup] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ZooManagementBackup] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ZooManagementBackup', N'ON'
GO
ALTER DATABASE [ZooManagementBackup] SET QUERY_STORE = OFF
GO
USE [ZooManagementBackup]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/15/2023 5:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Animals]    Script Date: 11/15/2023 5:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Animals](
	[AnimalId] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Region] [nvarchar](max) NULL,
	[Behavior] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[BirthDate] [datetime2](7) NULL,
	[ImportDate] [datetime2](7) NULL,
	[Image] [text] NULL,
	[HealthStatus] [tinyint] NULL,
	[Rarity] [nvarchar](max) NULL,
	[MaxFeedingQuantity] [decimal](5, 2) NOT NULL,
	[IsDeleted] [tinyint] NULL,
	[EmployeeId] [nvarchar](450) NULL,
	[CageId] [nvarchar](450) NULL,
	[SpeciesId] [int] NOT NULL,
	[CreatedDate] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Animals] PRIMARY KEY CLUSTERED 
(
	[AnimalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AnimalSpecies]    Script Date: 11/15/2023 5:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnimalSpecies](
	[SpeciesId] [int] IDENTITY(1,1) NOT NULL,
	[SpeciesName] [nvarchar](max) NULL,
	[CreatedDate] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_AnimalSpecies] PRIMARY KEY CLUSTERED 
(
	[SpeciesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Areas]    Script Date: 11/15/2023 5:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Areas](
	[AreaId] [nvarchar](450) NOT NULL,
	[AreaName] [nvarchar](max) NULL,
	[EmployeeId] [nvarchar](450) NULL,
	[CreatedDate] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Areas] PRIMARY KEY CLUSTERED 
(
	[AreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cages]    Script Date: 11/15/2023 5:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cages](
	[CageId] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[MaxCapacity] [int] NOT NULL,
	[CurrentCapacity] [int] NOT NULL,
	[AreaId] [nvarchar](450) NULL,
	[CreatedDate] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Cages] PRIMARY KEY CLUSTERED 
(
	[CageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Certificates]    Script Date: 11/15/2023 5:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Certificates](
	[CertificateCode] [nvarchar](450) NOT NULL,
	[CertificateName] [nvarchar](max) NULL,
	[Level] [nvarchar](max) NULL,
	[TrainingInstitution] [nvarchar](max) NULL,
	[CreatedDate] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Certificates] PRIMARY KEY CLUSTERED 
(
	[CertificateCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeCertificates]    Script Date: 11/15/2023 5:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeCertificates](
	[No] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [nvarchar](450) NULL,
	[CertificateCode] [nvarchar](450) NULL,
	[Description] [nvarchar](max) NULL,
	[CertificateImage] [text] NULL,
 CONSTRAINT [PK_EmployeeCertificates] PRIMARY KEY CLUSTERED 
(
	[No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 11/15/2023 5:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [nvarchar](450) NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[CitizenId] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[Image] [text] NULL,
	[Role] [nvarchar](max) NULL,
	[EmployeeStatus] [tinyint] NOT NULL,
	[CreatedDate] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FeedingMenus]    Script Date: 11/15/2023 5:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedingMenus](
	[MenuNo] [nvarchar](450) NOT NULL,
	[MenuName] [nvarchar](max) NULL,
	[FoodId] [nvarchar](450) NULL,
	[CreatedDate] [datetimeoffset](7) NOT NULL,
	[SpeciesId] [int] NOT NULL,
 CONSTRAINT [PK_FeedingMenus] PRIMARY KEY CLUSTERED 
(
	[MenuNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FeedingSchedules]    Script Date: 11/15/2023 5:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedingSchedules](
	[No] [int] IDENTITY(1,1) NOT NULL,
	[MenuNo] [nvarchar](450) NULL,
	[CageId] [nvarchar](450) NULL,
	[AnimalId] [nvarchar](450) NULL,
	[StartTime] [datetimeoffset](7) NOT NULL,
	[FeedingStatus] [tinyint] NOT NULL,
	[FeedingAmount] [decimal](5, 2) NOT NULL,
	[CreatedTime] [datetimeoffset](7) NOT NULL,
	[EmployeeId] [nvarchar](450) NULL,
	[EndTime] [datetimeoffset](7) NOT NULL,
	[Note] [nvarchar](250) NULL,
 CONSTRAINT [PK_FeedingSchedules] PRIMARY KEY CLUSTERED 
(
	[No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodInventories]    Script Date: 11/15/2023 5:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodInventories](
	[FoodId] [nvarchar](450) NOT NULL,
	[FoodName] [nvarchar](max) NULL,
	[InventoryQuantity] [decimal](5, 2) NOT NULL,
	[CreatedDate] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_FoodInventories] PRIMARY KEY CLUSTERED 
(
	[FoodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImportHistories]    Script Date: 11/15/2023 5:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImportHistories](
	[No] [int] IDENTITY(1,1) NOT NULL,
	[ImportDate] [datetime2](7) NOT NULL,
	[ImportQuantity] [decimal](5, 2) NOT NULL,
	[FoodId] [nvarchar](450) NULL,
 CONSTRAINT [PK_ImportHistories] PRIMARY KEY CLUSTERED 
(
	[No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 11/15/2023 5:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[NewsId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Content] [text] NULL,
	[WritingDate] [datetime2](7) NULL,
	[Image] [text] NULL,
	[EmployeeId] [nvarchar](450) NULL,
	[SpeciesId] [int] NOT NULL,
	[AnimalId] [nvarchar](450) NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[NewsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 11/15/2023 5:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderId] [int] NOT NULL,
	[TicketId] [nvarchar](450) NOT NULL,
	[Quantity] [int] NULL,
	[EntryDate] [datetime2](7) NULL,
	[UnitTotalPrice] [decimal](10, 3) NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11/15/2023 5:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[FullName] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 11/15/2023 5:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[TicketId] [nvarchar](450) NOT NULL,
	[Type] [nvarchar](max) NULL,
	[UnitPrice] [float] NULL,
	[Description] [nvarchar](max) NULL,
	[Image] [text] NULL,
 CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED 
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionHistories]    Script Date: 11/15/2023 5:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionHistories](
	[TransactionId] [int] IDENTITY(1,1) NOT NULL,
	[PaymentMethod] [nvarchar](max) NULL,
	[TotalPrice] [float] NULL,
	[PurchaseDate] [datetime2](7) NULL,
	[PaymentStatus] [tinyint] NULL,
	[OrderId] [int] NOT NULL,
 CONSTRAINT [PK_TransactionHistories] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231014143009_InitialDb', N'7.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231015022258_AddImageAndDescriptionInTickets', N'7.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231016020137_ModifyFeedingSchedulesAndFeedingMenus', N'7.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231017091847_ModifyEmployeeCertificateAndFeedingSchedule', N'7.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231018082929_CreateRelationshipBetweenEmployeesAndAreas', N'7.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231018144418_RenameColumnsForFeedingMenusTable', N'7.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231019092748_AddedUnitTotalPriceInOrderDetail', N'7.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231024075448_ChangedColDataTypeAtAnimal', N'7.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231026020836_AddColumnNoteInFeedingSchedule', N'7.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231030132849_ChangedTimeDataTypeInFeedingSchedule', N'7.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231031032434_AddedCreatedDateInAllTables', N'7.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231031034222_RemoveCreatedProfileDateAtAnimal', N'7.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231031073421_AddedCreatedDataAtAnimal', N'7.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231101055757_CreateRelationshipBetweenSpeciesAndMenu', N'7.0.11')
GO
INSERT [dbo].[Animals] ([AnimalId], [Name], [Region], [Behavior], [Gender], [BirthDate], [ImportDate], [Image], [HealthStatus], [Rarity], [MaxFeedingQuantity], [IsDeleted], [EmployeeId], [CageId], [SpeciesId], [CreatedDate]) VALUES (N'ANI001', N'Corbett Tiger', N'Indochina', N'The Corbett Tiger, a subspecies of the Bengal tiger, is native to India''s Corbett National Park. These solitary nocturnal predators are territorial and fiercely protect their domains. They are excellent swimmers, often crossing rivers in search of prey. Their diet consists mainly of deer and wild boar, hunted stealthily from within tall grass.', N'Male', CAST(N'2021-10-20T00:00:00.0000000' AS DateTime2), CAST(N'2023-11-15T16:17:30.3818824' AS DateTime2), N'[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253396/images/thu-an-thit/tiger/g8iszebifjsocj92xae2.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253395/images/thu-an-thit/tiger/sj2qglno6netfrt9ki3j.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253395/images/thu-an-thit/tiger/mr7xtin4sirnqri0rzqq.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253395/images/thu-an-thit/tiger/z4bhexybccpmzmqlvnx8.jpg]', 1, N'Critically Endangered', CAST(10.00 AS Decimal(5, 2)), 0, N'E001', N'A0002', 7, CAST(N'2023-11-15T16:17:30.3819725+07:00' AS DateTimeOffset))
INSERT [dbo].[Animals] ([AnimalId], [Name], [Region], [Behavior], [Gender], [BirthDate], [ImportDate], [Image], [HealthStatus], [Rarity], [MaxFeedingQuantity], [IsDeleted], [EmployeeId], [CageId], [SpeciesId], [CreatedDate]) VALUES (N'ANI002', N'Asian Elephant (Luna)', N'Indochina', N'Asian elephants are known for their strong sense of community and social bonds. They often travel in close-knit family groups, led by the oldest female, and communicate through vocalizations, body language, and tactile interactions. Their intelligence is remarkable, allowing them to problem-solve, learn from experience, and even display self-awareness.', N'Female', CAST(N'2022-09-30T00:00:00.0000000' AS DateTime2), CAST(N'2023-11-15T16:17:30.3820529' AS DateTime2), N'[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253379/images/thu-an-thuc-vat/elephant/dhjco1vn0rkiscc55uwi.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253378/images/thu-an-thuc-vat/elephant/oymlhd9odsosig7brife.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253378/images/thu-an-thuc-vat/elephant/ixro6vpmf4roplkthlzz.jpg]', 1, N'Endangered', CAST(12.00 AS Decimal(5, 2)), 0, N'E003', N'B0002', 2, CAST(N'2023-11-15T16:17:30.3820541+07:00' AS DateTimeOffset))
INSERT [dbo].[Animals] ([AnimalId], [Name], [Region], [Behavior], [Gender], [BirthDate], [ImportDate], [Image], [HealthStatus], [Rarity], [MaxFeedingQuantity], [IsDeleted], [EmployeeId], [CageId], [SpeciesId], [CreatedDate]) VALUES (N'ANI003', N'Asian Elephant (Leo)', N'Indochina', N'Asian elephants are known for their strong sense of community and social bonds. They often travel in close-knit family groups, led by the oldest female, and communicate through vocalizations, body language, and tactile interactions. Their intelligence is remarkable, allowing them to problem-solve, learn from experience, and even display self-awareness.', N'Male', CAST(N'2022-08-30T00:00:00.0000000' AS DateTime2), CAST(N'2023-11-15T16:17:30.3820549' AS DateTime2), N'[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253379/images/thu-an-thuc-vat/elephant/dhjco1vn0rkiscc55uwi.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253378/images/thu-an-thuc-vat/elephant/oymlhd9odsosig7brife.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253378/images/thu-an-thuc-vat/elephant/ixro6vpmf4roplkthlzz.jpg]', 1, N'Endangered', CAST(15.00 AS Decimal(5, 2)), 0, N'E003', N'B0002', 2, CAST(N'2023-11-15T16:17:30.3820550+07:00' AS DateTimeOffset))
INSERT [dbo].[Animals] ([AnimalId], [Name], [Region], [Behavior], [Gender], [BirthDate], [ImportDate], [Image], [HealthStatus], [Rarity], [MaxFeedingQuantity], [IsDeleted], [EmployeeId], [CageId], [SpeciesId], [CreatedDate]) VALUES (N'ANI004', N'Indo Flamingo (Daisy)', N'Indo', N'The Indo Flamingo, or the Greater Flamingo (Phoenicopterus roseus), is a striking and elegant wading bird known for its vivid pink plumage and distinct long, slender legs. These birds are primarily found in the Indian subcontinent and some parts of Africa and Europe. Indo Flamingos are characterized by their graceful behavior and their affinity for shallow, saline wetlands.', N'Female', CAST(N'2022-08-15T00:00:00.0000000' AS DateTime2), CAST(N'2023-11-15T16:17:30.3820555' AS DateTime2), N'[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253382/images/thu-an-thuc-vat/flamingo/cykpobgngqjn8velykyc.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253381/images/thu-an-thuc-vat/flamingo/vnghr1qiadnx03oioeef.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253381/images/thu-an-thuc-vat/flamingo/qccsob0qoxdtoiclau6f.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253381/images/thu-an-thuc-vat/flamingo/aobfuhg9wqo2rnpphb5y.jpg]', 1, N'Normal', CAST(8.00 AS Decimal(5, 2)), 0, N'E008', N'B0003', 8, CAST(N'2023-11-15T16:17:30.3820556+07:00' AS DateTimeOffset))
INSERT [dbo].[Animals] ([AnimalId], [Name], [Region], [Behavior], [Gender], [BirthDate], [ImportDate], [Image], [HealthStatus], [Rarity], [MaxFeedingQuantity], [IsDeleted], [EmployeeId], [CageId], [SpeciesId], [CreatedDate]) VALUES (N'ANI005', N'Indo Flamingo (Buddy)', N'Indo', N'The Indo Flamingo, or the Greater Flamingo (Phoenicopterus roseus), is a striking and elegant wading bird known for its vivid pink plumage and distinct long, slender legs. These birds are primarily found in the Indian subcontinent and some parts of Africa and Europe. Indo Flamingos are characterized by their graceful behavior and their affinity for shallow, saline wetlands.', N'Male', CAST(N'2021-07-12T00:00:00.0000000' AS DateTime2), CAST(N'2023-11-15T16:17:30.3820559' AS DateTime2), N'[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253382/images/thu-an-thuc-vat/flamingo/cykpobgngqjn8velykyc.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253381/images/thu-an-thuc-vat/flamingo/vnghr1qiadnx03oioeef.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253381/images/thu-an-thuc-vat/flamingo/qccsob0qoxdtoiclau6f.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253381/images/thu-an-thuc-vat/flamingo/aobfuhg9wqo2rnpphb5y.jpg]', 2, N'Normal', CAST(12.00 AS Decimal(5, 2)), 0, N'E008', N'B0003', 8, CAST(N'2023-11-15T16:17:30.3820559+07:00' AS DateTimeOffset))
INSERT [dbo].[Animals] ([AnimalId], [Name], [Region], [Behavior], [Gender], [BirthDate], [ImportDate], [Image], [HealthStatus], [Rarity], [MaxFeedingQuantity], [IsDeleted], [EmployeeId], [CageId], [SpeciesId], [CreatedDate]) VALUES (N'ANI006', N'Angola Giraffe', N'South African', N'The Angola Giraffe, scientifically known as Giraffa camelopardalis angolensis, is a captivating subspecies of giraffe primarily found in southwestern Africa, particularly in Angola and parts of Namibia. These gentle giants are known for their unique and intricate spotted coat, characterized by irregular and jagged patterns.', N'Male', CAST(N'2020-12-30T00:00:00.0000000' AS DateTime2), CAST(N'2023-11-15T16:17:30.3820567' AS DateTime2), N'[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253393/images/thu-an-thuc-vat/giraffe/yoi6zxjqqykoryindntl.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253391/images/thu-an-thuc-vat/giraffe/mlibbgxp756qtpcecn4o.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253391/images/thu-an-thuc-vat/giraffe/ln6w1lbpzm973julylx5.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253390/images/thu-an-thuc-vat/giraffe/ah7gnlqazxd7jxlpsk57.jpg]', 1, N'Normal', CAST(10.00 AS Decimal(5, 2)), 0, N'E006', N'B0001', 1, CAST(N'2023-11-15T16:17:30.3820567+07:00' AS DateTimeOffset))
INSERT [dbo].[Animals] ([AnimalId], [Name], [Region], [Behavior], [Gender], [BirthDate], [ImportDate], [Image], [HealthStatus], [Rarity], [MaxFeedingQuantity], [IsDeleted], [EmployeeId], [CageId], [SpeciesId], [CreatedDate]) VALUES (N'ANI007', N'African Zebra', N'South African', N'The African Zebra, part of the Equus zebra species, is an iconic and unmistakable creature native to the grasslands and savannahs of Africa. Renowned for their striking black and white striped coats, these herbivorous animals are characterized by their social and spirited behavior.', N'Male', CAST(N'2020-12-31T00:00:00.0000000' AS DateTime2), CAST(N'2023-11-15T16:17:30.3820584' AS DateTime2), N'[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253390/images/thu-an-thuc-vat/zebra/xd7jzximk4clmoyrzaje.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253390/images/thu-an-thuc-vat/zebra/w2zfbqlpkxtexs2vhqed.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253389/images/thu-an-thuc-vat/zebra/wpkh0hlq40yd0aykuzpl.jpg]', 1, N'Endangered', CAST(10.00 AS Decimal(5, 2)), 0, N'E006', N'B0005', 9, CAST(N'2023-11-15T16:17:30.3820585+07:00' AS DateTimeOffset))
INSERT [dbo].[Animals] ([AnimalId], [Name], [Region], [Behavior], [Gender], [BirthDate], [ImportDate], [Image], [HealthStatus], [Rarity], [MaxFeedingQuantity], [IsDeleted], [EmployeeId], [CageId], [SpeciesId], [CreatedDate]) VALUES (N'ANI008', N'African Parrot', N'Africa', N'The African Parrot, a diverse group of colorful and intelligent parrot species, graces the forests and savannahs of Africa with its vibrant plumage and lively behavior. These avian wonders are celebrated for their charming personalities and impressive vocal abilities.', N'Female', CAST(N'2020-12-30T00:00:00.0000000' AS DateTime2), CAST(N'2023-11-15T16:17:30.3820588' AS DateTime2), N'[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253387/images/thu-an-thuc-vat/parrot/myeyqf3wvj2ojyfgvmkl.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253386/images/thu-an-thuc-vat/parrot/lp7fwviqprlpbum0r8pm.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253386/images/thu-an-thuc-vat/parrot/jo1pwznbgslpfsujguqm.jpg]', 1, N'Normal', CAST(2.00 AS Decimal(5, 2)), 0, N'E007', N'B0004', 10, CAST(N'2023-11-15T16:17:30.3820589+07:00' AS DateTimeOffset))
INSERT [dbo].[Animals] ([AnimalId], [Name], [Region], [Behavior], [Gender], [BirthDate], [ImportDate], [Image], [HealthStatus], [Rarity], [MaxFeedingQuantity], [IsDeleted], [EmployeeId], [CageId], [SpeciesId], [CreatedDate]) VALUES (N'ANI009', N'Thailand Crocodile (Charlie)', N'Southeast Asia', N'The Thailand Crocodile, scientifically known as Crocodylus siamensis, is a critically endangered reptile native to Southeast Asia, including Thailand. These crocodiles are semi-aquatic, spending much of their time in and around freshwater habitats. They exhibit a solitary nature, with adult individuals leading independent lives, and they can be territorial during the breeding season.', N'Male', CAST(N'2020-12-30T00:00:00.0000000' AS DateTime2), CAST(N'2023-11-15T16:17:30.3820595' AS DateTime2), N'[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253374/images/thu-duoi-nuoc/alligator/aptsdg9ozv3q86ebjrhs.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253374/images/thu-duoi-nuoc/alligator/pqoetvgxhfjccftwkzzj.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253373/images/thu-duoi-nuoc/alligator/rrcuxxtbrtf6hpudl7g6.jpg]', 1, N'Endangered', CAST(6.00 AS Decimal(5, 2)), 0, N'E010', N'C0002', 6, CAST(N'2023-11-15T16:17:30.3820596+07:00' AS DateTimeOffset))
INSERT [dbo].[Animals] ([AnimalId], [Name], [Region], [Behavior], [Gender], [BirthDate], [ImportDate], [Image], [HealthStatus], [Rarity], [MaxFeedingQuantity], [IsDeleted], [EmployeeId], [CageId], [SpeciesId], [CreatedDate]) VALUES (N'ANI010', N'Thailand Crocodile (Sophie)', N'Southeast Asia', N'The Thailand Crocodile, scientifically known as Crocodylus siamensis, is a critically endangered reptile native to Southeast Asia, including Thailand. These crocodiles are semi-aquatic, spending much of their time in and around freshwater habitats. They exhibit a solitary nature, with adult individuals leading independent lives, and they can be territorial during the breeding season.', N'Female', CAST(N'2020-12-30T00:00:00.0000000' AS DateTime2), CAST(N'2023-11-15T16:17:30.3820600' AS DateTime2), N'[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253374/images/thu-duoi-nuoc/alligator/aptsdg9ozv3q86ebjrhs.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253374/images/thu-duoi-nuoc/alligator/pqoetvgxhfjccftwkzzj.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253373/images/thu-duoi-nuoc/alligator/rrcuxxtbrtf6hpudl7g6.jpg]', 1, N'Endangered', CAST(4.00 AS Decimal(5, 2)), 0, N'E010', N'C0002', 6, CAST(N'2023-11-15T16:17:30.3820600+07:00' AS DateTimeOffset))
GO
SET IDENTITY_INSERT [dbo].[AnimalSpecies] ON 

INSERT [dbo].[AnimalSpecies] ([SpeciesId], [SpeciesName], [CreatedDate]) VALUES (1, N'Giraffe', CAST(N'2023-11-15T16:17:30.3608405+07:00' AS DateTimeOffset))
INSERT [dbo].[AnimalSpecies] ([SpeciesId], [SpeciesName], [CreatedDate]) VALUES (2, N'Elephant', CAST(N'2023-11-15T16:17:30.3608758+07:00' AS DateTimeOffset))
INSERT [dbo].[AnimalSpecies] ([SpeciesId], [SpeciesName], [CreatedDate]) VALUES (3, N'Peacook', CAST(N'2023-11-15T16:17:30.3608762+07:00' AS DateTimeOffset))
INSERT [dbo].[AnimalSpecies] ([SpeciesId], [SpeciesName], [CreatedDate]) VALUES (4, N'Lion', CAST(N'2023-11-15T16:17:30.3608763+07:00' AS DateTimeOffset))
INSERT [dbo].[AnimalSpecies] ([SpeciesId], [SpeciesName], [CreatedDate]) VALUES (5, N'Hippo', CAST(N'2023-11-15T16:17:30.3608766+07:00' AS DateTimeOffset))
INSERT [dbo].[AnimalSpecies] ([SpeciesId], [SpeciesName], [CreatedDate]) VALUES (6, N'Alligator', CAST(N'2023-11-15T16:17:30.3608774+07:00' AS DateTimeOffset))
INSERT [dbo].[AnimalSpecies] ([SpeciesId], [SpeciesName], [CreatedDate]) VALUES (7, N'Tiger', CAST(N'2023-11-15T16:17:30.3608775+07:00' AS DateTimeOffset))
INSERT [dbo].[AnimalSpecies] ([SpeciesId], [SpeciesName], [CreatedDate]) VALUES (8, N'Flamingo', CAST(N'2023-11-15T16:17:30.3608776+07:00' AS DateTimeOffset))
INSERT [dbo].[AnimalSpecies] ([SpeciesId], [SpeciesName], [CreatedDate]) VALUES (9, N'Zebra', CAST(N'2023-11-15T16:17:30.3608777+07:00' AS DateTimeOffset))
INSERT [dbo].[AnimalSpecies] ([SpeciesId], [SpeciesName], [CreatedDate]) VALUES (10, N'Parrot', CAST(N'2023-11-15T16:17:30.3608779+07:00' AS DateTimeOffset))
SET IDENTITY_INSERT [dbo].[AnimalSpecies] OFF
GO
INSERT [dbo].[Areas] ([AreaId], [AreaName], [EmployeeId], [CreatedDate]) VALUES (N'A', N'Carnivore', N'E001', CAST(N'2023-11-15T16:17:30.2355444+07:00' AS DateTimeOffset))
INSERT [dbo].[Areas] ([AreaId], [AreaName], [EmployeeId], [CreatedDate]) VALUES (N'B', N'Herbivore', N'E003', CAST(N'2023-11-15T16:17:30.2375035+07:00' AS DateTimeOffset))
INSERT [dbo].[Areas] ([AreaId], [AreaName], [EmployeeId], [CreatedDate]) VALUES (N'C', N'Underwater', N'E006', CAST(N'2023-11-15T16:17:30.2375052+07:00' AS DateTimeOffset))
GO
INSERT [dbo].[Cages] ([CageId], [Name], [MaxCapacity], [CurrentCapacity], [AreaId], [CreatedDate]) VALUES (N'A0001', N'Lion Enclosure', 10, 0, N'A', CAST(N'2023-11-15T16:17:30.2846190+07:00' AS DateTimeOffset))
INSERT [dbo].[Cages] ([CageId], [Name], [MaxCapacity], [CurrentCapacity], [AreaId], [CreatedDate]) VALUES (N'A0002', N'Tiger Enclosure', 10, 0, N'A', CAST(N'2023-11-15T16:17:30.2846530+07:00' AS DateTimeOffset))
INSERT [dbo].[Cages] ([CageId], [Name], [MaxCapacity], [CurrentCapacity], [AreaId], [CreatedDate]) VALUES (N'B0001', N'Giraffe Enclosure', 10, 0, N'B', CAST(N'2023-11-15T16:17:30.2846535+07:00' AS DateTimeOffset))
INSERT [dbo].[Cages] ([CageId], [Name], [MaxCapacity], [CurrentCapacity], [AreaId], [CreatedDate]) VALUES (N'B0002', N'Elephant Enclosure', 10, 0, N'B', CAST(N'2023-11-15T16:17:30.2846537+07:00' AS DateTimeOffset))
INSERT [dbo].[Cages] ([CageId], [Name], [MaxCapacity], [CurrentCapacity], [AreaId], [CreatedDate]) VALUES (N'B0003', N'Peacook and Flamingo Enclosure', 10, 0, N'B', CAST(N'2023-11-15T16:17:30.2846539+07:00' AS DateTimeOffset))
INSERT [dbo].[Cages] ([CageId], [Name], [MaxCapacity], [CurrentCapacity], [AreaId], [CreatedDate]) VALUES (N'B0004', N'Rooster and Parrot Enclosure', 10, 0, N'B', CAST(N'2023-11-15T16:17:30.2846546+07:00' AS DateTimeOffset))
INSERT [dbo].[Cages] ([CageId], [Name], [MaxCapacity], [CurrentCapacity], [AreaId], [CreatedDate]) VALUES (N'B0005', N'Zebra Enclosure', 10, 0, N'B', CAST(N'2023-11-15T16:17:30.2846547+07:00' AS DateTimeOffset))
INSERT [dbo].[Cages] ([CageId], [Name], [MaxCapacity], [CurrentCapacity], [AreaId], [CreatedDate]) VALUES (N'C0001', N'Hippo Enclosure', 10, 0, N'C', CAST(N'2023-11-15T16:17:30.2846549+07:00' AS DateTimeOffset))
INSERT [dbo].[Cages] ([CageId], [Name], [MaxCapacity], [CurrentCapacity], [AreaId], [CreatedDate]) VALUES (N'C0002', N'Alligator Enclosure', 10, 0, N'C', CAST(N'2023-11-15T16:17:30.2846581+07:00' AS DateTimeOffset))
GO
INSERT [dbo].[Certificates] ([CertificateCode], [CertificateName], [Level], [TrainingInstitution], [CreatedDate]) VALUES (N'4WT7BN49', N'Zoologist Certification', N'Beginner', N'Ho Chi Minh City Department of Agriculture and Rural Development', CAST(N'2023-11-15T16:17:30.3104607+07:00' AS DateTimeOffset))
INSERT [dbo].[Certificates] ([CertificateCode], [CertificateName], [Level], [TrainingInstitution], [CreatedDate]) VALUES (N'INZ08ISN', N'Elephant Training Certificate', N'Expert', N'Ho Chi Minh City Department of Agriculture and Rural Development', CAST(N'2023-11-15T16:17:30.3104614+07:00' AS DateTimeOffset))
INSERT [dbo].[Certificates] ([CertificateCode], [CertificateName], [Level], [TrainingInstitution], [CreatedDate]) VALUES (N'NG8LXLFCX2', N'Herbivore Specilization', N'Expert', N'Ho Chi Minh City Department of Agriculture and Rural Development', CAST(N'2023-11-15T16:17:30.3104627+07:00' AS DateTimeOffset))
INSERT [dbo].[Certificates] ([CertificateCode], [CertificateName], [Level], [TrainingInstitution], [CreatedDate]) VALUES (N'NIOV30OMXB', N'Zebra Training Qualification', N'Intermediate', N'Ho Chi Minh City Department of Agriculture and Rural Development', CAST(N'2023-11-15T16:17:30.3104623+07:00' AS DateTimeOffset))
INSERT [dbo].[Certificates] ([CertificateCode], [CertificateName], [Level], [TrainingInstitution], [CreatedDate]) VALUES (N'OESN5O1H', N'Tiger Training Specilization', N'Intermediate', N'Ho Chi Minh City Department of Agriculture and Rural Development', CAST(N'2023-11-15T16:17:30.3104611+07:00' AS DateTimeOffset))
INSERT [dbo].[Certificates] ([CertificateCode], [CertificateName], [Level], [TrainingInstitution], [CreatedDate]) VALUES (N'UDYO5UYK', N'Reptile Specilization', N'Expert', N'Ho Chi Minh City Department of Agriculture and Rural Development', CAST(N'2023-11-15T16:17:30.3104247+07:00' AS DateTimeOffset))
INSERT [dbo].[Certificates] ([CertificateCode], [CertificateName], [Level], [TrainingInstitution], [CreatedDate]) VALUES (N'Z1XM30E1', N'Animal Care Specialist', N'Intermeidate', N'Nong Lam University', CAST(N'2023-11-15T16:17:30.3104585+07:00' AS DateTimeOffset))
GO
SET IDENTITY_INSERT [dbo].[EmployeeCertificates] ON 

INSERT [dbo].[EmployeeCertificates] ([No], [EmployeeId], [CertificateCode], [Description], [CertificateImage]) VALUES (1, N'E001', N'OESN5O1H', NULL, NULL)
INSERT [dbo].[EmployeeCertificates] ([No], [EmployeeId], [CertificateCode], [Description], [CertificateImage]) VALUES (2, N'E001', N'4WT7BN49', NULL, NULL)
INSERT [dbo].[EmployeeCertificates] ([No], [EmployeeId], [CertificateCode], [Description], [CertificateImage]) VALUES (3, N'E003', N'INZ08ISN', NULL, NULL)
INSERT [dbo].[EmployeeCertificates] ([No], [EmployeeId], [CertificateCode], [Description], [CertificateImage]) VALUES (4, N'E003', N'NG8LXLFCX2', NULL, NULL)
INSERT [dbo].[EmployeeCertificates] ([No], [EmployeeId], [CertificateCode], [Description], [CertificateImage]) VALUES (5, N'E006', N'UDYO5UYK', NULL, NULL)
INSERT [dbo].[EmployeeCertificates] ([No], [EmployeeId], [CertificateCode], [Description], [CertificateImage]) VALUES (6, N'E006', N'NIOV30OMXB', NULL, NULL)
SET IDENTITY_INSERT [dbo].[EmployeeCertificates] OFF
GO
INSERT [dbo].[Employees] ([EmployeeId], [FullName], [CitizenId], [Email], [Password], [PhoneNumber], [Image], [Role], [EmployeeStatus], [CreatedDate]) VALUES (N'E001', N'Nguyen Duc Son', N'943370230', N'nguyenducson2003@gmail.com', N'1', N'0981342455', N'https://res.cloudinary.com/dnk5fcjhn/image/upload/v1699106448/logo/kg0i7lvb0dtygc0hnol5.jpg', N'trainer', 0, CAST(N'2023-11-15T16:17:30.3223479+07:00' AS DateTimeOffset))
INSERT [dbo].[Employees] ([EmployeeId], [FullName], [CitizenId], [Email], [Password], [PhoneNumber], [Image], [Role], [EmployeeStatus], [CreatedDate]) VALUES (N'E002', N'Tran Minh Nhat', N'841135889', N'minhnhat2000@gmail.com', N'1', N'0981342455', N'https://res.cloudinary.com/dnk5fcjhn/image/upload/v1699106448/logo/kg0i7lvb0dtygc0hnol5.jpg', N'staff', 0, CAST(N'2023-11-15T16:17:30.3223869+07:00' AS DateTimeOffset))
INSERT [dbo].[Employees] ([EmployeeId], [FullName], [CitizenId], [Email], [Password], [PhoneNumber], [Image], [Role], [EmployeeStatus], [CreatedDate]) VALUES (N'E003', N'Nguyen Tien Dung', N'590254810', N'dungnt93@gmail.com', N'1', N'0897876321', N'https://res.cloudinary.com/dnk5fcjhn/image/upload/v1699106448/logo/kg0i7lvb0dtygc0hnol5.jpg', N'trainer', 0, CAST(N'2023-11-15T16:17:30.3223878+07:00' AS DateTimeOffset))
INSERT [dbo].[Employees] ([EmployeeId], [FullName], [CitizenId], [Email], [Password], [PhoneNumber], [Image], [Role], [EmployeeStatus], [CreatedDate]) VALUES (N'E004', N'Ta Vu Thanh Van', N'6941670627', N'thanhvan03@gmail.com', N'2', N'0923463674', N'https://res.cloudinary.com/dnk5fcjhn/image/upload/v1699106448/logo/kg0i7lvb0dtygc0hnol5.jpg', N'staff', 0, CAST(N'2023-11-15T16:17:30.3223881+07:00' AS DateTimeOffset))
INSERT [dbo].[Employees] ([EmployeeId], [FullName], [CitizenId], [Email], [Password], [PhoneNumber], [Image], [Role], [EmployeeStatus], [CreatedDate]) VALUES (N'E005', N'David Copperfield', N'8481289654', N'davidcopperfield@gmail.com', N'2', N'0823458761', N'https://res.cloudinary.com/dnk5fcjhn/image/upload/v1699106448/logo/kg0i7lvb0dtygc0hnol5.jpg', N'staff', 0, CAST(N'2023-11-15T16:17:30.3223885+07:00' AS DateTimeOffset))
INSERT [dbo].[Employees] ([EmployeeId], [FullName], [CitizenId], [Email], [Password], [PhoneNumber], [Image], [Role], [EmployeeStatus], [CreatedDate]) VALUES (N'E006', N'John Doe', N'2502417558', N'johndoeno1@gmail.com', N'1', N'0876312334', N'https://res.cloudinary.com/dnk5fcjhn/image/upload/v1699106448/logo/kg0i7lvb0dtygc0hnol5.jpg', N'trainer', 0, CAST(N'2023-11-15T16:17:30.3223997+07:00' AS DateTimeOffset))
INSERT [dbo].[Employees] ([EmployeeId], [FullName], [CitizenId], [Email], [Password], [PhoneNumber], [Image], [Role], [EmployeeStatus], [CreatedDate]) VALUES (N'E007', N'John Smith', N'1234567890', N'john.smith@example.com', N'1', N'0589169697', N'https://res.cloudinary.com/dnk5fcjhn/image/upload/v1699106448/logo/kg0i7lvb0dtygc0hnol5.jpg', N'trainer', 0, CAST(N'2023-11-15T16:17:30.3224001+07:00' AS DateTimeOffset))
INSERT [dbo].[Employees] ([EmployeeId], [FullName], [CitizenId], [Email], [Password], [PhoneNumber], [Image], [Role], [EmployeeStatus], [CreatedDate]) VALUES (N'E008', N'Jane Doe', N'9876543210', N'jane.doe@example.com', N'1', N'0986665343', N'https://res.cloudinary.com/dnk5fcjhn/image/upload/v1699106448/logo/kg0i7lvb0dtygc0hnol5.jpg', N'trainer', 0, CAST(N'2023-11-15T16:17:30.3224004+07:00' AS DateTimeOffset))
INSERT [dbo].[Employees] ([EmployeeId], [FullName], [CitizenId], [Email], [Password], [PhoneNumber], [Image], [Role], [EmployeeStatus], [CreatedDate]) VALUES (N'E009', N'John Doe', N'2502417558', N'johndoeno1@gmail.com', N'1', N'0881230814', N'https://res.cloudinary.com/dnk5fcjhn/image/upload/v1699106448/logo/kg0i7lvb0dtygc0hnol5.jpg', N'staff', 0, CAST(N'2023-11-15T16:17:30.3224005+07:00' AS DateTimeOffset))
INSERT [dbo].[Employees] ([EmployeeId], [FullName], [CitizenId], [Email], [Password], [PhoneNumber], [Image], [Role], [EmployeeStatus], [CreatedDate]) VALUES (N'E010', N'Abigail Scott', N'2402223095', N'parents@verizon.net', N'1', N'0954715955', N'https://res.cloudinary.com/dnk5fcjhn/image/upload/v1699106448/logo/kg0i7lvb0dtygc0hnol5.jpg', N'trainer', 0, CAST(N'2023-11-15T16:17:30.3224009+07:00' AS DateTimeOffset))
INSERT [dbo].[Employees] ([EmployeeId], [FullName], [CitizenId], [Email], [Password], [PhoneNumber], [Image], [Role], [EmployeeStatus], [CreatedDate]) VALUES (N'E011', N'Daniel Harris', N'7383372105', N'sjava@icloud.com', N'3', N'0831713773', N'https://res.cloudinary.com/dnk5fcjhn/image/upload/v1699106448/logo/kg0i7lvb0dtygc0hnol5.jpg', N'staff', 0, CAST(N'2023-11-15T16:17:30.3224012+07:00' AS DateTimeOffset))
INSERT [dbo].[Employees] ([EmployeeId], [FullName], [CitizenId], [Email], [Password], [PhoneNumber], [Image], [Role], [EmployeeStatus], [CreatedDate]) VALUES (N'E012', N'Christopher Wilson', N'4975833434', N'carmena@mac.com', N'3', N'0304835408', N'https://res.cloudinary.com/dnk5fcjhn/image/upload/v1699106448/logo/kg0i7lvb0dtygc0hnol5.jpg', N'staff', 0, CAST(N'2023-11-15T16:17:30.3224014+07:00' AS DateTimeOffset))
INSERT [dbo].[Employees] ([EmployeeId], [FullName], [CitizenId], [Email], [Password], [PhoneNumber], [Image], [Role], [EmployeeStatus], [CreatedDate]) VALUES (N'E013', N'Isabella Hernandez', N'8956520907', N'studyabr@gmail.com', N'4', N'0978803964', N'https://res.cloudinary.com/dnk5fcjhn/image/upload/v1699106448/logo/kg0i7lvb0dtygc0hnol5.jpg', N'trainer', 0, CAST(N'2023-11-15T16:17:30.3224017+07:00' AS DateTimeOffset))
INSERT [dbo].[Employees] ([EmployeeId], [FullName], [CitizenId], [Email], [Password], [PhoneNumber], [Image], [Role], [EmployeeStatus], [CreatedDate]) VALUES (N'E014', N'Sophia Martinez', N'6721102359', N'gslondon@live.com', N'4', N'0786008864', N'https://res.cloudinary.com/dnk5fcjhn/image/upload/v1699106448/logo/kg0i7lvb0dtygc0hnol5.jpg', N'staff', 0, CAST(N'2023-11-15T16:17:30.3224020+07:00' AS DateTimeOffset))
GO
INSERT [dbo].[FeedingMenus] ([MenuNo], [MenuName], [FoodId], [CreatedDate], [SpeciesId]) VALUES (N'MNU001', N'Breakfast for Tiger in 1st week of November', N'FD04', CAST(N'2023-11-15T16:17:30.4242188+07:00' AS DateTimeOffset), 7)
INSERT [dbo].[FeedingMenus] ([MenuNo], [MenuName], [FoodId], [CreatedDate], [SpeciesId]) VALUES (N'MNU002', N'Afternoon for Tiger 1st week of November', N'FD03', CAST(N'2023-11-15T16:17:30.4242505+07:00' AS DateTimeOffset), 7)
INSERT [dbo].[FeedingMenus] ([MenuNo], [MenuName], [FoodId], [CreatedDate], [SpeciesId]) VALUES (N'MNU003', N'Breakfast for Elephant in 1st week of November', N'FD05', CAST(N'2023-11-15T16:17:30.4242511+07:00' AS DateTimeOffset), 2)
INSERT [dbo].[FeedingMenus] ([MenuNo], [MenuName], [FoodId], [CreatedDate], [SpeciesId]) VALUES (N'MNU004', N'Lunch for Elephant in 1st week of November', N'FD06', CAST(N'2023-11-15T16:17:30.4242513+07:00' AS DateTimeOffset), 2)
INSERT [dbo].[FeedingMenus] ([MenuNo], [MenuName], [FoodId], [CreatedDate], [SpeciesId]) VALUES (N'MNU005', N'Flamingo 1st week', N'FD09', CAST(N'2023-11-15T16:17:30.4242515+07:00' AS DateTimeOffset), 8)
INSERT [dbo].[FeedingMenus] ([MenuNo], [MenuName], [FoodId], [CreatedDate], [SpeciesId]) VALUES (N'MNU006', N'Breakfast for Giraffe 1st week of November', N'FD01', CAST(N'2023-11-15T16:17:30.4242520+07:00' AS DateTimeOffset), 1)
INSERT [dbo].[FeedingMenus] ([MenuNo], [MenuName], [FoodId], [CreatedDate], [SpeciesId]) VALUES (N'MNU007', N'Lunch for Giraffe in 1st week of November', N'FD02', CAST(N'2023-11-15T16:17:30.4242522+07:00' AS DateTimeOffset), 1)
GO
INSERT [dbo].[FoodInventories] ([FoodId], [FoodName], [InventoryQuantity], [CreatedDate]) VALUES (N'FD01', N'Carrot', CAST(10.00 AS Decimal(5, 2)), CAST(N'2023-11-15T16:17:30.3479678+07:00' AS DateTimeOffset))
INSERT [dbo].[FoodInventories] ([FoodId], [FoodName], [InventoryQuantity], [CreatedDate]) VALUES (N'FD02', N'Grass', CAST(10.00 AS Decimal(5, 2)), CAST(N'2023-11-15T16:17:30.3480049+07:00' AS DateTimeOffset))
INSERT [dbo].[FoodInventories] ([FoodId], [FoodName], [InventoryQuantity], [CreatedDate]) VALUES (N'FD03', N'Beef', CAST(10.00 AS Decimal(5, 2)), CAST(N'2023-11-15T16:17:30.3480056+07:00' AS DateTimeOffset))
INSERT [dbo].[FoodInventories] ([FoodId], [FoodName], [InventoryQuantity], [CreatedDate]) VALUES (N'FD04', N'Chicken', CAST(10.00 AS Decimal(5, 2)), CAST(N'2023-11-15T16:17:30.3480108+07:00' AS DateTimeOffset))
INSERT [dbo].[FoodInventories] ([FoodId], [FoodName], [InventoryQuantity], [CreatedDate]) VALUES (N'FD05', N'Sugarcane', CAST(10.00 AS Decimal(5, 2)), CAST(N'2023-11-15T16:17:30.3480110+07:00' AS DateTimeOffset))
INSERT [dbo].[FoodInventories] ([FoodId], [FoodName], [InventoryQuantity], [CreatedDate]) VALUES (N'FD06', N'Watermelon', CAST(10.00 AS Decimal(5, 2)), CAST(N'2023-11-15T16:17:30.3480117+07:00' AS DateTimeOffset))
INSERT [dbo].[FoodInventories] ([FoodId], [FoodName], [InventoryQuantity], [CreatedDate]) VALUES (N'FD07', N'Squirrel', CAST(10.00 AS Decimal(5, 2)), CAST(N'2023-11-15T16:17:30.3480119+07:00' AS DateTimeOffset))
INSERT [dbo].[FoodInventories] ([FoodId], [FoodName], [InventoryQuantity], [CreatedDate]) VALUES (N'FD08', N'FruitBlend', CAST(10.00 AS Decimal(5, 2)), CAST(N'2023-11-15T16:17:30.3480121+07:00' AS DateTimeOffset))
INSERT [dbo].[FoodInventories] ([FoodId], [FoodName], [InventoryQuantity], [CreatedDate]) VALUES (N'FD09', N'Mixed beans', CAST(10.00 AS Decimal(5, 2)), CAST(N'2023-11-15T16:17:30.3480123+07:00' AS DateTimeOffset))
INSERT [dbo].[FoodInventories] ([FoodId], [FoodName], [InventoryQuantity], [CreatedDate]) VALUES (N'FD11', N'Corn', CAST(10.00 AS Decimal(5, 2)), CAST(N'2023-11-15T16:17:30.3480126+07:00' AS DateTimeOffset))
GO
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([NewsId], [Title], [Content], [WritingDate], [Image], [EmployeeId], [SpeciesId], [AnimalId]) VALUES (1, N'The Majestic Peacock''s Vibrant Beauty', N'<div>The peacock, scientifically known as Pavo cristatus, is a magnificent and iconic bird renowned for its striking beauty and vibrant plumage. Native to the Indian subcontinent, this avian species is famous for its resplendent tail feathers, which are adorned with iridescent hues of blue, green, and gold. These stunning feathers are fanned out in an elaborate display during courtship rituals, making the peacock a symbol of grace and elegance. While the male, known as a peacock, boasts these eye-catching plumage, the female, called a peahen, exhibits a more subdued appearance.</div><div><br></div><div><img src="http://res.cloudinary.com/dnk5fcjhn/image/upload/v1698844334/s9vvaghqn4vxrsexylks.jpg"></div><div><br></div><div>Beyond their captivating appearance, peacocks are also known for their distinctive, haunting calls that echo through their natural habitats, creating a harmonious soundscape. These birds have a significant cultural and symbolic presence in many societies, often representing themes of beauty, pride, and renewal. The peacock''s striking appearance and symbolic significance continue to captivate and inspire people worldwide, making it one of the most recognized and cherished birds in the avian kingdom.</div><div><br></div><div><img src="http://res.cloudinary.com/dnk5fcjhn/image/upload/v1698844374/vgpcef5bnseobn2edwzr.jpg"></div>', CAST(N'2023-11-15T16:17:30.4490458' AS DateTime2), N'https://res.cloudinary.com/dnk5fcjhn/image/upload/v1698844280/jojqhcbjbkw283nyp0q0.jpg', N'E004', 3, NULL)
INSERT [dbo].[News] ([NewsId], [Title], [Content], [WritingDate], [Image], [EmployeeId], [SpeciesId], [AnimalId]) VALUES (2, N'Giraffle is coming guys', N'<div>The giraffe, scientifically known as Giraffa camelopardalis, is one of the most iconic and distinctively tall mammals on Earth. Native to the African continent, giraffes are renowned for their long necks, which can reach up to 18 feet in length, allowing them to graze on treetop foliage that is out of reach for most other herbivores. These gentle giants have a unique spotted coat, with irregularly shaped patches that vary in color, acting as a form of camouflage in their natural habitat.</div><div><br></div><div><img src="http://res.cloudinary.com/dnk5fcjhn/image/upload/v1698766472/vdkxczjngpimymdt6lpn.jpg"></div><div><br></div><div>Giraffes are social animals, often found in groups known as towers. They have a calm and peaceful demeanor, relying on their remarkable vision and acute hearing for communication and protection. Their diet primarily consists of leaves, buds, and flowers from acacia and other trees. Despite their towering stature, giraffes are vulnerable to predation, particularly from lions.</div><div>Conservation efforts are crucial to ensure the survival of these majestic creatures, as their populations have declined due to habitat loss and poaching. Giraffes continue to be a symbol of Africa''s diverse wildlife and the importance of preserving the natural world.</div><div><br></div><div><img src="http://res.cloudinary.com/dnk5fcjhn/image/upload/v1698766524/tg7ydupy5vrspyavrqza.jpg"></div><div><br></div>', CAST(N'2023-11-15T16:17:30.4489604' AS DateTime2), N'https://res.cloudinary.com/dnk5fcjhn/image/upload/v1698766561/otzqufrhcunztrfvfg1x.jpg', N'E004', 1, N'ANI006')
INSERT [dbo].[News] ([NewsId], [Title], [Content], [WritingDate], [Image], [EmployeeId], [SpeciesId], [AnimalId]) VALUES (3, N'The Graceful Elegance of Red Flamingos', N'<div>The red flamingo, scientifically known as Phoenicopterus ruber, is a remarkable and iconic bird celebrated for its vibrant and striking appearance. Native to the Caribbean, coastal areas of northern South America, and some parts of West Africa, this avian species stands out with its distinctive pinkish-red plumage, long legs, and gracefully curved neck. These flamingos are known for their striking appearance and their unique feeding behavior, often seen standing on one leg in shallow waters. While the flamingos'' pink coloration is captivating, the pigments in their diet, including carotenoids, contribute to their vibrant hue.</div><div><br></div><div><img src="http://res.cloudinary.com/dnk5fcjhn/image/upload/v1698846056/nrutwjcrdjakwugcjbml.jpg"></div><div><br></div><div>Beyond their enchanting coloration, red flamingos are a symbol of elegance and grace in the avian world. Their striking appearance and characteristic group formations create a mesmerizing spectacle in their natural habitats. Red flamingos have a significant presence in various cultures and are often associated with themes of beauty, vitality, and unity. Their vivid plumage and graceful demeanor continue to captivate people around the world, making them one of the most recognized and cherished birds in the bird kingdom.</div><div><br></div><div><img src="http://res.cloudinary.com/dnk5fcjhn/image/upload/v1698846078/y56i8a8twcop56cututf.webp"></div>', CAST(N'2023-11-15T16:17:30.4490462' AS DateTime2), N'https://res.cloudinary.com/dnk5fcjhn/image/upload/v1698846085/uonis6swfpoajbhds0jb.jpg', N'E002', 8, N'ANI005')
SET IDENTITY_INSERT [dbo].[News] OFF
GO
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1, N'AMA_ENTRANCE_01', 3, CAST(N'2023-10-31T13:10:21.0000000' AS DateTime2), CAST(300000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1, N'AMA_ENTRANCE_02', 4, CAST(N'2023-11-03T13:10:21.0000000' AS DateTime2), CAST(240000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (2, N'AMA_ENTRANCE_01', 3, CAST(N'2023-10-29T13:12:10.1500000' AS DateTime2), CAST(300000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (2, N'AMA_ENTRANCE_02', 6, CAST(N'2023-10-29T13:12:10.1500000' AS DateTime2), CAST(360000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (3, N'AMA_ENTRANCE_01', 6, CAST(N'2023-10-29T13:15:43.0690000' AS DateTime2), CAST(600000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (3, N'AMA_ENTRANCE_02', 4, CAST(N'2023-10-29T13:15:43.0690000' AS DateTime2), CAST(240000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (4, N'AMA_ENTRANCE_01', 5, CAST(N'2023-10-29T13:27:40.7970000' AS DateTime2), CAST(500000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (4, N'AMA_ENTRANCE_02', 8, CAST(N'2023-10-29T13:27:40.7970000' AS DateTime2), CAST(480000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (5, N'AMA_ENTRANCE_01', 4, CAST(N'2023-10-29T13:28:28.3000000' AS DateTime2), CAST(400000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (5, N'AMA_ENTRANCE_02', 3, CAST(N'2023-10-29T13:28:28.3000000' AS DateTime2), CAST(180000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (6, N'AMA_ENTRANCE_01', 5, CAST(N'2023-10-29T13:29:05.8710000' AS DateTime2), CAST(500000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (6, N'AMA_ENTRANCE_02', 5, CAST(N'2023-10-29T13:29:05.8710000' AS DateTime2), CAST(300000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (7, N'AMA_ENTRANCE_01', 3, CAST(N'2023-10-29T13:37:17.8050000' AS DateTime2), CAST(300000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (7, N'AMA_ENTRANCE_02', 3, CAST(N'2023-10-29T13:37:17.8050000' AS DateTime2), CAST(180000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (8, N'AMA_ENTRANCE_01', 4, CAST(N'2023-10-29T13:38:01.2880000' AS DateTime2), CAST(400000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (8, N'AMA_ENTRANCE_02', 5, CAST(N'2023-10-29T13:38:01.2880000' AS DateTime2), CAST(300000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (9, N'AMA_ENTRANCE_01', 5, CAST(N'2023-10-29T13:38:41.4030000' AS DateTime2), CAST(500000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (9, N'AMA_ENTRANCE_02', 6, CAST(N'2023-10-29T13:38:41.4030000' AS DateTime2), CAST(360000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (10, N'AMA_ENTRANCE_01', 4, CAST(N'2023-10-29T13:51:04.3720000' AS DateTime2), CAST(400000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (10, N'AMA_ENTRANCE_02', 4, CAST(N'2023-10-29T13:51:04.3720000' AS DateTime2), CAST(240000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (11, N'AMA_ENTRANCE_01', 5, CAST(N'2023-10-29T13:51:50.7330000' AS DateTime2), CAST(500000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (11, N'AMA_ENTRANCE_02', 4, CAST(N'2023-10-29T13:51:50.7330000' AS DateTime2), CAST(240000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (12, N'AMA_ENTRANCE_01', 3, CAST(N'2023-10-29T13:52:32.5130000' AS DateTime2), CAST(300000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (12, N'AMA_ENTRANCE_02', 1, CAST(N'2023-10-29T13:52:32.5130000' AS DateTime2), CAST(60000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (13, N'AMA_ENTRANCE_01', 1, CAST(N'2023-10-29T13:53:05.1010000' AS DateTime2), CAST(100000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (13, N'AMA_ENTRANCE_02', 3, CAST(N'2023-10-29T13:53:05.1010000' AS DateTime2), CAST(180000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (14, N'AMA_ENTRANCE_01', 2, CAST(N'2023-10-29T13:57:58.3920000' AS DateTime2), CAST(200000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (14, N'AMA_ENTRANCE_02', 2, CAST(N'2023-10-29T13:57:58.3920000' AS DateTime2), CAST(120000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (15, N'AMA_ENTRANCE_01', 3, CAST(N'2023-11-01T08:31:32.0000000' AS DateTime2), CAST(300000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (15, N'AMA_ENTRANCE_02', 5, CAST(N'2023-12-04T08:31:32.0000000' AS DateTime2), CAST(300000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (16, N'AMA_ENTRANCE_01', 2, CAST(N'2023-10-30T08:32:51.6430000' AS DateTime2), CAST(200000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (16, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-02T08:32:51.0000000' AS DateTime2), CAST(60000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (17, N'AMA_ENTRANCE_01', 4, CAST(N'2023-11-07T14:31:42.0000000' AS DateTime2), CAST(400000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (17, N'AMA_ENTRANCE_02', 2, CAST(N'2023-10-31T14:31:42.0000000' AS DateTime2), CAST(120000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (18, N'AMA_ENTRANCE_01', 2, CAST(N'2023-10-31T14:34:10.0000000' AS DateTime2), CAST(200000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1002, N'AMA_ENTRANCE_01', 2, CAST(N'2023-10-31T08:46:15.3870000' AS DateTime2), CAST(200000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1002, N'AMA_ENTRANCE_02', 4, CAST(N'2023-11-22T08:46:15.0000000' AS DateTime2), CAST(240000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1003, N'AMA_ENTRANCE_01', 1, CAST(N'2023-11-01T03:44:27.4790000' AS DateTime2), CAST(100000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1003, N'AMA_ENTRANCE_02', 2, CAST(N'2023-11-01T03:44:27.4790000' AS DateTime2), CAST(120000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1004, N'AMA_ENTRANCE_01', 2, CAST(N'2023-11-01T03:50:14.3100000' AS DateTime2), CAST(200000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1004, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-01T03:50:14.3100000' AS DateTime2), CAST(60000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1005, N'AMA_ENTRANCE_01', 1, CAST(N'2023-11-01T03:55:02.9090000' AS DateTime2), CAST(100000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1005, N'AMA_ENTRANCE_02', 2, CAST(N'2023-11-01T03:55:02.9090000' AS DateTime2), CAST(120000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1006, N'AMA_ENTRANCE_02', 2, CAST(N'2023-11-01T03:59:17.6880000' AS DateTime2), CAST(120000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1007, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-01T04:05:24.3600000' AS DateTime2), CAST(60000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1008, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-01T04:48:54.2710000' AS DateTime2), CAST(60000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1009, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-01T04:54:39.9500000' AS DateTime2), CAST(60000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1010, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-01T04:59:59.5190000' AS DateTime2), CAST(60000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1011, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-01T05:08:04.1610000' AS DateTime2), CAST(60000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1012, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-01T05:11:51.8680000' AS DateTime2), CAST(60000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1013, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-01T07:40:18.4280000' AS DateTime2), CAST(60000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1014, N'AMA_ENTRANCE_01', 2, CAST(N'2023-11-01T07:46:13.2470000' AS DateTime2), CAST(200000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1014, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-01T07:46:13.2470000' AS DateTime2), CAST(60000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1015, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-01T07:48:50.3690000' AS DateTime2), CAST(60000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1016, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-01T07:49:25.0350000' AS DateTime2), CAST(60000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1017, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-01T07:52:18.0940000' AS DateTime2), CAST(60000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1018, N'AMA_ENTRANCE_01', 1, CAST(N'2023-11-01T07:54:42.1200000' AS DateTime2), CAST(100000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1019, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-01T07:59:07.0600000' AS DateTime2), CAST(60000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1020, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-01T08:04:12.8080000' AS DateTime2), CAST(60000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1021, N'AMA_ENTRANCE_01', 1, CAST(N'2023-11-01T08:06:35.2730000' AS DateTime2), CAST(100000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1022, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-01T08:16:17.5340000' AS DateTime2), CAST(60000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1023, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-01T08:18:55.4380000' AS DateTime2), CAST(60000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1024, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-01T08:30:05.0150000' AS DateTime2), CAST(60000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1025, N'AMA_ENTRANCE_01', 1, CAST(N'2023-11-01T08:31:58.4090000' AS DateTime2), CAST(100000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1026, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-01T08:42:34.1460000' AS DateTime2), CAST(60000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1027, N'AMA_ENTRANCE_01', 1, CAST(N'2023-11-01T08:46:58.7270000' AS DateTime2), CAST(100000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1027, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-01T08:46:58.7270000' AS DateTime2), CAST(60000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1028, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-01T09:05:57.6740000' AS DateTime2), CAST(60000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (1029, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-01T09:17:39.8270000' AS DateTime2), CAST(60000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (2022, N'AMA_ENTRANCE_01', 1, CAST(N'2023-11-07T02:55:06.0680000' AS DateTime2), CAST(100000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (2022, N'AMA_ENTRANCE_02', 2, CAST(N'2023-11-07T02:55:06.0680000' AS DateTime2), CAST(120000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (2023, N'AMA_ENTRANCE_01', 1, CAST(N'2023-11-07T03:48:45.9270000' AS DateTime2), CAST(100000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (2023, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-07T03:48:45.9270000' AS DateTime2), CAST(60000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (2024, N'AMA_ENTRANCE_02', 3, CAST(N'2023-11-07T14:41:42.1550000' AS DateTime2), CAST(180000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (2025, N'AMA_ENTRANCE_02', 3, CAST(N'2023-11-07T14:41:42.1550000' AS DateTime2), CAST(180000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (2026, N'AMA_ENTRANCE_01', 1, CAST(N'2023-11-07T15:07:54.3610000' AS DateTime2), CAST(100000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (2026, N'AMA_ENTRANCE_02', 2, CAST(N'2023-11-07T15:07:54.3610000' AS DateTime2), CAST(120000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (2027, N'AMA_ENTRANCE_01', 1, CAST(N'2023-11-08T04:49:20.3680000' AS DateTime2), CAST(100000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (2027, N'AMA_ENTRANCE_02', 2, CAST(N'2023-11-23T04:49:20.0000000' AS DateTime2), CAST(120000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (2028, N'AMA_ENTRANCE_01', 2, CAST(N'2023-11-10T14:48:14.0000000' AS DateTime2), CAST(200000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (2028, N'AMA_ENTRANCE_02', 3, CAST(N'2023-11-11T14:48:14.0000000' AS DateTime2), CAST(180000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (2029, N'AMA_ENTRANCE_01', 3, CAST(N'2023-11-25T16:06:12.0000000' AS DateTime2), CAST(300000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (2029, N'AMA_ENTRANCE_02', 4, CAST(N'2023-11-17T16:06:12.0000000' AS DateTime2), CAST(280000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (2030, N'AMA_ENTRANCE_01', 2, CAST(N'2023-11-24T16:08:10.0000000' AS DateTime2), CAST(200000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (2030, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-08T16:08:10.5090000' AS DateTime2), CAST(70000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (2031, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-08T16:10:40.5650000' AS DateTime2), CAST(70000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (2032, N'AMA_ENTRANCE_01', 1, CAST(N'2023-11-09T14:28:20.2750000' AS DateTime2), CAST(100000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (2032, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-09T14:28:20.2750000' AS DateTime2), CAST(70000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (3032, N'AMA_ENTRANCE_01', 1, CAST(N'2023-11-11T07:05:14.3870000' AS DateTime2), CAST(100000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (3032, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-11T07:05:14.3870000' AS DateTime2), CAST(70000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (3033, N'AMA_ENTRANCE_01', 1, CAST(N'2023-11-11T07:08:16.3410000' AS DateTime2), CAST(100000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (3033, N'AMA_ENTRANCE_02', 2, CAST(N'2023-11-11T07:08:16.3410000' AS DateTime2), CAST(140000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (3034, N'AMA_ENTRANCE_01', 1, CAST(N'2023-11-12T12:01:57.3950000' AS DateTime2), CAST(100000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (3034, N'AMA_ENTRANCE_02', 2, CAST(N'2023-11-14T12:01:57.0000000' AS DateTime2), CAST(140000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (3035, N'AMA_ENTRANCE_01', 3, CAST(N'2023-11-16T13:03:42.0000000' AS DateTime2), CAST(300000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (3035, N'AMA_ENTRANCE_02', 2, CAST(N'2023-11-12T13:03:42.6650000' AS DateTime2), CAST(140000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (3036, N'AMA_ENTRANCE_01', 2, CAST(N'2023-11-14T14:40:38.0000000' AS DateTime2), CAST(200000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (3036, N'AMA_ENTRANCE_02', 4, CAST(N'2023-11-23T14:40:38.0000000' AS DateTime2), CAST(280000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (4034, N'AMA_ENTRANCE_01', 3, CAST(N'2023-11-14T13:25:09.1060000' AS DateTime2), CAST(300000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (4034, N'AMA_ENTRANCE_02', 3, CAST(N'2023-11-14T13:25:09.1060000' AS DateTime2), CAST(210000.000 AS Decimal(10, 3)))
GO
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (4035, N'AMA_ENTRANCE_01', 2, CAST(N'2023-11-14T15:41:39.7160000' AS DateTime2), CAST(200000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (4035, N'AMA_ENTRANCE_02', 2, CAST(N'2023-11-14T15:41:39.7160000' AS DateTime2), CAST(140000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (4036, N'AMA_ENTRANCE_01', 1, CAST(N'2023-11-14T15:43:59.8810000' AS DateTime2), CAST(100000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (4036, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-14T15:43:59.8810000' AS DateTime2), CAST(70000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (4037, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-14T15:46:38.2960000' AS DateTime2), CAST(70000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (4038, N'AMA_ENTRANCE_01', 1, CAST(N'2023-11-14T16:14:22.7640000' AS DateTime2), CAST(100000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (4038, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-14T16:14:22.7640000' AS DateTime2), CAST(70000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (4039, N'AMA_ENTRANCE_01', 1, CAST(N'2023-11-14T16:23:50.2770000' AS DateTime2), CAST(100000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (4040, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-15T02:11:15.7650000' AS DateTime2), CAST(70000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (4041, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-15T02:29:35.2600000' AS DateTime2), CAST(70000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (4042, N'AMA_ENTRANCE_01', 1, CAST(N'2023-11-15T03:36:21.2580000' AS DateTime2), CAST(100000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (4042, N'AMA_ENTRANCE_02', 2, CAST(N'2023-11-15T03:36:21.2580000' AS DateTime2), CAST(140000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (4043, N'AMA_ENTRANCE_01', 1, CAST(N'2023-11-15T03:40:57.4420000' AS DateTime2), CAST(100000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (4043, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-15T03:40:57.4420000' AS DateTime2), CAST(70000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (4044, N'AMA_ENTRANCE_01', 1, CAST(N'2023-11-15T03:44:29.8360000' AS DateTime2), CAST(100000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (4045, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-15T03:54:59.4810000' AS DateTime2), CAST(70000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (4046, N'AMA_ENTRANCE_01', 1, CAST(N'2023-11-15T03:57:32.0930000' AS DateTime2), CAST(100000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (4047, N'AMA_ENTRANCE_01', 1, CAST(N'2023-11-15T03:59:26.0890000' AS DateTime2), CAST(100000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (4047, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-15T03:59:26.0890000' AS DateTime2), CAST(70000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (4048, N'AMA_ENTRANCE_02', 2, CAST(N'2023-11-15T04:02:49.9570000' AS DateTime2), CAST(140000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (4049, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-15T04:02:49.9570000' AS DateTime2), CAST(70000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (4050, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-15T04:10:10.5840000' AS DateTime2), CAST(70000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (4051, N'AMA_ENTRANCE_01', 1, CAST(N'2023-11-15T04:18:39.6300000' AS DateTime2), CAST(100000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (4051, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-15T04:18:39.6300000' AS DateTime2), CAST(70000.000 AS Decimal(10, 3)))
INSERT [dbo].[OrderDetails] ([OrderId], [TicketId], [Quantity], [EntryDate], [UnitTotalPrice]) VALUES (4052, N'AMA_ENTRANCE_02', 1, CAST(N'2023-11-15T08:27:38.5450000' AS DateTime2), CAST(70000.000 AS Decimal(10, 3)))
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (1, N'nguyentiendung2003@gmail.com', N'Nguyễn Thị Hương', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (2, N'nguyentiendung2003@gmail.com', N'Nguyễn Thị Hoa', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (3, N'dungntse171710@fpt.edu.vn', N'Nguyễn Tiến Dũng', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (4, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (5, N'dungntse171710@fpt.edu.vn', N'Nguyễn Tiến Dũng', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (6, N'dungntse171710@fpt.edu.vn', N'Nguyễn Tiến Dũng', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (7, N'dungntse171710@fpt.edu.vn', N'Nguyễn Tiến Dũng', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (8, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (9, N'dungntse171710@fpt.edu.vn', N'Nguyễn Tiến Dũng', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (10, N'dungntse171710@fpt.edu.vn', N'Nguyễn Tiến Dũng', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (11, N'dungntse171710@fpt.edu.vn', N'Nguyễn Tiến Dũng', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (12, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (13, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (14, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (15, N'tvtvan1407@gmail.com', N'Thanh Vân', N'0975470522')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (16, N'tvtvan1407@gmail.com', N'Thanh Vân', N'0975470522')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (17, N'nguyentiendung2003@gmail.com', N'Dung Nguyen', N'0975470522')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (18, N'sonndse171782@fpt.edu.vn', N'Duc Ngu', N'0975470522')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (1002, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (1003, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (1004, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (1005, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (1006, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (1007, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (1008, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (1009, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (1010, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (1011, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (1012, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (1013, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (1014, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (1015, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (1016, N'dungntse171710@fpt.edu.vn', N'Nguyễn Tiến Dũng', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (1017, N'dungntse171710@fpt.edu.vn', N'Nguyễn Tiến Dũng', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (1018, N'nguyentiendung2003@gmail.com', N'Nguyễn Tiến Dũng', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (1019, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (1020, N'minhnhatt0908@gmail.com', N'Nguyễn Tiến Dũng', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (1021, N'minhnhatt0908@gmail.com', N'Nguyễn Tiến Dũng', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (1022, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (1023, N'dungntse171710@fpt.edu.vn', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (1024, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (1025, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (1026, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (1027, N'dungntse171710@fpt.edu.vn', N'Nguyễn Tiến Dũng', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (1028, N'dungntse171710@fpt.edu.vn', N'Nguyễn Tiến Dũng', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (1029, N'dungntse171710@fpt.edu.vn', N'Nguyễn Tiến Dũng', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (2022, N'dungntse171710@fpt.edu.vn', N'Nguyễn Tiến Dũng', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (2023, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (2024, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (2025, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (2026, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (2027, N'nguyenducson2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (2028, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (2029, N'nguyenducson2915@gmai.com', N'Duc Ngu', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (2030, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (2031, N'dungntse171710@fpt.edu.vn', N'Dung Nguyen', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (2032, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (3032, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (3033, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (3034, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (3035, N'nguyentiendung2003@gmail.com', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (3036, N'nguyentiendung2003@gmail.com', N'Tien Dung', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (4034, N'nguyentiendung2003@gmail.com', N'Tien Dung', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (4035, N'nguyenducson2915@gmai.com', N'Tien Dung', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (4036, N'nguyentiendung2003@gmail.com', N'Tien Dung', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (4037, N'anhhddse171777@fpt.edu.vn', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (4038, N'anhhddse171777@fpt.edu.vn', N'Dung N', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (4039, N'dungntse171710@fpt.edu.vn', N'Nguyễn Tiến Dũng', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (4040, N'dungntse171710@fpt.edu.vn', N'Nguyễn Tiến Dũng', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (4041, N'dungntse171710@fpt.edu.vn', N'Nguyễn Tiến Dũng', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (4042, N'dungntse171710@fpt.edu.vn', N'Nguyễn Tiến Dũng', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (4043, N'dungntse171710@fpt.edu.vn', N'Nguyễn Tiến Dũng', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (4044, N'dungntse171710@fpt.edu.vn', N'Nguyễn Tiến Dũng', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (4045, N'dungntse171710@fpt.edu.vn', N'Nguyễn Tiến Dũng', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (4046, N'dungntse171710@fpt.edu.vn', N'Nguyễn Tiến Dũng', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (4047, N'dungntse171710@fpt.edu.vn', N'Nguyễn Tiến Dũng', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (4048, N'dungntse171710@fpt.edu.vn', N'Nguyễn Tiến Dũng', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (4049, N'dungntse171710@fpt.edu.vn', N'Nguyễn Tiến Dũng', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (4050, N'dungntse171710@fpt.edu.vn', N'Nguyễn Tiến Dũng', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (4051, N'dungntse171710@fpt.edu.vn', N'Nguyễn Tiến Dũng', N'0985295441')
INSERT [dbo].[Orders] ([OrderId], [Email], [FullName], [PhoneNumber]) VALUES (4052, N'dungntse171710@fpt.edu.vn', N'Nguyễn Tiến Dũng', N'0985295441')
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
INSERT [dbo].[Tickets] ([TicketId], [Type], [UnitPrice], [Description], [Image]) VALUES (N'AMA_ENTRANCE_01', N'Adult', 100000, N'View animals, play games and have a drink for free', N'https://res.cloudinary.com/dnk5fcjhn/image/upload/v1698412937/dq5alv2boskm2js9tgab.png')
INSERT [dbo].[Tickets] ([TicketId], [Type], [UnitPrice], [Description], [Image]) VALUES (N'AMA_ENTRANCE_02', N'Child', 70000, N'View animals, play games and have an ice cream for free', N'https://res.cloudinary.com/dnk5fcjhn/image/upload/v1698413005/xm9gpmwzoxukxjdt1rio.png')
GO
SET IDENTITY_INSERT [dbo].[TransactionHistories] ON 

INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (1, N'Credit Card', 540000, CAST(N'2023-01-29T20:10:57.8947226' AS DateTime2), 1, 1)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (2, N'Credit Card', 660000, CAST(N'2023-01-29T20:12:51.0863728' AS DateTime2), 1, 2)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (3, N'Credit Card', 840000, CAST(N'2023-02-25T20:16:11.5660320' AS DateTime2), 1, 3)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (4, N'Credit Card', 980000, CAST(N'2023-03-29T20:28:06.7189692' AS DateTime2), 1, 4)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (5, N'Credit Card', 580000, CAST(N'2023-04-29T20:28:56.8033158' AS DateTime2), 1, 5)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (6, N'Credit Card', 800000, CAST(N'2023-04-29T20:29:28.7752166' AS DateTime2), 1, 6)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (7, N'Credit Card', 480000, CAST(N'2023-05-29T20:37:38.7697838' AS DateTime2), 1, 7)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (8, N'Credit Card', 700000, CAST(N'2023-06-29T20:38:26.2903455' AS DateTime2), 1, 8)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (9, N'Credit Card', 860000, CAST(N'2023-07-29T20:39:11.7540414' AS DateTime2), 1, 9)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (10, N'Credit Card', 640000, CAST(N'2023-08-29T20:51:30.9828954' AS DateTime2), 1, 10)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (11, N'Credit Card', 740000, CAST(N'2023-09-29T20:52:14.9564000' AS DateTime2), 1, 11)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (12, N'Credit Card', 360000, CAST(N'2023-09-29T20:52:56.4840544' AS DateTime2), 1, 12)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (13, N'Credit Card', 280000, CAST(N'2023-10-29T20:53:28.0819528' AS DateTime2), 1, 13)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (14, N'Credit Card', 320000, CAST(N'2023-10-29T20:58:21.1099614' AS DateTime2), 1, 14)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (15, N'Credit Card', 260000, CAST(N'2023-10-30T15:33:27.1963006' AS DateTime2), 1, 16)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (16, N'Credit Card', 520000, CAST(N'2023-10-30T21:32:27.4883022' AS DateTime2), 1, 17)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (17, N'Credit Card', 200000, CAST(N'2023-10-30T21:34:59.2346220' AS DateTime2), 1, 18)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (1002, N'Credit Card', 440000, CAST(N'2023-10-31T15:50:13.7447165' AS DateTime2), 1, 1002)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (1003, N'Credit Card', 220000, CAST(N'2023-05-01T10:44:51.3783910' AS DateTime2), 1, 1003)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (1004, N'Credit Card', 260000, CAST(N'2023-02-01T10:50:52.1732679' AS DateTime2), 1, 1004)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (1005, N'Credit Card', 220000, CAST(N'2023-08-01T10:55:28.6457981' AS DateTime2), 1, 1005)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (1006, N'Credit Card', 120000, CAST(N'2023-06-01T10:59:49.9670142' AS DateTime2), 1, 1006)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (1007, N'Credit Card', 60000, CAST(N'2023-07-01T11:05:49.6295821' AS DateTime2), 1, 1007)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (1008, N'Credit Card', 60000, CAST(N'2023-07-01T11:49:19.3901413' AS DateTime2), 1, 1008)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (1009, N'Credit Card', 60000, CAST(N'2023-07-01T11:55:04.4973788' AS DateTime2), 1, 1009)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (1010, N'Credit Card', 60000, CAST(N'2023-07-01T12:00:26.1313028' AS DateTime2), 1, 1010)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (1011, N'Credit Card', 60000, CAST(N'2023-01-01T12:08:29.4177295' AS DateTime2), 1, 1011)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (1012, N'Credit Card', 60000, CAST(N'2023-02-01T12:12:16.5752783' AS DateTime2), 1, 1012)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (1013, N'Credit Card', 60000, CAST(N'2023-07-01T14:40:42.2118806' AS DateTime2), 1, 1013)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (1014, N'Credit Card', 260000, CAST(N'2023-04-01T14:46:40.3588974' AS DateTime2), 1, 1014)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (1015, N'Credit Card', 60000, CAST(N'2023-08-01T14:49:51.5260359' AS DateTime2), 1, 1016)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (1016, N'Credit Card', 60000, CAST(N'2023-09-01T14:52:51.2972826' AS DateTime2), 1, 1017)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (1017, N'Credit Card', 100000, CAST(N'2023-01-01T14:55:12.3849372' AS DateTime2), 1, 1018)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (1018, N'Credit Card', 60000, CAST(N'2023-01-01T14:59:36.5946719' AS DateTime2), 1, 1019)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (1019, N'Credit Card', 60000, CAST(N'2023-07-01T15:05:07.2067770' AS DateTime2), 1, 1020)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (1020, N'Credit Card', 100000, CAST(N'2023-07-01T15:06:58.9833732' AS DateTime2), 1, 1021)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (1021, N'Credit Card', 60000, CAST(N'2023-02-01T15:16:53.0533780' AS DateTime2), 1, 1022)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (1022, N'Credit Card', 60000, CAST(N'2023-02-01T15:19:23.8682964' AS DateTime2), 1, 1023)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (1023, N'Credit Card', 60000, CAST(N'2023-02-01T15:30:30.5557836' AS DateTime2), 1, 1024)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (1024, N'Credit Card', 100000, CAST(N'2023-11-01T15:32:21.6874042' AS DateTime2), 1, 1025)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (1025, N'Credit Card', 60000, CAST(N'2023-05-01T15:43:26.6600678' AS DateTime2), 1, 1026)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (1026, N'Credit Card', 160000, CAST(N'2023-05-01T15:47:23.4879009' AS DateTime2), 1, 1027)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (1027, N'Credit Card', 60000, CAST(N'2023-02-01T16:06:20.8840519' AS DateTime2), 1, 1028)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (1028, N'Credit Card', 60000, CAST(N'2023-07-01T16:18:09.1917750' AS DateTime2), 1, 1029)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (2021, N'Credit Card', 160000, CAST(N'2023-02-07T10:50:45.4509980' AS DateTime2), 1, 2023)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (2022, N'Credit Card', 220000, CAST(N'2023-02-07T22:08:21.4878311' AS DateTime2), 1, 2026)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (2023, N'Credit Card', 380000, CAST(N'2023-05-08T21:49:07.7461455' AS DateTime2), 1, 2028)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (2024, N'Credit Card', 580000, CAST(N'2023-11-08T23:07:04.8662914' AS DateTime2), 1, 2029)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (2025, N'Credit Card', 270000, CAST(N'2023-11-08T23:08:34.3430246' AS DateTime2), 1, 2030)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (2026, N'Credit Card', 670000, CAST(N'2023-11-08T23:11:07.4704551' AS DateTime2), 1, 2031)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (2027, N'Credit Card', 170000, CAST(N'2023-02-11T14:05:38.9279689' AS DateTime2), 1, 3032)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (2028, N'Credit Card', 240000, CAST(N'2023-02-11T14:08:46.9366219' AS DateTime2), 1, 3033)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (2029, N'Credit Card', 240000, CAST(N'2023-01-12T19:02:26.1237329' AS DateTime2), 1, 3034)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (2030, N'Credit Card', 440000, CAST(N'2023-03-12T20:04:09.2272762' AS DateTime2), 1, 3035)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (2031, N'Credit Card', 480000, CAST(N'2023-04-12T21:41:46.8502569' AS DateTime2), 1, 3036)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (3029, N'Credit Card', 510000, CAST(N'2023-05-14T20:25:31.2873684' AS DateTime2), 1, 4034)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (3034, N'Credit Card', 340000, CAST(N'2023-06-14T22:42:36.1937511' AS DateTime2), 1, 4035)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (3035, N'Credit Card', 170000, CAST(N'2023-07-14T22:44:27.8624172' AS DateTime2), 1, 4036)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (3036, N'Credit Card', 70000, CAST(N'2023-08-14T22:47:13.2939404' AS DateTime2), 1, 4037)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (3037, N'Credit Card', 170000, CAST(N'2023-09-14T23:14:46.1137610' AS DateTime2), 1, 4038)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (3038, N'Credit Card', 100000, CAST(N'2023-10-14T23:24:21.6273437' AS DateTime2), 1, 4039)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (3039, N'Credit Card', 70000, CAST(N'2023-01-15T09:11:44.1627639' AS DateTime2), 1, 4040)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (3040, N'Credit Card', 70000, CAST(N'2023-02-15T09:30:00.8521231' AS DateTime2), 1, 4041)
INSERT [dbo].[TransactionHistories] ([TransactionId], [PaymentMethod], [TotalPrice], [PurchaseDate], [PaymentStatus], [OrderId]) VALUES (3041, N'Credit Card', 170000, CAST(N'2023-03-15T11:19:04.5702070' AS DateTime2), 1, 4051)
SET IDENTITY_INSERT [dbo].[TransactionHistories] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Animals_CageId]    Script Date: 11/15/2023 5:30:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_Animals_CageId] ON [dbo].[Animals]
(
	[CageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Animals_EmployeeId]    Script Date: 11/15/2023 5:30:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_Animals_EmployeeId] ON [dbo].[Animals]
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Animals_SpeciesId]    Script Date: 11/15/2023 5:30:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_Animals_SpeciesId] ON [dbo].[Animals]
(
	[SpeciesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Areas_EmployeeId]    Script Date: 11/15/2023 5:30:51 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Areas_EmployeeId] ON [dbo].[Areas]
(
	[EmployeeId] ASC
)
WHERE ([EmployeeId] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Cages_AreaId]    Script Date: 11/15/2023 5:30:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_Cages_AreaId] ON [dbo].[Cages]
(
	[AreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_EmployeeCertificates_CertificateCode]    Script Date: 11/15/2023 5:30:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeCertificates_CertificateCode] ON [dbo].[EmployeeCertificates]
(
	[CertificateCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_EmployeeCertificates_EmployeeId]    Script Date: 11/15/2023 5:30:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeCertificates_EmployeeId] ON [dbo].[EmployeeCertificates]
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_FeedingMenus_FoodId]    Script Date: 11/15/2023 5:30:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_FeedingMenus_FoodId] ON [dbo].[FeedingMenus]
(
	[FoodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FeedingMenus_SpeciesId]    Script Date: 11/15/2023 5:30:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_FeedingMenus_SpeciesId] ON [dbo].[FeedingMenus]
(
	[SpeciesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_FeedingSchedules_AnimalId]    Script Date: 11/15/2023 5:30:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_FeedingSchedules_AnimalId] ON [dbo].[FeedingSchedules]
(
	[AnimalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_FeedingSchedules_CageId]    Script Date: 11/15/2023 5:30:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_FeedingSchedules_CageId] ON [dbo].[FeedingSchedules]
(
	[CageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_FeedingSchedules_EmployeeId]    Script Date: 11/15/2023 5:30:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_FeedingSchedules_EmployeeId] ON [dbo].[FeedingSchedules]
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_FeedingSchedules_MenuNo]    Script Date: 11/15/2023 5:30:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_FeedingSchedules_MenuNo] ON [dbo].[FeedingSchedules]
(
	[MenuNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ImportHistories_FoodId]    Script Date: 11/15/2023 5:30:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_ImportHistories_FoodId] ON [dbo].[ImportHistories]
(
	[FoodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_News_AnimalId]    Script Date: 11/15/2023 5:30:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_News_AnimalId] ON [dbo].[News]
(
	[AnimalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_News_EmployeeId]    Script Date: 11/15/2023 5:30:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_News_EmployeeId] ON [dbo].[News]
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_News_SpeciesId]    Script Date: 11/15/2023 5:30:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_News_SpeciesId] ON [dbo].[News]
(
	[SpeciesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_OrderDetails_TicketId]    Script Date: 11/15/2023 5:30:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_TicketId] ON [dbo].[OrderDetails]
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TransactionHistories_OrderId]    Script Date: 11/15/2023 5:30:51 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TransactionHistories_OrderId] ON [dbo].[TransactionHistories]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Animals] ADD  DEFAULT ('0001-01-01T00:00:00.0000000+00:00') FOR [CreatedDate]
GO
ALTER TABLE [dbo].[AnimalSpecies] ADD  DEFAULT ('0001-01-01T00:00:00.0000000+00:00') FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Areas] ADD  DEFAULT ('0001-01-01T00:00:00.0000000+00:00') FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Cages] ADD  DEFAULT ('0001-01-01T00:00:00.0000000+00:00') FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Certificates] ADD  DEFAULT ('0001-01-01T00:00:00.0000000+00:00') FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Employees] ADD  DEFAULT ('0001-01-01T00:00:00.0000000+00:00') FOR [CreatedDate]
GO
ALTER TABLE [dbo].[FeedingMenus] ADD  DEFAULT ('0001-01-01T00:00:00.0000000+00:00') FOR [CreatedDate]
GO
ALTER TABLE [dbo].[FeedingMenus] ADD  DEFAULT ((0)) FOR [SpeciesId]
GO
ALTER TABLE [dbo].[FeedingSchedules] ADD  DEFAULT ((0.0)) FOR [FeedingAmount]
GO
ALTER TABLE [dbo].[FoodInventories] ADD  DEFAULT ('0001-01-01T00:00:00.0000000+00:00') FOR [CreatedDate]
GO
ALTER TABLE [dbo].[OrderDetails] ADD  DEFAULT ((0.0)) FOR [UnitTotalPrice]
GO
ALTER TABLE [dbo].[Animals]  WITH CHECK ADD  CONSTRAINT [FK_Animals_AnimalSpecies_SpeciesId] FOREIGN KEY([SpeciesId])
REFERENCES [dbo].[AnimalSpecies] ([SpeciesId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Animals] CHECK CONSTRAINT [FK_Animals_AnimalSpecies_SpeciesId]
GO
ALTER TABLE [dbo].[Animals]  WITH CHECK ADD  CONSTRAINT [FK_Animals_Cages_CageId] FOREIGN KEY([CageId])
REFERENCES [dbo].[Cages] ([CageId])
GO
ALTER TABLE [dbo].[Animals] CHECK CONSTRAINT [FK_Animals_Cages_CageId]
GO
ALTER TABLE [dbo].[Animals]  WITH CHECK ADD  CONSTRAINT [FK_Animals_Employees_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[Animals] CHECK CONSTRAINT [FK_Animals_Employees_EmployeeId]
GO
ALTER TABLE [dbo].[Areas]  WITH CHECK ADD  CONSTRAINT [FK_Areas_Employees_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[Areas] CHECK CONSTRAINT [FK_Areas_Employees_EmployeeId]
GO
ALTER TABLE [dbo].[Cages]  WITH CHECK ADD  CONSTRAINT [FK_Cages_Areas_AreaId] FOREIGN KEY([AreaId])
REFERENCES [dbo].[Areas] ([AreaId])
GO
ALTER TABLE [dbo].[Cages] CHECK CONSTRAINT [FK_Cages_Areas_AreaId]
GO
ALTER TABLE [dbo].[EmployeeCertificates]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeCertificates_Certificates_CertificateCode] FOREIGN KEY([CertificateCode])
REFERENCES [dbo].[Certificates] ([CertificateCode])
GO
ALTER TABLE [dbo].[EmployeeCertificates] CHECK CONSTRAINT [FK_EmployeeCertificates_Certificates_CertificateCode]
GO
ALTER TABLE [dbo].[EmployeeCertificates]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeCertificates_Employees_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[EmployeeCertificates] CHECK CONSTRAINT [FK_EmployeeCertificates_Employees_EmployeeId]
GO
ALTER TABLE [dbo].[FeedingMenus]  WITH CHECK ADD  CONSTRAINT [FK_FeedingMenus_AnimalSpecies_SpeciesId] FOREIGN KEY([SpeciesId])
REFERENCES [dbo].[AnimalSpecies] ([SpeciesId])
GO
ALTER TABLE [dbo].[FeedingMenus] CHECK CONSTRAINT [FK_FeedingMenus_AnimalSpecies_SpeciesId]
GO
ALTER TABLE [dbo].[FeedingMenus]  WITH CHECK ADD  CONSTRAINT [FK_FeedingMenus_FoodInventories_FoodId] FOREIGN KEY([FoodId])
REFERENCES [dbo].[FoodInventories] ([FoodId])
GO
ALTER TABLE [dbo].[FeedingMenus] CHECK CONSTRAINT [FK_FeedingMenus_FoodInventories_FoodId]
GO
ALTER TABLE [dbo].[FeedingSchedules]  WITH CHECK ADD  CONSTRAINT [FK_FeedingSchedules_Animals_AnimalId] FOREIGN KEY([AnimalId])
REFERENCES [dbo].[Animals] ([AnimalId])
GO
ALTER TABLE [dbo].[FeedingSchedules] CHECK CONSTRAINT [FK_FeedingSchedules_Animals_AnimalId]
GO
ALTER TABLE [dbo].[FeedingSchedules]  WITH CHECK ADD  CONSTRAINT [FK_FeedingSchedules_Cages_CageId] FOREIGN KEY([CageId])
REFERENCES [dbo].[Cages] ([CageId])
GO
ALTER TABLE [dbo].[FeedingSchedules] CHECK CONSTRAINT [FK_FeedingSchedules_Cages_CageId]
GO
ALTER TABLE [dbo].[FeedingSchedules]  WITH CHECK ADD  CONSTRAINT [FK_FeedingSchedules_Employees_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[FeedingSchedules] CHECK CONSTRAINT [FK_FeedingSchedules_Employees_EmployeeId]
GO
ALTER TABLE [dbo].[FeedingSchedules]  WITH CHECK ADD  CONSTRAINT [FK_FeedingSchedules_FeedingMenus_MenuNo] FOREIGN KEY([MenuNo])
REFERENCES [dbo].[FeedingMenus] ([MenuNo])
GO
ALTER TABLE [dbo].[FeedingSchedules] CHECK CONSTRAINT [FK_FeedingSchedules_FeedingMenus_MenuNo]
GO
ALTER TABLE [dbo].[ImportHistories]  WITH CHECK ADD  CONSTRAINT [FK_ImportHistories_FoodInventories_FoodId] FOREIGN KEY([FoodId])
REFERENCES [dbo].[FoodInventories] ([FoodId])
GO
ALTER TABLE [dbo].[ImportHistories] CHECK CONSTRAINT [FK_ImportHistories_FoodInventories_FoodId]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_Animals_AnimalId] FOREIGN KEY([AnimalId])
REFERENCES [dbo].[Animals] ([AnimalId])
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_Animals_AnimalId]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_AnimalSpecies_SpeciesId] FOREIGN KEY([SpeciesId])
REFERENCES [dbo].[AnimalSpecies] ([SpeciesId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_AnimalSpecies_SpeciesId]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_Employees_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_Employees_EmployeeId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders_OrderId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Tickets_TicketId] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Tickets] ([TicketId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Tickets_TicketId]
GO
ALTER TABLE [dbo].[TransactionHistories]  WITH CHECK ADD  CONSTRAINT [FK_TransactionHistories_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TransactionHistories] CHECK CONSTRAINT [FK_TransactionHistories_Orders_OrderId]
GO
USE [master]
GO
ALTER DATABASE [ZooManagementBackup] SET  READ_WRITE 
GO
