USE [master]
GO

/****** Object:  Database [budget_tracker]    Script Date: 11/23/2026 3:39:13 PM ******/
CREATE DATABASE [budget_tracker]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'budget_tracker', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL17.MSSQLSERVER\MSSQL\DATA\budget_tracker.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'budget_tracker_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL17.MSSQLSERVER\MSSQL\DATA\budget_tracker_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [budget_tracker].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [budget_tracker] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [budget_tracker] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [budget_tracker] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [budget_tracker] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [budget_tracker] SET ARITHABORT OFF 
GO

ALTER DATABASE [budget_tracker] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [budget_tracker] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [budget_tracker] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [budget_tracker] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [budget_tracker] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [budget_tracker] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [budget_tracker] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [budget_tracker] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [budget_tracker] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [budget_tracker] SET  DISABLE_BROKER 
GO

ALTER DATABASE [budget_tracker] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [budget_tracker] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [budget_tracker] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [budget_tracker] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [budget_tracker] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [budget_tracker] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [budget_tracker] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [budget_tracker] SET RECOVERY FULL 
GO

ALTER DATABASE [budget_tracker] SET  MULTI_USER 
GO

ALTER DATABASE [budget_tracker] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [budget_tracker] SET DB_CHAINING OFF 
GO

ALTER DATABASE [budget_tracker] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [budget_tracker] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [budget_tracker] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [budget_tracker] SET OPTIMIZED_LOCKING = OFF 
GO

ALTER DATABASE [budget_tracker] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [budget_tracker] SET QUERY_STORE = ON
GO

ALTER DATABASE [budget_tracker] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO

ALTER DATABASE [budget_tracker] SET  READ_WRITE 
GO


USE [budget_tracker]
GO

/****** Object:  Table [dbo].[tb_category]    Script Date: 11/23/2026 3:40:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tb_category](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [budget_tracker]
GO

/****** Object:  Table [dbo].[tb_type]    Script Date: 11/23/2026 3:40:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tb_type](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NULL,
	[description] [varchar](255) NULL,
	[id_category] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tb_type]  WITH CHECK ADD FOREIGN KEY([id_category])
REFERENCES [dbo].[tb_category] ([id])
GO


USE [budget_tracker]
GO

/****** Object:  Table [dbo].[tb_expenses]    Script Date: 11/23/2026 3:40:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tb_expenses](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[id_type] [smallint] NULL,
	[value] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tb_expenses]  WITH CHECK ADD FOREIGN KEY([id_type])
REFERENCES [dbo].[tb_type] ([id])
GO

/****** INSERT INTO Category table ******/
INSERT INTO tb_category
VALUES ('Income');
INSERT INTO tb_category
VALUES ('Housing');
INSERT INTO tb_category
VALUES ('Groceries');
INSERT INTO tb_category
VALUES ('Restaurants');
INSERT INTO tb_category
VALUES ('Travel');
INSERT INTO tb_category
VALUES ('Shopping');
INSERT INTO tb_category
VALUES ('Medical');
INSERT INTO tb_category
VALUES ('Savings');

/****** INSERT INTO Type table ******/
INSERT INTO tb_type (name , id_category)
VALUES ('Salary',(SELECT id FROM tb_category WHERE NAME = 'Income'));
INSERT INTO tb_type (name , id_category)
VALUES ('Rent',(SELECT id FROM tb_category WHERE NAME = 'Housing'));
INSERT INTO tb_type (name , id_category)
VALUES ('Water',(SELECT id FROM tb_category WHERE NAME = 'Housing'));
INSERT INTO tb_type (name , id_category)
VALUES ('Eletricity',(SELECT id FROM tb_category WHERE NAME = 'Housing'));
INSERT INTO tb_type (name , id_category)
VALUES ('Market',(SELECT id FROM tb_category WHERE NAME = 'Groceries'));
INSERT INTO tb_type (name , id_category)
VALUES ('Pizza Place',(SELECT id FROM tb_category WHERE NAME = 'Restaurants'));
INSERT INTO tb_type (name , id_category)
VALUES ('Sushi Sushi',(SELECT id FROM tb_category WHERE NAME = 'Restaurants'));
INSERT INTO tb_type (name , id_category)
VALUES ('Museum',(SELECT id FROM tb_category WHERE NAME = 'Travel'));
INSERT INTO tb_type (name , id_category)
VALUES ('Bus',(SELECT id FROM tb_category WHERE NAME = 'Travel'));
INSERT INTO tb_type (name , id_category)
VALUES ('Gelatto',(SELECT id FROM tb_category WHERE NAME = 'Travel'));
INSERT INTO tb_type (name , id_category)
VALUES ('Clothes',(SELECT id FROM tb_category WHERE NAME = 'Shopping'));
INSERT INTO tb_type (name , id_category)
VALUES ('Emergency Fund',(SELECT id FROM tb_category WHERE NAME = 'Savings'));


/****** INSERT INTO Expenses table ******/
INSERT INTO tb_expenses (value , id_type)
VALUES (2000,(SELECT id FROM tb_type WHERE NAME = 'Salary'));
INSERT INTO tb_expenses (value , id_type)
VALUES (550,(SELECT id FROM tb_type WHERE NAME = 'Rent'));
INSERT INTO tb_expenses (value , id_type)
VALUES (25.5,(SELECT id FROM tb_type WHERE NAME = 'Water'));
INSERT INTO tb_expenses (value , id_type)
VALUES (53.90,(SELECT id FROM tb_type WHERE NAME = 'Eletricity'));
INSERT INTO tb_expenses (value , id_type)
VALUES (283,(SELECT id FROM tb_type WHERE NAME = 'Market'));
INSERT INTO tb_expenses (value , id_type)
VALUES (17.98,(SELECT id FROM tb_type WHERE NAME = 'Pizza Place'));
INSERT INTO tb_expenses (value , id_type)
VALUES (26.99,(SELECT id FROM tb_type WHERE NAME = 'Sushi Sushi'));
INSERT INTO tb_expenses (value , id_type)
VALUES (14,(SELECT id FROM tb_type WHERE NAME = 'Museum'));
INSERT INTO tb_expenses (value , id_type)
VALUES (35,(SELECT id FROM tb_type WHERE NAME = 'Bus'));
INSERT INTO tb_expenses (value , id_type)
VALUES (8,(SELECT id FROM tb_type WHERE NAME = 'Gelatto'));
INSERT INTO tb_expenses (value , id_type)
VALUES (129.5,(SELECT id FROM tb_type WHERE NAME = 'Clothes'));
INSERT INTO tb_expenses (value , id_type)
VALUES (300,(SELECT id FROM tb_type WHERE NAME = 'Emergency Fund'));