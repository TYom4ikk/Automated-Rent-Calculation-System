USE [master]
GO
/****** Object:  Database [RentCalculation]    Script Date: 15.04.2025 4:41:27 ******/
CREATE DATABASE [RentCalculation]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RentCalculation', FILENAME = N'C:\Users\Admin\RentCalculation.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RentCalculation_log', FILENAME = N'C:\Users\Admin\RentCalculation_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [RentCalculation] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RentCalculation].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RentCalculation] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RentCalculation] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RentCalculation] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RentCalculation] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RentCalculation] SET ARITHABORT OFF 
GO
ALTER DATABASE [RentCalculation] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [RentCalculation] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RentCalculation] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RentCalculation] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RentCalculation] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RentCalculation] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RentCalculation] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RentCalculation] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RentCalculation] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RentCalculation] SET  ENABLE_BROKER 
GO
ALTER DATABASE [RentCalculation] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RentCalculation] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RentCalculation] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RentCalculation] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RentCalculation] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RentCalculation] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RentCalculation] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RentCalculation] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RentCalculation] SET  MULTI_USER 
GO
ALTER DATABASE [RentCalculation] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RentCalculation] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RentCalculation] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RentCalculation] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RentCalculation] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RentCalculation] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [RentCalculation] SET QUERY_STORE = OFF
GO
USE [RentCalculation]
GO
/****** Object:  Table [dbo].[Apartments]    Script Date: 15.04.2025 4:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Apartments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NOT NULL,
	[Area] [decimal](6, 2) NOT NULL,
	[ResidentsCount] [tinyint] NOT NULL,
	[Floor] [smallint] NOT NULL,
	[BuildingId] [int] NOT NULL,
 CONSTRAINT [PK_Apartments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BuildingFacilities]    Script Date: 15.04.2025 4:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuildingFacilities](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[BuildingId] [int] NOT NULL,
	[ServiceId] [int] NULL,
 CONSTRAINT [PK_BuildingFacilities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Buildings]    Script Date: 15.04.2025 4:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Buildings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[RegionId] [smallint] NOT NULL,
 CONSTRAINT [PK_Buildings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceDetails]    Script Date: 15.04.2025 4:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetails](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[InvoiceId] [int] NULL,
	[ServiceId] [int] NULL,
	[Consumption] [int] NULL,
	[Amount] [decimal](7, 2) NULL,
 CONSTRAINT [PK_InvoiceDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoices]    Script Date: 15.04.2025 4:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApartmentId] [int] NULL,
	[BuildingId] [int] NULL,
	[PeriodStart] [date] NULL,
	[PeriodEnd] [date] NULL,
	[TotalAmound] [decimal](9, 2) NULL,
	[CreatedAt] [datetime] NULL,
 CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MeterReadings]    Script Date: 15.04.2025 4:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeterReadings](
	[Id] [int] NOT NULL,
	[ApartmentId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
	[Value] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_MeterReadings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Regions]    Script Date: 15.04.2025 4:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regions](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Regions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 15.04.2025 4:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 15.04.2025 4:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Unit] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tariffs]    Script Date: 15.04.2025 4:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tariffs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServiceId] [int] NOT NULL,
	[RegionId] [smallint] NULL,
	[Price] [decimal](8, 2) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
 CONSTRAINT [PK_Tariffs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 15.04.2025 4:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](max) NULL,
	[Surname] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Patronymic] [nvarchar](50) NULL,
	[RoleId] [smallint] NOT NULL,
	[ApartmentId] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Apartments] ON 

INSERT [dbo].[Apartments] ([Id], [Number], [Area], [ResidentsCount], [Floor], [BuildingId]) VALUES (1, 1, CAST(50.00 AS Decimal(6, 2)), 1, 1, 1)
INSERT [dbo].[Apartments] ([Id], [Number], [Area], [ResidentsCount], [Floor], [BuildingId]) VALUES (2, 2, CAST(60.00 AS Decimal(6, 2)), 2, 1, 1)
SET IDENTITY_INSERT [dbo].[Apartments] OFF
GO
SET IDENTITY_INSERT [dbo].[Buildings] ON 

INSERT [dbo].[Buildings] ([Id], [Address], [RegionId]) VALUES (1, N'ул. Декабристов, 83, Екатеринбург', 59)
SET IDENTITY_INSERT [dbo].[Buildings] OFF
GO
SET IDENTITY_INSERT [dbo].[Regions] ON 

INSERT [dbo].[Regions] ([Id], [Name]) VALUES (1, N'Белгородская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (2, N'Брянская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (3, N'Владимирская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (4, N'Воронежская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (5, N'Ивановская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (6, N'Калужская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (7, N'Костромская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (8, N'Курская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (9, N'Липецкая область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (10, N'Московская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (11, N'Орловская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (12, N'Рязанская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (13, N'Смоленская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (14, N'Тамбовская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (15, N'Тверская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (16, N'Тульская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (17, N'Ярославская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (18, N'г. Москва')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (19, N'Республика Карелия')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (20, N'Республика Коми')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (21, N'Архангельская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (22, N'Ненецкий автономный округ')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (23, N'Вологодская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (24, N'Калининградская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (25, N'Ленинградская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (26, N'Мурманская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (27, N'Новгородская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (28, N'Псковская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (29, N'г. Санкт-Петербург')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (30, N'Республика Адыгея')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (31, N'Республика Дагестан')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (32, N'Республика Ингушетия')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (33, N'Кабардино-Балкарская Республика')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (34, N'Республика Калмыкия')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (35, N'Карачаево-Черкесская Республика')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (36, N'Республика Северная Осетия - Алания')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (37, N'Чеченская Республика')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (38, N'Краснодарский край')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (39, N'Ставропольский край')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (40, N'Астраханская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (41, N'Волгоградская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (42, N'Ростовская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (43, N'Республика Башкортостан')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (44, N'Республика Марий Эл')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (45, N'Республика Мордовия')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (46, N'Республика Татарстан')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (47, N'Удмуртская Республика')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (48, N'Чувашская Республика')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (49, N'Кировская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (50, N'Нижегородская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (51, N'Оренбургская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (52, N'Пензенская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (53, N'Пермская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (54, N'Коми-Пермяцкий автономный округ')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (55, N'Самарская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (56, N'Саратовская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (57, N'Ульяновская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (58, N'Курганская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (59, N'Свердловская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (60, N'Тюменская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (61, N'Ханты-Мансийский автономный округ - Югра')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (62, N'Ямало-Ненецкий автономный округ')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (63, N'Челябинская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (64, N'Республика Алтай')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (65, N'Республика Бурятия')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (66, N'Республика Тыва')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (67, N'Республика Хакасия')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (68, N'Алтайский край')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (69, N'Красноярский край')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (70, N'Таймырский (Долгано-Ненецкий) автономный округ')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (71, N'Эвенкийский автономный округ')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (72, N'Иркутская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (73, N'Усть-Ордынский Бурятский автономный округ')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (74, N'Кемеровская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (75, N'Новосибирская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (76, N'Омская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (77, N'Томская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (78, N'Читинская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (79, N'Агинский Бурятский автономный округ')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (80, N'Республика Саха (Якутия)')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (81, N'Приморский край')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (82, N'Хабаровский край')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (83, N'Амурская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (84, N'Камчатская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (85, N'Корякский автономный округ')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (86, N'Магаданская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (87, N'Сахалинская область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (88, N'Еврейская автономная область')
INSERT [dbo].[Regions] ([Id], [Name]) VALUES (89, N'Чукотский автономный округ')
SET IDENTITY_INSERT [dbo].[Regions] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Name]) VALUES (1, N'Житель')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (2, N'Бухгалтер')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (3, N'Администратор')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Services] ON 

INSERT [dbo].[Services] ([Id], [Name], [Unit]) VALUES (2, N'Холодное водоснабжение', N'м3')
INSERT [dbo].[Services] ([Id], [Name], [Unit]) VALUES (3, N'Горячее водоснабжение', N'м3')
INSERT [dbo].[Services] ([Id], [Name], [Unit]) VALUES (5, N'Электроснабжение', N'кВт.ч')
INSERT [dbo].[Services] ([Id], [Name], [Unit]) VALUES (6, N'Газоснабжение', N'м3')
INSERT [dbo].[Services] ([Id], [Name], [Unit]) VALUES (7, N'Отопление', N'Гкал')
INSERT [dbo].[Services] ([Id], [Name], [Unit]) VALUES (8, N'Содержание и ремонт лифтов', N'шт')
INSERT [dbo].[Services] ([Id], [Name], [Unit]) VALUES (9, N'Содержание общего имущества
', N'шт')
INSERT [dbo].[Services] ([Id], [Name], [Unit]) VALUES (10, N'Текущий ремонт общего имущества', N'шт')
INSERT [dbo].[Services] ([Id], [Name], [Unit]) VALUES (11, N'Бытовой газ в баллонах', N'м3')
INSERT [dbo].[Services] ([Id], [Name], [Unit]) VALUES (12, N'Твердое топливо', N'т')
INSERT [dbo].[Services] ([Id], [Name], [Unit]) VALUES (13, N'Отведение сточных вод', N'м3')
INSERT [dbo].[Services] ([Id], [Name], [Unit]) VALUES (14, N'Обращение с твердыми коммунальными отходами', N'т')
SET IDENTITY_INSERT [dbo].[Services] OFF
GO
SET IDENTITY_INSERT [dbo].[Tariffs] ON 

INSERT [dbo].[Tariffs] ([Id], [ServiceId], [RegionId], [Price], [StartDate], [EndDate]) VALUES (2, 2, 59, CAST(0.11 AS Decimal(8, 2)), CAST(N'2025-07-01' AS Date), CAST(N'2025-12-31' AS Date))
INSERT [dbo].[Tariffs] ([Id], [ServiceId], [RegionId], [Price], [StartDate], [EndDate]) VALUES (3, 3, 59, CAST(0.27 AS Decimal(8, 2)), CAST(N'2025-07-01' AS Date), CAST(N'2025-12-31' AS Date))
SET IDENTITY_INSERT [dbo].[Tariffs] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Email], [Password], [Surname], [Name], [Patronymic], [RoleId], [ApartmentId]) VALUES (3, N'george@gmail.com', N'qwerty', N'Савенков', N'Геогрий', N'Георгиевич', 1, 1)
INSERT [dbo].[Users] ([Id], [Email], [Password], [Surname], [Name], [Patronymic], [RoleId], [ApartmentId]) VALUES (4, N'test@gmail.com', N'password', N'Петров', N'Пётр', N'Петрович', 1, 1)
INSERT [dbo].[Users] ([Id], [Email], [Password], [Surname], [Name], [Patronymic], [RoleId], [ApartmentId]) VALUES (8, N'misha@yandex.ru', N'WF8904H98', N'Круг', N'Михаил', N'Иванович', 2, 2)
INSERT [dbo].[Users] ([Id], [Email], [Password], [Surname], [Name], [Patronymic], [RoleId], [ApartmentId]) VALUES (10, N'ivan@gmail.com', N'qweasdzxc', N'Иванов', N'Иван', N'Иванович', 3, 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Apartments]  WITH CHECK ADD  CONSTRAINT [FK_Apartments_Buildings] FOREIGN KEY([BuildingId])
REFERENCES [dbo].[Buildings] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Apartments] CHECK CONSTRAINT [FK_Apartments_Buildings]
GO
ALTER TABLE [dbo].[BuildingFacilities]  WITH CHECK ADD  CONSTRAINT [FK_BuildingFacilities_Buildings] FOREIGN KEY([BuildingId])
REFERENCES [dbo].[Buildings] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BuildingFacilities] CHECK CONSTRAINT [FK_BuildingFacilities_Buildings]
GO
ALTER TABLE [dbo].[BuildingFacilities]  WITH CHECK ADD  CONSTRAINT [FK_BuildingFacilities_Services] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Services] ([Id])
ON UPDATE SET NULL
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[BuildingFacilities] CHECK CONSTRAINT [FK_BuildingFacilities_Services]
GO
ALTER TABLE [dbo].[Buildings]  WITH CHECK ADD  CONSTRAINT [FK_Buildings_Regions] FOREIGN KEY([RegionId])
REFERENCES [dbo].[Regions] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Buildings] CHECK CONSTRAINT [FK_Buildings_Regions]
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetails_Invoices] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[Invoices] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InvoiceDetails] CHECK CONSTRAINT [FK_InvoiceDetails_Invoices]
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetails_Services] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Services] ([Id])
GO
ALTER TABLE [dbo].[InvoiceDetails] CHECK CONSTRAINT [FK_InvoiceDetails_Services]
GO
ALTER TABLE [dbo].[MeterReadings]  WITH CHECK ADD  CONSTRAINT [FK_MeterReadings_Apartments] FOREIGN KEY([ApartmentId])
REFERENCES [dbo].[Apartments] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MeterReadings] CHECK CONSTRAINT [FK_MeterReadings_Apartments]
GO
ALTER TABLE [dbo].[MeterReadings]  WITH CHECK ADD  CONSTRAINT [FK_MeterReadings_Services] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Services] ([Id])
GO
ALTER TABLE [dbo].[MeterReadings] CHECK CONSTRAINT [FK_MeterReadings_Services]
GO
ALTER TABLE [dbo].[Tariffs]  WITH CHECK ADD  CONSTRAINT [FK_Tariffs_Regions] FOREIGN KEY([RegionId])
REFERENCES [dbo].[Regions] ([Id])
ON UPDATE SET NULL
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Tariffs] CHECK CONSTRAINT [FK_Tariffs_Regions]
GO
ALTER TABLE [dbo].[Tariffs]  WITH CHECK ADD  CONSTRAINT [FK_Tariffs_Services] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Services] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tariffs] CHECK CONSTRAINT [FK_Tariffs_Services]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Apartments] FOREIGN KEY([ApartmentId])
REFERENCES [dbo].[Apartments] ([Id])
ON UPDATE SET NULL
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Apartments]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
USE [master]
GO
ALTER DATABASE [RentCalculation] SET  READ_WRITE 
GO
