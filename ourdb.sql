USE [master]
GO
/****** Object:  Database [EPproject]    Script Date: 15/02/2021 23:46:45 ******/
CREATE DATABASE [EPproject]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EPproject', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EPproject.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EPproject_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EPproject_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EPproject] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EPproject].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EPproject] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EPproject] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EPproject] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EPproject] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EPproject] SET ARITHABORT OFF 
GO
ALTER DATABASE [EPproject] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EPproject] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EPproject] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EPproject] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EPproject] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EPproject] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EPproject] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EPproject] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EPproject] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EPproject] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EPproject] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EPproject] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EPproject] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EPproject] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EPproject] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EPproject] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EPproject] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EPproject] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EPproject] SET  MULTI_USER 
GO
ALTER DATABASE [EPproject] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EPproject] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EPproject] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EPproject] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EPproject] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EPproject] SET QUERY_STORE = OFF
GO
USE [EPproject]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 15/02/2021 23:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[country] [nvarchar](50) NOT NULL,
	[city] [nvarchar](50) NOT NULL,
	[street] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ageRange]    Script Date: 15/02/2021 23:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ageRange](
	[ageRangeID] [int] IDENTITY(1,1) NOT NULL,
	[age_min] [int] NOT NULL,
	[age_max] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ageRangeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bookedDates]    Script Date: 15/02/2021 23:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bookedDates](
	[bookedDateId] [int] IDENTITY(1,1) NOT NULL,
	[SuggestionId] [int] NOT NULL,
	[dateStart] [datetime] NULL,
	[dateEnd] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[bookedDateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hosts]    Script Date: 15/02/2021 23:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hosts](
	[HostID] [int] NOT NULL,
	[HostName] [nvarchar](30) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[gender] [nvarchar](10) NULL,
	[HostEmail] [nvarchar](30) NOT NULL,
	[HostTel] [nvarchar](20) NOT NULL,
	[HostTextDetails] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[HostID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoursRange]    Script Date: 15/02/2021 23:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoursRange](
	[hoursRangeID] [int] IDENTITY(1,1) NOT NULL,
	[hours_start] [int] NOT NULL,
	[hours_end] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[hoursRangeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceTypeList]    Script Date: 15/02/2021 23:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceTypeList](
	[ServiceTypeListID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceTypeName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ServiceTypeListID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceTypesToSuggestions]    Script Date: 15/02/2021 23:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceTypesToSuggestions](
	[ServiceTypeToSuggestionID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceTypeListID] [int] NOT NULL,
	[SuggestionID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ServiceTypeToSuggestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suggestions]    Script Date: 15/02/2021 23:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suggestions](
	[SuggestionID] [int] IDENTITY(1,1) NOT NULL,
	[SuggestionTitle] [nvarchar](max) NULL,
	[SuggestionDescreotion] [nvarchar](max) NULL,
	[AdressId] [int] NOT NULL,
	[ageRangeID] [int] NULL,
	[hoursRangeID] [int] NULL,
	[hostId] [int] NOT NULL,
	[gender] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[SuggestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SuggestionTraveler]    Script Date: 15/02/2021 23:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SuggestionTraveler](
	[SuggestionId] [int] NOT NULL,
	[TravelerId] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_SuggestionTraveler] PRIMARY KEY CLUSTERED 
(
	[SuggestionId] ASC,
	[TravelerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Travelers]    Script Date: 15/02/2021 23:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Travelers](
	[TravelerID] [int] NOT NULL,
	[TravelerName] [nvarchar](30) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[gender] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[TravelerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 15/02/2021 23:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserPassword] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([AddressId], [country], [city], [street]) VALUES (6, N'Israel', N'nb', N'j,mb')
INSERT [dbo].[Address] ([AddressId], [country], [city], [street]) VALUES (9, N'Israel', N'fd', N'hmmn')
INSERT [dbo].[Address] ([AddressId], [country], [city], [street]) VALUES (1008, N'Israel', N'Ashdod', N'Gad 3')
INSERT [dbo].[Address] ([AddressId], [country], [city], [street]) VALUES (1010, N'Israel', N'Aco', N'chachmoni 4')
INSERT [dbo].[Address] ([AddressId], [country], [city], [street]) VALUES (1011, N'cdcd', N'cdcd', N'cdcd')
INSERT [dbo].[Address] ([AddressId], [country], [city], [street]) VALUES (1013, N'dfhfg', N'sdsgs', N'sfgfd')
INSERT [dbo].[Address] ([AddressId], [country], [city], [street]) VALUES (1014, N'112', N'454', N'454')
INSERT [dbo].[Address] ([AddressId], [country], [city], [street]) VALUES (1017, N'Israel', N'Ashdod', N'Chermesh 2')
SET IDENTITY_INSERT [dbo].[Address] OFF
SET IDENTITY_INSERT [dbo].[ageRange] ON 

INSERT [dbo].[ageRange] ([ageRangeID], [age_min], [age_max]) VALUES (6, 40, 60)
INSERT [dbo].[ageRange] ([ageRangeID], [age_min], [age_max]) VALUES (9, 0, 120)
INSERT [dbo].[ageRange] ([ageRangeID], [age_min], [age_max]) VALUES (1008, 19, 45)
INSERT [dbo].[ageRange] ([ageRangeID], [age_min], [age_max]) VALUES (1010, 0, 120)
INSERT [dbo].[ageRange] ([ageRangeID], [age_min], [age_max]) VALUES (1011, 40, 60)
INSERT [dbo].[ageRange] ([ageRangeID], [age_min], [age_max]) VALUES (1013, 40, 60)
INSERT [dbo].[ageRange] ([ageRangeID], [age_min], [age_max]) VALUES (1014, 0, 120)
INSERT [dbo].[ageRange] ([ageRangeID], [age_min], [age_max]) VALUES (1017, 0, 112)
SET IDENTITY_INSERT [dbo].[ageRange] OFF
SET IDENTITY_INSERT [dbo].[bookedDates] ON 

INSERT [dbo].[bookedDates] ([bookedDateId], [SuggestionId], [dateStart], [dateEnd]) VALUES (1008, 1008, CAST(N'2021-02-11T22:00:00.000' AS DateTime), CAST(N'2021-02-18T22:00:00.000' AS DateTime))
INSERT [dbo].[bookedDates] ([bookedDateId], [SuggestionId], [dateStart], [dateEnd]) VALUES (1017, 1017, CAST(N'2021-02-15T20:00:00.000' AS DateTime), CAST(N'2021-02-26T20:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[bookedDates] OFF
INSERT [dbo].[Hosts] ([HostID], [HostName], [BirthDate], [gender], [HostEmail], [HostTel], [HostTextDetails]) VALUES (1, N'esty', CAST(N'2021-01-14' AS Date), N'female', N'1qaz@wsx', N'0522222222', N',bnkjhbhm')
INSERT [dbo].[Hosts] ([HostID], [HostName], [BirthDate], [gender], [HostEmail], [HostTel], [HostTextDetails]) VALUES (1003, N'Shoshana', CAST(N'1994-01-04' AS Date), N'male', N'1@3456', N'0556541254', N'works at a bank')
INSERT [dbo].[Hosts] ([HostID], [HostName], [BirthDate], [gender], [HostEmail], [HostTel], [HostTextDetails]) VALUES (1007, N'pesi', CAST(N'2021-02-16' AS Date), N'female', N'123456@23', N'0583245841', N'home very big')
INSERT [dbo].[Hosts] ([HostID], [HostName], [BirthDate], [gender], [HostEmail], [HostTel], [HostTextDetails]) VALUES (1012, N'Shira Cohen', CAST(N'2021-02-10' AS Date), N'male', N'pp@nn.jj', N'0583245841', N'penthouse')
SET IDENTITY_INSERT [dbo].[HoursRange] ON 

INSERT [dbo].[HoursRange] ([hoursRangeID], [hours_start], [hours_end]) VALUES (6, 10, 15)
INSERT [dbo].[HoursRange] ([hoursRangeID], [hours_start], [hours_end]) VALUES (9, 10, 15)
INSERT [dbo].[HoursRange] ([hoursRangeID], [hours_start], [hours_end]) VALUES (1008, 0, 24)
INSERT [dbo].[HoursRange] ([hoursRangeID], [hours_start], [hours_end]) VALUES (1010, 7, 15)
INSERT [dbo].[HoursRange] ([hoursRangeID], [hours_start], [hours_end]) VALUES (1011, 10, 15)
INSERT [dbo].[HoursRange] ([hoursRangeID], [hours_start], [hours_end]) VALUES (1013, 10, 15)
INSERT [dbo].[HoursRange] ([hoursRangeID], [hours_start], [hours_end]) VALUES (1014, 10, 15)
INSERT [dbo].[HoursRange] ([hoursRangeID], [hours_start], [hours_end]) VALUES (1017, 10, 15)
SET IDENTITY_INSERT [dbo].[HoursRange] OFF
SET IDENTITY_INSERT [dbo].[ServiceTypeList] ON 

INSERT [dbo].[ServiceTypeList] ([ServiceTypeListID], [ServiceTypeName]) VALUES (1, N'cleaning')
INSERT [dbo].[ServiceTypeList] ([ServiceTypeListID], [ServiceTypeName]) VALUES (2, N'other')
INSERT [dbo].[ServiceTypeList] ([ServiceTypeListID], [ServiceTypeName]) VALUES (3, N'wash the dishes')
INSERT [dbo].[ServiceTypeList] ([ServiceTypeListID], [ServiceTypeName]) VALUES (4, N'babysitting')
INSERT [dbo].[ServiceTypeList] ([ServiceTypeListID], [ServiceTypeName]) VALUES (5, N'Sweep the floor')
INSERT [dbo].[ServiceTypeList] ([ServiceTypeListID], [ServiceTypeName]) VALUES (6, N'Sleep with an elderly person')
INSERT [dbo].[ServiceTypeList] ([ServiceTypeListID], [ServiceTypeName]) VALUES (7, N'Shine silverware')
SET IDENTITY_INSERT [dbo].[ServiceTypeList] OFF
SET IDENTITY_INSERT [dbo].[ServiceTypesToSuggestions] ON 

INSERT [dbo].[ServiceTypesToSuggestions] ([ServiceTypeToSuggestionID], [ServiceTypeListID], [SuggestionID]) VALUES (1009, 4, 1008)
INSERT [dbo].[ServiceTypesToSuggestions] ([ServiceTypeToSuggestionID], [ServiceTypeListID], [SuggestionID]) VALUES (1019, 1, 1017)
SET IDENTITY_INSERT [dbo].[ServiceTypesToSuggestions] OFF
SET IDENTITY_INSERT [dbo].[Suggestions] ON 

INSERT [dbo].[Suggestions] ([SuggestionID], [SuggestionTitle], [SuggestionDescreotion], [AdressId], [ageRangeID], [hoursRangeID], [hostId], [gender]) VALUES (1008, N'Babysitting', N'', 1008, 1008, 1008, 1003, N'female')
INSERT [dbo].[Suggestions] ([SuggestionID], [SuggestionTitle], [SuggestionDescreotion], [AdressId], [ageRangeID], [hoursRangeID], [hostId], [gender]) VALUES (1017, N'Clean the house', N'', 1017, 1017, 1017, 1012, N'')
SET IDENTITY_INSERT [dbo].[Suggestions] OFF
INSERT [dbo].[Travelers] ([TravelerID], [TravelerName], [BirthDate], [gender]) VALUES (2, N'estydd', CAST(N'2018-01-06' AS Date), N'female')
INSERT [dbo].[Travelers] ([TravelerID], [TravelerName], [BirthDate], [gender]) VALUES (1002, N'estyggggdd', CAST(N'2021-01-28' AS Date), N'male')
INSERT [dbo].[Travelers] ([TravelerID], [TravelerName], [BirthDate], [gender]) VALUES (1004, N'Zehava', CAST(N'2000-02-17' AS Date), N'female')
INSERT [dbo].[Travelers] ([TravelerID], [TravelerName], [BirthDate], [gender]) VALUES (1005, N'Chava', CAST(N'1925-12-09' AS Date), N'female')
INSERT [dbo].[Travelers] ([TravelerID], [TravelerName], [BirthDate], [gender]) VALUES (1010, N'pesiq', CAST(N'2021-02-24' AS Date), N'female')
INSERT [dbo].[Travelers] ([TravelerID], [TravelerName], [BirthDate], [gender]) VALUES (1011, N'pesiqq', CAST(N'1993-02-02' AS Date), N'female')
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [UserPassword], [UserName]) VALUES (1, N'1qaz2wsx', N'esty')
INSERT [dbo].[Users] ([UserId], [UserPassword], [UserName]) VALUES (2, N'1qaz2wsx', N'estydd')
INSERT [dbo].[Users] ([UserId], [UserPassword], [UserName]) VALUES (1002, N'1qaz2wsx', N'estyggggdd')
INSERT [dbo].[Users] ([UserId], [UserPassword], [UserName]) VALUES (1003, N'123456', N'Shoshana')
INSERT [dbo].[Users] ([UserId], [UserPassword], [UserName]) VALUES (1004, N'123456', N'Zehava')
INSERT [dbo].[Users] ([UserId], [UserPassword], [UserName]) VALUES (1005, N'123456', N'Chava')
INSERT [dbo].[Users] ([UserId], [UserPassword], [UserName]) VALUES (1007, N'123456', N'pesi')
INSERT [dbo].[Users] ([UserId], [UserPassword], [UserName]) VALUES (1010, N'123456', N'pesiq')
INSERT [dbo].[Users] ([UserId], [UserPassword], [UserName]) VALUES (1011, N'123456', N'pesiqq')
INSERT [dbo].[Users] ([UserId], [UserPassword], [UserName]) VALUES (1012, N'123456', N'Shira Cohen')
SET IDENTITY_INSERT [dbo].[Users] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__C9F28456AC619667]    Script Date: 15/02/2021 23:46:46 ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[bookedDates]  WITH CHECK ADD FOREIGN KEY([SuggestionId])
REFERENCES [dbo].[Suggestions] ([SuggestionID])
GO
ALTER TABLE [dbo].[Hosts]  WITH CHECK ADD FOREIGN KEY([HostID])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[ServiceTypesToSuggestions]  WITH CHECK ADD FOREIGN KEY([ServiceTypeListID])
REFERENCES [dbo].[ServiceTypeList] ([ServiceTypeListID])
GO
ALTER TABLE [dbo].[ServiceTypesToSuggestions]  WITH CHECK ADD FOREIGN KEY([SuggestionID])
REFERENCES [dbo].[Suggestions] ([SuggestionID])
GO
ALTER TABLE [dbo].[Suggestions]  WITH CHECK ADD FOREIGN KEY([AdressId])
REFERENCES [dbo].[Address] ([AddressId])
GO
ALTER TABLE [dbo].[Suggestions]  WITH CHECK ADD FOREIGN KEY([ageRangeID])
REFERENCES [dbo].[ageRange] ([ageRangeID])
GO
ALTER TABLE [dbo].[Suggestions]  WITH CHECK ADD FOREIGN KEY([hostId])
REFERENCES [dbo].[Hosts] ([HostID])
GO
ALTER TABLE [dbo].[Suggestions]  WITH CHECK ADD FOREIGN KEY([hoursRangeID])
REFERENCES [dbo].[HoursRange] ([hoursRangeID])
GO
ALTER TABLE [dbo].[SuggestionTraveler]  WITH CHECK ADD  CONSTRAINT [FK_SuggestionTraveler_Suggestions] FOREIGN KEY([SuggestionId])
REFERENCES [dbo].[Suggestions] ([SuggestionID])
GO
ALTER TABLE [dbo].[SuggestionTraveler] CHECK CONSTRAINT [FK_SuggestionTraveler_Suggestions]
GO
ALTER TABLE [dbo].[SuggestionTraveler]  WITH CHECK ADD  CONSTRAINT [FK_SuggestionTraveler_Travelers] FOREIGN KEY([TravelerId])
REFERENCES [dbo].[Travelers] ([TravelerID])
GO
ALTER TABLE [dbo].[SuggestionTraveler] CHECK CONSTRAINT [FK_SuggestionTraveler_Travelers]
GO
ALTER TABLE [dbo].[Travelers]  WITH CHECK ADD FOREIGN KEY([TravelerID])
REFERENCES [dbo].[Users] ([UserId])
GO
USE [master]
GO
ALTER DATABASE [EPproject] SET  READ_WRITE 
GO
