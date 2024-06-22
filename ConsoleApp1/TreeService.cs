using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class TreeService
    {
        public  List<Node> Nodes = new List<Node>()
        {
            new Node () { Id = 1, Text = "Item 0. 1", ParentId = 0},

            new Node () { Id = 3, Text = "Item 0. 1.3", ParentId = 1},
            new Node () { Id = 4, Text = "Item 0. 1.4", ParentId = 1},
            new Node () { Id = 7, Text = "Item 0. 1.4.7", ParentId = 4},


            new Node () { Id = 2, Text = "Item 0.2", ParentId = 0},
            new Node () { Id = 5, Text = "Item 0.2.5", ParentId = 2},
            new Node () { Id = 6, Text = "Item 0.2.6", ParentId = 2},
        };
        public List<Node> GetChildren(int parentId, List<Node> comments)
        {
            var children = Nodes.Where(x => x.ParentId == parentId);

            foreach (var item in children)
            {
                comments.Add(item);
                GetChildren(item.Id, comments);
            }

            return comments;
        }

        public List<Node> GetParentsWithSelf(int? id, List<Node> comments, List<Node> data)
        {
            var node = data.Single(x => x.Id == id);
            comments.Add(node);
            if (node.ParentId == 0)
                return comments;
            GetParentsWithSelf(node.ParentId, comments, data);

            return comments;

        }


        public List<Node> GetParents(int? id, List<Node> comments, List<Node> data)
        {
            var node = data.Single(x => x.Id == id);
           
            if (node.ParentId == 0)
                return comments;
            var parent = data.Single(x => x.Id == node.ParentId);
            comments.Add(parent);
            GetParents(node.ParentId, comments, data);

            return comments;

        }
        public List<Node> GetChildren2(int parentId, List<Node> comments)
        {
            return Nodes
                .Where(c => c.ParentId == parentId)
                .Select(c => new Node
                {
                    Id = c.Id,
                    Text = c.Text,
                    ParentId = c.ParentId,

                    Children = GetChildren2(c.Id, comments)
                })
                .ToList();
        }
    }

}


﻿namespace ssftest
{
    public class Class1
    {
        //m jlk   nv z1 rtvvddfdfdfdsdfsfsdb
USE [master]
GO
/****** Object:  Database [SpecificationDB]    Script Date: 6/22/2024 12:50:26 AM ******/
CREATE DATABASE [SpecificationDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SpecificationDB', FILENAME = N'C:\Users\Sajad\SpecificationDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SpecificationDB_log', FILENAME = N'C:\Users\Sajad\SpecificationDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SpecificationDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SpecificationDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SpecificationDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SpecificationDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SpecificationDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SpecificationDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SpecificationDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SpecificationDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SpecificationDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SpecificationDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SpecificationDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SpecificationDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SpecificationDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SpecificationDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SpecificationDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SpecificationDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SpecificationDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SpecificationDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SpecificationDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SpecificationDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SpecificationDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SpecificationDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SpecificationDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [SpecificationDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SpecificationDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SpecificationDB] SET  MULTI_USER 
GO
ALTER DATABASE [SpecificationDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SpecificationDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SpecificationDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SpecificationDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SpecificationDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SpecificationDB] SET QUERY_STORE = OFF
GO
USE [SpecificationDB]
GO
/****** Object:  Schema [Specification]    Script Date: 6/22/2024 12:50:26 AM ******/
CREATE SCHEMA [Specification]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/22/2024 12:50:26 AM ******/
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
/****** Object:  Table [Specification].[Answer]    Script Date: 6/22/2024 12:50:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Specification].[Answer](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[QuestionId] [bigint] NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Specification].[Categories]    Script Date: 6/22/2024 12:50:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Specification].[Categories](
	[CategoryId] [bigint] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ModuleId] [nvarchar](50) NOT NULL,
	[Icon] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[ParentId] [bigint] NULL,
	[Code] [nvarchar](max) NOT NULL,
	[LevelCode] [int] NOT NULL,
	[ParentCode] [nvarchar](max) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ExternalId] [varchar](36) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Specification].[CategoryProperties]    Script Date: 6/22/2024 12:50:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Specification].[CategoryProperties](
	[CategoryPropertyId] [nvarchar](450) NOT NULL,
	[CategoryId] [bigint] NOT NULL,
	[PropertyId] [nvarchar](450) NOT NULL,
	[IsRequired] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ExternalId] [varchar](36) NOT NULL,
 CONSTRAINT [PK_CategoryProperties] PRIMARY KEY CLUSTERED 
(
	[CategoryPropertyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Specification].[Properties]    Script Date: 6/22/2024 12:50:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Specification].[Properties](
	[PropertyId] [nvarchar](450) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ElementType] [tinyint] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsSystemic] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ExternalId] [varchar](36) NOT NULL,
 CONSTRAINT [PK_Properties] PRIMARY KEY CLUSTERED 
(
	[PropertyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Specification].[PropertyValue]    Script Date: 6/22/2024 12:50:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Specification].[PropertyValue](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[PropertyId] [nvarchar](450) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_PropertyValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Specification].[Question]    Script Date: 6/22/2024 12:50:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Specification].[Question](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[ParentId] [bigint] NULL,
	[SubjectId] [bigint] NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Specification].[ResultSubject]    Script Date: 6/22/2024 12:50:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Specification].[ResultSubject](
	[Id] [nvarchar](450) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ExternalId] [varchar](36) NOT NULL,
 CONSTRAINT [PK_ResultSubject] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Specification].[RunSubject]    Script Date: 6/22/2024 12:50:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Specification].[RunSubject](
	[Id] [nvarchar](450) NOT NULL,
	[StartTime] [datetime2](7) NOT NULL,
	[EndTime] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ExternalId] [varchar](36) NOT NULL,
 CONSTRAINT [PK_RunSubject] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Specification].[Subject]    Script Date: 6/22/2024 12:50:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Specification].[Subject](
	[SubjectId] [bigint] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[ModuleId] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LevelId] [nvarchar](max) NULL,
	[TargetJameh] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[ExternalId] [varchar](36) NOT NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Specification].[SubjectType]    Script Date: 6/22/2024 12:50:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Specification].[SubjectType](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[SubjectId] [bigint] NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_SubjectType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Answer_QuestionId]    Script Date: 6/22/2024 12:50:26 AM ******/
CREATE NONCLUSTERED INDEX [IX_Answer_QuestionId] ON [Specification].[Answer]
(
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Categories_ParentId]    Script Date: 6/22/2024 12:50:26 AM ******/
CREATE NONCLUSTERED INDEX [IX_Categories_ParentId] ON [Specification].[Categories]
(
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CategoryProperties_CategoryId]    Script Date: 6/22/2024 12:50:26 AM ******/
CREATE NONCLUSTERED INDEX [IX_CategoryProperties_CategoryId] ON [Specification].[CategoryProperties]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_CategoryProperties_PropertyId]    Script Date: 6/22/2024 12:50:26 AM ******/
CREATE NONCLUSTERED INDEX [IX_CategoryProperties_PropertyId] ON [Specification].[CategoryProperties]
(
	[PropertyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_PropertyValue_PropertyId]    Script Date: 6/22/2024 12:50:26 AM ******/
CREATE NONCLUSTERED INDEX [IX_PropertyValue_PropertyId] ON [Specification].[PropertyValue]
(
	[PropertyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Question_ParentId]    Script Date: 6/22/2024 12:50:26 AM ******/
CREATE NONCLUSTERED INDEX [IX_Question_ParentId] ON [Specification].[Question]
(
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Question_SubjectId]    Script Date: 6/22/2024 12:50:26 AM ******/
CREATE NONCLUSTERED INDEX [IX_Question_SubjectId] ON [Specification].[Question]
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SubjectType_SubjectId]    Script Date: 6/22/2024 12:50:26 AM ******/
CREATE NONCLUSTERED INDEX [IX_SubjectType_SubjectId] ON [Specification].[SubjectType]
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [Specification].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Answer_Question_QuestionId] FOREIGN KEY([QuestionId])
REFERENCES [Specification].[Question] ([Id])
GO
ALTER TABLE [Specification].[Answer] CHECK CONSTRAINT [FK_Answer_Question_QuestionId]
GO
ALTER TABLE [Specification].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Categories_ParentId] FOREIGN KEY([ParentId])
REFERENCES [Specification].[Categories] ([CategoryId])
GO
ALTER TABLE [Specification].[Categories] CHECK CONSTRAINT [FK_Categories_Categories_ParentId]
GO
ALTER TABLE [Specification].[CategoryProperties]  WITH CHECK ADD  CONSTRAINT [FK_CategoryProperties_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [Specification].[Categories] ([CategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [Specification].[CategoryProperties] CHECK CONSTRAINT [FK_CategoryProperties_Categories_CategoryId]
GO
ALTER TABLE [Specification].[CategoryProperties]  WITH CHECK ADD  CONSTRAINT [FK_CategoryProperties_Properties_PropertyId] FOREIGN KEY([PropertyId])
REFERENCES [Specification].[Properties] ([PropertyId])
ON DELETE CASCADE
GO
ALTER TABLE [Specification].[CategoryProperties] CHECK CONSTRAINT [FK_CategoryProperties_Properties_PropertyId]
GO
ALTER TABLE [Specification].[PropertyValue]  WITH CHECK ADD  CONSTRAINT [FK_PropertyValue_Properties_PropertyId] FOREIGN KEY([PropertyId])
REFERENCES [Specification].[Properties] ([PropertyId])
GO
ALTER TABLE [Specification].[PropertyValue] CHECK CONSTRAINT [FK_PropertyValue_Properties_PropertyId]
GO
ALTER TABLE [Specification].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Question_ParentId] FOREIGN KEY([ParentId])
REFERENCES [Specification].[Question] ([Id])
GO
ALTER TABLE [Specification].[Question] CHECK CONSTRAINT [FK_Question_Question_ParentId]
GO
ALTER TABLE [Specification].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Subject_SubjectId] FOREIGN KEY([SubjectId])
REFERENCES [Specification].[Subject] ([SubjectId])
GO
ALTER TABLE [Specification].[Question] CHECK CONSTRAINT [FK_Question_Subject_SubjectId]
GO
ALTER TABLE [Specification].[SubjectType]  WITH CHECK ADD  CONSTRAINT [FK_SubjectType_Subject_SubjectId] FOREIGN KEY([SubjectId])
REFERENCES [Specification].[Subject] ([SubjectId])
GO
ALTER TABLE [Specification].[SubjectType] CHECK CONSTRAINT [FK_SubjectType_Subject_SubjectId]
GO
USE [master]
GO
ALTER DATABASE [SpecificationDB] SET  READ_WRITE 
GO

    }
}
