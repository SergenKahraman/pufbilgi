USE [master]
GO
/****** Object:  Database [PufDb]    Script Date: 8.04.2021 19:55:20 ******/
CREATE DATABASE [PufDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PufDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PufDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PufDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PufDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PufDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PufDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PufDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PufDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PufDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PufDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PufDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [PufDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PufDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PufDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PufDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PufDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PufDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PufDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PufDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PufDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PufDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PufDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PufDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PufDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PufDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PufDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PufDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PufDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PufDb] SET RECOVERY FULL 
GO
ALTER DATABASE [PufDb] SET  MULTI_USER 
GO
ALTER DATABASE [PufDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PufDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PufDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PufDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PufDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PufDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PufDb', N'ON'
GO
ALTER DATABASE [PufDb] SET QUERY_STORE = OFF
GO
USE [PufDb]
GO
/****** Object:  Schema [Categorization]    Script Date: 8.04.2021 19:55:20 ******/
CREATE SCHEMA [Categorization]
GO
/****** Object:  Schema [Content]    Script Date: 8.04.2021 19:55:20 ******/
CREATE SCHEMA [Content]
GO
/****** Object:  Schema [Management]    Script Date: 8.04.2021 19:55:20 ******/
CREATE SCHEMA [Management]
GO
/****** Object:  Table [Categorization].[ArticleExams]    Script Date: 8.04.2021 19:55:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Categorization].[ArticleExams](
	[Id] [uniqueidentifier] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Updated] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[ArticleId] [uniqueidentifier] NOT NULL,
	[ExamId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ArticleExams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Categorization].[Exams]    Script Date: 8.04.2021 19:55:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Categorization].[Exams](
	[Id] [uniqueidentifier] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Updated] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Name] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_Exams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Categorization].[Grades]    Script Date: 8.04.2021 19:55:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Categorization].[Grades](
	[Id] [uniqueidentifier] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Updated] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Name] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_Grades] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Categorization].[Lessons]    Script Date: 8.04.2021 19:55:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Categorization].[Lessons](
	[Id] [uniqueidentifier] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Updated] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Name] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_Lessons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Categorization].[Subjects]    Script Date: 8.04.2021 19:55:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Categorization].[Subjects](
	[Id] [uniqueidentifier] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Updated] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Name] [nvarchar](80) NOT NULL,
	[LessonId] [uniqueidentifier] NOT NULL,
	[GradeId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Content].[Articles]    Script Date: 8.04.2021 19:55:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Content].[Articles](
	[Id] [uniqueidentifier] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Updated] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LikeCount] [int] NULL,
	[HtmlContent] [nvarchar](max) NOT NULL,
	[SubjectId] [uniqueidentifier] NOT NULL,
	[WriterId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8.04.2021 19:55:20 ******/
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
/****** Object:  Table [Management].[Documents]    Script Date: 8.04.2021 19:55:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Management].[Documents](
	[Id] [uniqueidentifier] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Updated] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[PhysicalAddress] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Management].[SocialAccounts]    Script Date: 8.04.2021 19:55:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Management].[SocialAccounts](
	[Id] [uniqueidentifier] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Updated] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[WriterId] [uniqueidentifier] NOT NULL,
	[Url] [nvarchar](max) NOT NULL,
	[TypeId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_SocialAccounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Management].[SocialTypes]    Script Date: 8.04.2021 19:55:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Management].[SocialTypes](
	[Id] [uniqueidentifier] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Updated] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Name] [nvarchar](60) NOT NULL,
 CONSTRAINT [PK_SocialTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Management].[Writers]    Script Date: 8.04.2021 19:55:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Management].[Writers](
	[Id] [uniqueidentifier] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Updated] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[UserName] [nvarchar](40) NOT NULL,
	[DisplayName] [nvarchar](60) NOT NULL,
	[Password] [nvarchar](64) NOT NULL,
	[MailAddress] [nvarchar](64) NOT NULL,
	[Job] [nvarchar](64) NULL,
	[Description] [nvarchar](240) NULL,
	[DocumentId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Writers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_ArticleExams_ArticleId]    Script Date: 8.04.2021 19:55:20 ******/
CREATE NONCLUSTERED INDEX [IX_ArticleExams_ArticleId] ON [Categorization].[ArticleExams]
(
	[ArticleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ArticleExams_ExamId]    Script Date: 8.04.2021 19:55:20 ******/
CREATE NONCLUSTERED INDEX [IX_ArticleExams_ExamId] ON [Categorization].[ArticleExams]
(
	[ExamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Subjects_GradeId]    Script Date: 8.04.2021 19:55:20 ******/
CREATE NONCLUSTERED INDEX [IX_Subjects_GradeId] ON [Categorization].[Subjects]
(
	[GradeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Subjects_LessonId]    Script Date: 8.04.2021 19:55:20 ******/
CREATE NONCLUSTERED INDEX [IX_Subjects_LessonId] ON [Categorization].[Subjects]
(
	[LessonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Articles_SubjectId]    Script Date: 8.04.2021 19:55:20 ******/
CREATE NONCLUSTERED INDEX [IX_Articles_SubjectId] ON [Content].[Articles]
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Articles_WriterId]    Script Date: 8.04.2021 19:55:20 ******/
CREATE NONCLUSTERED INDEX [IX_Articles_WriterId] ON [Content].[Articles]
(
	[WriterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SocialAccounts_TypeId]    Script Date: 8.04.2021 19:55:20 ******/
CREATE NONCLUSTERED INDEX [IX_SocialAccounts_TypeId] ON [Management].[SocialAccounts]
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SocialAccounts_WriterId]    Script Date: 8.04.2021 19:55:20 ******/
CREATE NONCLUSTERED INDEX [IX_SocialAccounts_WriterId] ON [Management].[SocialAccounts]
(
	[WriterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Writers_DocumentId]    Script Date: 8.04.2021 19:55:20 ******/
CREATE NONCLUSTERED INDEX [IX_Writers_DocumentId] ON [Management].[Writers]
(
	[DocumentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [Categorization].[ArticleExams]  WITH CHECK ADD  CONSTRAINT [FK_ArticleExams_Articles_ArticleId] FOREIGN KEY([ArticleId])
REFERENCES [Content].[Articles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Categorization].[ArticleExams] CHECK CONSTRAINT [FK_ArticleExams_Articles_ArticleId]
GO
ALTER TABLE [Categorization].[ArticleExams]  WITH CHECK ADD  CONSTRAINT [FK_ArticleExams_Exams_ExamId] FOREIGN KEY([ExamId])
REFERENCES [Categorization].[Exams] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Categorization].[ArticleExams] CHECK CONSTRAINT [FK_ArticleExams_Exams_ExamId]
GO
ALTER TABLE [Categorization].[Subjects]  WITH CHECK ADD  CONSTRAINT [FK_Subjects_Grades_GradeId] FOREIGN KEY([GradeId])
REFERENCES [Categorization].[Grades] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Categorization].[Subjects] CHECK CONSTRAINT [FK_Subjects_Grades_GradeId]
GO
ALTER TABLE [Categorization].[Subjects]  WITH CHECK ADD  CONSTRAINT [FK_Subjects_Lessons_LessonId] FOREIGN KEY([LessonId])
REFERENCES [Categorization].[Lessons] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Categorization].[Subjects] CHECK CONSTRAINT [FK_Subjects_Lessons_LessonId]
GO
ALTER TABLE [Content].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_Articles_Subjects_SubjectId] FOREIGN KEY([SubjectId])
REFERENCES [Categorization].[Subjects] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Content].[Articles] CHECK CONSTRAINT [FK_Articles_Subjects_SubjectId]
GO
ALTER TABLE [Content].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_Articles_Writers_WriterId] FOREIGN KEY([WriterId])
REFERENCES [Management].[Writers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Content].[Articles] CHECK CONSTRAINT [FK_Articles_Writers_WriterId]
GO
ALTER TABLE [Management].[SocialAccounts]  WITH CHECK ADD  CONSTRAINT [FK_SocialAccounts_SocialTypes_TypeId] FOREIGN KEY([TypeId])
REFERENCES [Management].[SocialTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Management].[SocialAccounts] CHECK CONSTRAINT [FK_SocialAccounts_SocialTypes_TypeId]
GO
ALTER TABLE [Management].[SocialAccounts]  WITH CHECK ADD  CONSTRAINT [FK_SocialAccounts_Writers_WriterId] FOREIGN KEY([WriterId])
REFERENCES [Management].[Writers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Management].[SocialAccounts] CHECK CONSTRAINT [FK_SocialAccounts_Writers_WriterId]
GO
ALTER TABLE [Management].[Writers]  WITH CHECK ADD  CONSTRAINT [FK_Writers_Documents_DocumentId] FOREIGN KEY([DocumentId])
REFERENCES [Management].[Documents] ([Id])
GO
ALTER TABLE [Management].[Writers] CHECK CONSTRAINT [FK_Writers_Documents_DocumentId]
GO
USE [master]
GO
ALTER DATABASE [PufDb] SET  READ_WRITE 
GO
