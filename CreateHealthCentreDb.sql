USE [master]
GO
/****** Object:  Database [HealthCentreDb]    Script Date: 05.03.2026 10:44:07 ******/
CREATE DATABASE [HealthCentreDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HealthCentreDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\HealthCentreDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'HealthCentreDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\HealthCentreDb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [HealthCentreDb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HealthCentreDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HealthCentreDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HealthCentreDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HealthCentreDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HealthCentreDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HealthCentreDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [HealthCentreDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HealthCentreDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HealthCentreDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HealthCentreDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HealthCentreDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HealthCentreDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HealthCentreDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HealthCentreDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HealthCentreDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HealthCentreDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HealthCentreDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HealthCentreDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HealthCentreDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HealthCentreDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HealthCentreDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HealthCentreDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HealthCentreDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HealthCentreDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HealthCentreDb] SET  MULTI_USER 
GO
ALTER DATABASE [HealthCentreDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HealthCentreDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HealthCentreDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HealthCentreDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [HealthCentreDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HealthCentreDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'HealthCentreDb', N'ON'
GO
ALTER DATABASE [HealthCentreDb] SET QUERY_STORE = ON
GO
ALTER DATABASE [HealthCentreDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [HealthCentreDb]
GO
/****** Object:  Table [dbo].[DoctorType]    Script Date: 05.03.2026 10:44:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoctorType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_DoctorType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 05.03.2026 10:44:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 05.03.2026 10:44:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[GenderId] [int] NOT NULL,
	[BirthDate] [date] NOT NULL,
	[InsuranceCertificate] [nvarchar](255) NOT NULL,
	[Fluorography] [date] NULL,
	[HealthAssessment] [date] NULL,
	[Height] [int] NOT NULL,
	[Weight] [int] NOT NULL,
	[DisabilityGroupI] [date] NULL,
	[DisabilityGroupII] [date] NULL,
	[DisabilityGroupIII] [date] NULL,
	[PhotoId] [int] NULL,
 CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Photo]    Script Date: 05.03.2026 10:44:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Photo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RelativePath] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Photo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 05.03.2026 10:44:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 05.03.2026 10:44:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Visit]    Script Date: 05.03.2026 10:44:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Visit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[PatientId] [int] NOT NULL,
	[DoctorTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Visit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DoctorType] ON 
GO
INSERT [dbo].[DoctorType] ([Id], [Name]) VALUES (1, N'Лор')
GO
INSERT [dbo].[DoctorType] ([Id], [Name]) VALUES (4, N'Невропатолог')
GO
INSERT [dbo].[DoctorType] ([Id], [Name]) VALUES (2, N'Терапевт')
GO
INSERT [dbo].[DoctorType] ([Id], [Name]) VALUES (3, N'Хирург')
GO
SET IDENTITY_INSERT [dbo].[DoctorType] OFF
GO
SET IDENTITY_INSERT [dbo].[Gender] ON 
GO
INSERT [dbo].[Gender] ([Id], [Name]) VALUES (2, N'Жен')
GO
INSERT [dbo].[Gender] ([Id], [Name]) VALUES (1, N'Муж')
GO
SET IDENTITY_INSERT [dbo].[Gender] OFF
GO
SET IDENTITY_INSERT [dbo].[Patient] ON 
GO
INSERT [dbo].[Patient] ([Id], [Name], [GenderId], [BirthDate], [InsuranceCertificate], [Fluorography], [HealthAssessment], [Height], [Weight], [DisabilityGroupI], [DisabilityGroupII], [DisabilityGroupIII], [PhotoId]) VALUES (1, N'Петров Петр Петрович', 1, CAST(N'2002-10-30' AS Date), N'XV 998-45-68', CAST(N'2024-12-22' AS Date), CAST(N'2024-10-23' AS Date), 192, 85, CAST(N'2024-12-12' AS Date), NULL, NULL, 1)
GO
INSERT [dbo].[Patient] ([Id], [Name], [GenderId], [BirthDate], [InsuranceCertificate], [Fluorography], [HealthAssessment], [Height], [Weight], [DisabilityGroupI], [DisabilityGroupII], [DisabilityGroupIII], [PhotoId]) VALUES (2, N'Сидоров Сидор Сидорович', 1, CAST(N'2003-07-06' AS Date), N' II 998-45-69', CAST(N'2024-01-21' AS Date), CAST(N'2024-11-22' AS Date), 178, 95, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Patient] ([Id], [Name], [GenderId], [BirthDate], [InsuranceCertificate], [Fluorography], [HealthAssessment], [Height], [Weight], [DisabilityGroupI], [DisabilityGroupII], [DisabilityGroupIII], [PhotoId]) VALUES (3, N'Веревкина Мария Евгеньевна', 2, CAST(N'1998-02-04' AS Date), N' III  998-45-64', CAST(N'2024-02-13' AS Date), CAST(N'2024-08-25' AS Date), 169, 65, NULL, NULL, NULL, 2)
GO
INSERT [dbo].[Patient] ([Id], [Name], [GenderId], [BirthDate], [InsuranceCertificate], [Fluorography], [HealthAssessment], [Height], [Weight], [DisabilityGroupI], [DisabilityGroupII], [DisabilityGroupIII], [PhotoId]) VALUES (4, N'Беляева Анастасия Павловна', 2, CAST(N'1996-07-10' AS Date), N'IV 998-45-67', CAST(N'2024-05-05' AS Date), CAST(N'2024-09-03' AS Date), 165, 90, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Patient] ([Id], [Name], [GenderId], [BirthDate], [InsuranceCertificate], [Fluorography], [HealthAssessment], [Height], [Weight], [DisabilityGroupI], [DisabilityGroupII], [DisabilityGroupIII], [PhotoId]) VALUES (5, N'Розова Марина Алексеевна', 2, CAST(N'2011-02-23' AS Date), N'VII 998-45-61', CAST(N'2023-02-07' AS Date), CAST(N'2022-10-03' AS Date), 155, 40, NULL, CAST(N'2024-05-05' AS Date), NULL, NULL)
GO
INSERT [dbo].[Patient] ([Id], [Name], [GenderId], [BirthDate], [InsuranceCertificate], [Fluorography], [HealthAssessment], [Height], [Weight], [DisabilityGroupI], [DisabilityGroupII], [DisabilityGroupIII], [PhotoId]) VALUES (6, N'Деев Андрей Валентинович', 1, CAST(N'1950-06-18' AS Date), N'XXV 998-45-62', CAST(N'2024-02-04' AS Date), NULL, 171, 75, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Patient] ([Id], [Name], [GenderId], [BirthDate], [InsuranceCertificate], [Fluorography], [HealthAssessment], [Height], [Weight], [DisabilityGroupI], [DisabilityGroupII], [DisabilityGroupIII], [PhotoId]) VALUES (7, N'Портной Михаил Михайлович', 1, CAST(N'2001-10-05' AS Date), N'VIII 998-45-63', CAST(N'2024-01-03' AS Date), CAST(N'2023-08-29' AS Date), 182, 105, NULL, NULL, CAST(N'2024-04-15' AS Date), 3)
GO
SET IDENTITY_INSERT [dbo].[Patient] OFF
GO
SET IDENTITY_INSERT [dbo].[Photo] ON 
GO
INSERT [dbo].[Photo] ([Id], [RelativePath]) VALUES (1, N'1.jpg')
GO
INSERT [dbo].[Photo] ([Id], [RelativePath]) VALUES (2, N'2.jpg')
GO
INSERT [dbo].[Photo] ([Id], [RelativePath]) VALUES (3, N'3.png')
GO
SET IDENTITY_INSERT [dbo].[Photo] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 
GO
INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'Администратор')
GO
INSERT [dbo].[Role] ([Id], [Name]) VALUES (2, N'Врач')
GO
INSERT [dbo].[Role] ([Id], [Name]) VALUES (3, N'Пациент')
GO
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([Id], [Login], [Password], [RoleId]) VALUES (1, N'admin', N'admin', 1)
GO
INSERT [dbo].[User] ([Id], [Login], [Password], [RoleId]) VALUES (2, N'doctor', N'doctor', 2)
GO
INSERT [dbo].[User] ([Id], [Login], [Password], [RoleId]) VALUES (3, N'patient', N'patient', 3)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[Visit] ON 
GO
INSERT [dbo].[Visit] ([Id], [Date], [PatientId], [DoctorTypeId]) VALUES (1, CAST(N'2024-01-20' AS Date), 1, 1)
GO
INSERT [dbo].[Visit] ([Id], [Date], [PatientId], [DoctorTypeId]) VALUES (2, CAST(N'2024-01-21' AS Date), 2, 2)
GO
INSERT [dbo].[Visit] ([Id], [Date], [PatientId], [DoctorTypeId]) VALUES (3, CAST(N'2024-01-22' AS Date), 3, 3)
GO
INSERT [dbo].[Visit] ([Id], [Date], [PatientId], [DoctorTypeId]) VALUES (4, CAST(N'2024-01-23' AS Date), 4, 2)
GO
INSERT [dbo].[Visit] ([Id], [Date], [PatientId], [DoctorTypeId]) VALUES (5, CAST(N'2024-01-24' AS Date), 5, 4)
GO
INSERT [dbo].[Visit] ([Id], [Date], [PatientId], [DoctorTypeId]) VALUES (6, CAST(N'2024-01-25' AS Date), 6, 1)
GO
INSERT [dbo].[Visit] ([Id], [Date], [PatientId], [DoctorTypeId]) VALUES (7, CAST(N'2024-01-26' AS Date), 7, 2)
GO
INSERT [dbo].[Visit] ([Id], [Date], [PatientId], [DoctorTypeId]) VALUES (8, CAST(N'2024-01-27' AS Date), 1, 3)
GO
INSERT [dbo].[Visit] ([Id], [Date], [PatientId], [DoctorTypeId]) VALUES (9, CAST(N'2024-01-28' AS Date), 2, 4)
GO
INSERT [dbo].[Visit] ([Id], [Date], [PatientId], [DoctorTypeId]) VALUES (10, CAST(N'2024-01-29' AS Date), 3, 2)
GO
INSERT [dbo].[Visit] ([Id], [Date], [PatientId], [DoctorTypeId]) VALUES (11, CAST(N'2024-01-30' AS Date), 4, 1)
GO
INSERT [dbo].[Visit] ([Id], [Date], [PatientId], [DoctorTypeId]) VALUES (12, CAST(N'2024-01-31' AS Date), 5, 4)
GO
INSERT [dbo].[Visit] ([Id], [Date], [PatientId], [DoctorTypeId]) VALUES (13, CAST(N'2024-02-01' AS Date), 6, 2)
GO
INSERT [dbo].[Visit] ([Id], [Date], [PatientId], [DoctorTypeId]) VALUES (14, CAST(N'2024-02-02' AS Date), 7, 3)
GO
INSERT [dbo].[Visit] ([Id], [Date], [PatientId], [DoctorTypeId]) VALUES (15, CAST(N'2024-02-03' AS Date), 1, 2)
GO
INSERT [dbo].[Visit] ([Id], [Date], [PatientId], [DoctorTypeId]) VALUES (16, CAST(N'2024-02-04' AS Date), 2, 1)
GO
INSERT [dbo].[Visit] ([Id], [Date], [PatientId], [DoctorTypeId]) VALUES (17, CAST(N'2024-02-05' AS Date), 3, 2)
GO
INSERT [dbo].[Visit] ([Id], [Date], [PatientId], [DoctorTypeId]) VALUES (18, CAST(N'2024-02-06' AS Date), 4, 3)
GO
INSERT [dbo].[Visit] ([Id], [Date], [PatientId], [DoctorTypeId]) VALUES (19, CAST(N'2024-02-07' AS Date), 5, 2)
GO
INSERT [dbo].[Visit] ([Id], [Date], [PatientId], [DoctorTypeId]) VALUES (20, CAST(N'2024-02-08' AS Date), 6, 1)
GO
INSERT [dbo].[Visit] ([Id], [Date], [PatientId], [DoctorTypeId]) VALUES (21, CAST(N'2024-02-09' AS Date), 7, 3)
GO
SET IDENTITY_INSERT [dbo].[Visit] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__DoctorTy__737584F66FB10588]    Script Date: 05.03.2026 10:44:07 ******/
ALTER TABLE [dbo].[DoctorType] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Gender__737584F6B4F6DF6F]    Script Date: 05.03.2026 10:44:07 ******/
ALTER TABLE [dbo].[Gender] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Photo__32B676F4C8300843]    Script Date: 05.03.2026 10:44:07 ******/
ALTER TABLE [dbo].[Photo] ADD UNIQUE NONCLUSTERED 
(
	[RelativePath] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Role__737584F6E899EC87]    Script Date: 05.03.2026 10:44:07 ******/
ALTER TABLE [dbo].[Role] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__User__5E55825BD80D264C]    Script Date: 05.03.2026 10:44:07 ******/
ALTER TABLE [dbo].[User] ADD UNIQUE NONCLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_Gender] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Gender] ([Id])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_Gender]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_Photo] FOREIGN KEY([PhotoId])
REFERENCES [dbo].[Photo] ([Id])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_Photo]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
ALTER TABLE [dbo].[Visit]  WITH CHECK ADD  CONSTRAINT [FK_Visit_DoctorType] FOREIGN KEY([DoctorTypeId])
REFERENCES [dbo].[DoctorType] ([Id])
GO
ALTER TABLE [dbo].[Visit] CHECK CONSTRAINT [FK_Visit_DoctorType]
GO
ALTER TABLE [dbo].[Visit]  WITH CHECK ADD  CONSTRAINT [FK_Visit_Patient] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patient] ([Id])
GO
ALTER TABLE [dbo].[Visit] CHECK CONSTRAINT [FK_Visit_Patient]
GO
USE [master]
GO
ALTER DATABASE [HealthCentreDb] SET  READ_WRITE 
GO
