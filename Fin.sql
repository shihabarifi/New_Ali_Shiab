USE [master]
GO
/****** Object:  Database [Fin]    Script Date: 5/13/2023 4:30:23 AM ******/
CREATE DATABASE [Fin]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Fin', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER2\MSSQL\DATA\Fin.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Fin_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER2\MSSQL\DATA\Fin_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Fin] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Fin].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Fin] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Fin] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Fin] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Fin] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Fin] SET ARITHABORT OFF 
GO
ALTER DATABASE [Fin] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Fin] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Fin] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Fin] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Fin] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Fin] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Fin] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Fin] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Fin] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Fin] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Fin] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Fin] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Fin] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Fin] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Fin] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Fin] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Fin] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Fin] SET RECOVERY FULL 
GO
ALTER DATABASE [Fin] SET  MULTI_USER 
GO
ALTER DATABASE [Fin] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Fin] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Fin] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Fin] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Fin] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Fin', N'ON'
GO
ALTER DATABASE [Fin] SET QUERY_STORE = OFF
GO
USE [Fin]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 5/13/2023 4:30:23 AM ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 5/13/2023 4:30:23 AM ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 5/13/2023 4:30:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ImageUser] [nvarchar](max) NOT NULL,
	[ActiveUser] [bit] NOT NULL,
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
/****** Object:  View [dbo].[VwUsers]    Script Date: 5/13/2023 4:30:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VwUsers]
AS
SELECT        dbo.AspNetUsers.Id, dbo.AspNetUsers.Name, dbo.AspNetUsers.ImageUser, dbo.AspNetUsers.ActiveUser, dbo.AspNetRoles.Name AS Role, dbo.AspNetUsers.Email
FROM            dbo.AspNetUsers INNER JOIN
                         dbo.AspNetUserRoles ON dbo.AspNetUsers.Id = dbo.AspNetUserRoles.UserId INNER JOIN
                         dbo.AspNetRoles ON dbo.AspNetUserRoles.RoleId = dbo.AspNetRoles.Id
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/13/2023 4:30:23 AM ******/
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
/****** Object:  Table [dbo].[Accounting_Manual]    Script Date: 5/13/2023 4:30:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounting_Manual](
	[AccNumber] [nvarchar](50) NOT NULL,
	[ParentAccNumber] [nvarchar](50) NOT NULL,
	[AccStatus] [nvarchar](50) NOT NULL,
	[AccLevel] [nvarchar](10) NOT NULL,
	[ArabicAccName] [nvarchar](50) NOT NULL,
	[EnglishAccName] [nvarchar](50) NULL,
	[AccType] [nvarchar](50) NULL,
	[AccMaxBalane] [float] NULL,
	[AccKind] [nvarchar](50) NULL,
	[fiscal_Year] [int] NOT NULL,
	[final_Account_Type] [int] NOT NULL,
	[system_Users] [nvarchar](450) NULL,
 CONSTRAINT [PK_Accounting_Manual] PRIMARY KEY CLUSTERED 
(
	[AccNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts_Currencies]    Script Date: 5/13/2023 4:30:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts_Currencies](
	[Accounts_Currencies_Id] [int] IDENTITY(1,1) NOT NULL,
	[accounting_manual] [nvarchar](50) NOT NULL,
	[currencies] [int] NOT NULL,
	[opening_Balance] [float] NULL,
	[Date] [datetime] NULL,
	[Description] [nvarchar](500) NULL,
	[system_User] [nvarchar](450) NULL,
 CONSTRAINT [PK_Accounts_Currencies] PRIMARY KEY CLUSTERED 
(
	[Accounts_Currencies_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Activity_Type]    Script Date: 5/13/2023 4:30:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activity_Type](
	[Activit_Type_Id] [int] NOT NULL,
	[ActivityName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Activity_Type] PRIMARY KEY CLUSTERED 
(
	[Activit_Type_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 5/13/2023 4:30:23 AM ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 5/13/2023 4:30:23 AM ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 5/13/2023 4:30:23 AM ******/
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
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 5/13/2023 4:30:23 AM ******/
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
/****** Object:  Table [dbo].[BackUpsDB]    Script Date: 5/13/2023 4:30:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BackUpsDB](
	[Backup_Id] [int] IDENTITY(1,1) NOT NULL,
	[system_users] [nvarchar](max) NULL,
	[Filename] [nvarchar](max) NULL,
	[StampDate] [datetime] NULL,
 CONSTRAINT [PK_BackUpsDB] PRIMARY KEY CLUSTERED 
(
	[Backup_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Banks]    Script Date: 5/13/2023 4:30:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banks](
	[Bank_Id] [int] NOT NULL,
	[BankName] [nvarchar](50) NOT NULL,
	[BankStatus] [int] NULL,
	[sub_accounting_manual] [nvarchar](50) NOT NULL,
	[system_Users] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Banks] PRIMARY KEY CLUSTERED 
(
	[Bank_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Check_Expens_Voucher]    Script Date: 5/13/2023 4:30:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Check_Expens_Voucher](
	[Check_ExpensVoucherNumber] [nvarchar](50) NOT NULL,
	[CheckNumber] [nvarchar](50) NULL,
	[banks] [int] NOT NULL,
	[fiscal_Year] [int] NOT NULL,
	[Check_Expend_cheques] [int] NULL,
	[CheckStatus] [int] NULL,
	[ReferenceNumber] [int] NULL,
	[ChequesType] [nvarchar](50) NULL,
	[ChequesDate] [datetime] NULL,
	[CheckDescription] [nvarchar](50) NULL,
	[CheckDatetime] [datetime] NULL,
	[currencies] [int] NOT NULL,
	[DebitChildAccount] [nvarchar](50) NULL,
	[CreditAmount_RLY] [float] NOT NULL,
	[DebittAmount_RLY] [float] NOT NULL,
	[CreditAmount_UDO] [float] NULL,
	[DebittAmount_UDO] [float] NULL,
	[currencies_exchange_rate] [int] NOT NULL,
	[system_Users] [nvarchar](450) NOT NULL,
	[IsDelete] [int] NULL,
 CONSTRAINT [PK_Check_Expens_Voucher] PRIMARY KEY CLUSTERED 
(
	[Check_ExpensVoucherNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Check_Paycheck_Voucher]    Script Date: 5/13/2023 4:30:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Check_Paycheck_Voucher](
	[Check_PaycheckVoucherNumber] [nvarchar](50) NOT NULL,
	[CheckNumber] [nvarchar](50) NULL,
	[banks] [int] NOT NULL,
	[fiscal_Year] [int] NOT NULL,
	[Check_PayCheck_cheques] [int] NULL,
	[CheckStatus] [int] NOT NULL,
	[ReferenceNumber] [int] NULL,
	[ChequesType] [nvarchar](50) NULL,
	[ChequesDate] [datetime] NULL,
	[CheckDescription] [nvarchar](50) NULL,
	[CheckDatetime] [datetime] NULL,
	[currencies] [int] NOT NULL,
	[CreditChildAccount] [nvarchar](50) NULL,
	[CreditAmount_RLY] [float] NOT NULL,
	[DebittAmount_RLY] [float] NOT NULL,
	[CreditAmount_UDO] [float] NULL,
	[DebittAmount_UDO] [float] NULL,
	[currencies_exchange_rate] [int] NOT NULL,
	[system_Users] [nvarchar](450) NOT NULL,
	[IsDelete] [int] NULL,
 CONSTRAINT [PK_Check_Paycheck_Voucher] PRIMARY KEY CLUSTERED 
(
	[Check_PaycheckVoucherNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company_Profile]    Script Date: 5/13/2023 4:30:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company_Profile](
	[Company_Profile_Id] [int] NOT NULL,
	[CompanyName] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[CompanyIcon] [nvarchar](50) NULL,
	[UserEmail] [nvarchar](50) NULL,
	[system_Users] [nvarchar](450) NULL,
 CONSTRAINT [PK_Company_Profile] PRIMARY KEY CLUSTERED 
(
	[Company_Profile_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Currencies]    Script Date: 5/13/2023 4:30:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currencies](
	[Currencies_Id] [int] IDENTITY(1,1) NOT NULL,
	[CurrenName] [nvarchar](50) NULL,
	[CurreType] [nvarchar](50) NULL,
	[CurreSymbol] [nvarchar](50) NULL,
	[CrreChangeName] [nvarchar](50) NULL,
	[system_Users] [nvarchar](450) NULL,
	[CurrStatus] [int] NULL,
 CONSTRAINT [PK_Currencies] PRIMARY KEY CLUSTERED 
(
	[Currencies_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Currencies_Exchange_Rate]    Script Date: 5/13/2023 4:30:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currencies_Exchange_Rate](
	[Currencies_Exchange_Rate_Id] [int] IDENTITY(1,1) NOT NULL,
	[CurreExchangeRate] [float] NULL,
	[CurreExchangeDate] [datetime] NULL,
	[CurreExhhangeStatus] [int] NULL,
	[system_users] [nvarchar](450) NULL,
	[currencies] [int] NULL,
 CONSTRAINT [PK_Currencies_Exchange_Rate] PRIMARY KEY CLUSTERED 
(
	[Currencies_Exchange_Rate_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detailed_Expens_Voucher]    Script Date: 5/13/2023 4:30:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detailed_Expens_Voucher](
	[Detailed_Expens_Voucher_Id] [int] IDENTITY(1,1) NOT NULL,
	[main_expens_voucher_number] [nvarchar](50) NOT NULL,
	[DetailedExpensVoucherAmount_RLY] [float] NOT NULL,
	[DetailedExpensVoucherAmount_UDO] [float] NULL,
	[DetailedExpensVoucherAmountDescription] [nvarchar](50) NULL,
	[DebitChildAccount] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Detailed_Expens_Voucher] PRIMARY KEY CLUSTERED 
(
	[Detailed_Expens_Voucher_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detailed_Journal_Enteries]    Script Date: 5/13/2023 4:30:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detailed_Journal_Enteries](
	[Detailed_Journal_Enteries_Id] [int] IDENTITY(1,1) NOT NULL,
	[main_journal_enteries] [int] NULL,
	[DetailedournalDescription] [nvarchar](50) NULL,
	[currencies] [int] NULL,
	[DebitChildAccount] [nvarchar](50) NULL,
	[CreditChildAccount] [nvarchar](50) NULL,
	[CreditAmount_RLY] [float] NULL,
	[DebittAmount_RLY] [float] NULL,
	[CreditAmount_UDO] [float] NULL,
	[DebittAmount_UDO] [float] NULL,
	[currencies_exchange_rate] [int] NULL,
 CONSTRAINT [PK_Detailed_Journal_Enteries] PRIMARY KEY CLUSTERED 
(
	[Detailed_Journal_Enteries_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detailed_PayCheck]    Script Date: 5/13/2023 4:30:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detailed_PayCheck](
	[Detailed_PayCheck_Id] [int] IDENTITY(1,1) NOT NULL,
	[main_paycheck] [nvarchar](50) NOT NULL,
	[DetailedPaycheckAmount_RLY] [float] NOT NULL,
	[DetailedPaycheckAmount_UDO] [float] NULL,
	[DetailedPaycheckrDescription] [nvarchar](50) NULL,
	[CreditChildAccount] [nvarchar](50) NULL,
 CONSTRAINT [PK_Detailed_PayCheck] PRIMARY KEY CLUSTERED 
(
	[Detailed_PayCheck_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Final_Account_Type]    Script Date: 5/13/2023 4:30:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Final_Account_Type](
	[Final_Account_Type_Id] [int] NOT NULL,
	[FinAccType] [nvarchar](50) NULL,
 CONSTRAINT [PK_Final_Account_Type] PRIMARY KEY CLUSTERED 
(
	[Final_Account_Type_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fiscal_Year]    Script Date: 5/13/2023 4:30:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fiscal_Year](
	[Fiscal_Year_Id] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[FiscalYearName] [nvarchar](50) NULL,
	[FiscalYearStatus] [int] NULL,
	[system_Users] [nvarchar](450) NULL,
 CONSTRAINT [PK_Fiscal_Year] PRIMARY KEY CLUSTERED 
(
	[Fiscal_Year_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Funds]    Script Date: 5/13/2023 4:30:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funds](
	[Funds_Id] [int] NOT NULL,
	[FundName] [nvarchar](50) NULL,
	[FundStatus] [int] NOT NULL,
	[sub_accounting_manual] [nvarchar](50) NULL,
	[system_Users] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Funds] PRIMARY KEY CLUSTERED 
(
	[Funds_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[General_Ledger]    Script Date: 5/13/2023 4:30:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[General_Ledger](
	[General_Ledger_Id] [int] IDENTITY(1,1) NOT NULL,
	[system_Users] [nvarchar](450) NULL,
	[fiscal_year] [int] NULL,
	[accounting_manual] [nvarchar](50) NULL,
	[currencies] [int] NULL,
	[currencies_exchange_rate] [int] NOT NULL,
	[Transaction_Is_Stage] [int] NULL,
	[GenLedgerDateTime] [datetime] NULL,
	[CreditAmount_RLY] [float] NULL,
	[DebittAmount_RLY] [float] NULL,
	[CreditAmountWith_TransCurre] [float] NULL,
	[DebitAmountWith_TransCurre] [float] NULL,
	[TransactionName] [nvarchar](50) NULL,
	[Main_Expens_Voucher_Number] [nvarchar](50) NULL,
	[Main_Journal_Enteries_id] [int] NULL,
	[Main_PayCheck_Number] [nvarchar](50) NULL,
	[Check_ExpensVoucher_Number] [nvarchar](50) NULL,
	[Check_PayCheckVoucher_Number] [nvarchar](50) NULL,
 CONSTRAINT [PK_General_Ledger] PRIMARY KEY CLUSTERED 
(
	[General_Ledger_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Journal_Enterie_Types]    Script Date: 5/13/2023 4:30:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Journal_Enterie_Types](
	[Journal_Enterie_Types_Id] [int] NOT NULL,
	[JournalEnteryName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Journal_Enterie_Types] PRIMARY KEY CLUSTERED 
(
	[Journal_Enterie_Types_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Main_Expens_Voucher]    Script Date: 5/13/2023 4:30:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Main_Expens_Voucher](
	[Main_ExpensVoucher_Number] [nvarchar](50) NOT NULL,
	[currencies_exchange_rate] [int] NOT NULL,
	[system_users] [nvarchar](450) NOT NULL,
	[fiscal_year] [int] NOT NULL,
	[funds] [int] NOT NULL,
	[currencies] [int] NOT NULL,
	[MainExpensVoucherStatus] [int] NOT NULL,
	[MainExpensVoucherAmount_RLY] [float] NOT NULL,
	[MainExpensVoucherAmount_UDO] [float] NULL,
	[ReferenceNumber] [int] NULL,
	[MainExpensVoucherDate] [datetime] NULL,
	[IsDelete] [int] NULL,
 CONSTRAINT [PK_Main_Expens_Voucher_1] PRIMARY KEY CLUSTERED 
(
	[Main_ExpensVoucher_Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Main_Journal_Enteries]    Script Date: 5/13/2023 4:30:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Main_Journal_Enteries](
	[Main_Journal_Enteries_Id] [int] IDENTITY(1,1) NOT NULL,
	[Main_Joural_Ent_Number] [nvarchar](50) NOT NULL,
	[journal_enterie_types] [int] NULL,
	[fiscal_year] [int] NULL,
	[MainJournalEnteriesAmount] [float] NULL,
	[MainournalEnteriesStatus] [int] NOT NULL,
	[MainJournalReferenceNumber] [int] NOT NULL,
	[MainJournalDateTime] [datetime] NULL,
	[MainPaycheckGlobalNote] [nvarchar](1000) NULL,
	[isStage] [int] NOT NULL,
	[isDeleted] [int] NULL,
	[system_users] [nvarchar](450) NULL,
 CONSTRAINT [PK_Main_Journal_Enteries_1] PRIMARY KEY CLUSTERED 
(
	[Main_Journal_Enteries_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Main_PayCheck]    Script Date: 5/13/2023 4:30:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Main_PayCheck](
	[MainPaycheckNumber] [nvarchar](50) NOT NULL,
	[system_users] [nvarchar](450) NOT NULL,
	[currencies_exchange_rate] [int] NULL,
	[fiscal_year] [int] NOT NULL,
	[funds] [int] NOT NULL,
	[currencies] [int] NOT NULL,
	[MainPaycheckStatus] [int] NOT NULL,
	[MainPaycheckAmount_RLY] [float] NOT NULL,
	[MainPaycheckAmount_UDO] [float] NULL,
	[ReferenceNumber] [int] NULL,
	[MainPaycheckDate] [datetime] NULL,
	[IsDelete] [int] NULL,
 CONSTRAINT [PK_Main_PayCheck_1] PRIMARY KEY CLUSTERED 
(
	[MainPaycheckNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions_Activity]    Script Date: 5/13/2023 4:30:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions_Activity](
	[Transactions_Activity_Id] [int] NOT NULL,
	[activity_type] [int] NOT NULL,
	[general_ledger] [int] NOT NULL,
	[main_expens_voucher] [nvarchar](50) NOT NULL,
	[main_PayCheck] [nvarchar](50) NOT NULL,
	[main_journal_enteries] [int] NOT NULL,
	[check_Paycheck] [nvarchar](50) NOT NULL,
	[check_expens] [nvarchar](50) NOT NULL,
	[sysyem_Users] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Transactions_Activity] PRIMARY KEY CLUSTERED 
(
	[Transactions_Activity_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221008143334_newdb', N'5.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221008160755_newdb', N'5.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230404143302_Firstdb', N'6.0.10')
INSERT [dbo].[Accounting_Manual] ([AccNumber], [ParentAccNumber], [AccStatus], [AccLevel], [ArabicAccName], [EnglishAccName], [AccType], [AccMaxBalane], [AccKind], [fiscal_Year], [final_Account_Type], [system_Users]) VALUES (N'0', N'0', N'0', N'0', N'xx', N'xx', N'xx', 9, N'xx', 7, 1, NULL)
INSERT [dbo].[Accounting_Manual] ([AccNumber], [ParentAccNumber], [AccStatus], [AccLevel], [ArabicAccName], [EnglishAccName], [AccType], [AccMaxBalane], [AccKind], [fiscal_Year], [final_Account_Type], [system_Users]) VALUES (N'1', N'0', N'1', N'1', N'الاصول', N'shihab', N'رئيسي', 9999, N'دائن', 7, 1, NULL)
INSERT [dbo].[Accounting_Manual] ([AccNumber], [ParentAccNumber], [AccStatus], [AccLevel], [ArabicAccName], [EnglishAccName], [AccType], [AccMaxBalane], [AccKind], [fiscal_Year], [final_Account_Type], [system_Users]) VALUES (N'11', N'1', N'1', N'2', N'اصول متداولة', NULL, N'رئيسي', NULL, N'دائن', 7, 1, NULL)
INSERT [dbo].[Accounting_Manual] ([AccNumber], [ParentAccNumber], [AccStatus], [AccLevel], [ArabicAccName], [EnglishAccName], [AccType], [AccMaxBalane], [AccKind], [fiscal_Year], [final_Account_Type], [system_Users]) VALUES (N'111', N'11', N'1', N'3', N'الصناديق', N'Funds', N'رئيسي', 999999, N'دائن', 7, 1, NULL)
INSERT [dbo].[Accounting_Manual] ([AccNumber], [ParentAccNumber], [AccStatus], [AccLevel], [ArabicAccName], [EnglishAccName], [AccType], [AccMaxBalane], [AccKind], [fiscal_Year], [final_Account_Type], [system_Users]) VALUES (N'1111', N'111', N'1', N'4', N'الصندوق الرئيسي', NULL, N'فرعي', 9999, N'دائن', 7, 1, NULL)
INSERT [dbo].[Accounting_Manual] ([AccNumber], [ParentAccNumber], [AccStatus], [AccLevel], [ArabicAccName], [EnglishAccName], [AccType], [AccMaxBalane], [AccKind], [fiscal_Year], [final_Account_Type], [system_Users]) VALUES (N'1112', N'111', N'1', N'4', N'صندوق رقم 3', NULL, N'فرعي', NULL, N'دائن', 7, 1, NULL)
INSERT [dbo].[Accounting_Manual] ([AccNumber], [ParentAccNumber], [AccStatus], [AccLevel], [ArabicAccName], [EnglishAccName], [AccType], [AccMaxBalane], [AccKind], [fiscal_Year], [final_Account_Type], [system_Users]) VALUES (N'1113', N'111', N'1', N'4', N'صندوق رقم 2', NULL, N'فرعي', NULL, N'دائن', 7, 1, NULL)
INSERT [dbo].[Accounting_Manual] ([AccNumber], [ParentAccNumber], [AccStatus], [AccLevel], [ArabicAccName], [EnglishAccName], [AccType], [AccMaxBalane], [AccKind], [fiscal_Year], [final_Account_Type], [system_Users]) VALUES (N'1114', N'111', N'1', N'4', N'صندوق تجريبي', NULL, N'فرعي', 999999, N'دائن', 7, 1, NULL)
INSERT [dbo].[Accounting_Manual] ([AccNumber], [ParentAccNumber], [AccStatus], [AccLevel], [ArabicAccName], [EnglishAccName], [AccType], [AccMaxBalane], [AccKind], [fiscal_Year], [final_Account_Type], [system_Users]) VALUES (N'1115', N'111', N'1', N'4', N'صندوق رقم 4', NULL, N'فرعي', NULL, N'دائن', 7, 1, NULL)
INSERT [dbo].[Accounting_Manual] ([AccNumber], [ParentAccNumber], [AccStatus], [AccLevel], [ArabicAccName], [EnglishAccName], [AccType], [AccMaxBalane], [AccKind], [fiscal_Year], [final_Account_Type], [system_Users]) VALUES (N'112', N'11', N'1', N'3', N'البنوك', NULL, N'رئيسي', NULL, N'دائن', 7, 1, NULL)
INSERT [dbo].[Accounting_Manual] ([AccNumber], [ParentAccNumber], [AccStatus], [AccLevel], [ArabicAccName], [EnglishAccName], [AccType], [AccMaxBalane], [AccKind], [fiscal_Year], [final_Account_Type], [system_Users]) VALUES (N'1121', N'112', N'1', N'4', N'بنك اليمني', NULL, N'فرعي', 99999, N'دائن', 7, 1, NULL)
INSERT [dbo].[Accounting_Manual] ([AccNumber], [ParentAccNumber], [AccStatus], [AccLevel], [ArabicAccName], [EnglishAccName], [AccType], [AccMaxBalane], [AccKind], [fiscal_Year], [final_Account_Type], [system_Users]) VALUES (N'1122', N'112', N'1', N'4', N'البنك الاهلي', N'AlAhaleey Bank', N'فرعي', 999999, N'دائن', 7, 1, N'6f94621c-3508-435c-98fe-c51cc63d076f')
INSERT [dbo].[Accounting_Manual] ([AccNumber], [ParentAccNumber], [AccStatus], [AccLevel], [ArabicAccName], [EnglishAccName], [AccType], [AccMaxBalane], [AccKind], [fiscal_Year], [final_Account_Type], [system_Users]) VALUES (N'1123', N'112', N'1', N'4', N'بنك التضامن', NULL, N'فرعي', 99999, N'مدين', 7, 1, N'6f94621c-3508-435c-98fe-c51cc63d076f')
INSERT [dbo].[Accounting_Manual] ([AccNumber], [ParentAccNumber], [AccStatus], [AccLevel], [ArabicAccName], [EnglishAccName], [AccType], [AccMaxBalane], [AccKind], [fiscal_Year], [final_Account_Type], [system_Users]) VALUES (N'113', N'11', N'1', N'3', N'الموظفين', N'Emplyees', N'رئيسي', NULL, N'دائن', 7, 1, N'6f94621c-3508-435c-98fe-c51cc63d076f')
INSERT [dbo].[Accounting_Manual] ([AccNumber], [ParentAccNumber], [AccStatus], [AccLevel], [ArabicAccName], [EnglishAccName], [AccType], [AccMaxBalane], [AccKind], [fiscal_Year], [final_Account_Type], [system_Users]) VALUES (N'1131', N'113', N'1', N'4', N'شهاب العريفي', N'Shihab AlArifi', N'فرعي', 999999, N'دائن', 7, 1, N'6f94621c-3508-435c-98fe-c51cc63d076f')
INSERT [dbo].[Accounting_Manual] ([AccNumber], [ParentAccNumber], [AccStatus], [AccLevel], [ArabicAccName], [EnglishAccName], [AccType], [AccMaxBalane], [AccKind], [fiscal_Year], [final_Account_Type], [system_Users]) VALUES (N'1132', N'113', N'0', N'4', N'علي الاكوع', N'Ali AlAkwa''a', N'فرعي', 999999, N'مدين', 7, 1, N'6f94621c-3508-435c-98fe-c51cc63d076f')
INSERT [dbo].[Accounting_Manual] ([AccNumber], [ParentAccNumber], [AccStatus], [AccLevel], [ArabicAccName], [EnglishAccName], [AccType], [AccMaxBalane], [AccKind], [fiscal_Year], [final_Account_Type], [system_Users]) VALUES (N'1133', N'113', N'0', N'4', N'محمد الزبيري', N'Mohammed AlZobiry', N'فرعي', 999999, N'مدين', 7, 1, N'6f94621c-3508-435c-98fe-c51cc63d076f')
INSERT [dbo].[Accounting_Manual] ([AccNumber], [ParentAccNumber], [AccStatus], [AccLevel], [ArabicAccName], [EnglishAccName], [AccType], [AccMaxBalane], [AccKind], [fiscal_Year], [final_Account_Type], [system_Users]) VALUES (N'1134', N'113', N'1', N'4', N'علي المطري', N'Ali AlMatari', N'فرعي', 999999, N'مدين', 7, 1, N'6f94621c-3508-435c-98fe-c51cc63d076f')
INSERT [dbo].[Accounting_Manual] ([AccNumber], [ParentAccNumber], [AccStatus], [AccLevel], [ArabicAccName], [EnglishAccName], [AccType], [AccMaxBalane], [AccKind], [fiscal_Year], [final_Account_Type], [system_Users]) VALUES (N'1135', N'113', N'1', N'4', N'شهاب العريفي $$$', N'shhihab$$$', N'فرعي', NULL, N'مدين', 7, 1, N'6f94621c-3508-435c-98fe-c51cc63d076f')
SET IDENTITY_INSERT [dbo].[Accounts_Currencies] ON 

INSERT [dbo].[Accounts_Currencies] ([Accounts_Currencies_Id], [accounting_manual], [currencies], [opening_Balance], [Date], [Description], [system_User]) VALUES (9, N'1111', 14, NULL, NULL, NULL, N'6f94621c-3508-435c-98fe-c51cc63d076f')
INSERT [dbo].[Accounts_Currencies] ([Accounts_Currencies_Id], [accounting_manual], [currencies], [opening_Balance], [Date], [Description], [system_User]) VALUES (10, N'1111', 17, NULL, NULL, NULL, N'6f94621c-3508-435c-98fe-c51cc63d076f')
INSERT [dbo].[Accounts_Currencies] ([Accounts_Currencies_Id], [accounting_manual], [currencies], [opening_Balance], [Date], [Description], [system_User]) VALUES (11, N'1111', 20, NULL, NULL, NULL, N'6f94621c-3508-435c-98fe-c51cc63d076f')
INSERT [dbo].[Accounts_Currencies] ([Accounts_Currencies_Id], [accounting_manual], [currencies], [opening_Balance], [Date], [Description], [system_User]) VALUES (14, N'1122', 25, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts_Currencies] ([Accounts_Currencies_Id], [accounting_manual], [currencies], [opening_Balance], [Date], [Description], [system_User]) VALUES (15, N'1122', 26, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts_Currencies] ([Accounts_Currencies_Id], [accounting_manual], [currencies], [opening_Balance], [Date], [Description], [system_User]) VALUES (16, N'1122', 14, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts_Currencies] ([Accounts_Currencies_Id], [accounting_manual], [currencies], [opening_Balance], [Date], [Description], [system_User]) VALUES (19, N'1133', 25, NULL, CAST(N'2022-10-17T14:53:14.970' AS DateTime), NULL, NULL)
INSERT [dbo].[Accounts_Currencies] ([Accounts_Currencies_Id], [accounting_manual], [currencies], [opening_Balance], [Date], [Description], [system_User]) VALUES (20, N'1133', 20, NULL, CAST(N'2022-10-17T14:53:14.970' AS DateTime), NULL, NULL)
INSERT [dbo].[Accounts_Currencies] ([Accounts_Currencies_Id], [accounting_manual], [currencies], [opening_Balance], [Date], [Description], [system_User]) VALUES (21, N'1133', 24, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts_Currencies] ([Accounts_Currencies_Id], [accounting_manual], [currencies], [opening_Balance], [Date], [Description], [system_User]) VALUES (22, N'1133', 14, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts_Currencies] ([Accounts_Currencies_Id], [accounting_manual], [currencies], [opening_Balance], [Date], [Description], [system_User]) VALUES (23, N'1134', 25, 100, CAST(N'2022-10-17T15:00:04.537' AS DateTime), NULL, NULL)
INSERT [dbo].[Accounts_Currencies] ([Accounts_Currencies_Id], [accounting_manual], [currencies], [opening_Balance], [Date], [Description], [system_User]) VALUES (24, N'1134', 14, 19900, CAST(N'2022-10-17T15:00:04.537' AS DateTime), NULL, NULL)
INSERT [dbo].[Accounts_Currencies] ([Accounts_Currencies_Id], [accounting_manual], [currencies], [opening_Balance], [Date], [Description], [system_User]) VALUES (25, N'1134', 20, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts_Currencies] ([Accounts_Currencies_Id], [accounting_manual], [currencies], [opening_Balance], [Date], [Description], [system_User]) VALUES (26, N'1135', 14, 9, CAST(N'2023-04-04T19:09:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Accounts_Currencies] ([Accounts_Currencies_Id], [accounting_manual], [currencies], [opening_Balance], [Date], [Description], [system_User]) VALUES (27, N'1135', 24, 8, CAST(N'2023-04-04T19:09:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Accounts_Currencies] ([Accounts_Currencies_Id], [accounting_manual], [currencies], [opening_Balance], [Date], [Description], [system_User]) VALUES (28, N'1135', 20, 7, CAST(N'2023-04-04T19:09:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Accounts_Currencies] ([Accounts_Currencies_Id], [accounting_manual], [currencies], [opening_Balance], [Date], [Description], [system_User]) VALUES (29, N'1135', 25, 6, CAST(N'2023-04-04T19:09:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Accounts_Currencies] ([Accounts_Currencies_Id], [accounting_manual], [currencies], [opening_Balance], [Date], [Description], [system_User]) VALUES (30, N'1123', 14, NULL, CAST(N'2023-04-15T16:49:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Accounts_Currencies] ([Accounts_Currencies_Id], [accounting_manual], [currencies], [opening_Balance], [Date], [Description], [system_User]) VALUES (31, N'1123', 25, 100000, CAST(N'2023-04-15T16:49:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Accounts_Currencies] OFF
SET IDENTITY_INSERT [dbo].[AspNetRoleClaims] ON 

INSERT [dbo].[AspNetRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (17, N'9c1630bd-362d-4f44-a1ec-9e7e1b121622', N'Permission', N'Permissions.Home.View')
INSERT [dbo].[AspNetRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (18, N'9c1630bd-362d-4f44-a1ec-9e7e1b121622', N'Permission', N'Permissions.Home.Create')
INSERT [dbo].[AspNetRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (19, N'9c1630bd-362d-4f44-a1ec-9e7e1b121622', N'Permission', N'Permissions.Home.Edit')
INSERT [dbo].[AspNetRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (20, N'9c1630bd-362d-4f44-a1ec-9e7e1b121622', N'Permission', N'Permissions.Home.Delete')
INSERT [dbo].[AspNetRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (21, N'9c1630bd-362d-4f44-a1ec-9e7e1b121622', N'Permission', N'Permissions.Accounts.View')
INSERT [dbo].[AspNetRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (22, N'9c1630bd-362d-4f44-a1ec-9e7e1b121622', N'Permission', N'Permissions.Accounts.Create')
INSERT [dbo].[AspNetRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (23, N'9c1630bd-362d-4f44-a1ec-9e7e1b121622', N'Permission', N'Permissions.Accounts.Edit')
INSERT [dbo].[AspNetRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (24, N'9c1630bd-362d-4f44-a1ec-9e7e1b121622', N'Permission', N'Permissions.Accounts.Delete')
INSERT [dbo].[AspNetRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (25, N'9c1630bd-362d-4f44-a1ec-9e7e1b121622', N'Permission', N'Permissions.Roles.View')
INSERT [dbo].[AspNetRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (26, N'9c1630bd-362d-4f44-a1ec-9e7e1b121622', N'Permission', N'Permissions.Roles.Create')
INSERT [dbo].[AspNetRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (27, N'9c1630bd-362d-4f44-a1ec-9e7e1b121622', N'Permission', N'Permissions.Roles.Edit')
INSERT [dbo].[AspNetRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (28, N'9c1630bd-362d-4f44-a1ec-9e7e1b121622', N'Permission', N'Permissions.Roles.Delete')
INSERT [dbo].[AspNetRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (29, N'9c1630bd-362d-4f44-a1ec-9e7e1b121622', N'Permission', N'Permissions.Registers.View')
INSERT [dbo].[AspNetRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (30, N'9c1630bd-362d-4f44-a1ec-9e7e1b121622', N'Permission', N'Permissions.Registers.Create')
INSERT [dbo].[AspNetRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (31, N'9c1630bd-362d-4f44-a1ec-9e7e1b121622', N'Permission', N'Permissions.Registers.Edit')
INSERT [dbo].[AspNetRoleClaims] ([Id], [RoleId], [ClaimType], [ClaimValue]) VALUES (32, N'9c1630bd-362d-4f44-a1ec-9e7e1b121622', N'Permission', N'Permissions.Registers.Delete')
SET IDENTITY_INSERT [dbo].[AspNetRoleClaims] OFF
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'01945ed0-be1d-488d-a143-633cdedb37ae', N'Basic', N'BASIC', N'5fcf599a-185d-4ec5-b021-60622e04ac30')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'9c1630bd-362d-4f44-a1ec-9e7e1b121622', N'SupperAdmin', N'SUPPERADMIN', N'b4e5ec3f-e4ac-481a-b1de-e30eee9503b6')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'a817b159-0cfc-41d4-a5ef-c987ab772c9b', N'Admin', N'ADMIN', N'a2d198b7-7a8c-494d-88e7-0d242d9fd76f')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'aa379499-7e62-4202-ac0d-89d0a61ad992', N'User', N'USER', N'01c44887-a057-4b8b-b700-893ec49b9e0d')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'ca9dec0d-0595-4fbd-8b90-deb3a4173364', N'مستخدم', N'مستخدم', N'07a96683-17cb-44fb-9562-8320e34aaecb')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'03ab1ae8-76d8-49ee-bda1-bcb8135ac6cb', N'01945ed0-be1d-488d-a143-633cdedb37ae')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'26f8c391-1aa7-4729-bbac-a441452e05b4', N'9c1630bd-362d-4f44-a1ec-9e7e1b121622')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5f16893f-81e3-44e9-9a10-f6a068af99d1', N'a817b159-0cfc-41d4-a5ef-c987ab772c9b')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'77155d98-47a0-48c1-b466-757f017fc751', N'a817b159-0cfc-41d4-a5ef-c987ab772c9b')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7b436081-b395-4d73-a204-c87727884269', N'a817b159-0cfc-41d4-a5ef-c987ab772c9b')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bf3b3c5a-9979-40d8-ba5a-ffea5a8fc1e8', N'9c1630bd-362d-4f44-a1ec-9e7e1b121622')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fc41b76a-684e-4635-8a40-7e992f0f771b', N'aa379499-7e62-4202-ac0d-89d0a61ad992')
INSERT [dbo].[AspNetUsers] ([Id], [Name], [ImageUser], [ActiveUser], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'03ab1ae8-76d8-49ee-bda1-bcb8135ac6cb', N'BasicUser', N'69805409-b5a1-4154-ad10-762baf4532a2.png', 1, N'basicuser@domin.com', N'BASICUSER@DOMIN.COM', N'basicuser@domin.com', N'BASICUSER@DOMIN.COM', 1, N'AQAAAAEAACcQAAAAEFD0XSHa3Bzocysq3lGpcdKOSeRbx0sa+kNQ51Bovtei2AUnnAP543MGYK/4sflDRg==', N'AXWTSCNBQOVKZUHJQPJZ44BYXN5IGBSU', N'1c527d75-289a-4efe-a0ef-f85cd2c0c8dc', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Name], [ImageUser], [ActiveUser], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'26f8c391-1aa7-4729-bbac-a441452e05b4', N'شهاب العريفي', N'628e1d48-3177-4e97-9df4-c5ecba4bb7b8.jpg', 1, N'Shihab@com.com', N'SHIHAB@COM.COM', N'Shihab@com.com', N'SHIHAB@COM.COM', 0, N'AQAAAAEAACcQAAAAEAz1XCaEOeehqlMu0IKIXtc34k/xbPpzIAYIv6IwRj9O3Duqsw4HdvNLS830/t5OaA==', N'X7RJBSAISZU6264SS2NOLWBVO4BV3YPU', N'b1661d20-bd15-46c4-9c9a-7b75d94ac1a0', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Name], [ImageUser], [ActiveUser], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'5f16893f-81e3-44e9-9a10-f6a068af99d1', N'Admin', N'69805409-b5a1-4154-ad10-762baf4532a2.png', 1, N'admin@domin.com', N'ADMIN@DOMIN.COM', N'admin@domin.com', N'ADMIN@DOMIN.COM', 1, N'AQAAAAEAACcQAAAAEE0Oh/cVQiM//oGvwAlqpBkMpLKgPLF8NqRaQ4BHYn3HGcCrUcX33HoqJs5H5+1iqg==', N'7ZL2R2YT5OCJE5FL2QNFSRZJ3SQRXYA7', N'dfd6741c-5a3b-4efe-93e1-4eb0ebcb1195', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Name], [ImageUser], [ActiveUser], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'6f94621c-3508-435c-98fe-c51cc63d076f', N'shihab', N'SHIHAB', 1, N'SHIHAB@GMAIL.COM', N'False', N'AQAAAAEAACcQAAAAELom+k4yI9TvN+RhytWMElHIsMe9XZ0FFI09KWTsKzPgSPT9EAVBJp9Kqm1IzAec4Q==', N'XVBDHMF4PXGESUPE4EMCLYAZ6HI4MJXO', 0, NULL, N'False', N'False', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Name], [ImageUser], [ActiveUser], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'77155d98-47a0-48c1-b466-757f017fc751', N'علي الاكوع', N'4975eb04-4560-4d02-8a9a-300ed24c2a03.jpg', 1, N'ali@ali.com', N'ALI@ALI.COM', N'ali@ali.com', N'ALI@ALI.COM', 0, N'AQAAAAEAACcQAAAAEMnzBqaT2NzJSnYWG7jj1drJkThYrqAN4rghUHNoG5vrbCPJw1akkEVfdCBhhxt5ow==', N'UCLWYPX67YTPVHRDD4LO57FR2DVEYMX5', N'48de4734-1b3e-4c99-8d8c-ba10453a3458', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Name], [ImageUser], [ActiveUser], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'7b436081-b395-4d73-a204-c87727884269', N'شهاب العريفي', N'61505fd4-c198-4093-9eae-636eec267c33.JPG', 1, N'Shiahb', N'TEST@TEST.COM', N'test@test.com', N'TEST@TEST.COM', 0, N'AQAAAAEAACcQAAAAEFvMOS74Bxfx5eJiaUTCEXccPDmQISmfmGyA+1Svdq5/tMuPvXG1O+dBLP3ObOyPhg==', N'STJGFHBS3WWAHNTTVQPGURM66NQUXLYA', N'f106ebdb-07ce-434d-b360-dafd7b5c9081', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Name], [ImageUser], [ActiveUser], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'bf3b3c5a-9979-40d8-ba5a-ffea5a8fc1e8', N'SuperAdmin', N'69805409-b5a1-4154-ad10-762baf4532a2.png', 1, N'xsuperadmin@domin.com', N'XSUPERADMIN@DOMIN.COM', N'xsuperadmin@domin.com', N'XSUPERADMIN@DOMIN.COM', 1, N'AQAAAAEAACcQAAAAEJjQFo0L0MpsQhv2ymzgX2WWcGi16L1gbQ/Zu+3/CACi0yAeILlXJM67FWmUIrPdZQ==', N'WSOP5KNHB6IZH4OJMVVFOV7C4QQELY6U', N'a674c6af-61c5-4426-a4b5-2d2dc7354538', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Name], [ImageUser], [ActiveUser], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'fc41b76a-684e-4635-8a40-7e992f0f771b', N'أيادوز', N'5b3d3836-aaa4-4db5-8180-01fb3ff91481.jpeg', 1, N'Eyados@gamm.com', N'EYADOS@GAMM.COM', N'Eyados@gamm.com', N'EYADOS@GAMM.COM', 0, N'AQAAAAEAACcQAAAAEFUms55W3j+5faisqepSHlt+TQMovynnm5SbdOJ3AH0eHbQd58/JDjBuaEsWXr7W1Q==', N'HR66UMODPAKPJOPCLLAPUBJ46NJHHPYX', N'3ec9f9d6-33ff-4d7c-b8c7-fb1e5e6c86fd', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Banks] ([Bank_Id], [BankName], [BankStatus], [sub_accounting_manual], [system_Users]) VALUES (1121, N'البنك اليمني', 1, N'1121', N'6f94621c-3508-435c-98fe-c51cc63d076f')
INSERT [dbo].[Banks] ([Bank_Id], [BankName], [BankStatus], [sub_accounting_manual], [system_Users]) VALUES (1122, N'البنك الاهلي', 0, N'1122', N'6f94621c-3508-435c-98fe-c51cc63d076f')
INSERT [dbo].[Banks] ([Bank_Id], [BankName], [BankStatus], [sub_accounting_manual], [system_Users]) VALUES (1123, N'بنك التضامن', 0, N'1123', N'6f94621c-3508-435c-98fe-c51cc63d076f')
INSERT [dbo].[Check_Expens_Voucher] ([Check_ExpensVoucherNumber], [CheckNumber], [banks], [fiscal_Year], [Check_Expend_cheques], [CheckStatus], [ReferenceNumber], [ChequesType], [ChequesDate], [CheckDescription], [CheckDatetime], [currencies], [DebitChildAccount], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmount_UDO], [DebittAmount_UDO], [currencies_exchange_rate], [system_Users], [IsDelete]) VALUES (N'CX00001', N'100002', 1122, 7, 1, 1, 2, N'يدوي', CAST(N'2022-10-31T00:00:00.000' AS DateTime), N'صرف للحب شيك', CAST(N'2022-10-11T00:00:00.000' AS DateTime), 14, N'1131', 9000, 9000, NULL, NULL, 3, N'6f94621c-3508-435c-98fe-c51cc63d076f', 0)
INSERT [dbo].[Check_Expens_Voucher] ([Check_ExpensVoucherNumber], [CheckNumber], [banks], [fiscal_Year], [Check_Expend_cheques], [CheckStatus], [ReferenceNumber], [ChequesType], [ChequesDate], [CheckDescription], [CheckDatetime], [currencies], [DebitChildAccount], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmount_UDO], [DebittAmount_UDO], [currencies_exchange_rate], [system_Users], [IsDelete]) VALUES (N'CX00002', N'100003', 1122, 7, 1, 1, 2, N'يدوي', CAST(N'2022-10-25T00:00:00.000' AS DateTime), N'صرف للحب شيك', CAST(N'2022-10-03T00:00:00.000' AS DateTime), 25, N'1132', 7999, 7999, NULL, NULL, 7, N'6f94621c-3508-435c-98fe-c51cc63d076f', 0)
INSERT [dbo].[Check_Expens_Voucher] ([Check_ExpensVoucherNumber], [CheckNumber], [banks], [fiscal_Year], [Check_Expend_cheques], [CheckStatus], [ReferenceNumber], [ChequesType], [ChequesDate], [CheckDescription], [CheckDatetime], [currencies], [DebitChildAccount], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmount_UDO], [DebittAmount_UDO], [currencies_exchange_rate], [system_Users], [IsDelete]) VALUES (N'CX00003', N'11134', 1122, 7, 1, 0, 2, N'يدوي', CAST(N'2022-10-17T00:00:00.000' AS DateTime), N'صرف للحب شيك', CAST(N'2022-10-17T00:00:00.000' AS DateTime), 14, N'1132', 120000, 120000, NULL, NULL, 3, N'6f94621c-3508-435c-98fe-c51cc63d076f', 0)
INSERT [dbo].[Check_Expens_Voucher] ([Check_ExpensVoucherNumber], [CheckNumber], [banks], [fiscal_Year], [Check_Expend_cheques], [CheckStatus], [ReferenceNumber], [ChequesType], [ChequesDate], [CheckDescription], [CheckDatetime], [currencies], [DebitChildAccount], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmount_UDO], [DebittAmount_UDO], [currencies_exchange_rate], [system_Users], [IsDelete]) VALUES (N'CX00004', N'1008', 1122, 7, 1, 1, 1, N'يدوي', CAST(N'2022-10-17T00:00:00.000' AS DateTime), N'صرف للحب شيك', CAST(N'2022-10-17T00:00:00.000' AS DateTime), 14, N'1131', 88000, 88000, NULL, NULL, 3, N'6f94621c-3508-435c-98fe-c51cc63d076f', 0)
INSERT [dbo].[Check_Expens_Voucher] ([Check_ExpensVoucherNumber], [CheckNumber], [banks], [fiscal_Year], [Check_Expend_cheques], [CheckStatus], [ReferenceNumber], [ChequesType], [ChequesDate], [CheckDescription], [CheckDatetime], [currencies], [DebitChildAccount], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmount_UDO], [DebittAmount_UDO], [currencies_exchange_rate], [system_Users], [IsDelete]) VALUES (N'CX00005', N'100055', 1122, 7, 0, 0, 1, N'يدوي', CAST(N'2022-10-17T00:00:00.000' AS DateTime), N'صرف للحب شيك', CAST(N'2022-10-17T00:00:00.000' AS DateTime), 25, N'1131', 5000, 5000, NULL, NULL, 3, N'6f94621c-3508-435c-98fe-c51cc63d076f', 0)
INSERT [dbo].[Check_Expens_Voucher] ([Check_ExpensVoucherNumber], [CheckNumber], [banks], [fiscal_Year], [Check_Expend_cheques], [CheckStatus], [ReferenceNumber], [ChequesType], [ChequesDate], [CheckDescription], [CheckDatetime], [currencies], [DebitChildAccount], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmount_UDO], [DebittAmount_UDO], [currencies_exchange_rate], [system_Users], [IsDelete]) VALUES (N'CX00006', N'100001', 1122, 7, 1, 1, 2, N'يدوي', CAST(N'2022-10-17T00:00:00.000' AS DateTime), N'صرف للحب شيك', CAST(N'2022-10-17T00:00:00.000' AS DateTime), 14, N'1131', 177000, 177000, NULL, NULL, 3, N'6f94621c-3508-435c-98fe-c51cc63d076f', 0)
INSERT [dbo].[Check_Paycheck_Voucher] ([Check_PaycheckVoucherNumber], [CheckNumber], [banks], [fiscal_Year], [Check_PayCheck_cheques], [CheckStatus], [ReferenceNumber], [ChequesType], [ChequesDate], [CheckDescription], [CheckDatetime], [currencies], [CreditChildAccount], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmount_UDO], [DebittAmount_UDO], [currencies_exchange_rate], [system_Users], [IsDelete]) VALUES (N'CP00001', N'100001', 1122, 7, 1, 1, 1, N'يدوي', CAST(N'2022-10-17T00:00:00.000' AS DateTime), N'قبضنا من شيك من شركة علوش الم', CAST(N'2022-10-17T00:00:00.000' AS DateTime), 26, N'1131', 500, 500, NULL, NULL, 6, N'6f94621c-3508-435c-98fe-c51cc63d076f', 0)
INSERT [dbo].[Check_Paycheck_Voucher] ([Check_PaycheckVoucherNumber], [CheckNumber], [banks], [fiscal_Year], [Check_PayCheck_cheques], [CheckStatus], [ReferenceNumber], [ChequesType], [ChequesDate], [CheckDescription], [CheckDatetime], [currencies], [CreditChildAccount], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmount_UDO], [DebittAmount_UDO], [currencies_exchange_rate], [system_Users], [IsDelete]) VALUES (N'CP00002', N'100054', 1122, 7, 1, 1, 2, N'يدوي', CAST(N'2022-10-24T00:00:00.000' AS DateTime), N'صرف للحب', CAST(N'2022-10-05T00:00:00.000' AS DateTime), 25, N'1132', 10000, 10000, NULL, NULL, 7, N'6f94621c-3508-435c-98fe-c51cc63d076f', 0)
INSERT [dbo].[Check_Paycheck_Voucher] ([Check_PaycheckVoucherNumber], [CheckNumber], [banks], [fiscal_Year], [Check_PayCheck_cheques], [CheckStatus], [ReferenceNumber], [ChequesType], [ChequesDate], [CheckDescription], [CheckDatetime], [currencies], [CreditChildAccount], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmount_UDO], [DebittAmount_UDO], [currencies_exchange_rate], [system_Users], [IsDelete]) VALUES (N'CP00003', N'10033', 1122, 7, 1, 1, 1, N'يدوي', CAST(N'2022-10-17T00:00:00.000' AS DateTime), N'صرف للحب شيك', CAST(N'2022-10-17T00:00:00.000' AS DateTime), 14, N'1131', 10000, 10000, NULL, NULL, 3, N'6f94621c-3508-435c-98fe-c51cc63d076f', 0)
INSERT [dbo].[Check_Paycheck_Voucher] ([Check_PaycheckVoucherNumber], [CheckNumber], [banks], [fiscal_Year], [Check_PayCheck_cheques], [CheckStatus], [ReferenceNumber], [ChequesType], [ChequesDate], [CheckDescription], [CheckDatetime], [currencies], [CreditChildAccount], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmount_UDO], [DebittAmount_UDO], [currencies_exchange_rate], [system_Users], [IsDelete]) VALUES (N'CP00004', N'001844', 1122, 7, 1, 1, 2, N'يدوي', CAST(N'2022-10-17T00:00:00.000' AS DateTime), N'قبضنا من شيك من شركة علوش الم', CAST(N'2022-10-17T00:00:00.000' AS DateTime), 25, N'1131', 117700, 117700, NULL, NULL, 7, N'6f94621c-3508-435c-98fe-c51cc63d076f', 0)
SET IDENTITY_INSERT [dbo].[Currencies] ON 

INSERT [dbo].[Currencies] ([Currencies_Id], [CurrenName], [CurreType], [CurreSymbol], [CrreChangeName], [system_Users], [CurrStatus]) VALUES (14, N'يمني', N'محلي', N'ريال', N'فلس', N'6f94621c-3508-435c-98fe-c51cc63d076f', 0)
INSERT [dbo].[Currencies] ([Currencies_Id], [CurrenName], [CurreType], [CurreSymbol], [CrreChangeName], [system_Users], [CurrStatus]) VALUES (17, N'سعودي', N'اجنيي', N'RS', N'فلس', N'6f94621c-3508-435c-98fe-c51cc63d076f', 1)
INSERT [dbo].[Currencies] ([Currencies_Id], [CurrenName], [CurreType], [CurreSymbol], [CrreChangeName], [system_Users], [CurrStatus]) VALUES (20, N'دولار', N'اجنيي', N'$', N'سنت', N'6f94621c-3508-435c-98fe-c51cc63d076f', 0)
INSERT [dbo].[Currencies] ([Currencies_Id], [CurrenName], [CurreType], [CurreSymbol], [CrreChangeName], [system_Users], [CurrStatus]) VALUES (24, N'يورو', N'اجنيي', N'E', N'سنت', N'6f94621c-3508-435c-98fe-c51cc63d076f', 0)
INSERT [dbo].[Currencies] ([Currencies_Id], [CurrenName], [CurreType], [CurreSymbol], [CrreChangeName], [system_Users], [CurrStatus]) VALUES (25, N'إماراتي', N'اجنبي', N'درهم', N'درهم', N'6f94621c-3508-435c-98fe-c51cc63d076f', 0)
INSERT [dbo].[Currencies] ([Currencies_Id], [CurrenName], [CurreType], [CurreSymbol], [CrreChangeName], [system_Users], [CurrStatus]) VALUES (26, N'مصري', N'اجنبي', N'EGP', N'جنية', N'6f94621c-3508-435c-98fe-c51cc63d076f', 1)
INSERT [dbo].[Currencies] ([Currencies_Id], [CurrenName], [CurreType], [CurreSymbol], [CrreChangeName], [system_Users], [CurrStatus]) VALUES (36, N'عماني22', N'اجنبي', N'OMN', N'فلس', N'6f94621c-3508-435c-98fe-c51cc63d076f', 1)
INSERT [dbo].[Currencies] ([Currencies_Id], [CurrenName], [CurreType], [CurreSymbol], [CrreChangeName], [system_Users], [CurrStatus]) VALUES (37, N'shihab', N'اجنبي', N'$hh', N'sho', N'6f94621c-3508-435c-98fe-c51cc63d076f', 0)
INSERT [dbo].[Currencies] ([Currencies_Id], [CurrenName], [CurreType], [CurreSymbol], [CrreChangeName], [system_Users], [CurrStatus]) VALUES (38, N'ضض', N'اجنبي', N'ضض', N'ضضض', N'6f94621c-3508-435c-98fe-c51cc63d076f', 0)
INSERT [dbo].[Currencies] ([Currencies_Id], [CurrenName], [CurreType], [CurreSymbol], [CrreChangeName], [system_Users], [CurrStatus]) VALUES (39, N'يمني جنوبي', N'اجنبي', N'ي', N'ريول', N'6f94621c-3508-435c-98fe-c51cc63d076f', 0)
SET IDENTITY_INSERT [dbo].[Currencies] OFF
SET IDENTITY_INSERT [dbo].[Currencies_Exchange_Rate] ON 

INSERT [dbo].[Currencies_Exchange_Rate] ([Currencies_Exchange_Rate_Id], [CurreExchangeRate], [CurreExchangeDate], [CurreExhhangeStatus], [system_users], [currencies]) VALUES (3, 1, CAST(N'2022-10-10T00:00:00.000' AS DateTime), 1, N'6f94621c-3508-435c-98fe-c51cc63d076f', 14)
INSERT [dbo].[Currencies_Exchange_Rate] ([Currencies_Exchange_Rate_Id], [CurreExchangeRate], [CurreExchangeDate], [CurreExhhangeStatus], [system_users], [currencies]) VALUES (4, 158, CAST(N'2022-10-10T00:00:00.000' AS DateTime), 1, N'6f94621c-3508-435c-98fe-c51cc63d076f', 17)
INSERT [dbo].[Currencies_Exchange_Rate] ([Currencies_Exchange_Rate_Id], [CurreExchangeRate], [CurreExchangeDate], [CurreExhhangeStatus], [system_users], [currencies]) VALUES (5, 575, CAST(N'2022-10-10T00:00:00.000' AS DateTime), 1, N'6f94621c-3508-435c-98fe-c51cc63d076f', 20)
INSERT [dbo].[Currencies_Exchange_Rate] ([Currencies_Exchange_Rate_Id], [CurreExchangeRate], [CurreExchangeDate], [CurreExhhangeStatus], [system_users], [currencies]) VALUES (6, 30, CAST(N'2022-10-10T00:00:00.000' AS DateTime), 1, N'6f94621c-3508-435c-98fe-c51cc63d076f', 26)
INSERT [dbo].[Currencies_Exchange_Rate] ([Currencies_Exchange_Rate_Id], [CurreExchangeRate], [CurreExchangeDate], [CurreExhhangeStatus], [system_users], [currencies]) VALUES (7, 160, CAST(N'2022-10-10T00:00:00.000' AS DateTime), 1, N'6f94621c-3508-435c-98fe-c51cc63d076f', 25)
INSERT [dbo].[Currencies_Exchange_Rate] ([Currencies_Exchange_Rate_Id], [CurreExchangeRate], [CurreExchangeDate], [CurreExhhangeStatus], [system_users], [currencies]) VALUES (8, 605, CAST(N'2022-02-20T00:00:00.000' AS DateTime), 1, NULL, 24)
SET IDENTITY_INSERT [dbo].[Currencies_Exchange_Rate] OFF
SET IDENTITY_INSERT [dbo].[Detailed_Expens_Voucher] ON 

INSERT [dbo].[Detailed_Expens_Voucher] ([Detailed_Expens_Voucher_Id], [main_expens_voucher_number], [DetailedExpensVoucherAmount_RLY], [DetailedExpensVoucherAmount_UDO], [DetailedExpensVoucherAmountDescription], [DebitChildAccount]) VALUES (4, N'EX00001', 5000, NULL, N'صرف للغالي', N'1112')
INSERT [dbo].[Detailed_Expens_Voucher] ([Detailed_Expens_Voucher_Id], [main_expens_voucher_number], [DetailedExpensVoucherAmount_RLY], [DetailedExpensVoucherAmount_UDO], [DetailedExpensVoucherAmountDescription], [DebitChildAccount]) VALUES (6, N'EX00002', 59900, NULL, N'صرف للغالي', N'1131')
INSERT [dbo].[Detailed_Expens_Voucher] ([Detailed_Expens_Voucher_Id], [main_expens_voucher_number], [DetailedExpensVoucherAmount_RLY], [DetailedExpensVoucherAmount_UDO], [DetailedExpensVoucherAmountDescription], [DebitChildAccount]) VALUES (8, N'EX00003', 500, NULL, N'صرف للغالي', N'1132')
INSERT [dbo].[Detailed_Expens_Voucher] ([Detailed_Expens_Voucher_Id], [main_expens_voucher_number], [DetailedExpensVoucherAmount_RLY], [DetailedExpensVoucherAmount_UDO], [DetailedExpensVoucherAmountDescription], [DebitChildAccount]) VALUES (9, N'EX00003', 5000, NULL, N'صرف للشيخ', N'1131')
INSERT [dbo].[Detailed_Expens_Voucher] ([Detailed_Expens_Voucher_Id], [main_expens_voucher_number], [DetailedExpensVoucherAmount_RLY], [DetailedExpensVoucherAmount_UDO], [DetailedExpensVoucherAmountDescription], [DebitChildAccount]) VALUES (16, N'EX00005', 600, NULL, N'صرف للغالي', N'1131')
INSERT [dbo].[Detailed_Expens_Voucher] ([Detailed_Expens_Voucher_Id], [main_expens_voucher_number], [DetailedExpensVoucherAmount_RLY], [DetailedExpensVoucherAmount_UDO], [DetailedExpensVoucherAmountDescription], [DebitChildAccount]) VALUES (17, N'EX00005', 500, NULL, N'صرف للشيخ', N'1134')
INSERT [dbo].[Detailed_Expens_Voucher] ([Detailed_Expens_Voucher_Id], [main_expens_voucher_number], [DetailedExpensVoucherAmount_RLY], [DetailedExpensVoucherAmount_UDO], [DetailedExpensVoucherAmountDescription], [DebitChildAccount]) VALUES (18, N'EX00004', 700, NULL, N'صرف للغالي', N'1131')
INSERT [dbo].[Detailed_Expens_Voucher] ([Detailed_Expens_Voucher_Id], [main_expens_voucher_number], [DetailedExpensVoucherAmount_RLY], [DetailedExpensVoucherAmount_UDO], [DetailedExpensVoucherAmountDescription], [DebitChildAccount]) VALUES (19, N'EX00004', 500, NULL, N'صرف للشبخ علي', N'1132')
SET IDENTITY_INSERT [dbo].[Detailed_Expens_Voucher] OFF
SET IDENTITY_INSERT [dbo].[Detailed_Journal_Enteries] ON 

INSERT [dbo].[Detailed_Journal_Enteries] ([Detailed_Journal_Enteries_Id], [main_journal_enteries], [DetailedournalDescription], [currencies], [DebitChildAccount], [CreditChildAccount], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmount_UDO], [DebittAmount_UDO], [currencies_exchange_rate]) VALUES (1, 3, NULL, 17, NULL, N'1111', 1185000, NULL, 7500, NULL, 4)
INSERT [dbo].[Detailed_Journal_Enteries] ([Detailed_Journal_Enteries_Id], [main_journal_enteries], [DetailedournalDescription], [currencies], [DebitChildAccount], [CreditChildAccount], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmount_UDO], [DebittAmount_UDO], [currencies_exchange_rate]) VALUES (2, 3, NULL, 17, NULL, N'1111', NULL, 1185000, NULL, 7500, 4)
INSERT [dbo].[Detailed_Journal_Enteries] ([Detailed_Journal_Enteries_Id], [main_journal_enteries], [DetailedournalDescription], [currencies], [DebitChildAccount], [CreditChildAccount], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmount_UDO], [DebittAmount_UDO], [currencies_exchange_rate]) VALUES (3, 4, NULL, 17, NULL, N'1111', 9000, NULL, 7500, NULL, 4)
INSERT [dbo].[Detailed_Journal_Enteries] ([Detailed_Journal_Enteries_Id], [main_journal_enteries], [DetailedournalDescription], [currencies], [DebitChildAccount], [CreditChildAccount], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmount_UDO], [DebittAmount_UDO], [currencies_exchange_rate]) VALUES (4, 4, NULL, 17, NULL, N'1111', NULL, 1185000, NULL, 7500, 4)
INSERT [dbo].[Detailed_Journal_Enteries] ([Detailed_Journal_Enteries_Id], [main_journal_enteries], [DetailedournalDescription], [currencies], [DebitChildAccount], [CreditChildAccount], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmount_UDO], [DebittAmount_UDO], [currencies_exchange_rate]) VALUES (5, 5, NULL, 14, NULL, N'1134', NULL, 90000, NULL, NULL, 3)
INSERT [dbo].[Detailed_Journal_Enteries] ([Detailed_Journal_Enteries_Id], [main_journal_enteries], [DetailedournalDescription], [currencies], [DebitChildAccount], [CreditChildAccount], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmount_UDO], [DebittAmount_UDO], [currencies_exchange_rate]) VALUES (6, 5, NULL, 14, NULL, N'1135', 90000, NULL, NULL, NULL, 3)
INSERT [dbo].[Detailed_Journal_Enteries] ([Detailed_Journal_Enteries_Id], [main_journal_enteries], [DetailedournalDescription], [currencies], [DebitChildAccount], [CreditChildAccount], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmount_UDO], [DebittAmount_UDO], [currencies_exchange_rate]) VALUES (7, 6, N'sadasds', 14, NULL, N'1134', NULL, 9000, NULL, NULL, 3)
INSERT [dbo].[Detailed_Journal_Enteries] ([Detailed_Journal_Enteries_Id], [main_journal_enteries], [DetailedournalDescription], [currencies], [DebitChildAccount], [CreditChildAccount], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmount_UDO], [DebittAmount_UDO], [currencies_exchange_rate]) VALUES (8, 6, N'fefeergeggr', 14, NULL, N'1135', 9000, NULL, NULL, NULL, 3)
INSERT [dbo].[Detailed_Journal_Enteries] ([Detailed_Journal_Enteries_Id], [main_journal_enteries], [DetailedournalDescription], [currencies], [DebitChildAccount], [CreditChildAccount], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmount_UDO], [DebittAmount_UDO], [currencies_exchange_rate]) VALUES (9, 7, N'EHFKEBFF', 20, NULL, N'1135', 0, 575, NULL, 1, 5)
INSERT [dbo].[Detailed_Journal_Enteries] ([Detailed_Journal_Enteries_Id], [main_journal_enteries], [DetailedournalDescription], [currencies], [DebitChildAccount], [CreditChildAccount], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmount_UDO], [DebittAmount_UDO], [currencies_exchange_rate]) VALUES (10, 7, NULL, 20, NULL, N'1134', 575, NULL, 1, NULL, 5)
INSERT [dbo].[Detailed_Journal_Enteries] ([Detailed_Journal_Enteries_Id], [main_journal_enteries], [DetailedournalDescription], [currencies], [DebitChildAccount], [CreditChildAccount], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmount_UDO], [DebittAmount_UDO], [currencies_exchange_rate]) VALUES (11, 8, N'HJJHHFDT', 14, NULL, N'1111', NULL, 9000, NULL, NULL, 3)
INSERT [dbo].[Detailed_Journal_Enteries] ([Detailed_Journal_Enteries_Id], [main_journal_enteries], [DetailedournalDescription], [currencies], [DebitChildAccount], [CreditChildAccount], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmount_UDO], [DebittAmount_UDO], [currencies_exchange_rate]) VALUES (12, 8, N'bjhvhfdtd', 14, NULL, N'1134', 9000, NULL, NULL, NULL, 3)
SET IDENTITY_INSERT [dbo].[Detailed_Journal_Enteries] OFF
SET IDENTITY_INSERT [dbo].[Detailed_PayCheck] ON 

INSERT [dbo].[Detailed_PayCheck] ([Detailed_PayCheck_Id], [main_paycheck], [DetailedPaycheckAmount_RLY], [DetailedPaycheckAmount_UDO], [DetailedPaycheckrDescription], [CreditChildAccount]) VALUES (1, N'PY00001', 72, NULL, N'قبض من القلب', N'1111')
INSERT [dbo].[Detailed_PayCheck] ([Detailed_PayCheck_Id], [main_paycheck], [DetailedPaycheckAmount_RLY], [DetailedPaycheckAmount_UDO], [DetailedPaycheckrDescription], [CreditChildAccount]) VALUES (2, N'PY00001', 78, NULL, N'قبص من صاحبي', N'1112')
INSERT [dbo].[Detailed_PayCheck] ([Detailed_PayCheck_Id], [main_paycheck], [DetailedPaycheckAmount_RLY], [DetailedPaycheckAmount_UDO], [DetailedPaycheckrDescription], [CreditChildAccount]) VALUES (5, N'PY00003', 450, NULL, N'قبض من القلب', N'1112')
INSERT [dbo].[Detailed_PayCheck] ([Detailed_PayCheck_Id], [main_paycheck], [DetailedPaycheckAmount_RLY], [DetailedPaycheckAmount_UDO], [DetailedPaycheckrDescription], [CreditChildAccount]) VALUES (6, N'PY00003', 450, NULL, N'قبص من صاحبي', N'1113')
INSERT [dbo].[Detailed_PayCheck] ([Detailed_PayCheck_Id], [main_paycheck], [DetailedPaycheckAmount_RLY], [DetailedPaycheckAmount_UDO], [DetailedPaycheckrDescription], [CreditChildAccount]) VALUES (7, N'PY00004', 1000, NULL, N'قبض من القلب', N'1112')
INSERT [dbo].[Detailed_PayCheck] ([Detailed_PayCheck_Id], [main_paycheck], [DetailedPaycheckAmount_RLY], [DetailedPaycheckAmount_UDO], [DetailedPaycheckrDescription], [CreditChildAccount]) VALUES (24, N'PY00005', 500, NULL, N'قبض من القلب', N'1112')
INSERT [dbo].[Detailed_PayCheck] ([Detailed_PayCheck_Id], [main_paycheck], [DetailedPaycheckAmount_RLY], [DetailedPaycheckAmount_UDO], [DetailedPaycheckrDescription], [CreditChildAccount]) VALUES (25, N'PY00006', 300000, NULL, N'قبض من القلب', N'1112')
INSERT [dbo].[Detailed_PayCheck] ([Detailed_PayCheck_Id], [main_paycheck], [DetailedPaycheckAmount_RLY], [DetailedPaycheckAmount_UDO], [DetailedPaycheckrDescription], [CreditChildAccount]) VALUES (26, N'PY00006', 300000, NULL, N'قبص من صاحبي', N'1111')
INSERT [dbo].[Detailed_PayCheck] ([Detailed_PayCheck_Id], [main_paycheck], [DetailedPaycheckAmount_RLY], [DetailedPaycheckAmount_UDO], [DetailedPaycheckrDescription], [CreditChildAccount]) VALUES (27, N'PY00002', 3000, NULL, N'قبض من القلب', N'1112')
INSERT [dbo].[Detailed_PayCheck] ([Detailed_PayCheck_Id], [main_paycheck], [DetailedPaycheckAmount_RLY], [DetailedPaycheckAmount_UDO], [DetailedPaycheckrDescription], [CreditChildAccount]) VALUES (28, N'PY00002', 1000, NULL, N'قبص من صاحبي', N'1113')
INSERT [dbo].[Detailed_PayCheck] ([Detailed_PayCheck_Id], [main_paycheck], [DetailedPaycheckAmount_RLY], [DetailedPaycheckAmount_UDO], [DetailedPaycheckrDescription], [CreditChildAccount]) VALUES (29, N'PY00002', 1000, NULL, N'قبض الفلوس', N'1112')
INSERT [dbo].[Detailed_PayCheck] ([Detailed_PayCheck_Id], [main_paycheck], [DetailedPaycheckAmount_RLY], [DetailedPaycheckAmount_UDO], [DetailedPaycheckrDescription], [CreditChildAccount]) VALUES (30, N'PY00007', 6000, NULL, N'قبض من القلب', N'1112')
INSERT [dbo].[Detailed_PayCheck] ([Detailed_PayCheck_Id], [main_paycheck], [DetailedPaycheckAmount_RLY], [DetailedPaycheckAmount_UDO], [DetailedPaycheckrDescription], [CreditChildAccount]) VALUES (31, N'PY00007', 10000, NULL, N'قبص من صاحبي', N'1111')
INSERT [dbo].[Detailed_PayCheck] ([Detailed_PayCheck_Id], [main_paycheck], [DetailedPaycheckAmount_RLY], [DetailedPaycheckAmount_UDO], [DetailedPaycheckrDescription], [CreditChildAccount]) VALUES (33, N'PY00008', 39330, NULL, N'قبض من القلب', N'1131')
SET IDENTITY_INSERT [dbo].[Detailed_PayCheck] OFF
INSERT [dbo].[Final_Account_Type] ([Final_Account_Type_Id], [FinAccType]) VALUES (1, N'الميزانية العمومية')
INSERT [dbo].[Final_Account_Type] ([Final_Account_Type_Id], [FinAccType]) VALUES (2, N'ارباح و خسائر')
SET IDENTITY_INSERT [dbo].[Fiscal_Year] ON 

INSERT [dbo].[Fiscal_Year] ([Fiscal_Year_Id], [StartDate], [EndDate], [FiscalYearName], [FiscalYearStatus], [system_Users]) VALUES (7, CAST(N'2017-02-06' AS Date), CAST(N'2022-12-31' AS Date), N'2022', 0, N'6f94621c-3508-435c-98fe-c51cc63d076f')
INSERT [dbo].[Fiscal_Year] ([Fiscal_Year_Id], [StartDate], [EndDate], [FiscalYearName], [FiscalYearStatus], [system_Users]) VALUES (10, CAST(N'2022-10-17' AS Date), CAST(N'2023-10-17' AS Date), N'2024', 0, N'6f94621c-3508-435c-98fe-c51cc63d076f')
INSERT [dbo].[Fiscal_Year] ([Fiscal_Year_Id], [StartDate], [EndDate], [FiscalYearName], [FiscalYearStatus], [system_Users]) VALUES (11, CAST(N'2023-08-30' AS Date), CAST(N'2025-11-30' AS Date), N'2025', 0, N'6f94621c-3508-435c-98fe-c51cc63d076f')
INSERT [dbo].[Fiscal_Year] ([Fiscal_Year_Id], [StartDate], [EndDate], [FiscalYearName], [FiscalYearStatus], [system_Users]) VALUES (12, CAST(N'2025-02-07' AS Date), CAST(N'2026-03-07' AS Date), N'2025', 1, N'6f94621c-3508-435c-98fe-c51cc63d076f')
INSERT [dbo].[Fiscal_Year] ([Fiscal_Year_Id], [StartDate], [EndDate], [FiscalYearName], [FiscalYearStatus], [system_Users]) VALUES (13, CAST(N'2025-07-17' AS Date), CAST(N'2026-08-19' AS Date), N'2026', 0, N'6f94621c-3508-435c-98fe-c51cc63d076f')
SET IDENTITY_INSERT [dbo].[Fiscal_Year] OFF
INSERT [dbo].[Funds] ([Funds_Id], [FundName], [FundStatus], [sub_accounting_manual], [system_Users]) VALUES (1111, N'الصندوق الرئيسي', 0, N'1111', N'6f94621c-3508-435c-98fe-c51cc63d076f')
INSERT [dbo].[Funds] ([Funds_Id], [FundName], [FundStatus], [sub_accounting_manual], [system_Users]) VALUES (1112, N'صندوق رقم 3', 0, N'1112', N'6f94621c-3508-435c-98fe-c51cc63d076f')
INSERT [dbo].[Funds] ([Funds_Id], [FundName], [FundStatus], [sub_accounting_manual], [system_Users]) VALUES (1113, N'صندوق رقم 2', 1, N'1113', N'6f94621c-3508-435c-98fe-c51cc63d076f')
INSERT [dbo].[Funds] ([Funds_Id], [FundName], [FundStatus], [sub_accounting_manual], [system_Users]) VALUES (1114, N'صندوق تجريبي', 0, N'1114', N'6f94621c-3508-435c-98fe-c51cc63d076f')
INSERT [dbo].[Funds] ([Funds_Id], [FundName], [FundStatus], [sub_accounting_manual], [system_Users]) VALUES (1115, N'صندوق شهاب 77', 1, N'1115', N'6f94621c-3508-435c-98fe-c51cc63d076f')
SET IDENTITY_INSERT [dbo].[General_Ledger] ON 

INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (3, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1111', 20, 5, 1, CAST(N'2022-10-08T10:30:30.210' AS DateTime), NULL, 150, NULL, NULL, N'قبض نقد', NULL, NULL, N'PY00001', NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (4, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1111', 20, 5, 1, CAST(N'2022-10-08T10:30:30.210' AS DateTime), 72, NULL, NULL, NULL, N'قبض نقد', NULL, NULL, N'PY00001', NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (5, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1112', 20, 5, 1, CAST(N'2022-10-08T10:30:30.210' AS DateTime), 78, NULL, NULL, NULL, N'قبض نقد', NULL, NULL, N'PY00001', NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (6, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1111', 17, 4, 1, CAST(N'2022-10-08T10:34:35.330' AS DateTime), 5000, NULL, NULL, NULL, N'صرف نقد', N'EX00001', NULL, NULL, NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (7, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1112', 17, 4, 1, CAST(N'2022-10-08T10:34:35.330' AS DateTime), NULL, 5000, NULL, NULL, N'صرف نقد', N'EX00001', NULL, NULL, NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (8, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1111', 17, 4, 0, CAST(N'2022-10-08T10:44:18.023' AS DateTime), 1185000, NULL, 7500, NULL, N'قيد يومي', NULL, 3, NULL, NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (9, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1111', 17, 4, 1, CAST(N'2022-10-12T07:53:49.567' AS DateTime), NULL, 900, NULL, NULL, N'قبض نقد', NULL, NULL, N'PY00003', NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (10, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1112', 17, 4, 1, CAST(N'2022-10-12T07:53:49.567' AS DateTime), 450, NULL, NULL, NULL, N'قبض نقد', NULL, NULL, N'PY00003', NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (11, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1113', 17, 4, 1, CAST(N'2022-10-12T07:53:49.567' AS DateTime), 450, NULL, NULL, NULL, N'قبض نقد', NULL, NULL, N'PY00003', NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (14, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1112', 25, 7, 1, CAST(N'2022-10-12T12:52:15.297' AS DateTime), NULL, 500, NULL, NULL, N'قبض نقد', NULL, NULL, N'PY00005', NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (15, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1112', 25, 7, 1, CAST(N'2022-10-12T12:52:15.300' AS DateTime), 500, NULL, NULL, NULL, N'قبض نقد', NULL, NULL, N'PY00005', NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (16, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1111', 20, 5, 1, CAST(N'2022-10-13T03:04:15.620' AS DateTime), NULL, 600000, NULL, 1000, N'قبض نقد', NULL, NULL, N'PY00006', NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (17, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1112', 20, 5, 1, CAST(N'2022-10-13T03:04:15.620' AS DateTime), 300000, NULL, NULL, NULL, N'قبض نقد', NULL, NULL, N'PY00006', NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (18, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1111', 20, 5, 1, CAST(N'2022-10-13T03:04:15.620' AS DateTime), 300000, NULL, NULL, NULL, N'قبض نقد', NULL, NULL, N'PY00006', NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (19, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1112', 25, 7, 1, CAST(N'2022-10-13T05:47:26.273' AS DateTime), NULL, 16000, NULL, 100, N'قبض نقد', NULL, NULL, N'PY00007', NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (20, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1112', 25, 7, 1, CAST(N'2022-10-13T05:47:26.273' AS DateTime), 6000, NULL, NULL, NULL, N'قبض نقد', NULL, NULL, N'PY00007', NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (21, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1111', 25, 7, 1, CAST(N'2022-10-13T05:47:26.273' AS DateTime), 10000, NULL, NULL, NULL, N'قبض نقد', NULL, NULL, N'PY00007', NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (22, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1112', 25, 7, 1, CAST(N'2022-10-14T09:16:49.873' AS DateTime), NULL, 39330, NULL, NULL, N'قبض نقد', NULL, NULL, N'PY00008', NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (23, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1131', 25, 7, 1, CAST(N'2022-10-14T09:16:49.880' AS DateTime), 39330, NULL, NULL, NULL, N'قبض نقد', NULL, NULL, N'PY00008', NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (26, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1111', 20, 5, 1, CAST(N'2022-10-16T14:31:03.080' AS DateTime), 59900, NULL, NULL, NULL, N'صرف نقد', N'EX00002', NULL, NULL, NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (27, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1131', 20, 5, 1, CAST(N'2022-10-16T14:31:03.087' AS DateTime), NULL, 59900, NULL, NULL, N'صرف نقد', N'EX00002', NULL, NULL, NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (31, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1111', 20, 5, 1, CAST(N'2022-10-16T14:42:52.070' AS DateTime), 5500, NULL, NULL, NULL, N'صرف نقد', N'EX00003', NULL, NULL, NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (32, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1132', 20, 5, 1, CAST(N'2022-10-16T14:42:52.073' AS DateTime), NULL, 500, NULL, NULL, N'صرف نقد', N'EX00003', NULL, NULL, NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (33, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1131', 20, 5, 1, CAST(N'2022-10-16T14:42:52.073' AS DateTime), NULL, 5000, NULL, NULL, N'صرف نقد', N'EX00003', NULL, NULL, NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (34, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1122', 26, 6, 1, CAST(N'2022-10-16T15:45:50.910' AS DateTime), NULL, 500, NULL, NULL, N'قبض شيك', NULL, NULL, NULL, NULL, N'CP00001')
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (35, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1131', 26, 6, 1, CAST(N'2022-10-16T15:45:50.910' AS DateTime), 500, NULL, NULL, NULL, N'قبض شيك', NULL, NULL, NULL, NULL, N'CP00001')
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (36, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1122', 14, 3, 1, CAST(N'2022-10-16T16:17:21.473' AS DateTime), 9000, NULL, NULL, NULL, N'صرف شيك', NULL, NULL, NULL, N'CX00001', NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (37, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1131', 14, 3, 1, CAST(N'2022-10-16T16:17:21.480' AS DateTime), NULL, 9000, NULL, NULL, N'صرف شيك', NULL, NULL, NULL, N'CX00001', NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (38, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1122', 25, 7, 1, CAST(N'2022-10-16T16:33:39.847' AS DateTime), 7999, NULL, NULL, NULL, N'صرف شيك', NULL, NULL, NULL, N'CX00002', NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (39, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1132', 25, 7, 1, CAST(N'2022-10-16T16:33:39.847' AS DateTime), NULL, 7999, NULL, NULL, N'صرف شيك', NULL, NULL, NULL, N'CX00002', NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (40, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1122', 25, 7, 1, CAST(N'2022-10-16T16:41:27.610' AS DateTime), 7999, NULL, NULL, NULL, N'صرف شيك', NULL, NULL, NULL, N'CX00002', NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (41, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1132', 25, 7, 1, CAST(N'2022-10-16T16:41:27.613' AS DateTime), NULL, 7999, NULL, NULL, N'صرف شيك', NULL, NULL, NULL, N'CX00002', NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (42, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1122', 25, 7, 1, CAST(N'2022-10-16T16:43:37.557' AS DateTime), 7999, NULL, NULL, NULL, N'صرف شيك', NULL, NULL, NULL, N'CX00002', NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (43, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1132', 25, 7, 1, CAST(N'2022-10-16T16:43:37.557' AS DateTime), NULL, 7999, NULL, NULL, N'صرف شيك', NULL, NULL, NULL, N'CX00002', NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (44, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1122', 25, 7, 1, CAST(N'2022-10-17T05:42:03.750' AS DateTime), NULL, 10000, NULL, NULL, N'قبض شيك', NULL, NULL, NULL, NULL, N'CP00002')
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (45, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1132', 25, 7, 1, CAST(N'2022-10-17T05:42:03.750' AS DateTime), 10000, NULL, NULL, NULL, N'قبض شيك', NULL, NULL, NULL, NULL, N'CP00002')
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (46, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1111', 20, 5, 1, CAST(N'2022-10-17T05:46:27.817' AS DateTime), 5500, NULL, NULL, NULL, N'صرف نقد', N'EX00003', NULL, NULL, NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (47, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1132', 20, 5, 1, CAST(N'2022-10-17T05:46:27.817' AS DateTime), NULL, 500, NULL, NULL, N'صرف نقد', N'EX00003', NULL, NULL, NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (48, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1131', 20, 5, 1, CAST(N'2022-10-17T05:46:27.817' AS DateTime), NULL, 5000, NULL, NULL, N'صرف نقد', N'EX00003', NULL, NULL, NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (49, N'6f94621c-3508-435c-98fe-c51cc63d076f', NULL, N'1111', 17, 4, 0, CAST(N'2022-10-17T08:28:24.857' AS DateTime), 9000, NULL, 7500, NULL, N'قيد يومي', NULL, 4, NULL, NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (50, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1122', 14, 3, 1, CAST(N'2022-10-17T11:04:52.117' AS DateTime), NULL, 10000, NULL, NULL, N'قبض شيك', NULL, NULL, NULL, NULL, N'CP00003')
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (51, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1131', 14, 3, 1, CAST(N'2022-10-17T11:04:52.117' AS DateTime), 10000, NULL, NULL, NULL, N'قبض شيك', NULL, NULL, NULL, NULL, N'CP00003')
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (52, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1112', 26, 6, 1, CAST(N'2022-10-17T12:35:16.273' AS DateTime), NULL, 5000, NULL, NULL, N'قبض نقد', NULL, NULL, N'PY00002', NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (53, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1112', 26, 6, 1, CAST(N'2022-10-17T12:35:16.273' AS DateTime), 3000, NULL, NULL, NULL, N'قبض نقد', NULL, NULL, N'PY00002', NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (54, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1113', 26, 6, 1, CAST(N'2022-10-17T12:35:16.273' AS DateTime), 1000, NULL, NULL, NULL, N'قبض نقد', NULL, NULL, N'PY00002', NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (55, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1112', 26, 6, 1, CAST(N'2022-10-17T12:35:16.273' AS DateTime), 1000, NULL, NULL, NULL, N'قبض نقد', NULL, NULL, N'PY00002', NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (56, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1122', 14, 3, 1, CAST(N'2022-10-17T12:46:02.647' AS DateTime), 88000, NULL, NULL, NULL, N'صرف شيك', NULL, NULL, NULL, N'CX00004', NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (57, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1131', 14, 3, 1, CAST(N'2022-10-17T12:46:02.647' AS DateTime), NULL, 88000, NULL, NULL, N'صرف شيك', NULL, NULL, NULL, N'CX00004', NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (58, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1111', 20, 5, 1, CAST(N'2022-10-17T15:04:10.557' AS DateTime), 1100, NULL, NULL, NULL, N'صرف نقد', N'EX00005', NULL, NULL, NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (59, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1131', 20, 5, 1, CAST(N'2022-10-17T15:04:10.557' AS DateTime), NULL, 600, NULL, NULL, N'صرف نقد', N'EX00005', NULL, NULL, NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (60, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1134', 20, 5, 1, CAST(N'2022-10-17T15:04:10.557' AS DateTime), NULL, 500, NULL, NULL, N'صرف نقد', N'EX00005', NULL, NULL, NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (61, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1122', 14, 3, 1, CAST(N'2022-10-17T15:06:04.627' AS DateTime), 177000, NULL, NULL, NULL, N'صرف شيك', NULL, NULL, NULL, N'CX00006', NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (62, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1131', 14, 3, 1, CAST(N'2022-10-17T15:06:04.630' AS DateTime), NULL, 177000, NULL, NULL, N'صرف شيك', NULL, NULL, NULL, N'CX00006', NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (63, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1122', 25, 7, 1, CAST(N'2022-10-17T15:06:32.587' AS DateTime), NULL, 117700, NULL, NULL, N'قبض شيك', NULL, NULL, NULL, NULL, N'CP00004')
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (64, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1131', 25, 7, 1, CAST(N'2022-10-17T15:06:32.590' AS DateTime), 117700, NULL, NULL, NULL, N'قبض شيك', NULL, NULL, NULL, NULL, N'CP00004')
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (65, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1112', 25, 7, 1, CAST(N'2023-05-08T05:29:56.360' AS DateTime), NULL, 500, NULL, NULL, N'??? ???', NULL, NULL, N'PY00005', NULL, NULL)
INSERT [dbo].[General_Ledger] ([General_Ledger_Id], [system_Users], [fiscal_year], [accounting_manual], [currencies], [currencies_exchange_rate], [Transaction_Is_Stage], [GenLedgerDateTime], [CreditAmount_RLY], [DebittAmount_RLY], [CreditAmountWith_TransCurre], [DebitAmountWith_TransCurre], [TransactionName], [Main_Expens_Voucher_Number], [Main_Journal_Enteries_id], [Main_PayCheck_Number], [Check_ExpensVoucher_Number], [Check_PayCheckVoucher_Number]) VALUES (66, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, N'1112', 25, 7, 1, CAST(N'2023-05-08T05:29:56.360' AS DateTime), 500, NULL, NULL, NULL, N'??? ???', NULL, NULL, N'PY00005', NULL, NULL)
SET IDENTITY_INSERT [dbo].[General_Ledger] OFF
INSERT [dbo].[Journal_Enterie_Types] ([Journal_Enterie_Types_Id], [JournalEnteryName]) VALUES (1, N'قيد بسيط')
INSERT [dbo].[Journal_Enterie_Types] ([Journal_Enterie_Types_Id], [JournalEnteryName]) VALUES (2, N'قيد مزودج')
INSERT [dbo].[Journal_Enterie_Types] ([Journal_Enterie_Types_Id], [JournalEnteryName]) VALUES (3, N'قيد تسوية')
INSERT [dbo].[Main_Expens_Voucher] ([Main_ExpensVoucher_Number], [currencies_exchange_rate], [system_users], [fiscal_year], [funds], [currencies], [MainExpensVoucherStatus], [MainExpensVoucherAmount_RLY], [MainExpensVoucherAmount_UDO], [ReferenceNumber], [MainExpensVoucherDate], [IsDelete]) VALUES (N'EX00001', 4, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, 1111, 17, 1, 5000, NULL, 2, CAST(N'2022-10-19T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Main_Expens_Voucher] ([Main_ExpensVoucher_Number], [currencies_exchange_rate], [system_users], [fiscal_year], [funds], [currencies], [MainExpensVoucherStatus], [MainExpensVoucherAmount_RLY], [MainExpensVoucherAmount_UDO], [ReferenceNumber], [MainExpensVoucherDate], [IsDelete]) VALUES (N'EX00002', 5, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, 1111, 20, 1, 59900, NULL, 2, CAST(N'2022-10-15T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Main_Expens_Voucher] ([Main_ExpensVoucher_Number], [currencies_exchange_rate], [system_users], [fiscal_year], [funds], [currencies], [MainExpensVoucherStatus], [MainExpensVoucherAmount_RLY], [MainExpensVoucherAmount_UDO], [ReferenceNumber], [MainExpensVoucherDate], [IsDelete]) VALUES (N'EX00003', 5, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, 1111, 20, 1, 5500, NULL, 2, CAST(N'2022-10-15T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Main_Expens_Voucher] ([Main_ExpensVoucher_Number], [currencies_exchange_rate], [system_users], [fiscal_year], [funds], [currencies], [MainExpensVoucherStatus], [MainExpensVoucherAmount_RLY], [MainExpensVoucherAmount_UDO], [ReferenceNumber], [MainExpensVoucherDate], [IsDelete]) VALUES (N'EX00004', 5, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, 1111, 20, 0, 1200, NULL, 2, CAST(N'2022-10-17T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Main_Expens_Voucher] ([Main_ExpensVoucher_Number], [currencies_exchange_rate], [system_users], [fiscal_year], [funds], [currencies], [MainExpensVoucherStatus], [MainExpensVoucherAmount_RLY], [MainExpensVoucherAmount_UDO], [ReferenceNumber], [MainExpensVoucherDate], [IsDelete]) VALUES (N'EX00005', 5, N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, 1111, 20, 1, 1100, NULL, 3, CAST(N'2022-10-17T00:00:00.000' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Main_Journal_Enteries] ON 

INSERT [dbo].[Main_Journal_Enteries] ([Main_Journal_Enteries_Id], [Main_Joural_Ent_Number], [journal_enterie_types], [fiscal_year], [MainJournalEnteriesAmount], [MainournalEnteriesStatus], [MainJournalReferenceNumber], [MainJournalDateTime], [MainPaycheckGlobalNote], [isStage], [isDeleted], [system_users]) VALUES (3, N'1', NULL, 7, 1185000, 0, 0, CAST(N'2022-10-08T10:43:24.143' AS DateTime), NULL, 1, 0, N'6f94621c-3508-435c-98fe-c51cc63d076f')
INSERT [dbo].[Main_Journal_Enteries] ([Main_Journal_Enteries_Id], [Main_Joural_Ent_Number], [journal_enterie_types], [fiscal_year], [MainJournalEnteriesAmount], [MainournalEnteriesStatus], [MainJournalReferenceNumber], [MainJournalDateTime], [MainPaycheckGlobalNote], [isStage], [isDeleted], [system_users]) VALUES (4, N'2', NULL, 7, 1185000, 0, 0, CAST(N'2022-10-08T10:43:24.143' AS DateTime), NULL, 1, 0, N'6f94621c-3508-435c-98fe-c51cc63d076f')
INSERT [dbo].[Main_Journal_Enteries] ([Main_Journal_Enteries_Id], [Main_Joural_Ent_Number], [journal_enterie_types], [fiscal_year], [MainJournalEnteriesAmount], [MainournalEnteriesStatus], [MainJournalReferenceNumber], [MainJournalDateTime], [MainPaycheckGlobalNote], [isStage], [isDeleted], [system_users]) VALUES (5, N'3', 1, 7, 90000, 0, 78778978, CAST(N'2023-05-08T05:04:06.830' AS DateTime), N'dhdherheh', 0, 0, N'6f94621c-3508-435c-98fe-c51cc63d076f')
INSERT [dbo].[Main_Journal_Enteries] ([Main_Journal_Enteries_Id], [Main_Joural_Ent_Number], [journal_enterie_types], [fiscal_year], [MainJournalEnteriesAmount], [MainournalEnteriesStatus], [MainJournalReferenceNumber], [MainJournalDateTime], [MainPaycheckGlobalNote], [isStage], [isDeleted], [system_users]) VALUES (6, N'4', 2, 7, 9000, 0, 87675754, CAST(N'2023-05-08T05:11:36.897' AS DateTime), N'dhdherheh', 0, 1, N'6f94621c-3508-435c-98fe-c51cc63d076f')
INSERT [dbo].[Main_Journal_Enteries] ([Main_Journal_Enteries_Id], [Main_Joural_Ent_Number], [journal_enterie_types], [fiscal_year], [MainJournalEnteriesAmount], [MainournalEnteriesStatus], [MainJournalReferenceNumber], [MainJournalDateTime], [MainPaycheckGlobalNote], [isStage], [isDeleted], [system_users]) VALUES (7, N'4', 1, 7, 575, 0, 0, CAST(N'2023-05-12T16:57:52.923' AS DateTime), N'WEIJEFOIWHIFW', 0, 0, N'6f94621c-3508-435c-98fe-c51cc63d076f')
INSERT [dbo].[Main_Journal_Enteries] ([Main_Journal_Enteries_Id], [Main_Joural_Ent_Number], [journal_enterie_types], [fiscal_year], [MainJournalEnteriesAmount], [MainournalEnteriesStatus], [MainJournalReferenceNumber], [MainJournalDateTime], [MainPaycheckGlobalNote], [isStage], [isDeleted], [system_users]) VALUES (8, N'5', 3, 7, 9000, 0, 857564, CAST(N'2023-05-12T17:18:15.593' AS DateTime), N'FTFHFHFHGF', 0, 0, N'6f94621c-3508-435c-98fe-c51cc63d076f')
SET IDENTITY_INSERT [dbo].[Main_Journal_Enteries] OFF
INSERT [dbo].[Main_PayCheck] ([MainPaycheckNumber], [system_users], [currencies_exchange_rate], [fiscal_year], [funds], [currencies], [MainPaycheckStatus], [MainPaycheckAmount_RLY], [MainPaycheckAmount_UDO], [ReferenceNumber], [MainPaycheckDate], [IsDelete]) VALUES (N'PY00001', N'6f94621c-3508-435c-98fe-c51cc63d076f', 5, 7, 1111, 20, 1, 150, NULL, 3, CAST(N'2022-10-12T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Main_PayCheck] ([MainPaycheckNumber], [system_users], [currencies_exchange_rate], [fiscal_year], [funds], [currencies], [MainPaycheckStatus], [MainPaycheckAmount_RLY], [MainPaycheckAmount_UDO], [ReferenceNumber], [MainPaycheckDate], [IsDelete]) VALUES (N'PY00002', N'6f94621c-3508-435c-98fe-c51cc63d076f', 6, 7, 1112, 26, 1, 5000, NULL, 2, CAST(N'2022-10-17T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Main_PayCheck] ([MainPaycheckNumber], [system_users], [currencies_exchange_rate], [fiscal_year], [funds], [currencies], [MainPaycheckStatus], [MainPaycheckAmount_RLY], [MainPaycheckAmount_UDO], [ReferenceNumber], [MainPaycheckDate], [IsDelete]) VALUES (N'PY00003', N'6f94621c-3508-435c-98fe-c51cc63d076f', 4, 7, 1111, 17, 1, 900, NULL, 5, CAST(N'2022-10-25T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Main_PayCheck] ([MainPaycheckNumber], [system_users], [currencies_exchange_rate], [fiscal_year], [funds], [currencies], [MainPaycheckStatus], [MainPaycheckAmount_RLY], [MainPaycheckAmount_UDO], [ReferenceNumber], [MainPaycheckDate], [IsDelete]) VALUES (N'PY00004', N'6f94621c-3508-435c-98fe-c51cc63d076f', 4, 7, 1111, 17, 0, 1000, NULL, 2, CAST(N'2022-10-10T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Main_PayCheck] ([MainPaycheckNumber], [system_users], [currencies_exchange_rate], [fiscal_year], [funds], [currencies], [MainPaycheckStatus], [MainPaycheckAmount_RLY], [MainPaycheckAmount_UDO], [ReferenceNumber], [MainPaycheckDate], [IsDelete]) VALUES (N'PY00005', N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, 7, 1112, 25, 1, 500, NULL, NULL, CAST(N'2022-10-05T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Main_PayCheck] ([MainPaycheckNumber], [system_users], [currencies_exchange_rate], [fiscal_year], [funds], [currencies], [MainPaycheckStatus], [MainPaycheckAmount_RLY], [MainPaycheckAmount_UDO], [ReferenceNumber], [MainPaycheckDate], [IsDelete]) VALUES (N'PY00006', N'6f94621c-3508-435c-98fe-c51cc63d076f', 5, 7, 1111, 20, 1, 600000, 1000, 2, CAST(N'2022-09-15T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Main_PayCheck] ([MainPaycheckNumber], [system_users], [currencies_exchange_rate], [fiscal_year], [funds], [currencies], [MainPaycheckStatus], [MainPaycheckAmount_RLY], [MainPaycheckAmount_UDO], [ReferenceNumber], [MainPaycheckDate], [IsDelete]) VALUES (N'PY00007', N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, 7, 1112, 25, 1, 16000, 100, NULL, CAST(N'2022-10-12T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Main_PayCheck] ([MainPaycheckNumber], [system_users], [currencies_exchange_rate], [fiscal_year], [funds], [currencies], [MainPaycheckStatus], [MainPaycheckAmount_RLY], [MainPaycheckAmount_UDO], [ReferenceNumber], [MainPaycheckDate], [IsDelete]) VALUES (N'PY00008', N'6f94621c-3508-435c-98fe-c51cc63d076f', 7, 7, 1112, 25, 1, 39330, NULL, NULL, CAST(N'2022-10-14T00:00:00.000' AS DateTime), 0)
ALTER TABLE [dbo].[Accounting_Manual]  WITH CHECK ADD  CONSTRAINT [FK_Accounting_Manual_Accounting_Manual] FOREIGN KEY([ParentAccNumber])
REFERENCES [dbo].[Accounting_Manual] ([AccNumber])
GO
ALTER TABLE [dbo].[Accounting_Manual] CHECK CONSTRAINT [FK_Accounting_Manual_Accounting_Manual]
GO
ALTER TABLE [dbo].[Accounting_Manual]  WITH CHECK ADD  CONSTRAINT [FK_Accounting_Manual_Final_Account_Type] FOREIGN KEY([final_Account_Type])
REFERENCES [dbo].[Final_Account_Type] ([Final_Account_Type_Id])
GO
ALTER TABLE [dbo].[Accounting_Manual] CHECK CONSTRAINT [FK_Accounting_Manual_Final_Account_Type]
GO
ALTER TABLE [dbo].[Accounting_Manual]  WITH CHECK ADD  CONSTRAINT [FK_Accounting_Manual_Fiscal_Year] FOREIGN KEY([fiscal_Year])
REFERENCES [dbo].[Fiscal_Year] ([Fiscal_Year_Id])
GO
ALTER TABLE [dbo].[Accounting_Manual] CHECK CONSTRAINT [FK_Accounting_Manual_Fiscal_Year]
GO
ALTER TABLE [dbo].[Accounts_Currencies]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Currencies_Accounting_Manual] FOREIGN KEY([accounting_manual])
REFERENCES [dbo].[Accounting_Manual] ([AccNumber])
GO
ALTER TABLE [dbo].[Accounts_Currencies] CHECK CONSTRAINT [FK_Accounts_Currencies_Accounting_Manual]
GO
ALTER TABLE [dbo].[Accounts_Currencies]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Currencies_Currencies] FOREIGN KEY([currencies])
REFERENCES [dbo].[Currencies] ([Currencies_Id])
GO
ALTER TABLE [dbo].[Accounts_Currencies] CHECK CONSTRAINT [FK_Accounts_Currencies_Currencies]
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
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Banks]  WITH CHECK ADD  CONSTRAINT [FK_Banks_Accounting_Manual] FOREIGN KEY([sub_accounting_manual])
REFERENCES [dbo].[Accounting_Manual] ([AccNumber])
GO
ALTER TABLE [dbo].[Banks] CHECK CONSTRAINT [FK_Banks_Accounting_Manual]
GO
ALTER TABLE [dbo].[Check_Expens_Voucher]  WITH CHECK ADD  CONSTRAINT [FK_Check_Expens_Voucher_Accounting_Manual] FOREIGN KEY([DebitChildAccount])
REFERENCES [dbo].[Accounting_Manual] ([AccNumber])
GO
ALTER TABLE [dbo].[Check_Expens_Voucher] CHECK CONSTRAINT [FK_Check_Expens_Voucher_Accounting_Manual]
GO
ALTER TABLE [dbo].[Check_Expens_Voucher]  WITH CHECK ADD  CONSTRAINT [FK_Check_Expens_Voucher_Banks] FOREIGN KEY([banks])
REFERENCES [dbo].[Banks] ([Bank_Id])
GO
ALTER TABLE [dbo].[Check_Expens_Voucher] CHECK CONSTRAINT [FK_Check_Expens_Voucher_Banks]
GO
ALTER TABLE [dbo].[Check_Expens_Voucher]  WITH CHECK ADD  CONSTRAINT [FK_Check_Expens_Voucher_Currencies] FOREIGN KEY([currencies])
REFERENCES [dbo].[Currencies] ([Currencies_Id])
GO
ALTER TABLE [dbo].[Check_Expens_Voucher] CHECK CONSTRAINT [FK_Check_Expens_Voucher_Currencies]
GO
ALTER TABLE [dbo].[Check_Expens_Voucher]  WITH CHECK ADD  CONSTRAINT [FK_Check_Expens_Voucher_Currencies_Exchange_Rate] FOREIGN KEY([currencies_exchange_rate])
REFERENCES [dbo].[Currencies_Exchange_Rate] ([Currencies_Exchange_Rate_Id])
GO
ALTER TABLE [dbo].[Check_Expens_Voucher] CHECK CONSTRAINT [FK_Check_Expens_Voucher_Currencies_Exchange_Rate]
GO
ALTER TABLE [dbo].[Check_Expens_Voucher]  WITH CHECK ADD  CONSTRAINT [FK_Check_Expens_Voucher_Fiscal_Year] FOREIGN KEY([fiscal_Year])
REFERENCES [dbo].[Fiscal_Year] ([Fiscal_Year_Id])
GO
ALTER TABLE [dbo].[Check_Expens_Voucher] CHECK CONSTRAINT [FK_Check_Expens_Voucher_Fiscal_Year]
GO
ALTER TABLE [dbo].[Check_Paycheck_Voucher]  WITH CHECK ADD  CONSTRAINT [FK_Check_Paycheck_Voucher_Accounting_Manual] FOREIGN KEY([CreditChildAccount])
REFERENCES [dbo].[Accounting_Manual] ([AccNumber])
GO
ALTER TABLE [dbo].[Check_Paycheck_Voucher] CHECK CONSTRAINT [FK_Check_Paycheck_Voucher_Accounting_Manual]
GO
ALTER TABLE [dbo].[Check_Paycheck_Voucher]  WITH CHECK ADD  CONSTRAINT [FK_Check_Paycheck_Voucher_Banks] FOREIGN KEY([banks])
REFERENCES [dbo].[Banks] ([Bank_Id])
GO
ALTER TABLE [dbo].[Check_Paycheck_Voucher] CHECK CONSTRAINT [FK_Check_Paycheck_Voucher_Banks]
GO
ALTER TABLE [dbo].[Check_Paycheck_Voucher]  WITH CHECK ADD  CONSTRAINT [FK_Check_Paycheck_Voucher_Currencies] FOREIGN KEY([currencies])
REFERENCES [dbo].[Currencies] ([Currencies_Id])
GO
ALTER TABLE [dbo].[Check_Paycheck_Voucher] CHECK CONSTRAINT [FK_Check_Paycheck_Voucher_Currencies]
GO
ALTER TABLE [dbo].[Check_Paycheck_Voucher]  WITH CHECK ADD  CONSTRAINT [FK_Check_Paycheck_Voucher_Currencies_Exchange_Rate] FOREIGN KEY([currencies_exchange_rate])
REFERENCES [dbo].[Currencies_Exchange_Rate] ([Currencies_Exchange_Rate_Id])
GO
ALTER TABLE [dbo].[Check_Paycheck_Voucher] CHECK CONSTRAINT [FK_Check_Paycheck_Voucher_Currencies_Exchange_Rate]
GO
ALTER TABLE [dbo].[Check_Paycheck_Voucher]  WITH CHECK ADD  CONSTRAINT [FK_Check_Paycheck_Voucher_Fiscal_Year] FOREIGN KEY([fiscal_Year])
REFERENCES [dbo].[Fiscal_Year] ([Fiscal_Year_Id])
GO
ALTER TABLE [dbo].[Check_Paycheck_Voucher] CHECK CONSTRAINT [FK_Check_Paycheck_Voucher_Fiscal_Year]
GO
ALTER TABLE [dbo].[Currencies_Exchange_Rate]  WITH CHECK ADD  CONSTRAINT [FK_Currencies_Exchange_Rate_Currencies] FOREIGN KEY([currencies])
REFERENCES [dbo].[Currencies] ([Currencies_Id])
GO
ALTER TABLE [dbo].[Currencies_Exchange_Rate] CHECK CONSTRAINT [FK_Currencies_Exchange_Rate_Currencies]
GO
ALTER TABLE [dbo].[Detailed_Expens_Voucher]  WITH CHECK ADD  CONSTRAINT [FK_Detailed_Expens_Voucher_Accounting_Manual] FOREIGN KEY([DebitChildAccount])
REFERENCES [dbo].[Accounting_Manual] ([AccNumber])
GO
ALTER TABLE [dbo].[Detailed_Expens_Voucher] CHECK CONSTRAINT [FK_Detailed_Expens_Voucher_Accounting_Manual]
GO
ALTER TABLE [dbo].[Detailed_Expens_Voucher]  WITH CHECK ADD  CONSTRAINT [FK_Detailed_Expens_Voucher_Main_Expens_Voucher] FOREIGN KEY([main_expens_voucher_number])
REFERENCES [dbo].[Main_Expens_Voucher] ([Main_ExpensVoucher_Number])
GO
ALTER TABLE [dbo].[Detailed_Expens_Voucher] CHECK CONSTRAINT [FK_Detailed_Expens_Voucher_Main_Expens_Voucher]
GO
ALTER TABLE [dbo].[Detailed_Journal_Enteries]  WITH CHECK ADD  CONSTRAINT [FK_Detailed_Journal_Enteries_Accounting_Manual] FOREIGN KEY([DebitChildAccount])
REFERENCES [dbo].[Accounting_Manual] ([AccNumber])
GO
ALTER TABLE [dbo].[Detailed_Journal_Enteries] CHECK CONSTRAINT [FK_Detailed_Journal_Enteries_Accounting_Manual]
GO
ALTER TABLE [dbo].[Detailed_Journal_Enteries]  WITH CHECK ADD  CONSTRAINT [FK_Detailed_Journal_Enteries_Accounting_Manual1] FOREIGN KEY([CreditChildAccount])
REFERENCES [dbo].[Accounting_Manual] ([AccNumber])
GO
ALTER TABLE [dbo].[Detailed_Journal_Enteries] CHECK CONSTRAINT [FK_Detailed_Journal_Enteries_Accounting_Manual1]
GO
ALTER TABLE [dbo].[Detailed_Journal_Enteries]  WITH CHECK ADD  CONSTRAINT [FK_Detailed_Journal_Enteries_Currencies] FOREIGN KEY([currencies])
REFERENCES [dbo].[Currencies] ([Currencies_Id])
GO
ALTER TABLE [dbo].[Detailed_Journal_Enteries] CHECK CONSTRAINT [FK_Detailed_Journal_Enteries_Currencies]
GO
ALTER TABLE [dbo].[Detailed_Journal_Enteries]  WITH CHECK ADD  CONSTRAINT [FK_Detailed_Journal_Enteries_Currencies_Exchange_Rate] FOREIGN KEY([currencies_exchange_rate])
REFERENCES [dbo].[Currencies_Exchange_Rate] ([Currencies_Exchange_Rate_Id])
GO
ALTER TABLE [dbo].[Detailed_Journal_Enteries] CHECK CONSTRAINT [FK_Detailed_Journal_Enteries_Currencies_Exchange_Rate]
GO
ALTER TABLE [dbo].[Detailed_Journal_Enteries]  WITH CHECK ADD  CONSTRAINT [FK_Detailed_Journal_Enteries_Main_Journal_Enteries1] FOREIGN KEY([main_journal_enteries])
REFERENCES [dbo].[Main_Journal_Enteries] ([Main_Journal_Enteries_Id])
GO
ALTER TABLE [dbo].[Detailed_Journal_Enteries] CHECK CONSTRAINT [FK_Detailed_Journal_Enteries_Main_Journal_Enteries1]
GO
ALTER TABLE [dbo].[Detailed_PayCheck]  WITH CHECK ADD  CONSTRAINT [FK_Detailed_PayCheck_Accounting_Manual] FOREIGN KEY([CreditChildAccount])
REFERENCES [dbo].[Accounting_Manual] ([AccNumber])
GO
ALTER TABLE [dbo].[Detailed_PayCheck] CHECK CONSTRAINT [FK_Detailed_PayCheck_Accounting_Manual]
GO
ALTER TABLE [dbo].[Detailed_PayCheck]  WITH CHECK ADD  CONSTRAINT [FK_Detailed_PayCheck_Detailed_PayCheck] FOREIGN KEY([main_paycheck])
REFERENCES [dbo].[Main_PayCheck] ([MainPaycheckNumber])
GO
ALTER TABLE [dbo].[Detailed_PayCheck] CHECK CONSTRAINT [FK_Detailed_PayCheck_Detailed_PayCheck]
GO
ALTER TABLE [dbo].[Funds]  WITH CHECK ADD  CONSTRAINT [FK_Funds_Accounting_Manual] FOREIGN KEY([sub_accounting_manual])
REFERENCES [dbo].[Accounting_Manual] ([AccNumber])
GO
ALTER TABLE [dbo].[Funds] CHECK CONSTRAINT [FK_Funds_Accounting_Manual]
GO
ALTER TABLE [dbo].[General_Ledger]  WITH CHECK ADD  CONSTRAINT [FK_General_Ledger_Accounting_Manual] FOREIGN KEY([accounting_manual])
REFERENCES [dbo].[Accounting_Manual] ([AccNumber])
GO
ALTER TABLE [dbo].[General_Ledger] CHECK CONSTRAINT [FK_General_Ledger_Accounting_Manual]
GO
ALTER TABLE [dbo].[General_Ledger]  WITH CHECK ADD  CONSTRAINT [FK_General_Ledger_Check_Expens_Voucher] FOREIGN KEY([Check_ExpensVoucher_Number])
REFERENCES [dbo].[Check_Expens_Voucher] ([Check_ExpensVoucherNumber])
GO
ALTER TABLE [dbo].[General_Ledger] CHECK CONSTRAINT [FK_General_Ledger_Check_Expens_Voucher]
GO
ALTER TABLE [dbo].[General_Ledger]  WITH CHECK ADD  CONSTRAINT [FK_General_Ledger_Check_Paycheck_Voucher] FOREIGN KEY([Check_PayCheckVoucher_Number])
REFERENCES [dbo].[Check_Paycheck_Voucher] ([Check_PaycheckVoucherNumber])
GO
ALTER TABLE [dbo].[General_Ledger] CHECK CONSTRAINT [FK_General_Ledger_Check_Paycheck_Voucher]
GO
ALTER TABLE [dbo].[General_Ledger]  WITH CHECK ADD  CONSTRAINT [FK_General_Ledger_Currencies] FOREIGN KEY([currencies])
REFERENCES [dbo].[Currencies] ([Currencies_Id])
GO
ALTER TABLE [dbo].[General_Ledger] CHECK CONSTRAINT [FK_General_Ledger_Currencies]
GO
ALTER TABLE [dbo].[General_Ledger]  WITH CHECK ADD  CONSTRAINT [FK_General_Ledger_Currencies_Exchange_Rate] FOREIGN KEY([currencies_exchange_rate])
REFERENCES [dbo].[Currencies_Exchange_Rate] ([Currencies_Exchange_Rate_Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[General_Ledger] CHECK CONSTRAINT [FK_General_Ledger_Currencies_Exchange_Rate]
GO
ALTER TABLE [dbo].[General_Ledger]  WITH CHECK ADD  CONSTRAINT [FK_General_Ledger_Fiscal_Year] FOREIGN KEY([fiscal_year])
REFERENCES [dbo].[Fiscal_Year] ([Fiscal_Year_Id])
GO
ALTER TABLE [dbo].[General_Ledger] CHECK CONSTRAINT [FK_General_Ledger_Fiscal_Year]
GO
ALTER TABLE [dbo].[General_Ledger]  WITH CHECK ADD  CONSTRAINT [FK_General_Ledger_Main_Expens_Voucher] FOREIGN KEY([Main_Expens_Voucher_Number])
REFERENCES [dbo].[Main_Expens_Voucher] ([Main_ExpensVoucher_Number])
GO
ALTER TABLE [dbo].[General_Ledger] CHECK CONSTRAINT [FK_General_Ledger_Main_Expens_Voucher]
GO
ALTER TABLE [dbo].[General_Ledger]  WITH CHECK ADD  CONSTRAINT [FK_General_Ledger_Main_Journal_Enteries] FOREIGN KEY([Main_Journal_Enteries_id])
REFERENCES [dbo].[Main_Journal_Enteries] ([Main_Journal_Enteries_Id])
GO
ALTER TABLE [dbo].[General_Ledger] CHECK CONSTRAINT [FK_General_Ledger_Main_Journal_Enteries]
GO
ALTER TABLE [dbo].[General_Ledger]  WITH CHECK ADD  CONSTRAINT [FK_General_Ledger_Main_PayCheck] FOREIGN KEY([Main_PayCheck_Number])
REFERENCES [dbo].[Main_PayCheck] ([MainPaycheckNumber])
GO
ALTER TABLE [dbo].[General_Ledger] CHECK CONSTRAINT [FK_General_Ledger_Main_PayCheck]
GO
ALTER TABLE [dbo].[Main_Expens_Voucher]  WITH CHECK ADD  CONSTRAINT [FK_Main_Expens_Voucher_Currencies] FOREIGN KEY([currencies])
REFERENCES [dbo].[Currencies] ([Currencies_Id])
GO
ALTER TABLE [dbo].[Main_Expens_Voucher] CHECK CONSTRAINT [FK_Main_Expens_Voucher_Currencies]
GO
ALTER TABLE [dbo].[Main_Expens_Voucher]  WITH CHECK ADD  CONSTRAINT [FK_Main_Expens_Voucher_Currencies_Exchange_Rate] FOREIGN KEY([currencies_exchange_rate])
REFERENCES [dbo].[Currencies_Exchange_Rate] ([Currencies_Exchange_Rate_Id])
GO
ALTER TABLE [dbo].[Main_Expens_Voucher] CHECK CONSTRAINT [FK_Main_Expens_Voucher_Currencies_Exchange_Rate]
GO
ALTER TABLE [dbo].[Main_Expens_Voucher]  WITH CHECK ADD  CONSTRAINT [FK_Main_Expens_Voucher_Fiscal_Year] FOREIGN KEY([fiscal_year])
REFERENCES [dbo].[Fiscal_Year] ([Fiscal_Year_Id])
GO
ALTER TABLE [dbo].[Main_Expens_Voucher] CHECK CONSTRAINT [FK_Main_Expens_Voucher_Fiscal_Year]
GO
ALTER TABLE [dbo].[Main_Expens_Voucher]  WITH CHECK ADD  CONSTRAINT [FK_Main_Expens_Voucher_Funds] FOREIGN KEY([funds])
REFERENCES [dbo].[Funds] ([Funds_Id])
GO
ALTER TABLE [dbo].[Main_Expens_Voucher] CHECK CONSTRAINT [FK_Main_Expens_Voucher_Funds]
GO
ALTER TABLE [dbo].[Main_Journal_Enteries]  WITH CHECK ADD  CONSTRAINT [FK_Main_Journal_Enteries_Fiscal_Year] FOREIGN KEY([fiscal_year])
REFERENCES [dbo].[Fiscal_Year] ([Fiscal_Year_Id])
GO
ALTER TABLE [dbo].[Main_Journal_Enteries] CHECK CONSTRAINT [FK_Main_Journal_Enteries_Fiscal_Year]
GO
ALTER TABLE [dbo].[Main_Journal_Enteries]  WITH CHECK ADD  CONSTRAINT [FK_Main_Journal_Enteries_Journal_Enterie_Types] FOREIGN KEY([journal_enterie_types])
REFERENCES [dbo].[Journal_Enterie_Types] ([Journal_Enterie_Types_Id])
GO
ALTER TABLE [dbo].[Main_Journal_Enteries] CHECK CONSTRAINT [FK_Main_Journal_Enteries_Journal_Enterie_Types]
GO
ALTER TABLE [dbo].[Main_PayCheck]  WITH CHECK ADD  CONSTRAINT [FK_Main_PayCheck_Currencies] FOREIGN KEY([currencies])
REFERENCES [dbo].[Currencies] ([Currencies_Id])
GO
ALTER TABLE [dbo].[Main_PayCheck] CHECK CONSTRAINT [FK_Main_PayCheck_Currencies]
GO
ALTER TABLE [dbo].[Main_PayCheck]  WITH CHECK ADD  CONSTRAINT [FK_Main_PayCheck_Currencies_Exchange_Rate] FOREIGN KEY([currencies_exchange_rate])
REFERENCES [dbo].[Currencies_Exchange_Rate] ([Currencies_Exchange_Rate_Id])
GO
ALTER TABLE [dbo].[Main_PayCheck] CHECK CONSTRAINT [FK_Main_PayCheck_Currencies_Exchange_Rate]
GO
ALTER TABLE [dbo].[Main_PayCheck]  WITH CHECK ADD  CONSTRAINT [FK_Main_PayCheck_Fiscal_Year] FOREIGN KEY([fiscal_year])
REFERENCES [dbo].[Fiscal_Year] ([Fiscal_Year_Id])
GO
ALTER TABLE [dbo].[Main_PayCheck] CHECK CONSTRAINT [FK_Main_PayCheck_Fiscal_Year]
GO
ALTER TABLE [dbo].[Main_PayCheck]  WITH CHECK ADD  CONSTRAINT [FK_Main_PayCheck_Funds] FOREIGN KEY([funds])
REFERENCES [dbo].[Funds] ([Funds_Id])
GO
ALTER TABLE [dbo].[Main_PayCheck] CHECK CONSTRAINT [FK_Main_PayCheck_Funds]
GO
ALTER TABLE [dbo].[Transactions_Activity]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Activity_Activity_Type] FOREIGN KEY([activity_type])
REFERENCES [dbo].[Activity_Type] ([Activit_Type_Id])
GO
ALTER TABLE [dbo].[Transactions_Activity] CHECK CONSTRAINT [FK_Transactions_Activity_Activity_Type]
GO
ALTER TABLE [dbo].[Transactions_Activity]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Activity_Check_Expens_Voucher] FOREIGN KEY([check_expens])
REFERENCES [dbo].[Check_Expens_Voucher] ([Check_ExpensVoucherNumber])
GO
ALTER TABLE [dbo].[Transactions_Activity] CHECK CONSTRAINT [FK_Transactions_Activity_Check_Expens_Voucher]
GO
ALTER TABLE [dbo].[Transactions_Activity]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Activity_Check_Paycheck_Voucher] FOREIGN KEY([check_Paycheck])
REFERENCES [dbo].[Check_Paycheck_Voucher] ([Check_PaycheckVoucherNumber])
GO
ALTER TABLE [dbo].[Transactions_Activity] CHECK CONSTRAINT [FK_Transactions_Activity_Check_Paycheck_Voucher]
GO
ALTER TABLE [dbo].[Transactions_Activity]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Activity_General_Ledger] FOREIGN KEY([general_ledger])
REFERENCES [dbo].[General_Ledger] ([General_Ledger_Id])
GO
ALTER TABLE [dbo].[Transactions_Activity] CHECK CONSTRAINT [FK_Transactions_Activity_General_Ledger]
GO
ALTER TABLE [dbo].[Transactions_Activity]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Activity_Main_Expens_Voucher] FOREIGN KEY([main_expens_voucher])
REFERENCES [dbo].[Main_Expens_Voucher] ([Main_ExpensVoucher_Number])
GO
ALTER TABLE [dbo].[Transactions_Activity] CHECK CONSTRAINT [FK_Transactions_Activity_Main_Expens_Voucher]
GO
ALTER TABLE [dbo].[Transactions_Activity]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Activity_Main_Journal_Enteries] FOREIGN KEY([main_journal_enteries])
REFERENCES [dbo].[Main_Journal_Enteries] ([Main_Journal_Enteries_Id])
GO
ALTER TABLE [dbo].[Transactions_Activity] CHECK CONSTRAINT [FK_Transactions_Activity_Main_Journal_Enteries]
GO
ALTER TABLE [dbo].[Transactions_Activity]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Activity_Main_PayCheck] FOREIGN KEY([main_PayCheck])
REFERENCES [dbo].[Main_PayCheck] ([MainPaycheckNumber])
GO
ALTER TABLE [dbo].[Transactions_Activity] CHECK CONSTRAINT [FK_Transactions_Activity_Main_PayCheck]
GO
/****** Object:  StoredProcedure [dbo].[ChexStages]    Script Date: 5/13/2023 4:30:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE proc [dbo].[ChexStages] 
@StageNo varchar(50)	
As

insert into General_Ledger(Check_ExpensVoucher_Number,currencies,currencies_exchange_rate,accounting_manual,CreditAmount_RLY,CreditAmountWith_TransCurre
							,fiscal_year
                           , Transaction_Is_Stage,GenLedgerDateTime,TransactionName,system_Users)  

					
						Select c.Check_ExpensVoucherNumber,c.currencies,c.currencies_exchange_rate,c.banks,
						c.CreditAmount_RLY,c.CreditAmount_UDO,c.fiscal_year,1,GetDate(),'صرف شيك','6f94621c-3508-435c-98fe-c51cc63d076f'
						From Check_Expens_Voucher c 
						where Check_ExpensVoucherNumber=@StageNo


insert into General_Ledger(Check_ExpensVoucher_Number,currencies,currencies_exchange_rate,accounting_manual,DebittAmount_RLY,DebitAmountWith_TransCurre
							,fiscal_year
                           , Transaction_Is_Stage,GenLedgerDateTime,TransactionName,system_Users)  

						Select c.Check_ExpensVoucherNumber,c.currencies,c.currencies_exchange_rate,c.DebitChildAccount,
						c.DebittAmount_RLY,c.DebittAmount_UDO,c.fiscal_year,1,GetDate(),'صرف شيك','6f94621c-3508-435c-98fe-c51cc63d076f'
						From Check_Expens_Voucher c 
						where Check_ExpensVoucherNumber=@StageNo



			UPDATE Check_Expens_Voucher SET CheckStatus=1 WHERE Check_ExpensVoucherNumber=@StageNo
GO
/****** Object:  StoredProcedure [dbo].[ChpyStages]    Script Date: 5/13/2023 4:30:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE proc [dbo].[ChpyStages] 
@StageNo varchar(50)	
As

insert into General_Ledger(Check_PayCheckVoucher_Number,currencies,currencies_exchange_rate,accounting_manual,DebittAmount_RLY,DebitAmountWith_TransCurre
							,fiscal_year
                           , Transaction_Is_Stage,GenLedgerDateTime,TransactionName,system_Users)  

					

						Select c.Check_PaycheckVoucherNumber,c.currencies,c.currencies_exchange_rate,c.banks,
						c.DebittAmount_RLY,c.DebittAmount_UDO,c.fiscal_year,1,GetDate(),'قبض شيك','6f94621c-3508-435c-98fe-c51cc63d076f'
						From Check_Paycheck_Voucher c 
						where Check_PaycheckVoucherNumber=@StageNo


insert into General_Ledger(Check_PayCheckVoucher_Number,currencies,currencies_exchange_rate,accounting_manual,CreditAmount_RLY,CreditAmountWith_TransCurre
							,fiscal_year
                           , Transaction_Is_Stage,GenLedgerDateTime,TransactionName,system_Users)  

					


						Select c.Check_PaycheckVoucherNumber,c.currencies,c.currencies_exchange_rate,c.CreditChildAccount,
						c.CreditAmount_RLY,c.CreditAmount_UDO,c.fiscal_year,1,GetDate(),'قبض شيك','6f94621c-3508-435c-98fe-c51cc63d076f'
						From Check_Paycheck_Voucher c 
						where Check_PaycheckVoucherNumber=@StageNo



			UPDATE Check_Paycheck_Voucher SET CheckStatus=1 WHERE Check_PaycheckVoucherNumber=@StageNo
GO
/****** Object:  StoredProcedure [dbo].[ExchangeRate]    Script Date: 5/13/2023 4:30:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROC [dbo].[ExchangeRate]
@Currencies int	
As
SELECT Currencies_Exchange_Rate.Currencies_Exchange_Rate_Id, Currencies.Currencies_Id,Currencies.currenName , Currencies_Exchange_Rate.CurreExchangeRate,Currencies_Exchange_Rate.CurreExchangeDate
FROM (Currencies
INNER JOIN Currencies_Exchange_Rate ON Currencies.Currencies_Id = Currencies_Exchange_Rate.currencies)

where Currencies.Currencies_Id=@Currencies And Currencies_Exchange_Rate.CurreExhhangeStatus=1
; 
GO
/****** Object:  StoredProcedure [dbo].[GetAccCurrByAccNumber]    Script Date: 5/13/2023 4:30:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROC [dbo].[GetAccCurrByAccNumber]

@AccNumber varchar(50)	
As

Select Accounts_Currencies.currencies,Currencies.CurrenName
From ((Accounts_Currencies
INNER Join Accounting_Manual ON Accounting_Manual.AccNumber= Accounts_Currencies.accounting_manual)
INNER Join Currencies ON Currencies_Id = Accounts_Currencies.currencies)
Where Accounts_Currencies.accounting_manual=@AccNumber AND Currencies.CurrStatus=0
GO
/****** Object:  StoredProcedure [dbo].[PayStages]    Script Date: 5/13/2023 4:30:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE proc [dbo].[PayStages]
@StageNo varchar(50)	
As

insert into General_Ledger(Main_PayCheck_Number,currencies,currencies_exchange_rate,accounting_manual,DebittAmount_RLY,DebitAmountWith_TransCurre
							,fiscal_year
                           , Transaction_Is_Stage,GenLedgerDateTime,TransactionName,system_Users)  

						Select m.MainPaycheckNumber,m.currencies,m.currencies_exchange_rate,m.funds,
						m.MainPaycheckAmount_RLY,m.MainPaycheckAmount_UDO,m.fiscal_year,1,GetDate(),'قبض نقد','6f94621c-3508-435c-98fe-c51cc63d076f'
						From Main_PayCheck m 
						where MainPaycheckNumber=@StageNo

insert into General_Ledger(Main_PayCheck_Number,currencies,currencies_exchange_rate,accounting_manual,CreditAmount_RLY,CreditAmountWith_TransCurre
							,fiscal_year
                           , Transaction_Is_Stage,GenLedgerDateTime,TransactionName,system_Users)  

						select  m.MainPaycheckNumber,m.currencies,m.currencies_exchange_rate,d.CreditChildAccount,d.DetailedPaycheckAmount_RLY
						,d.DetailedPaycheckAmount_UDO,m.fiscal_year,1,GetDate(),'قبض نقد','6f94621c-3508-435c-98fe-c51cc63d076f'
						From (Main_PayCheck m
							INNER Join Detailed_PayCheck d ON d.main_paycheck= m.MainPaycheckNumber)
						where MainPaycheckNumber=@StageNo



			UPDATE Main_PayCheck SET MainPaycheckStatus=1 WHERE MainPaycheckNumber=@StageNo
GO
/****** Object:  StoredProcedure [dbo].[Stages]    Script Date: 5/13/2023 4:30:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE proc [dbo].[Stages] 
@StageNo varchar(50)	
As

insert into General_Ledger(Main_Expens_Voucher_Number,currencies,currencies_exchange_rate,accounting_manual,CreditAmount_RLY,CreditAmountWith_TransCurre
							,fiscal_year
                           , Transaction_Is_Stage,GenLedgerDateTime,TransactionName,system_Users)  

						   Select m.Main_ExpensVoucher_Number,m.currencies,m.currencies_exchange_rate,m.funds,
						m.MainExpensVoucherAmount_RLY,m.MainExpensVoucherAmount_UDO,m.fiscal_year,1,GetDate(),'صرف نقد','6f94621c-3508-435c-98fe-c51cc63d076f'
						From Main_Expens_Voucher m 
						where Main_ExpensVoucher_Number=@StageNo

insert into General_Ledger(Main_Expens_Voucher_Number,currencies,currencies_exchange_rate,accounting_manual,DebittAmount_RLY,DebitAmountWith_TransCurre
							,fiscal_year
                           , Transaction_Is_Stage,GenLedgerDateTime,TransactionName,system_Users)  

						select  m.Main_ExpensVoucher_Number,m.currencies,m.currencies_exchange_rate,d.DebitChildAccount,d.DetailedExpensVoucherAmount_RLY
					,d.DetailedExpensVoucherAmount_UDO,m.fiscal_year,1,GetDate(),'صرف نقد','6f94621c-3508-435c-98fe-c51cc63d076f'
					From (Main_Expens_Voucher m
					INNER Join Detailed_Expens_Voucher d ON d.main_expens_voucher_number= m.Main_ExpensVoucher_Number)
						where Main_ExpensVoucher_Number=@StageNo


UPDATE Main_Expens_Voucher SET MainExpensVoucherStatus=1 WHERE Main_ExpensVoucher_Number=@StageNo
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "AspNetUsers"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 262
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AspNetUserRoles"
            Begin Extent = 
               Top = 6
               Left = 300
               Bottom = 102
               Right = 470
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AspNetRoles"
            Begin Extent = 
               Top = 6
               Left = 508
               Bottom = 136
               Right = 699
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwUsers'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwUsers'
GO
USE [master]
GO
ALTER DATABASE [Fin] SET  READ_WRITE 
GO
