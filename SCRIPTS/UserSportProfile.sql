USE [master]
GO
/****** Object:  Database [UserSportsAPPV1]    Script Date: 26/03/2024 20:20:01 ******/
CREATE DATABASE [UserSportsAPPV1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UserSportsAPPV1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\UserSportsAPPV1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UserSportsAPPV1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\UserSportsAPPV1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [UserSportsAPPV1] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UserSportsAPPV1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UserSportsAPPV1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UserSportsAPPV1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UserSportsAPPV1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UserSportsAPPV1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UserSportsAPPV1] SET ARITHABORT OFF 
GO
ALTER DATABASE [UserSportsAPPV1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UserSportsAPPV1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UserSportsAPPV1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UserSportsAPPV1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UserSportsAPPV1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UserSportsAPPV1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UserSportsAPPV1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UserSportsAPPV1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UserSportsAPPV1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UserSportsAPPV1] SET  ENABLE_BROKER 
GO
ALTER DATABASE [UserSportsAPPV1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UserSportsAPPV1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UserSportsAPPV1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UserSportsAPPV1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UserSportsAPPV1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UserSportsAPPV1] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [UserSportsAPPV1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UserSportsAPPV1] SET RECOVERY FULL 
GO
ALTER DATABASE [UserSportsAPPV1] SET  MULTI_USER 
GO
ALTER DATABASE [UserSportsAPPV1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UserSportsAPPV1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UserSportsAPPV1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UserSportsAPPV1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UserSportsAPPV1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [UserSportsAPPV1] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'UserSportsAPPV1', N'ON'
GO
ALTER DATABASE [UserSportsAPPV1] SET QUERY_STORE = OFF
GO
USE [UserSportsAPPV1]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 26/03/2024 20:20:01 ******/
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
/****** Object:  Table [dbo].[Activity]    Script Date: 26/03/2024 20:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Created_At] [datetime2](7) NULL,
	[Created_By] [nvarchar](max) NULL,
	[Update_At] [datetime2](7) NULL,
	[Update_By] [nvarchar](max) NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 26/03/2024 20:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 26/03/2024 20:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 26/03/2024 20:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 26/03/2024 20:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 26/03/2024 20:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 26/03/2024 20:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[GenreId] [int] NULL,
	[CountryId] [int] NULL,
	[StateId] [int] NULL,
	[CityId] [int] NULL,
	[DateOfBirth] [datetime2](7) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 26/03/2024 20:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 26/03/2024 20:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[StateId] [int] NOT NULL,
	[Created_At] [datetime2](7) NULL,
	[Created_By] [nvarchar](max) NULL,
	[Update_At] [datetime2](7) NULL,
	[Update_By] [nvarchar](max) NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 26/03/2024 20:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Created_At] [datetime2](7) NULL,
	[Created_By] [nvarchar](max) NULL,
	[Update_At] [datetime2](7) NULL,
	[Update_By] [nvarchar](max) NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 26/03/2024 20:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Created_At] [datetime2](7) NULL,
	[Created_By] [nvarchar](max) NULL,
	[Update_At] [datetime2](7) NULL,
	[Update_By] [nvarchar](max) NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Goal]    Script Date: 26/03/2024 20:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Goal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Created_At] [datetime2](7) NULL,
	[Created_By] [nvarchar](max) NULL,
	[Update_At] [datetime2](7) NULL,
	[Update_By] [nvarchar](max) NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_Goal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NutricionalAllergy]    Script Date: 26/03/2024 20:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NutricionalAllergy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Created_At] [datetime2](7) NULL,
	[Created_By] [nvarchar](max) NULL,
	[Update_At] [datetime2](7) NULL,
	[Update_By] [nvarchar](max) NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_NutricionalAllergy] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NutrionalProfile]    Script Date: 26/03/2024 20:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NutrionalProfile](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HasAllergies] [bit] NOT NULL,
	[HasMedicalAllergies] [bit] NOT NULL,
	[TypeOfNutritionId] [int] NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[AveragesCaloriesPerDay] [decimal](18, 2) NOT NULL,
	[Created_At] [datetime2](7) NULL,
	[Created_By] [nvarchar](max) NULL,
	[Update_At] [datetime2](7) NULL,
	[Update_By] [nvarchar](max) NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_NutrionalProfile] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhysicalLevel]    Script Date: 26/03/2024 20:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhysicalLevel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Created_At] [datetime2](7) NULL,
	[Created_By] [nvarchar](max) NULL,
	[Update_At] [datetime2](7) NULL,
	[Update_By] [nvarchar](max) NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_PhysicalLevel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SportProfile]    Script Date: 26/03/2024 20:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SportProfile](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExcerciseByWeek] [int] NOT NULL,
	[HasInjuries] [bit] NOT NULL,
	[Weight] [decimal](18, 2) NOT NULL,
	[Heigth] [decimal](18, 2) NOT NULL,
	[TestMe] [nvarchar](max) NOT NULL,
	[WhatInjuries] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[PhysicalLevelId] [int] NOT NULL,
	[Created_At] [datetime2](7) NULL,
	[Created_By] [nvarchar](max) NULL,
	[Update_At] [datetime2](7) NULL,
	[Update_By] [nvarchar](max) NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_SportProfile] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 26/03/2024 20:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CountryId] [int] NOT NULL,
	[Created_At] [datetime2](7) NULL,
	[Created_By] [nvarchar](max) NULL,
	[Update_At] [datetime2](7) NULL,
	[Update_By] [nvarchar](max) NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeOfNutrition]    Script Date: 26/03/2024 20:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeOfNutrition](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Created_At] [datetime2](7) NULL,
	[Created_By] [nvarchar](max) NULL,
	[Update_At] [datetime2](7) NULL,
	[Update_By] [nvarchar](max) NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_TypeOfNutrition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserActivities]    Script Date: 26/03/2024 20:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserActivities](
	[UsersId] [nvarchar](450) NOT NULL,
	[ActivityId] [int] NOT NULL,
	[Id] [int] NOT NULL,
	[Created_At] [datetime2](7) NULL,
	[Created_By] [nvarchar](max) NULL,
	[Update_At] [datetime2](7) NULL,
	[Update_By] [nvarchar](max) NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_UserActivities] PRIMARY KEY CLUSTERED 
(
	[UsersId] ASC,
	[ActivityId] ASC,
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAllergy]    Script Date: 26/03/2024 20:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAllergy](
	[UsersId] [nvarchar](450) NOT NULL,
	[NutricionalAllergyId] [int] NOT NULL,
	[Id] [int] NOT NULL,
	[Created_At] [datetime2](7) NULL,
	[Created_By] [nvarchar](max) NULL,
	[Update_At] [datetime2](7) NULL,
	[Update_By] [nvarchar](max) NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_UserAllergy] PRIMARY KEY CLUSTERED 
(
	[NutricionalAllergyId] ASC,
	[UsersId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserGoal]    Script Date: 26/03/2024 20:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGoal](
	[GoalId] [int] NOT NULL,
	[UsersId] [nvarchar](450) NOT NULL,
	[Id] [int] NOT NULL,
	[Created_At] [datetime2](7) NULL,
	[Created_By] [nvarchar](max) NULL,
	[Update_At] [datetime2](7) NULL,
	[Update_By] [nvarchar](max) NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_UserGoal] PRIMARY KEY CLUSTERED 
(
	[GoalId] ASC,
	[UsersId] ASC,
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240325214017_initial-migration', N'8.0.0')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240325215201_second-migration', N'8.0.0')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240325215233_three-migration', N'8.0.0')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240325215359_four-migration', N'8.0.0')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240325231006_five-migration', N'8.0.0')
GO
SET IDENTITY_INSERT [dbo].[Activity] ON 
GO
INSERT [dbo].[Activity] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (1, N'Basket', CAST(N'2024-03-24T00:00:00.0000000' AS DateTime2), N'System', NULL, NULL, 1)
GO
INSERT [dbo].[Activity] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (2, N'Futbol
', CAST(N'2024-03-24T00:00:00.0000000' AS DateTime2), N'System', NULL, NULL, 1)
GO
INSERT [dbo].[Activity] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (3, N'Ciclismo', CAST(N'2024-03-24T00:00:00.0000000' AS DateTime2), N'System', NULL, NULL, 1)
GO
INSERT [dbo].[Activity] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (4, N'Correr', CAST(N'2024-03-24T00:00:00.0000000' AS DateTime2), N'System', NULL, NULL, 1)
GO
INSERT [dbo].[Activity] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (5, N'Zumba', CAST(N'2024-03-24T00:00:00.0000000' AS DateTime2), N'System', NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Activity] OFF
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'0037fc1b-5414-449c-8f68-ff9d7365f1a0', N'Asociado', N'ASOCIADO', NULL)
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'7707e9fa-14cb-4067-a2b0-73437dd87e36', N'Usuario', N'USUARIO', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5e04afa0-357b-4ac5-a5bc-7ba38da316b7', N'7707e9fa-14cb-4067-a2b0-73437dd87e36')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9aaf3e4a-5929-44cc-9fe5-49143a86e4be', N'7707e9fa-14cb-4067-a2b0-73437dd87e36')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Name], [LastName], [GenreId], [CountryId], [StateId], [CityId], [DateOfBirth], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'5e04afa0-357b-4ac5-a5bc-7ba38da316b7', N'Yonathan', N'Beltran Romero', 1, 1, 1, 2, CAST(N'1983-10-08T17:25:51.0510000' AS DateTime2), N'nathanbelt23@hotmail.com', N'NATHANBELT23@HOTMAIL.COM', N'nathanbelt23@hotmail.com', N'NATHANBELT23@HOTMAIL.COM', 1, N'AQAAAAIAAYagAAAAEK8dIAZYvmrJhhHHzO/PE6l0g4Z/cOyN7LDENu9cjjGrpzCdTRJ1nOS/ItQtkBK1/g==', N'6MMKEVUXEL444XIYON2SLFZKYCQFMMVH', N'e74b67f6-4b22-478b-89e8-4bfb63d3a8d2', N'3102711918', 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [Name], [LastName], [GenreId], [CountryId], [StateId], [CityId], [DateOfBirth], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'9aaf3e4a-5929-44cc-9fe5-49143a86e4be', N'Yonathan', N'Beltran Romero', 1, 1, 1, 2, CAST(N'1983-10-08T17:25:51.0510000' AS DateTime2), N'natanbelt23@gmail.com', N'natanbelt23@gmail.com', N'natanbelt23@gmail.com', N'NATANBELT23@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEMOpvLvPmukGrgQGhL6x25SliRBM6eJd7AioWbrx4268nYOdr7O+WNg7Y7ZFZSaiYw==', N'DQ67I443WAODUMWE67SDY7TA5FDWYUZH', N'e4097415-2466-4d9c-8cd8-ff0f687989dd', N'3102711918', 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[City] ON 
GO
INSERT [dbo].[City] ([Id], [Name], [StateId], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (2, N'Medellin', 1, CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), N'System', NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[City] OFF
GO
SET IDENTITY_INSERT [dbo].[Country] ON 
GO
INSERT [dbo].[Country] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (1, N'Colombia', CAST(N'2023-01-20T00:00:00.0000000' AS DateTime2), N'System', NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Country] OFF
GO
SET IDENTITY_INSERT [dbo].[Genre] ON 
GO
INSERT [dbo].[Genre] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (1, N'Masculino', CAST(N'2023-03-02T00:00:00.0000000' AS DateTime2), N'System', NULL, NULL, 1)
GO
INSERT [dbo].[Genre] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (2, N'Femenino', CAST(N'2023-03-02T00:00:00.0000000' AS DateTime2), N'System', NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Genre] OFF
GO
SET IDENTITY_INSERT [dbo].[Goal] ON 
GO
INSERT [dbo].[Goal] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (1, N'Mejorar resistencia
', CAST(N'2024-03-24T00:00:00.0000000' AS DateTime2), N'System', NULL, NULL, 1)
GO
INSERT [dbo].[Goal] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (2, N'Ganar peso', CAST(N'2024-03-24T00:00:00.0000000' AS DateTime2), N'System', NULL, NULL, 1)
GO
INSERT [dbo].[Goal] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (3, N'Construir musculo', CAST(N'2024-03-24T00:00:00.0000000' AS DateTime2), N'System', NULL, NULL, 1)
GO
INSERT [dbo].[Goal] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (4, N'Aumentar Frexibilidad', CAST(N'2024-03-24T00:00:00.0000000' AS DateTime2), N'System', NULL, NULL, 1)
GO
INSERT [dbo].[Goal] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (5, N'Perder peso', CAST(N'2024-03-24T00:00:00.0000000' AS DateTime2), N'System', NULL, NULL, 1)
GO
INSERT [dbo].[Goal] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (6, N'Aumentar Fuerza', CAST(N'2024-03-24T00:00:00.0000000' AS DateTime2), N'System', NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Goal] OFF
GO
SET IDENTITY_INSERT [dbo].[NutricionalAllergy] ON 
GO
INSERT [dbo].[NutricionalAllergy] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (1, N'Lateos', CAST(N'2024-03-24T00:00:00.0000000' AS DateTime2), N'System', NULL, NULL, 1)
GO
INSERT [dbo].[NutricionalAllergy] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (2, N'Frutos secos', CAST(N'2024-03-24T00:00:00.0000000' AS DateTime2), N'System', NULL, NULL, 1)
GO
INSERT [dbo].[NutricionalAllergy] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (3, N'Gluten', CAST(N'2024-03-24T00:00:00.0000000' AS DateTime2), N'System', NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[NutricionalAllergy] OFF
GO
SET IDENTITY_INSERT [dbo].[NutrionalProfile] ON 
GO
INSERT [dbo].[NutrionalProfile] ([Id], [HasAllergies], [HasMedicalAllergies], [TypeOfNutritionId], [UserId], [AveragesCaloriesPerDay], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (20, 0, 0, 1, N'9aaf3e4a-5929-44cc-9fe5-49143a86e4be', CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-03-25T23:26:18.7157734' AS DateTime2), N'9aaf3e4a-5929-44cc-9fe5-49143a86e4be', CAST(N'2024-03-26T03:42:03.1063266' AS DateTime2), N'9aaf3e4a-5929-44cc-9fe5-49143a86e4be', 1)
GO
INSERT [dbo].[NutrionalProfile] ([Id], [HasAllergies], [HasMedicalAllergies], [TypeOfNutritionId], [UserId], [AveragesCaloriesPerDay], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (1020, 0, 0, 1027, N'5e04afa0-357b-4ac5-a5bc-7ba38da316b7', CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-03-27T01:02:51.6014203' AS DateTime2), N'5e04afa0-357b-4ac5-a5bc-7ba38da316b7', NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[NutrionalProfile] OFF
GO
SET IDENTITY_INSERT [dbo].[PhysicalLevel] ON 
GO
INSERT [dbo].[PhysicalLevel] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (1, N'Basico', CAST(N'2024-03-24T00:00:00.0000000' AS DateTime2), N'System', NULL, NULL, 1)
GO
INSERT [dbo].[PhysicalLevel] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (2, N'Medio', CAST(N'2024-03-24T00:00:00.0000000' AS DateTime2), N'System', NULL, NULL, 1)
GO
INSERT [dbo].[PhysicalLevel] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (3, N'Avanzado', CAST(N'2024-03-24T00:00:00.0000000' AS DateTime2), N'System', NULL, NULL, 1)
GO
INSERT [dbo].[PhysicalLevel] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (8, N'', CAST(N'2024-03-25T22:25:22.3344205' AS DateTime2), N'system', NULL, NULL, 1)
GO
INSERT [dbo].[PhysicalLevel] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (9, N'', CAST(N'2024-03-25T22:32:01.8914201' AS DateTime2), N'system', NULL, NULL, 1)
GO
INSERT [dbo].[PhysicalLevel] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (10, N'', CAST(N'2024-03-25T22:36:14.7820608' AS DateTime2), N'system', NULL, NULL, 1)
GO
INSERT [dbo].[PhysicalLevel] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (11, N'', CAST(N'2024-03-25T22:37:58.6544917' AS DateTime2), N'system', NULL, NULL, 1)
GO
INSERT [dbo].[PhysicalLevel] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (12, N'', CAST(N'2024-03-25T22:38:58.2719103' AS DateTime2), N'system', NULL, NULL, 1)
GO
INSERT [dbo].[PhysicalLevel] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (13, N'', CAST(N'2024-03-25T22:41:57.7024200' AS DateTime2), N'system', NULL, NULL, 1)
GO
INSERT [dbo].[PhysicalLevel] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (14, N'', CAST(N'2024-03-25T22:46:02.1880269' AS DateTime2), N'system', NULL, NULL, 1)
GO
INSERT [dbo].[PhysicalLevel] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (15, N'', CAST(N'2024-03-25T22:47:29.3532082' AS DateTime2), N'system', NULL, NULL, 1)
GO
INSERT [dbo].[PhysicalLevel] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (16, N'', CAST(N'2024-03-25T22:59:05.5150236' AS DateTime2), N'system', NULL, NULL, 1)
GO
INSERT [dbo].[PhysicalLevel] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (17, N'', CAST(N'2024-03-27T01:02:51.8057493' AS DateTime2), NULL, NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[PhysicalLevel] OFF
GO
SET IDENTITY_INSERT [dbo].[SportProfile] ON 
GO
INSERT [dbo].[SportProfile] ([Id], [ExcerciseByWeek], [HasInjuries], [Weight], [Heigth], [TestMe], [WhatInjuries], [UserId], [PhysicalLevelId], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (13, 10, 1, CAST(180.00 AS Decimal(18, 2)), CAST(85.00 AS Decimal(18, 2)), N'x', N'None', N'9aaf3e4a-5929-44cc-9fe5-49143a86e4be', 1, CAST(N'2024-03-25T22:59:05.5150221' AS DateTime2), N'system', CAST(N'2024-03-26T03:42:03.2485254' AS DateTime2), N'9aaf3e4a-5929-44cc-9fe5-49143a86e4be', 1)
GO
INSERT [dbo].[SportProfile] ([Id], [ExcerciseByWeek], [HasInjuries], [Weight], [Heigth], [TestMe], [WhatInjuries], [UserId], [PhysicalLevelId], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (14, 10, 1, CAST(180.00 AS Decimal(18, 2)), CAST(85.00 AS Decimal(18, 2)), N'x', N'None', N'5e04afa0-357b-4ac5-a5bc-7ba38da316b7', 17, CAST(N'2024-03-27T01:02:51.8057506' AS DateTime2), N'5e04afa0-357b-4ac5-a5bc-7ba38da316b7', NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[SportProfile] OFF
GO
SET IDENTITY_INSERT [dbo].[State] ON 
GO
INSERT [dbo].[State] ([Id], [Name], [CountryId], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (1, N'Antioquia', 1, CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), N'System', NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[State] OFF
GO
SET IDENTITY_INSERT [dbo].[TypeOfNutrition] ON 
GO
INSERT [dbo].[TypeOfNutrition] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (1, N'Ornivoro', CAST(N'2024-03-23T00:00:00.0000000' AS DateTime2), N'System', NULL, NULL, 1)
GO
INSERT [dbo].[TypeOfNutrition] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (2, N'Frutivoro', CAST(N'2024-03-23T00:00:00.0000000' AS DateTime2), N'System', NULL, NULL, 1)
GO
INSERT [dbo].[TypeOfNutrition] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (3, N'Vegano', CAST(N'2024-03-23T00:00:00.0000000' AS DateTime2), N'System', NULL, NULL, 1)
GO
INSERT [dbo].[TypeOfNutrition] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (4, N'Carnivoro', CAST(N'2024-03-23T00:00:00.0000000' AS DateTime2), N'System', NULL, NULL, 1)
GO
INSERT [dbo].[TypeOfNutrition] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (5, N'Vegtariano', CAST(N'2024-03-23T00:00:00.0000000' AS DateTime2), N'System', NULL, NULL, 1)
GO
INSERT [dbo].[TypeOfNutrition] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (8, N'', CAST(N'2024-03-25T21:54:48.0325833' AS DateTime2), N'system', NULL, NULL, 1)
GO
INSERT [dbo].[TypeOfNutrition] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (9, N'', CAST(N'2024-03-25T21:56:49.2883139' AS DateTime2), N'system', NULL, NULL, 1)
GO
INSERT [dbo].[TypeOfNutrition] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (10, N'', CAST(N'2024-03-25T21:58:13.3584459' AS DateTime2), N'system', NULL, NULL, 1)
GO
INSERT [dbo].[TypeOfNutrition] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (11, N'', CAST(N'2024-03-25T22:05:50.5196284' AS DateTime2), N'system', NULL, NULL, 1)
GO
INSERT [dbo].[TypeOfNutrition] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (12, N'', CAST(N'2024-03-25T22:24:21.8427873' AS DateTime2), N'system', NULL, NULL, 1)
GO
INSERT [dbo].[TypeOfNutrition] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (13, N'', CAST(N'2024-03-25T22:27:25.0879774' AS DateTime2), N'system', NULL, NULL, 1)
GO
INSERT [dbo].[TypeOfNutrition] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (14, N'', CAST(N'2024-03-25T22:31:53.3940692' AS DateTime2), N'system', NULL, NULL, 1)
GO
INSERT [dbo].[TypeOfNutrition] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (15, N'', CAST(N'2024-03-25T22:32:37.8726442' AS DateTime2), N'system', NULL, NULL, 1)
GO
INSERT [dbo].[TypeOfNutrition] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (16, N'', CAST(N'2024-03-25T22:34:46.5470093' AS DateTime2), N'system', NULL, NULL, 1)
GO
INSERT [dbo].[TypeOfNutrition] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (17, N'', CAST(N'2024-03-25T22:36:14.7041521' AS DateTime2), N'system', NULL, NULL, 1)
GO
INSERT [dbo].[TypeOfNutrition] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (18, N'', CAST(N'2024-03-25T22:37:55.8661851' AS DateTime2), N'system', NULL, NULL, 1)
GO
INSERT [dbo].[TypeOfNutrition] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (19, N'', CAST(N'2024-03-25T22:38:58.2016994' AS DateTime2), N'system', NULL, NULL, 1)
GO
INSERT [dbo].[TypeOfNutrition] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (20, N'', CAST(N'2024-03-25T22:39:45.5380366' AS DateTime2), N'system', NULL, NULL, 1)
GO
INSERT [dbo].[TypeOfNutrition] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (21, N'', CAST(N'2024-03-25T22:41:26.0967723' AS DateTime2), N'system', NULL, NULL, 1)
GO
INSERT [dbo].[TypeOfNutrition] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (22, N'', CAST(N'2024-03-25T22:44:08.8836244' AS DateTime2), N'system', NULL, NULL, 1)
GO
INSERT [dbo].[TypeOfNutrition] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (23, N'', CAST(N'2024-03-25T22:44:52.6813659' AS DateTime2), N'system', NULL, NULL, 1)
GO
INSERT [dbo].[TypeOfNutrition] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (24, N'', CAST(N'2024-03-25T22:47:26.3932064' AS DateTime2), N'system', NULL, NULL, 1)
GO
INSERT [dbo].[TypeOfNutrition] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (25, N'', CAST(N'2024-03-25T22:48:19.7546533' AS DateTime2), N'system', NULL, NULL, 1)
GO
INSERT [dbo].[TypeOfNutrition] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (26, N'', CAST(N'2024-03-25T22:51:01.2518779' AS DateTime2), N'system', NULL, NULL, 1)
GO
INSERT [dbo].[TypeOfNutrition] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (27, N'', CAST(N'2024-03-25T23:26:18.7158516' AS DateTime2), NULL, NULL, NULL, 1)
GO
INSERT [dbo].[TypeOfNutrition] ([Id], [Name], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (1027, N'', CAST(N'2024-03-27T01:02:51.6014947' AS DateTime2), NULL, NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[TypeOfNutrition] OFF
GO
INSERT [dbo].[UserActivities] ([UsersId], [ActivityId], [Id], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (N'5e04afa0-357b-4ac5-a5bc-7ba38da316b7', 1, 0, CAST(N'2024-03-27T01:02:51.6856508' AS DateTime2), N'5e04afa0-357b-4ac5-a5bc-7ba38da316b7', NULL, NULL, 1)
GO
INSERT [dbo].[UserActivities] ([UsersId], [ActivityId], [Id], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (N'5e04afa0-357b-4ac5-a5bc-7ba38da316b7', 2, 0, CAST(N'2024-03-27T01:02:51.6946655' AS DateTime2), N'5e04afa0-357b-4ac5-a5bc-7ba38da316b7', NULL, NULL, 1)
GO
INSERT [dbo].[UserActivities] ([UsersId], [ActivityId], [Id], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (N'5e04afa0-357b-4ac5-a5bc-7ba38da316b7', 3, 0, CAST(N'2024-03-27T01:02:51.6910563' AS DateTime2), N'5e04afa0-357b-4ac5-a5bc-7ba38da316b7', NULL, NULL, 1)
GO
INSERT [dbo].[UserActivities] ([UsersId], [ActivityId], [Id], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (N'9aaf3e4a-5929-44cc-9fe5-49143a86e4be', 1, 0, CAST(N'2024-03-26T03:42:03.2078219' AS DateTime2), N'9aaf3e4a-5929-44cc-9fe5-49143a86e4be', NULL, NULL, 1)
GO
INSERT [dbo].[UserActivities] ([UsersId], [ActivityId], [Id], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (N'9aaf3e4a-5929-44cc-9fe5-49143a86e4be', 2, 0, CAST(N'2024-03-26T03:42:03.2166699' AS DateTime2), N'9aaf3e4a-5929-44cc-9fe5-49143a86e4be', NULL, NULL, 1)
GO
INSERT [dbo].[UserActivities] ([UsersId], [ActivityId], [Id], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (N'9aaf3e4a-5929-44cc-9fe5-49143a86e4be', 3, 0, CAST(N'2024-03-26T03:42:03.2127341' AS DateTime2), N'9aaf3e4a-5929-44cc-9fe5-49143a86e4be', NULL, NULL, 1)
GO
INSERT [dbo].[UserAllergy] ([UsersId], [NutricionalAllergyId], [Id], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (N'5e04afa0-357b-4ac5-a5bc-7ba38da316b7', 2, 0, CAST(N'2024-03-27T01:02:51.6557700' AS DateTime2), N'5e04afa0-357b-4ac5-a5bc-7ba38da316b7', NULL, NULL, 1)
GO
INSERT [dbo].[UserAllergy] ([UsersId], [NutricionalAllergyId], [Id], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (N'9aaf3e4a-5929-44cc-9fe5-49143a86e4be', 2, 0, CAST(N'2024-03-26T03:42:03.1823994' AS DateTime2), N'9aaf3e4a-5929-44cc-9fe5-49143a86e4be', NULL, NULL, 1)
GO
INSERT [dbo].[UserAllergy] ([UsersId], [NutricionalAllergyId], [Id], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (N'5e04afa0-357b-4ac5-a5bc-7ba38da316b7', 3, 0, CAST(N'2024-03-27T01:02:51.6613813' AS DateTime2), N'5e04afa0-357b-4ac5-a5bc-7ba38da316b7', NULL, NULL, 1)
GO
INSERT [dbo].[UserAllergy] ([UsersId], [NutricionalAllergyId], [Id], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (N'9aaf3e4a-5929-44cc-9fe5-49143a86e4be', 3, 0, CAST(N'2024-03-26T03:42:03.1882644' AS DateTime2), N'9aaf3e4a-5929-44cc-9fe5-49143a86e4be', NULL, NULL, 1)
GO
INSERT [dbo].[UserGoal] ([GoalId], [UsersId], [Id], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (1, N'5e04afa0-357b-4ac5-a5bc-7ba38da316b7', 0, CAST(N'2024-03-27T01:02:51.7167114' AS DateTime2), N'5e04afa0-357b-4ac5-a5bc-7ba38da316b7', NULL, NULL, 1)
GO
INSERT [dbo].[UserGoal] ([GoalId], [UsersId], [Id], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (1, N'9aaf3e4a-5929-44cc-9fe5-49143a86e4be', 0, CAST(N'2024-03-26T03:42:03.2339913' AS DateTime2), N'9aaf3e4a-5929-44cc-9fe5-49143a86e4be', NULL, NULL, 1)
GO
INSERT [dbo].[UserGoal] ([GoalId], [UsersId], [Id], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (2, N'5e04afa0-357b-4ac5-a5bc-7ba38da316b7', 0, CAST(N'2024-03-27T01:02:51.7217474' AS DateTime2), N'5e04afa0-357b-4ac5-a5bc-7ba38da316b7', NULL, NULL, 1)
GO
INSERT [dbo].[UserGoal] ([GoalId], [UsersId], [Id], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (2, N'9aaf3e4a-5929-44cc-9fe5-49143a86e4be', 0, CAST(N'2024-03-26T03:42:03.2380574' AS DateTime2), N'9aaf3e4a-5929-44cc-9fe5-49143a86e4be', NULL, NULL, 1)
GO
INSERT [dbo].[UserGoal] ([GoalId], [UsersId], [Id], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (3, N'5e04afa0-357b-4ac5-a5bc-7ba38da316b7', 0, CAST(N'2024-03-27T01:02:51.7254190' AS DateTime2), N'5e04afa0-357b-4ac5-a5bc-7ba38da316b7', NULL, NULL, 1)
GO
INSERT [dbo].[UserGoal] ([GoalId], [UsersId], [Id], [Created_At], [Created_By], [Update_At], [Update_By], [Enabled]) VALUES (3, N'9aaf3e4a-5929-44cc-9fe5-49143a86e4be', 0, CAST(N'2024-03-26T03:42:03.2411027' AS DateTime2), N'9aaf3e4a-5929-44cc-9fe5-49143a86e4be', NULL, NULL, 1)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 26/03/2024 20:20:01 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 26/03/2024 20:20:01 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 26/03/2024 20:20:01 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 26/03/2024 20:20:01 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 26/03/2024 20:20:01 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 26/03/2024 20:20:01 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUsers_CityId]    Script Date: 26/03/2024 20:20:01 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_CityId] ON [dbo].[AspNetUsers]
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUsers_CountryId]    Script Date: 26/03/2024 20:20:01 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_CountryId] ON [dbo].[AspNetUsers]
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUsers_GenreId]    Script Date: 26/03/2024 20:20:01 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_GenreId] ON [dbo].[AspNetUsers]
(
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUsers_StateId]    Script Date: 26/03/2024 20:20:01 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_StateId] ON [dbo].[AspNetUsers]
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 26/03/2024 20:20:01 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_City_StateId]    Script Date: 26/03/2024 20:20:01 ******/
CREATE NONCLUSTERED INDEX [IX_City_StateId] ON [dbo].[City]
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_NutrionalProfile_TypeOfNutritionId]    Script Date: 26/03/2024 20:20:01 ******/
CREATE NONCLUSTERED INDEX [IX_NutrionalProfile_TypeOfNutritionId] ON [dbo].[NutrionalProfile]
(
	[TypeOfNutritionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_NutrionalProfile_UserId]    Script Date: 26/03/2024 20:20:01 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_NutrionalProfile_UserId] ON [dbo].[NutrionalProfile]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SportProfile_PhysicalLevelId]    Script Date: 26/03/2024 20:20:01 ******/
CREATE NONCLUSTERED INDEX [IX_SportProfile_PhysicalLevelId] ON [dbo].[SportProfile]
(
	[PhysicalLevelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_SportProfile_UserId]    Script Date: 26/03/2024 20:20:01 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_SportProfile_UserId] ON [dbo].[SportProfile]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_State_CountryId]    Script Date: 26/03/2024 20:20:01 ******/
CREATE NONCLUSTERED INDEX [IX_State_CountryId] ON [dbo].[State]
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserActivities_ActivityId]    Script Date: 26/03/2024 20:20:01 ******/
CREATE NONCLUSTERED INDEX [IX_UserActivities_ActivityId] ON [dbo].[UserActivities]
(
	[ActivityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserAllergy_UsersId]    Script Date: 26/03/2024 20:20:01 ******/
CREATE NONCLUSTERED INDEX [IX_UserAllergy_UsersId] ON [dbo].[UserAllergy]
(
	[UsersId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserGoal_UsersId]    Script Date: 26/03/2024 20:20:01 ******/
CREATE NONCLUSTERED INDEX [IX_UserGoal_UsersId] ON [dbo].[UserGoal]
(
	[UsersId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_City_CityId] FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([Id])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_City_CityId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_Country_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_Country_CountryId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_Genre_GenreId] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genre] ([Id])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_Genre_GenreId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_State_StateId] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([Id])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_State_StateId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[City]  WITH CHECK ADD  CONSTRAINT [FK_City_State_StateId] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[City] CHECK CONSTRAINT [FK_City_State_StateId]
GO
ALTER TABLE [dbo].[NutrionalProfile]  WITH CHECK ADD  CONSTRAINT [FK_NutrionalProfile_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[NutrionalProfile] CHECK CONSTRAINT [FK_NutrionalProfile_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[NutrionalProfile]  WITH CHECK ADD  CONSTRAINT [FK_NutrionalProfile_TypeOfNutrition_TypeOfNutritionId] FOREIGN KEY([TypeOfNutritionId])
REFERENCES [dbo].[TypeOfNutrition] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NutrionalProfile] CHECK CONSTRAINT [FK_NutrionalProfile_TypeOfNutrition_TypeOfNutritionId]
GO
ALTER TABLE [dbo].[SportProfile]  WITH CHECK ADD  CONSTRAINT [FK_SportProfile_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[SportProfile] CHECK CONSTRAINT [FK_SportProfile_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[SportProfile]  WITH CHECK ADD  CONSTRAINT [FK_SportProfile_PhysicalLevel_PhysicalLevelId] FOREIGN KEY([PhysicalLevelId])
REFERENCES [dbo].[PhysicalLevel] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SportProfile] CHECK CONSTRAINT [FK_SportProfile_PhysicalLevel_PhysicalLevelId]
GO
ALTER TABLE [dbo].[State]  WITH CHECK ADD  CONSTRAINT [FK_State_Country_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[State] CHECK CONSTRAINT [FK_State_Country_CountryId]
GO
ALTER TABLE [dbo].[UserActivities]  WITH CHECK ADD  CONSTRAINT [FK_UserActivities_Activity_ActivityId] FOREIGN KEY([ActivityId])
REFERENCES [dbo].[Activity] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserActivities] CHECK CONSTRAINT [FK_UserActivities_Activity_ActivityId]
GO
ALTER TABLE [dbo].[UserActivities]  WITH CHECK ADD  CONSTRAINT [FK_UserActivities_AspNetUsers_UsersId] FOREIGN KEY([UsersId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserActivities] CHECK CONSTRAINT [FK_UserActivities_AspNetUsers_UsersId]
GO
ALTER TABLE [dbo].[UserAllergy]  WITH CHECK ADD  CONSTRAINT [FK_UserAllergy_AspNetUsers_UsersId] FOREIGN KEY([UsersId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserAllergy] CHECK CONSTRAINT [FK_UserAllergy_AspNetUsers_UsersId]
GO
ALTER TABLE [dbo].[UserAllergy]  WITH CHECK ADD  CONSTRAINT [FK_UserAllergy_NutricionalAllergy_NutricionalAllergyId] FOREIGN KEY([NutricionalAllergyId])
REFERENCES [dbo].[NutricionalAllergy] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserAllergy] CHECK CONSTRAINT [FK_UserAllergy_NutricionalAllergy_NutricionalAllergyId]
GO
ALTER TABLE [dbo].[UserGoal]  WITH CHECK ADD  CONSTRAINT [FK_UserGoal_AspNetUsers_UsersId] FOREIGN KEY([UsersId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserGoal] CHECK CONSTRAINT [FK_UserGoal_AspNetUsers_UsersId]
GO
ALTER TABLE [dbo].[UserGoal]  WITH CHECK ADD  CONSTRAINT [FK_UserGoal_Goal_GoalId] FOREIGN KEY([GoalId])
REFERENCES [dbo].[Goal] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserGoal] CHECK CONSTRAINT [FK_UserGoal_Goal_GoalId]
GO
USE [master]
GO
ALTER DATABASE [UserSportsAPPV1] SET  READ_WRITE 
GO
