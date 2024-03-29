USE [master]
GO
/****** Object:  Database [InvoiceMaker]    Script Date: 9/20/2019 9:58:06 AM ******/
CREATE DATABASE [InvoiceMaker]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'InvoiceMaker', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\InvoiceMaker.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'InvoiceMaker_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\InvoiceMaker_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [InvoiceMaker] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InvoiceMaker].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InvoiceMaker] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InvoiceMaker] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InvoiceMaker] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InvoiceMaker] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InvoiceMaker] SET ARITHABORT OFF 
GO
ALTER DATABASE [InvoiceMaker] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [InvoiceMaker] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InvoiceMaker] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InvoiceMaker] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InvoiceMaker] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InvoiceMaker] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InvoiceMaker] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InvoiceMaker] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InvoiceMaker] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InvoiceMaker] SET  DISABLE_BROKER 
GO
ALTER DATABASE [InvoiceMaker] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InvoiceMaker] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InvoiceMaker] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InvoiceMaker] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InvoiceMaker] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InvoiceMaker] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [InvoiceMaker] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InvoiceMaker] SET RECOVERY FULL 
GO
ALTER DATABASE [InvoiceMaker] SET  MULTI_USER 
GO
ALTER DATABASE [InvoiceMaker] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InvoiceMaker] SET DB_CHAINING OFF 
GO
ALTER DATABASE [InvoiceMaker] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [InvoiceMaker] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [InvoiceMaker] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'InvoiceMaker', N'ON'
GO
ALTER DATABASE [InvoiceMaker] SET QUERY_STORE = OFF
GO
USE [InvoiceMaker]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 9/20/2019 9:58:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientName] [nvarchar](255) NOT NULL,
	[IsActivated] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FeeLineItem]    Script Date: 9/20/2019 9:58:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeeLineItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[When] [datetimeoffset](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkDone]    Script Date: 9/20/2019 9:58:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkDone](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[WorkTypeId] [int] NOT NULL,
	[StartedOn] [datetimeoffset](7) NOT NULL,
	[EndedOn] [datetimeoffset](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkLineItem]    Script Date: 9/20/2019 9:58:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkLineItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WorkDoneId] [int] NOT NULL,
 CONSTRAINT [PK__WorkLine__3214EC073DB9DE81] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkType]    Script Date: 9/20/2019 9:58:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WorkName] [nvarchar](255) NOT NULL,
	[Rate] [decimal](18, 4) NOT NULL,
 CONSTRAINT [PK__WorkType__3214EC07F416EA54] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([Id], [ClientName], [IsActivated]) VALUES (1, N'Bob', 1)
INSERT [dbo].[Client] ([Id], [ClientName], [IsActivated]) VALUES (2, N'John', 1)
INSERT [dbo].[Client] ([Id], [ClientName], [IsActivated]) VALUES (3, N'Tom', 0)
INSERT [dbo].[Client] ([Id], [ClientName], [IsActivated]) VALUES (4, N'CompanyA', 1)
INSERT [dbo].[Client] ([Id], [ClientName], [IsActivated]) VALUES (5, N'Client1.5', 1)
INSERT [dbo].[Client] ([Id], [ClientName], [IsActivated]) VALUES (6, N'Client3', 1)
INSERT [dbo].[Client] ([Id], [ClientName], [IsActivated]) VALUES (7, N'Entity Framework', 1)
SET IDENTITY_INSERT [dbo].[Client] OFF
SET IDENTITY_INSERT [dbo].[WorkDone] ON 

INSERT [dbo].[WorkDone] ([Id], [ClientId], [WorkTypeId], [StartedOn], [EndedOn]) VALUES (1, 1, 1, CAST(N'2019-08-12T00:00:00.0000000-04:00' AS DateTimeOffset), CAST(N'2019-09-20T09:51:59.7528492-04:00' AS DateTimeOffset))
INSERT [dbo].[WorkDone] ([Id], [ClientId], [WorkTypeId], [StartedOn], [EndedOn]) VALUES (2, 4, 1, CAST(N'2019-08-21T00:00:00.0000000-04:00' AS DateTimeOffset), CAST(N'2019-09-03T00:00:00.0000000-04:00' AS DateTimeOffset))
INSERT [dbo].[WorkDone] ([Id], [ClientId], [WorkTypeId], [StartedOn], [EndedOn]) VALUES (3, 6, 1, CAST(N'2019-09-17T10:51:21.0000000-04:00' AS DateTimeOffset), NULL)
INSERT [dbo].[WorkDone] ([Id], [ClientId], [WorkTypeId], [StartedOn], [EndedOn]) VALUES (4, 1, 3, CAST(N'2019-09-17T11:42:49.9054524-04:00' AS DateTimeOffset), CAST(N'2019-09-20T09:51:17.0835105-04:00' AS DateTimeOffset))
INSERT [dbo].[WorkDone] ([Id], [ClientId], [WorkTypeId], [StartedOn], [EndedOn]) VALUES (5, 3, 6, CAST(N'2019-09-19T14:46:12.0000000-04:00' AS DateTimeOffset), NULL)
INSERT [dbo].[WorkDone] ([Id], [ClientId], [WorkTypeId], [StartedOn], [EndedOn]) VALUES (6, 6, 11, CAST(N'2019-09-19T15:05:57.0000000-04:00' AS DateTimeOffset), CAST(N'2019-09-20T00:00:00.0000000-04:00' AS DateTimeOffset))
INSERT [dbo].[WorkDone] ([Id], [ClientId], [WorkTypeId], [StartedOn], [EndedOn]) VALUES (7, 5, 9, CAST(N'2019-09-19T15:16:53.0000000-04:00' AS DateTimeOffset), NULL)
SET IDENTITY_INSERT [dbo].[WorkDone] OFF
SET IDENTITY_INSERT [dbo].[WorkLineItem] ON 

INSERT [dbo].[WorkLineItem] ([Id], [WorkDoneId]) VALUES (1, 1)
INSERT [dbo].[WorkLineItem] ([Id], [WorkDoneId]) VALUES (2, 2)
INSERT [dbo].[WorkLineItem] ([Id], [WorkDoneId]) VALUES (3, 3)
SET IDENTITY_INSERT [dbo].[WorkLineItem] OFF
SET IDENTITY_INSERT [dbo].[WorkType] ON 

INSERT [dbo].[WorkType] ([Id], [WorkName], [Rate]) VALUES (1, N'Paint Wall', CAST(10.5900 AS Decimal(18, 4)))
INSERT [dbo].[WorkType] ([Id], [WorkName], [Rate]) VALUES (3, N'Deliver Package', CAST(9.5200 AS Decimal(18, 4)))
INSERT [dbo].[WorkType] ([Id], [WorkName], [Rate]) VALUES (4, N'Make Food', CAST(15.0000 AS Decimal(18, 4)))
INSERT [dbo].[WorkType] ([Id], [WorkName], [Rate]) VALUES (6, N'Make More Food', CAST(16.0000 AS Decimal(18, 4)))
INSERT [dbo].[WorkType] ([Id], [WorkName], [Rate]) VALUES (7, N'Create Invoice ', CAST(17.2400 AS Decimal(18, 4)))
INSERT [dbo].[WorkType] ([Id], [WorkName], [Rate]) VALUES (8, N'Finish Invoice Maker', CAST(100000.0000 AS Decimal(18, 4)))
INSERT [dbo].[WorkType] ([Id], [WorkName], [Rate]) VALUES (9, N'Make Coffee', CAST(3.0000 AS Decimal(18, 4)))
INSERT [dbo].[WorkType] ([Id], [WorkName], [Rate]) VALUES (11, N'Update Invoice ', CAST(12.0000 AS Decimal(18, 4)))
SET IDENTITY_INSERT [dbo].[WorkType] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Client__65800DA05CCF7CAE]    Script Date: 9/20/2019 9:58:07 AM ******/
ALTER TABLE [dbo].[Client] ADD UNIQUE NONCLUSTERED 
(
	[ClientName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__WorkType__58DF351DD474373A]    Script Date: 9/20/2019 9:58:07 AM ******/
ALTER TABLE [dbo].[WorkType] ADD  CONSTRAINT [UQ__WorkType__58DF351DD474373A] UNIQUE NONCLUSTERED 
(
	[WorkName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[WorkDone]  WITH CHECK ADD FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[WorkDone]  WITH CHECK ADD FOREIGN KEY([WorkTypeId])
REFERENCES [dbo].[WorkType] ([Id])
GO
ALTER TABLE [dbo].[WorkLineItem]  WITH CHECK ADD  CONSTRAINT [FK__WorkLineI__WorkD__4D94879B] FOREIGN KEY([WorkDoneId])
REFERENCES [dbo].[WorkDone] ([Id])
GO
ALTER TABLE [dbo].[WorkLineItem] CHECK CONSTRAINT [FK__WorkLineI__WorkD__4D94879B]
GO
USE [master]
GO
ALTER DATABASE [InvoiceMaker] SET  READ_WRITE 
GO
