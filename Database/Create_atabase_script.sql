USE [BCC]
GO

/****** Object:  Table [dbo].[Admin]    Script Date: 7/1/2019 6:35:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Content](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[ProfileId] [int] NOT NULL,
	[LineMessageId] [varchar](32) NOT NULL,
	[DriveContentId] [varchar](128) NOT NULL,
	[MimeType] [varchar](64) NOT NULL,
	[Inactive] [bit] NOT NULL,
	[DriveDownloadUrl] [varchar](256) NULL,
	[DrivePreviewUrl] [varchar](256) NULL,
 CONSTRAINT [PK_Content] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO

CREATE TABLE [dbo].[ContentAccess](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[ContentId] [bigint] NOT NULL,
	[ProfileId] [int] NOT NULL,
	[Inactive] [bit] NOT NULL,
 CONSTRAINT [PK_ContentAccess] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[Profile](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[LineUserId] [varchar](64) NOT NULL,
	[DefaultName] [nvarchar](32) NULL,
 CONSTRAINT [PK_Profile] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[ServiceLog](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[ModuleName] [varchar](128) NOT NULL,
	[TypeName] [varchar](128) NOT NULL,
	[Headers] [nvarchar](512) NULL,
	[Request] [nvarchar](2048) NULL,
	[Response] [nvarchar](2048) NULL,
	[Details] [nvarchar](2048) NULL,
	[ServiceVersion] [varchar](128) NOT NULL,
 CONSTRAINT [PK_ServiceLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO

SET ANSI_PADDING OFF
GO


CREATE TABLE [dbo].[SystemInfo](
	[Name] [varchar](64) NOT NULL,
	[Value] [nvarchar](1048) NOT NULL,
 CONSTRAINT [PK_SystemInfo] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO

SET ANSI_PADDING OFF
GO
 
INSERT [dbo].[SystemInfo] ([Name], [Value]) VALUES ('DRIVE_ACCESS_TOKEN','[GOOGLE_DRIVE_ACCESS_TOKEN_WITH_BEARER_TYPE]')
GO
INSERT [dbo].[SystemInfo] ([Name], [Value]) VALUES ('DRIVE_CLIENT_ID','[GOOGLE_DRIVE_CLIENT_ID]')
GO
INSERT [dbo].[SystemInfo] ([Name], [Value]) VALUES ('DRIVE_CLIENT_SECRET','[GOOGLE_DRIVE_CLIENT_SECRET]')
GO
INSERT [dbo].[SystemInfo] ([Name], [Value]) VALUES ('DRIVE_IMG_SCHEME','https://doc.google.com/uc?id={0}')
GO
INSERT [dbo].[SystemInfo] ([Name], [Value]) VALUES ('DRIVE_REFRESH_TOKEN','[GOOGLE_DRIVE_REFRESH_TOKEN_WITH_BEARER_TYPE]')
GO
INSERT [dbo].[SystemInfo] ([Name], [Value]) VALUES ('DRIVE_TOKEN_SVC','https://www.googleapis.com/oauth2/v4/token')
GO
INSERT [dbo].[SystemInfo] ([Name], [Value]) VALUES ('DRIVE_UPLOAD_SVC','https://www.googleapis.com/upload/drive/v3/files?uploadType=media')
GO
INSERT [dbo].[SystemInfo] ([Name], [Value]) VALUES ('LINE_ACCESS_TOKEN','[LINE@_ACCESS_TOKEN_WITH_BEARER_TYPE]')
GO
INSERT [dbo].[SystemInfo] ([Name], [Value]) VALUES ('LINE_IMG_SCHEME','https://api.line.me/v2/bot/message/{0}/content')
GO
INSERT [dbo].[SystemInfo] ([Name], [Value]) VALUES ('LINE_SVC','https://api.line.me/v2')