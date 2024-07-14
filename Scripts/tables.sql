USE [HRM_Portal]
GO

/****** Object:  Table [dbo].[tblAttributeDetail]    Script Date: 7/15/2024 12:13:39 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tblAttributeDetail](
	[AttributeCode] [varchar](10) NOT NULL,
	[AttributeName] [varchar](100) NOT NULL,
	[AttributeValue] [varchar](255) NOT NULL,
	[AttributeIsActive] [bit] NOT NULL,
	[AttributeDataType] [varchar](45) NOT NULL,
	[AttributeModifyDate] [datetime] NOT NULL,
 CONSTRAINT [PK_attributedetail] PRIMARY KEY CLUSTERED 
(
	[AttributeCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[tblAuditLog]    Script Date: 7/15/2024 12:13:39 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tblAuditLog](
	[AuditLogId] [bigint] IDENTITY(1,1) NOT NULL,
	[AuditDes] [text] NOT NULL,
	[AuditUserId] [varchar](8) NOT NULL,
	[AutditTransType] [varchar](45) NOT NULL,
	[AuditCreateTime] [datetime] NOT NULL,
	[AuditRef] [varchar](255) NULL,
 CONSTRAINT [PK_auditlog] PRIMARY KEY CLUSTERED 
(
	[AuditLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[tblErrorLog]    Script Date: 7/15/2024 12:13:39 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tblErrorLog](
	[ErrorLogId] [bigint] IDENTITY(1,1) NOT NULL,
	[ErrorDescription] [text] NULL,
	[ErrorUserId] [varchar](8) NULL,
	[ErrorDatetime] [datetime] NULL,
	[ErrorLoggedIp] [varchar](45) NULL,
	[ErrorRef] [text] NULL,
	[ErrorPage] [text] NULL,
 CONSTRAINT [PK_errorlog] PRIMARY KEY CLUSTERED 
(
	[ErrorLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[tblUserDetails]    Script Date: 7/15/2024 12:13:39 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tblUserDetails](
	[UD_StaffID] [varchar](10) NOT NULL,
	[UD_FirstName] [varchar](100) NULL,
	[UD_LastName] [varchar](100) NULL,
	[UD_EmailAddress] [varchar](100) NULL,
	[UD_MobileNumber] [varchar](100) NULL,
	[UD_PhoneNumber] [varchar](100) NULL,
	[UD_Remarks] [varchar](max) NULL,
	[authorizationToken] [varchar](max) NULL,
	[UD_UserName] [varchar](100) NULL,
	[UD_Password] [varchar](100) NULL,
 CONSTRAINT [PK_tblUserDetails] PRIMARY KEY CLUSTERED 
(
	[UD_StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[tblUserLog]    Script Date: 7/15/2024 12:13:39 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tblUserLog](
	[UserLogId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserUserId] [varchar](8) NULL,
	[UserLogTime] [datetime] NULL,
	[UserLogOffTime] [datetime] NULL,
 CONSTRAINT [PK_userlog] PRIMARY KEY CLUSTERED 
(
	[UserLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[tblUserMenuItem]    Script Date: 7/15/2024 12:13:39 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tblUserMenuItem](
	[UserMenuItemCode] [varchar](8) NOT NULL,
	[UserMenuItemDes] [varchar](100) NOT NULL,
	[UserMenuItemIsActive] [bit] NOT NULL,
	[UserMenuItemModifyDate] [datetime] NOT NULL,
	[UserMenuItemIsFiltered] [bit] NULL,
 CONSTRAINT [PK_usermenuitem] PRIMARY KEY CLUSTERED 
(
	[UserMenuItemCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[tblUserRole]    Script Date: 7/15/2024 12:13:39 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tblUserRole](
	[UserRoleCode] [varchar](4) NOT NULL,
	[UserRoleName] [varchar](50) NOT NULL,
	[UserRoleIsActive] [bit] NOT NULL,
	[UserRoleModifiedDate] [datetime] NOT NULL,
	[UserRoleModifiedBy] [varchar](50) NOT NULL,
	[UserRoleCreatedDate] [datetime] NOT NULL,
	[UserRoleCreatedBy] [varchar](50) NOT NULL,
 CONSTRAINT [PK_userrole] PRIMARY KEY CLUSTERED 
(
	[UserRoleCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[tblUserRoleMenu]    Script Date: 7/15/2024 12:13:39 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tblUserRoleMenu](
	[UserRMRoleCode] [varchar](4) NOT NULL,
	[UserRMMenuCode] [varchar](8) NOT NULL,
	[UserRMIsActive] [bit] NOT NULL,
	[UserRMModifyDate] [datetime] NOT NULL,
	[UserRMLoggedUserId] [varchar](8) NOT NULL,
	[UserRMId] [bigint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_userrolemenu] PRIMARY KEY CLUSTERED 
(
	[UserRMId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[tblUserRoleMenu]  WITH CHECK ADD  CONSTRAINT [FK_userrolemenu_usermenuitem] FOREIGN KEY([UserRMMenuCode])
REFERENCES [dbo].[tblUserMenuItem] ([UserMenuItemCode])
GO

ALTER TABLE [dbo].[tblUserRoleMenu] CHECK CONSTRAINT [FK_userrolemenu_usermenuitem]
GO

ALTER TABLE [dbo].[tblUserRoleMenu]  WITH CHECK ADD  CONSTRAINT [FK_userrolemenu_userrole] FOREIGN KEY([UserRMRoleCode])
REFERENCES [dbo].[tblUserRole] ([UserRoleCode])
GO

ALTER TABLE [dbo].[tblUserRoleMenu] CHECK CONSTRAINT [FK_userrolemenu_userrole]
GO


