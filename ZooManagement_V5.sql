USE [master]
GO
/****** Object:  Database [ZooManagement]    Script Date: 10/2/2023 8:58:24 PM ******/
CREATE DATABASE [ZooManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ZooManagement', FILENAME = N'D:\Microsoft SQL Server\MSSQL16.LONGVU\MSSQL\DATA\ZooManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ZooManagement_log', FILENAME = N'D:\Microsoft SQL Server\MSSQL16.LONGVU\MSSQL\DATA\ZooManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ZooManagement] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ZooManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ZooManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ZooManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ZooManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ZooManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ZooManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [ZooManagement] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ZooManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ZooManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ZooManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ZooManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ZooManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ZooManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ZooManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ZooManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ZooManagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ZooManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ZooManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ZooManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ZooManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ZooManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ZooManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ZooManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ZooManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ZooManagement] SET  MULTI_USER 
GO
ALTER DATABASE [ZooManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ZooManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ZooManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ZooManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ZooManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ZooManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ZooManagement] SET QUERY_STORE = ON
GO
ALTER DATABASE [ZooManagement] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ZooManagement]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/2/2023 8:58:24 PM ******/
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
/****** Object:  Table [dbo].[Animals]    Script Date: 10/2/2023 8:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Animals](
	[id] [varchar](75) NOT NULL,
	[name] [varchar](255) NULL,
	[region] [varchar](255) NULL,
	[behavior] [varchar](300) NULL,
	[gender] [varchar](15) NULL,
	[birthDate] [datetime] NULL,
	[image] [text] NULL,
	[healthStatus] [tinyint] NULL,
	[rarity] [varchar](100) NULL,
	[isDeleted] [tinyint] NULL,
	[empID] [varchar](75) NOT NULL,
	[cageID] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AnimalSpecies]    Script Date: 10/2/2023 8:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnimalSpecies](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[cageID] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Areas]    Script Date: 10/2/2023 8:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Areas](
	[id] [varchar](5) NOT NULL,
	[name] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cages]    Script Date: 10/2/2023 8:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cages](
	[id] [varchar](10) NOT NULL,
	[name] [varchar](255) NULL,
	[maxCapacity] [int] NULL,
	[areaID] [varchar](5) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Certificates]    Script Date: 10/2/2023 8:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Certificates](
	[code] [varchar](75) NOT NULL,
	[name] [varchar](255) NULL,
	[level] [varchar](100) NULL,
	[trainingInstitution] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeCertificates]    Script Date: 10/2/2023 8:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeCertificates](
	[No] [int] IDENTITY(1,1) NOT NULL,
	[empID] [varchar](75) NOT NULL,
	[cerfCode] [varchar](75) NOT NULL,
	[description] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 10/2/2023 8:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[id] [varchar](75) NOT NULL,
	[fullName] [varchar](255) NULL,
	[citizenID] [varchar](25) NULL,
	[email] [varchar](100) NULL,
	[password] [varchar](30) NULL,
	[phoneNumber] [varchar](25) NULL,
	[image] [text] NULL,
	[role] [varchar](75) NULL,
	[isDeleted] [tinyint] NULL,
	[refreshToken] [nvarchar](max) NULL,
	[refreshTokenExpiryTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FeedingSchedules]    Script Date: 10/2/2023 8:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedingSchedules](
	[scheduleNo] [int] IDENTITY(1,1) NOT NULL,
	[foodID] [int] NOT NULL,
	[employeeID] [varchar](75) NOT NULL,
	[animalID] [varchar](75) NOT NULL,
	[feedTime] [datetime] NULL,
	[feedStatus] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[scheduleNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Foods]    Script Date: 10/2/2023 8:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Foods](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImportHistory]    Script Date: 10/2/2023 8:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImportHistory](
	[No] [int] IDENTITY(1,1) NOT NULL,
	[importDate] [datetime] NULL,
	[quantity] [int] NULL,
	[foodID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 10/2/2023 8:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](500) NULL,
	[content] [text] NULL,
	[writingDate] [datetime] NULL,
	[image] [text] NULL,
	[empID] [varchar](75) NOT NULL,
	[speciesID] [int] NOT NULL,
	[animalID] [varchar](75) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 10/2/2023 8:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[orderID] [int] NOT NULL,
	[ticketID] [int] NOT NULL,
	[quantity] [int] NULL,
	[entryDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[orderID] ASC,
	[ticketID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 10/2/2023 8:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](100) NULL,
	[fullName] [varchar](255) NULL,
	[phoneNumber] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 10/2/2023 8:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [varchar](75) NULL,
	[unitPrice] [decimal](10, 4) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionHistory]    Script Date: 10/2/2023 8:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionHistory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[paymentMethod] [varchar](100) NULL,
	[totalPrice] [decimal](10, 4) NULL,
	[purchaseDate] [datetime] NULL,
	[paymentStatus] [tinyint] NULL,
	[orderID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Animals] ([id], [name], [region], [behavior], [gender], [birthDate], [image], [healthStatus], [rarity], [isDeleted], [empID], [cageID]) VALUES (N'1', N'Corbett Tiger', N'Indochina', N'Indochinese Tigers live solitarily and hide in deep forests with hilly terrain,  primarily hunt medium-sized and large ungulate species in the wild', N'Male ', CAST(N'2021-11-22T00:00:00.000' AS DateTime), N'[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253396/images/thu-an-thit/tiger/g8iszebifjsocj92xae2.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253395/images/thu-an-thit/tiger/sj2qglno6netfrt9ki3j.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253395/images/thu-an-thit/tiger/mr7xtin4sirnqri0rzqq.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253395/images/thu-an-thit/tiger/z4bhexybccpmzmqlvnx8.jpg]', 1, N'Critically Endangered', 0, N'E002', N'A0002')
GO
INSERT [dbo].[Animals] ([id], [name], [region], [behavior], [gender], [birthDate], [image], [healthStatus], [rarity], [isDeleted], [empID], [cageID]) VALUES (N'10', N'Africa Zebra', N'Afica', N'N/A', N'Female', CAST(N'2023-09-23T00:00:00.000' AS DateTime), N'[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253390/images/thu-an-thuc-vat/zebra/xd7jzximk4clmoyrzaje.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253390/images/thu-an-thuc-vat/zebra/w2zfbqlpkxtexs2vhqed.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253389/images/thu-an-thuc-vat/zebra/wpkh0hlq40yd0aykuzpl.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253389/images/thu-an-thuc-vat/zebra/ersav7u8kvnxgcfsuurt.jpg]', 1, N'Endangered', 0, N'E007', N'B0005')
GO
INSERT [dbo].[Animals] ([id], [name], [region], [behavior], [gender], [birthDate], [image], [healthStatus], [rarity], [isDeleted], [empID], [cageID]) VALUES (N'2', N'Indo Flamingo', N'Indo', N'Peafowls are omnivorous animals and primarily feed on vegetation, flower petals, seeds, insects, and other arthropods, reptiles, and amphibians', N'Male ', CAST(N'2022-02-12T00:00:00.000' AS DateTime), N'[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253382/images/thu-an-thuc-vat/flamingo/cykpobgngqjn8velykyc.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253381/images/thu-an-thuc-vat/flamingo/vnghr1qiadnx03oioeef.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253381/images/thu-an-thuc-vat/flamingo/qccsob0qoxdtoiclau6f.jpg, 
https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253381/images/thu-an-thuc-vat/flamingo/aobfuhg9wqo2rnpphb5y.jpg]', 1, N'Normal', 0, N'E006', N'C0001')
GO
INSERT [dbo].[Animals] ([id], [name], [region], [behavior], [gender], [birthDate], [image], [healthStatus], [rarity], [isDeleted], [empID], [cageID]) VALUES (N'3', N'Indo Flamingo', N'Indo', N'Peafowls are omnivorous animals and primarily feed on vegetation, flower petals, seeds, insects, and other arthropods, reptiles, and amphibians', N'Female', CAST(N'2022-02-14T00:00:00.000' AS DateTime), N'[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253382/images/thu-an-thuc-vat/flamingo/cykpobgngqjn8velykyc.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253381/images/thu-an-thuc-vat/flamingo/vnghr1qiadnx03oioeef.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253381/images/thu-an-thuc-vat/flamingo/qccsob0qoxdtoiclau6f.jpg, 
https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253381/images/thu-an-thuc-vat/flamingo/aobfuhg9wqo2rnpphb5y.jpg]', 1, N'Normal', 0, N'E006', N'C0001')
GO
INSERT [dbo].[Animals] ([id], [name], [region], [behavior], [gender], [birthDate], [image], [healthStatus], [rarity], [isDeleted], [empID], [cageID]) VALUES (N'4', N'Asian Elephant', N'Indochina', NULL, N'Male', CAST(N'2023-01-01T00:00:00.000' AS DateTime), N'[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253379/images/thu-an-thuc-vat/elephant/dhjco1vn0rkiscc55uwi.jpg, 
https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253378/images/thu-an-thuc-vat/elephant/oymlhd9odsosig7brife.jpg, 
https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253378/images/thu-an-thuc-vat/elephant/ixro6vpmf4roplkthlzz.jpg]', 1, N'Endangered', 0, N'E006', N'B0003')
GO
INSERT [dbo].[Animals] ([id], [name], [region], [behavior], [gender], [birthDate], [image], [healthStatus], [rarity], [isDeleted], [empID], [cageID]) VALUES (N'5', N'Angola Girrafe', N'South African', NULL, N'Male', CAST(N'2020-08-30T00:00:00.000' AS DateTime), N'[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253393/images/thu-an-thuc-vat/giraffe/yoi6zxjqqykoryindntl.jpg, 
https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253391/images/thu-an-thuc-vat/giraffe/mlibbgxp756qtpcecn4o.jpg, 
https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253391/images/thu-an-thuc-vat/giraffe/ln6w1lbpzm973julylx5.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253390/images/thu-an-thuc-vat/giraffe/ah7gnlqazxd7jxlpsk57.jpg]', 1, N'Vulnerable', 0, N'E005', N'B0001')
GO
INSERT [dbo].[Animals] ([id], [name], [region], [behavior], [gender], [birthDate], [image], [healthStatus], [rarity], [isDeleted], [empID], [cageID]) VALUES (N'6', N'Thailand Crocodile', N'Southeast Asia', N'This is a species of medium size, with the majority of individuals reaching sizes under 3.5 meters', N'Female', CAST(N'2020-07-29T00:00:00.000' AS DateTime), N'[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253374/images/thu-duoi-nuoc/alligator/aptsdg9ozv3q86ebjrhs.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253374/images/thu-duoi-nuoc/alligator/pqoetvgxhfjccftwkzzj.jpg, 
https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253373/images/thu-duoi-nuoc/alligator/re9ly1g9rxekag6t0swn.jpg, 
https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253373/images/thu-duoi-nuoc/alligator/rrcuxxtbrtf6hpudl7g6.jpg]', 1, N'Critically Endangered', 0, N'E004', N'D0001')
GO
INSERT [dbo].[Animals] ([id], [name], [region], [behavior], [gender], [birthDate], [image], [healthStatus], [rarity], [isDeleted], [empID], [cageID]) VALUES (N'7', N'Parrot', N'Africa', N'', N'Male', CAST(N'2023-09-23T00:00:00.000' AS DateTime), N'[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253387/images/thu-an-thuc-vat/parrot/myeyqf3wvj2ojyfgvmkl.jpg,
https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253386/images/thu-an-thuc-vat/parrot/lp7fwviqprlpbum0r8pm.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253386/images/thu-an-thuc-vat/parrot/jo1pwznbgslpfsujguqm.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253385/images/thu-an-thuc-vat/parrot/cyfgda0d355ma0dcce33.jpg]', 1, N'Normal', 0, N'E006', N'C0002')
GO
INSERT [dbo].[Animals] ([id], [name], [region], [behavior], [gender], [birthDate], [image], [healthStatus], [rarity], [isDeleted], [empID], [cageID]) VALUES (N'8', N'Monkey', NULL, NULL, N'Male', CAST(N'2023-09-23T00:00:00.000' AS DateTime), N'[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253389/images/thu-an-thuc-vat/monkey/w9cimkuwvxz7uofl6wxx.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253389/images/thu-an-thuc-vat/monkey/vvqgbhm2eefxrfw0qnxl.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253388/images/thu-an-thuc-vat/monkey/vlqknpjs532advul2ssv.jpg]', 1, N'Endangered', 0, N'E006', N'B0004')
GO
INSERT [dbo].[Animals] ([id], [name], [region], [behavior], [gender], [birthDate], [image], [healthStatus], [rarity], [isDeleted], [empID], [cageID]) VALUES (N'9', N'Antelope', N'Southest Asia', NULL, N'Male', CAST(N'2023-09-23T00:00:00.000' AS DateTime), N'[https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253379/images/thu-an-thuc-vat/antelope/lvb49u5zq1hifpm5gyel.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253376/images/thu-an-thuc-vat/antelope/mm5p4ixwbcb5ckioaups.jpg, https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696253376/images/thu-an-thuc-vat/antelope/ct2empf9tq9ymzhkdpcu.jpg]', 1, N'Normal', 0, N'E005', N'B0002')
GO
SET IDENTITY_INSERT [dbo].[AnimalSpecies] ON 
GO
INSERT [dbo].[AnimalSpecies] ([id], [name], [cageID]) VALUES (1, N'Elephant', N'B0003')
GO
INSERT [dbo].[AnimalSpecies] ([id], [name], [cageID]) VALUES (2, N'Tiger', N'A0002')
GO
INSERT [dbo].[AnimalSpecies] ([id], [name], [cageID]) VALUES (3, N'Girrafe', N'B0001')
GO
INSERT [dbo].[AnimalSpecies] ([id], [name], [cageID]) VALUES (4, N'Peafowl', N'C0001')
GO
INSERT [dbo].[AnimalSpecies] ([id], [name], [cageID]) VALUES (15, N'Lion', N'A0001')
GO
INSERT [dbo].[AnimalSpecies] ([id], [name], [cageID]) VALUES (16, N'Fox', N'A0003')
GO
INSERT [dbo].[AnimalSpecies] ([id], [name], [cageID]) VALUES (18, N'Monkey', N'B0004')
GO
INSERT [dbo].[AnimalSpecies] ([id], [name], [cageID]) VALUES (19, N'Crocodile', N'D0001')
GO
INSERT [dbo].[AnimalSpecies] ([id], [name], [cageID]) VALUES (20, N'Rooster', N'C0002')
GO
INSERT [dbo].[AnimalSpecies] ([id], [name], [cageID]) VALUES (21, N'Tortoise', N'D0002')
GO
SET IDENTITY_INSERT [dbo].[AnimalSpecies] OFF
GO
INSERT [dbo].[Areas] ([id], [name]) VALUES (N'A', N'Carnivore')
GO
INSERT [dbo].[Areas] ([id], [name]) VALUES (N'B', N'Herbivore')
GO
INSERT [dbo].[Areas] ([id], [name]) VALUES (N'C', N'Bird')
GO
INSERT [dbo].[Areas] ([id], [name]) VALUES (N'D', N'Reptile')
GO
INSERT [dbo].[Cages] ([id], [name], [maxCapacity], [areaID]) VALUES (N'A0001', N'Lion', 10, N'A')
GO
INSERT [dbo].[Cages] ([id], [name], [maxCapacity], [areaID]) VALUES (N'A0002', N'Tiger', 10, N'A')
GO
INSERT [dbo].[Cages] ([id], [name], [maxCapacity], [areaID]) VALUES (N'A0003', N'Fox', 8, N'A')
GO
INSERT [dbo].[Cages] ([id], [name], [maxCapacity], [areaID]) VALUES (N'B0001', N'Girrafe', 12, N'B')
GO
INSERT [dbo].[Cages] ([id], [name], [maxCapacity], [areaID]) VALUES (N'B0002', N'Deer and Antelope', 30, N'B')
GO
INSERT [dbo].[Cages] ([id], [name], [maxCapacity], [areaID]) VALUES (N'B0003', N'Elephant', 10, N'B')
GO
INSERT [dbo].[Cages] ([id], [name], [maxCapacity], [areaID]) VALUES (N'B0004', N'Monkey', 20, N'B')
GO
INSERT [dbo].[Cages] ([id], [name], [maxCapacity], [areaID]) VALUES (N'B0005', N'Zebra', 10, N'B')
GO
INSERT [dbo].[Cages] ([id], [name], [maxCapacity], [areaID]) VALUES (N'C0001', N'Peacook and Flamingo', 30, N'C')
GO
INSERT [dbo].[Cages] ([id], [name], [maxCapacity], [areaID]) VALUES (N'C0002', N'Rooster and Parrot', 15, N'C')
GO
INSERT [dbo].[Cages] ([id], [name], [maxCapacity], [areaID]) VALUES (N'C0003', N'Red factor Canary', 10, N'C')
GO
INSERT [dbo].[Cages] ([id], [name], [maxCapacity], [areaID]) VALUES (N'D0001', N'Crocodile', 10, N'D')
GO
INSERT [dbo].[Cages] ([id], [name], [maxCapacity], [areaID]) VALUES (N'D0002', N'Lizard and Tortoise', 10, N'D')
GO
INSERT [dbo].[Certificates] ([code], [name], [level], [trainingInstitution]) VALUES (N'3FQLO', N'Reptile Specialist', N'Expert', N'Ho Chi Minh City Department of Agriculture and Rural Development')
GO
INSERT [dbo].[Certificates] ([code], [name], [level], [trainingInstitution]) VALUES (N'CER001', N'Animal Care Specialist', N'Intermeidate', N'Nong Lam University')
GO
INSERT [dbo].[Certificates] ([code], [name], [level], [trainingInstitution]) VALUES (N'CER002', N'Zoologist Certification', N'Beginner', N'Nong Lam University')
GO
INSERT [dbo].[Certificates] ([code], [name], [level], [trainingInstitution]) VALUES (N'CER2ND49', N'Tiger Training Specilization', N'Intermediate', N'Ho Chi Minh City Department of Agriculture and Rural Development')
GO
INSERT [dbo].[Certificates] ([code], [name], [level], [trainingInstitution]) VALUES (N'CEREZ769', N'Elephant Training Certificate', N'Expert', N'Ho Chi Minh City Department of Agriculture and Rural Development')
GO
INSERT [dbo].[Certificates] ([code], [name], [level], [trainingInstitution]) VALUES (N'MYHOK', N'Bird Care Certificate', N'Intermediate', N'Nong Lam University')
GO
SET IDENTITY_INSERT [dbo].[EmployeeCertificates] ON 
GO
INSERT [dbo].[EmployeeCertificates] ([No], [empID], [cerfCode], [description]) VALUES (1, N'E002', N'CER001', N'Has 3 years working experience')
GO
INSERT [dbo].[EmployeeCertificates] ([No], [empID], [cerfCode], [description]) VALUES (2, N'E002', N'CER2ND49', N'Has 2 years working experience')
GO
INSERT [dbo].[EmployeeCertificates] ([No], [empID], [cerfCode], [description]) VALUES (3, N'E006', N'CEREZ769', N'Has 6 years working experience, training elephants at many Vietnamese zoos')
GO
INSERT [dbo].[EmployeeCertificates] ([No], [empID], [cerfCode], [description]) VALUES (4, N'E006', N'MYHOK', N'Has 2 years working experience')
GO
INSERT [dbo].[EmployeeCertificates] ([No], [empID], [cerfCode], [description]) VALUES (5, N'E005', N'CER002', N'Has 6 months intern at Thao Cam Vien Botanical Gardens and Zoos')
GO
INSERT [dbo].[EmployeeCertificates] ([No], [empID], [cerfCode], [description]) VALUES (6, N'E004', N'3FQLO', N'Has 7 years working experience')
GO
INSERT [dbo].[EmployeeCertificates] ([No], [empID], [cerfCode], [description]) VALUES (7, N'E005', N'CER001', NULL)
GO
SET IDENTITY_INSERT [dbo].[EmployeeCertificates] OFF
GO
INSERT [dbo].[Employees] ([id], [fullName], [citizenID], [email], [password], [phoneNumber], [image], [role], [isDeleted], [refreshToken], [refreshTokenExpiryTime]) VALUES (N'E001', N'John Doe', N'070863628583', N'johndoe1@gmail.com', N'1', N'0876312334', N'N/A', N'Staff', 0, NULL, NULL)
GO
INSERT [dbo].[Employees] ([id], [fullName], [citizenID], [email], [password], [phoneNumber], [image], [role], [isDeleted], [refreshToken], [refreshTokenExpiryTime]) VALUES (N'E002', N'Nguyen Duc Son', N'01234567899', N'nguyenducson2003@gmail.com', N'1', N'0981342456', N'N/A', N'Trainer', 0, N'XpUPI7vy9NdtwJOusx7Ly/3lie2ZkHoR1k683mpm6Pw=', CAST(N'2023-10-03T15:23:31.070' AS DateTime))
GO
INSERT [dbo].[Employees] ([id], [fullName], [citizenID], [email], [password], [phoneNumber], [image], [role], [isDeleted], [refreshToken], [refreshTokenExpiryTime]) VALUES (N'E003', N'Tran Minh Nhat', N'184113588935', N'minhnhat2000@gmail.com', N'2', N'0998123675', NULL, N'Staff', 0, NULL, NULL)
GO
INSERT [dbo].[Employees] ([id], [fullName], [citizenID], [email], [password], [phoneNumber], [image], [role], [isDeleted], [refreshToken], [refreshTokenExpiryTime]) VALUES (N'E004', N'Nguyen Tien Dung', N'698252930728', N'dungnt93@gmail.com', N'2', N'0897876321', NULL, N'Trainer', 0, NULL, NULL)
GO
INSERT [dbo].[Employees] ([id], [fullName], [citizenID], [email], [password], [phoneNumber], [image], [role], [isDeleted], [refreshToken], [refreshTokenExpiryTime]) VALUES (N'E005', N'Ta Vu Thanh Van ', N'861624870410
', N'thanhvan03@gmail.com', N'2', N'0123463674', NULL, N'Trainer', 0, NULL, NULL)
GO
INSERT [dbo].[Employees] ([id], [fullName], [citizenID], [email], [password], [phoneNumber], [image], [role], [isDeleted], [refreshToken], [refreshTokenExpiryTime]) VALUES (N'E006', N'Tran Hoang Mai', N'359448450789', N'maihoang0412@gmail.com', N'3', N'0864567345', NULL, N'Trainer', 0, NULL, NULL)
GO
INSERT [dbo].[Employees] ([id], [fullName], [citizenID], [email], [password], [phoneNumber], [image], [role], [isDeleted], [refreshToken], [refreshTokenExpiryTime]) VALUES (N'E007', N'John Avocado Wick', N'012391234312', N'johnwick123@gmail.com', N'3', N'0988732134', NULL, N'Trainer', 0, NULL, NULL)
GO
INSERT [dbo].[Employees] ([id], [fullName], [citizenID], [email], [password], [phoneNumber], [image], [role], [isDeleted], [refreshToken], [refreshTokenExpiryTime]) VALUES (N'E008', N'Vu Long', N'074203000803', N'vulongbinhduong@gmail.com', N'3', N'0866742614', N'N/A', N'Staff', 0, N'EWxCBNS85pCu5gF1omTZcZBo/wtXkK/BqTaI7xDYOG4=', CAST(N'2023-10-03T20:37:58.627' AS DateTime))
GO
INSERT [dbo].[Employees] ([id], [fullName], [citizenID], [email], [password], [phoneNumber], [image], [role], [isDeleted], [refreshToken], [refreshTokenExpiryTime]) VALUES (N'E009', N'David Copperfield', N'123456789', N'davidcopperfield@gmail.com', N'4', N'0123458761', NULL, N'Staff', 0, NULL, NULL)
GO
INSERT [dbo].[Employees] ([id], [fullName], [citizenID], [email], [password], [phoneNumber], [image], [role], [isDeleted], [refreshToken], [refreshTokenExpiryTime]) VALUES (N'E010', N'Kendrick Lamar', N'092812ab31132', N'kendricklamar12@gmail.com', N'123', N'0001341231', N'N/A', N'Trainer', 0, NULL, NULL)
GO
INSERT [dbo].[Employees] ([id], [fullName], [citizenID], [email], [password], [phoneNumber], [image], [role], [isDeleted], [refreshToken], [refreshTokenExpiryTime]) VALUES (N'E011', N'Doan Van Hau', N'074203803', N'doanvanhau123@gmail.com', N'4', N'08667123321', N'N/A', N'Trainer', 0, NULL, NULL)
GO
INSERT [dbo].[Employees] ([id], [fullName], [citizenID], [email], [password], [phoneNumber], [image], [role], [isDeleted], [refreshToken], [refreshTokenExpiryTime]) VALUES (N'E012', N'abcdaw', N'awdwd12313', N'asdawd@123gmail.com', N'123', N'01231342290', NULL, N'Staff', 0, NULL, NULL)
GO
INSERT [dbo].[Employees] ([id], [fullName], [citizenID], [email], [password], [phoneNumber], [image], [role], [isDeleted], [refreshToken], [refreshTokenExpiryTime]) VALUES (N'E013', N'Cuc ta 1000kg', N'0000000000', N'cucta1000kg@gmail.com', N'123', N'0000000000', N'N/A', N'Trainer', 0, NULL, NULL)
GO
INSERT [dbo].[Employees] ([id], [fullName], [citizenID], [email], [password], [phoneNumber], [image], [role], [isDeleted], [refreshToken], [refreshTokenExpiryTime]) VALUES (N'E014', N'Tran Mai Thanh Truc', N'0000000000', N'tructhanhmt@example.com', N'123', N'0123000123', N'N/A', N'Staff', 0, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Foods] ON 
GO
INSERT [dbo].[Foods] ([id], [name]) VALUES (1, N'Pork')
GO
INSERT [dbo].[Foods] ([id], [name]) VALUES (2, N'Beef')
GO
INSERT [dbo].[Foods] ([id], [name]) VALUES (3, N'Chicken')
GO
INSERT [dbo].[Foods] ([id], [name]) VALUES (4, N'Timothy Hay')
GO
INSERT [dbo].[Foods] ([id], [name]) VALUES (5, N'Orchard Grass')
GO
INSERT [dbo].[Foods] ([id], [name]) VALUES (6, N'Peanut')
GO
INSERT [dbo].[Foods] ([id], [name]) VALUES (7, N'Carrot')
GO
INSERT [dbo].[Foods] ([id], [name]) VALUES (8, N'Corn')
GO
INSERT [dbo].[Foods] ([id], [name]) VALUES (9, N'Bananas')
GO
INSERT [dbo].[Foods] ([id], [name]) VALUES (10, N'Lettuce')
GO
SET IDENTITY_INSERT [dbo].[Foods] OFF
GO
SET IDENTITY_INSERT [dbo].[Tickets] ON 
GO
INSERT [dbo].[Tickets] ([id], [type], [unitPrice]) VALUES (1, N'Child', CAST(40000.0000 AS Decimal(10, 4)))
GO
INSERT [dbo].[Tickets] ([id], [type], [unitPrice]) VALUES (2, N'Adult', CAST(60000.0000 AS Decimal(10, 4)))
GO
SET IDENTITY_INSERT [dbo].[Tickets] OFF
GO
/****** Object:  Index [UQ__Transact__0809337CEC7C97EF]    Script Date: 10/2/2023 8:58:24 PM ******/
ALTER TABLE [dbo].[TransactionHistory] ADD UNIQUE NONCLUSTERED 
(
	[orderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Animals]  WITH CHECK ADD  CONSTRAINT [FKAnimals175197] FOREIGN KEY([empID])
REFERENCES [dbo].[Employees] ([id])
GO
ALTER TABLE [dbo].[Animals] CHECK CONSTRAINT [FKAnimals175197]
GO
ALTER TABLE [dbo].[Animals]  WITH CHECK ADD  CONSTRAINT [FKAnimals343887] FOREIGN KEY([cageID])
REFERENCES [dbo].[Cages] ([id])
GO
ALTER TABLE [dbo].[Animals] CHECK CONSTRAINT [FKAnimals343887]
GO
ALTER TABLE [dbo].[AnimalSpecies]  WITH CHECK ADD  CONSTRAINT [FKAnimalSpec939317] FOREIGN KEY([cageID])
REFERENCES [dbo].[Cages] ([id])
GO
ALTER TABLE [dbo].[AnimalSpecies] CHECK CONSTRAINT [FKAnimalSpec939317]
GO
ALTER TABLE [dbo].[Cages]  WITH CHECK ADD  CONSTRAINT [FKCages158657] FOREIGN KEY([areaID])
REFERENCES [dbo].[Areas] ([id])
GO
ALTER TABLE [dbo].[Cages] CHECK CONSTRAINT [FKCages158657]
GO
ALTER TABLE [dbo].[EmployeeCertificates]  WITH CHECK ADD  CONSTRAINT [FKEmployeeCe279067] FOREIGN KEY([empID])
REFERENCES [dbo].[Employees] ([id])
GO
ALTER TABLE [dbo].[EmployeeCertificates] CHECK CONSTRAINT [FKEmployeeCe279067]
GO
ALTER TABLE [dbo].[EmployeeCertificates]  WITH CHECK ADD  CONSTRAINT [FKEmployeeCe355275] FOREIGN KEY([cerfCode])
REFERENCES [dbo].[Certificates] ([code])
GO
ALTER TABLE [dbo].[EmployeeCertificates] CHECK CONSTRAINT [FKEmployeeCe355275]
GO
ALTER TABLE [dbo].[FeedingSchedules]  WITH CHECK ADD  CONSTRAINT [FKFeedingSch255596] FOREIGN KEY([animalID])
REFERENCES [dbo].[Animals] ([id])
GO
ALTER TABLE [dbo].[FeedingSchedules] CHECK CONSTRAINT [FKFeedingSch255596]
GO
ALTER TABLE [dbo].[FeedingSchedules]  WITH CHECK ADD  CONSTRAINT [FKFeedingSch604322] FOREIGN KEY([employeeID])
REFERENCES [dbo].[Employees] ([id])
GO
ALTER TABLE [dbo].[FeedingSchedules] CHECK CONSTRAINT [FKFeedingSch604322]
GO
ALTER TABLE [dbo].[FeedingSchedules]  WITH CHECK ADD  CONSTRAINT [FKFeedingSch65873] FOREIGN KEY([foodID])
REFERENCES [dbo].[Foods] ([id])
GO
ALTER TABLE [dbo].[FeedingSchedules] CHECK CONSTRAINT [FKFeedingSch65873]
GO
ALTER TABLE [dbo].[ImportHistory]  WITH CHECK ADD  CONSTRAINT [FKImportHist755200] FOREIGN KEY([foodID])
REFERENCES [dbo].[Foods] ([id])
GO
ALTER TABLE [dbo].[ImportHistory] CHECK CONSTRAINT [FKImportHist755200]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FKNews881619] FOREIGN KEY([empID])
REFERENCES [dbo].[Employees] ([id])
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FKNews881619]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FKNews885351] FOREIGN KEY([speciesID])
REFERENCES [dbo].[AnimalSpecies] ([id])
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FKNews885351]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FKNews933514] FOREIGN KEY([animalID])
REFERENCES [dbo].[Animals] ([id])
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FKNews933514]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FKOrderDetai157073] FOREIGN KEY([ticketID])
REFERENCES [dbo].[Tickets] ([id])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FKOrderDetai157073]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FKOrderDetai933386] FOREIGN KEY([orderID])
REFERENCES [dbo].[Orders] ([id])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FKOrderDetai933386]
GO
ALTER TABLE [dbo].[TransactionHistory]  WITH CHECK ADD  CONSTRAINT [FKTransactio989133] FOREIGN KEY([orderID])
REFERENCES [dbo].[Orders] ([id])
GO
ALTER TABLE [dbo].[TransactionHistory] CHECK CONSTRAINT [FKTransactio989133]
GO
USE [master]
GO
ALTER DATABASE [ZooManagement] SET  READ_WRITE 
GO
