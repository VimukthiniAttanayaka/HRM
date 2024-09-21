USE [Neelaka1]
GO

ALTER TABLE [dbo].[tblEmployee] DROP CONSTRAINT [DF__tbl_user___USR_M__22B5168E]
GO

ALTER TABLE [dbo].[tblEmployee] DROP CONSTRAINT [DF__tbl_user___USR_M__21C0F255]
GO

ALTER TABLE [dbo].[tblEmployee] DROP CONSTRAINT [DF__tbl_user___USR_C__20CCCE1C]
GO

ALTER TABLE [dbo].[tblEmployee] DROP CONSTRAINT [DF__tbl_user___USR_S__1FD8A9E3]
GO

ALTER TABLE [dbo].[tblEmployee] DROP CONSTRAINT [DF__tbl_user___USR_L__1EE485AA]
GO

ALTER TABLE [dbo].[tblEmployee] DROP CONSTRAINT [DF__tbl_user___USR_P__1CFC3D38]
GO

ALTER TABLE [dbo].[tblEmployee] DROP CONSTRAINT [DF__tbl_user___USR_R__164F3FA9]
GO

ALTER TABLE [dbo].[tblEmployee] DROP CONSTRAINT [DF__tbl_user___USR_P__155B1B70]
GO

ALTER TABLE [dbo].[tblEmployee] DROP CONSTRAINT [DF__tbl_user___USR_J__1466F737]
GO

ALTER TABLE [dbo].[tblEmployee] DROP CONSTRAINT [DF__tbl_user___USR_D__1372D2FE]
GO

ALTER TABLE [dbo].[tblEmployee] DROP CONSTRAINT [DF__tbl_user___USR_D__127EAEC5]
GO

ALTER TABLE [dbo].[tblEmployee] DROP CONSTRAINT [DF__tbl_user___USR_D__118A8A8C]
GO

ALTER TABLE [dbo].[tblCustomer] DROP CONSTRAINT [DF__tbl_custo__CUS_M__7E37BEF6]
GO

ALTER TABLE [dbo].[tblCustomer] DROP CONSTRAINT [DF__tbl_custo__CUS_M__7D439ABD]
GO

ALTER TABLE [dbo].[tblCustomer] DROP CONSTRAINT [DF__tbl_custo__CUS_C__7C4F7684]
GO

ALTER TABLE [dbo].[tblCustomer] DROP CONSTRAINT [DF__tbl_custo__CUS_P__7B5B524B]
GO

ALTER TABLE [dbo].[tblCountry] DROP CONSTRAINT [DF__tbl_count__COU_T__49C3F6B7]
GO

ALTER TABLE [dbo].[tbl_user_profile_map] DROP CONSTRAINT [DF__tbl_user___UPM_T__3D2915A8]
GO

ALTER TABLE [dbo].[tbl_user_profile_map] DROP CONSTRAINT [DF__tbl_user___UPM_D__3C34F16F]
GO

ALTER TABLE [dbo].[tbl_user_profile_map] DROP CONSTRAINT [DF__tbl_user___UPM_U__3B40CD36]
GO

ALTER TABLE [dbo].[tbl_user_profile_map] DROP CONSTRAINT [DF__tbl_user___UPM_U__3A4CA8FD]
GO

ALTER TABLE [dbo].[tbl_user_internal] DROP CONSTRAINT [DF_tbl_user_internal_UE_ModifiedDateTime]
GO

ALTER TABLE [dbo].[tbl_user_internal] DROP CONSTRAINT [DF_tbl_user_internal_UE_ModifiedBy]
GO

ALTER TABLE [dbo].[tbl_user_internal] DROP CONSTRAINT [DF_tbl_user_internal_UE_CreatedDateTime]
GO

ALTER TABLE [dbo].[tbl_user_internal] DROP CONSTRAINT [DF_tbl_user_internal_UE_LastName]
GO

ALTER TABLE [dbo].[tbl_user_external] DROP CONSTRAINT [DF__tbl_user___UE_Mo__489AC854]
GO

ALTER TABLE [dbo].[tbl_user_external] DROP CONSTRAINT [DF__tbl_user___UE_Mo__47A6A41B]
GO

ALTER TABLE [dbo].[tbl_user_external] DROP CONSTRAINT [DF__tbl_user___UE_Cr__46B27FE2]
GO

ALTER TABLE [dbo].[tbl_user_external] DROP CONSTRAINT [DF__tbl_user___UE_La__44CA3770]
GO

ALTER TABLE [dbo].[tbl_system_parameter] DROP CONSTRAINT [DF__tbl_syste__SP_Mo__3F115E1A]
GO

ALTER TABLE [dbo].[tbl_system_parameter] DROP CONSTRAINT [DF__tbl_syste__SP_Mo__3E1D39E1]
GO

ALTER TABLE [dbo].[tbl_system_parameter] DROP CONSTRAINT [DF__tbl_syste__SP_Di__3D2915A8]
GO

ALTER TABLE [dbo].[tbl_system_parameter] DROP CONSTRAINT [DF__tbl_syste__SP_Ty__3C34F16F]
GO

ALTER TABLE [dbo].[tbl_system_parameter] DROP CONSTRAINT [DF__tbl_syste__SP_Va__3B40CD36]
GO

ALTER TABLE [dbo].[tbl_system_parameter] DROP CONSTRAINT [DF__tbl_syste__SP_De__3A4CA8FD]
GO

ALTER TABLE [dbo].[tbl_country] DROP CONSTRAINT [DF__tbl_count__COU_T__5DCAEF64]
GO

/****** Object:  Table [dbo].[tblUserRoleAccessGroup]    Script Date: 9/22/2024 4:58:58 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblUserRoleAccessGroup]') AND type in (N'U'))
DROP TABLE [dbo].[tblUserRoleAccessGroup]
GO

/****** Object:  Table [dbo].[tblUserRole]    Script Date: 9/22/2024 4:58:58 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblUserRole]') AND type in (N'U'))
DROP TABLE [dbo].[tblUserRole]
GO

/****** Object:  Table [dbo].[tblUserMenu]    Script Date: 9/22/2024 4:58:58 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblUserMenu]') AND type in (N'U'))
DROP TABLE [dbo].[tblUserMenu]
GO

/****** Object:  Table [dbo].[tblUserLog]    Script Date: 9/22/2024 4:58:58 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblUserLog]') AND type in (N'U'))
DROP TABLE [dbo].[tblUserLog]
GO

/****** Object:  Table [dbo].[tblMenuAccess]    Script Date: 9/22/2024 4:58:58 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblMenuAccess]') AND type in (N'U'))
DROP TABLE [dbo].[tblMenuAccess]
GO

/****** Object:  Table [dbo].[tblLocation]    Script Date: 9/22/2024 4:58:58 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblLocation]') AND type in (N'U'))
DROP TABLE [dbo].[tblLocation]
GO

/****** Object:  Table [dbo].[tblJobRole]    Script Date: 9/22/2024 4:58:58 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblJobRole]') AND type in (N'U'))
DROP TABLE [dbo].[tblJobRole]
GO

/****** Object:  Table [dbo].[tblErrorLog]    Script Date: 9/22/2024 4:58:58 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblErrorLog]') AND type in (N'U'))
DROP TABLE [dbo].[tblErrorLog]
GO

/****** Object:  Table [dbo].[tblEmployee_EmployeeDocument]    Script Date: 9/22/2024 4:58:58 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblEmployee_EmployeeDocument]') AND type in (N'U'))
DROP TABLE [dbo].[tblEmployee_EmployeeDocument]
GO

/****** Object:  Table [dbo].[tblEmployee]    Script Date: 9/22/2024 4:58:58 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblEmployee]') AND type in (N'U'))
DROP TABLE [dbo].[tblEmployee]
GO

/****** Object:  Table [dbo].[tblDepartment]    Script Date: 9/22/2024 4:58:58 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblDepartment]') AND type in (N'U'))
DROP TABLE [dbo].[tblDepartment]
GO

/****** Object:  Table [dbo].[tblCustomer]    Script Date: 9/22/2024 4:58:58 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblCustomer]') AND type in (N'U'))
DROP TABLE [dbo].[tblCustomer]
GO

/****** Object:  Table [dbo].[tblCountry]    Script Date: 9/22/2024 4:58:58 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblCountry]') AND type in (N'U'))
DROP TABLE [dbo].[tblCountry]
GO

/****** Object:  Table [dbo].[tblBranch]    Script Date: 9/22/2024 4:58:58 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblBranch]') AND type in (N'U'))
DROP TABLE [dbo].[tblBranch]
GO

/****** Object:  Table [dbo].[tblAttributeDetail]    Script Date: 9/22/2024 4:58:58 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblAttributeDetail]') AND type in (N'U'))
DROP TABLE [dbo].[tblAttributeDetail]
GO

/****** Object:  Table [dbo].[tblAccessGroup]    Script Date: 9/22/2024 4:58:58 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblAccessGroup]') AND type in (N'U'))
DROP TABLE [dbo].[tblAccessGroup]
GO

/****** Object:  Table [dbo].[tbl_user_profile_map]    Script Date: 9/22/2024 4:58:58 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_user_profile_map]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_user_profile_map]
GO

/****** Object:  Table [dbo].[tbl_user_internal]    Script Date: 9/22/2024 4:58:58 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_user_internal]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_user_internal]
GO

/****** Object:  Table [dbo].[tbl_user_external]    Script Date: 9/22/2024 4:58:58 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_user_external]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_user_external]
GO

/****** Object:  Table [dbo].[tbl_system_parameter]    Script Date: 9/22/2024 4:58:58 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_system_parameter]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_system_parameter]
GO

/****** Object:  Table [dbo].[tbl_holidaycalender]    Script Date: 9/22/2024 4:58:58 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_holidaycalender]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_holidaycalender]
GO

/****** Object:  Table [dbo].[tbl_excel_upload_data_tracer]    Script Date: 9/22/2024 4:58:58 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_excel_upload_data_tracer]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_excel_upload_data_tracer]
GO

/****** Object:  Table [dbo].[tbl_country]    Script Date: 9/22/2024 4:58:58 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_country]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_country]
GO

/****** Object:  Table [dbo].[tbl_AuditLog_ActionMap]    Script Date: 9/22/2024 4:58:58 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_AuditLog_ActionMap]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_AuditLog_ActionMap]
GO

/****** Object:  Table [dbo].[tbl_auditlog]    Script Date: 9/22/2024 4:58:58 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_auditlog]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_auditlog]
GO

/****** Object:  Table [dbo].[tbl_auditlog]    Script Date: 9/22/2024 4:58:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_auditlog](
	[Action] [varchar](255) NULL,
	[Description] [varchar](max) NULL,
	[CreatedBy] [varchar](255) NULL,
	[ClientIP] [varchar](255) NULL,
	[CreatedDateTime] [datetime] NULL,
	[SequenceNo] [bigint] IDENTITY(1,1) NOT NULL,
	[Module] [varchar](255) NULL,
	[Controler] [varchar](255) NULL,
	[ActionType] [varchar](255) NULL,
	[ActionMap_ID] [varchar](10) NULL,
 CONSTRAINT [PK_tbl_auditlog_1] PRIMARY KEY CLUSTERED 
(
	[SequenceNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tbl_AuditLog_ActionMap]    Script Date: 9/22/2024 4:58:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_AuditLog_ActionMap](
	[Module] [varchar](255) NULL,
	[Controller] [varchar](255) NULL,
	[Action] [varchar](255) NULL,
	[ID] [varchar](10) NOT NULL,
 CONSTRAINT [PK_tbl_AuditLog_ActionMap] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tbl_country]    Script Date: 9/22/2024 4:58:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_country](
	[COU_Code] [varchar](3) NOT NULL,
	[COU_Name] [varchar](100) NOT NULL,
	[COU_ISO_AlphaCode] [varchar](3) NOT NULL,
	[COU_ISO_NumericCode] [decimal](3, 0) NOT NULL,
	[COU_TimeZoneDifferenceInMinutes] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[COU_Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tbl_excel_upload_data_tracer]    Script Date: 9/22/2024 4:58:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_excel_upload_data_tracer](
	[CUST_ID] [varchar](max) NULL,
	[IMPORT_FILE_TYPE] [varchar](max) NULL,
	[FULL_LIST] [bit] NULL,
	[IMPORTED_BY] [varchar](100) NULL,
	[STATUS] [varchar](100) NULL,
	[UPLOADED_EXCEL_NAME] [varchar](100) NOT NULL,
	[SUCCESS_RECORD_COUNT] [bigint] NULL,
	[ERROR_RECORD_COUNT] [bigint] NULL,
	[UPLOADED_EXCEL_URL] [varchar](max) NULL,
	[IMPORTED_DATE] [datetime] NULL,
 CONSTRAINT [PK_tbl_excel_upload_data_tracer] PRIMARY KEY CLUSTERED 
(
	[UPLOADED_EXCEL_NAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tbl_holidaycalender]    Script Date: 9/22/2024 4:58:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_holidaycalender](
	[HolidayCalenderDate] [datetime] NOT NULL,
	[HolidayCalenderModifiedDate] [datetime] NOT NULL,
	[HolidayCalenderModifiedBy] [varchar](50) NOT NULL,
	[HolidayCalenderIsActive] [bit] NOT NULL,
	[HolidayCalenderCreatedDate] [datetime] NOT NULL,
	[HolidayCalenderCreatedBy] [varchar](50) NOT NULL,
	[HolidayCalenderDescription] [varchar](50) NOT NULL,
	[HolidayCalenderHolidayType] [varchar](5) NULL,
 CONSTRAINT [PK_holidaycalender_1] PRIMARY KEY CLUSTERED 
(
	[HolidayCalenderDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tbl_system_parameter]    Script Date: 9/22/2024 4:58:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_system_parameter](
	[SP_ID] [varchar](50) NOT NULL,
	[SP_Description] [varchar](500) NULL,
	[SP_Value] [varchar](200) NULL,
	[SP_Type] [varchar](10) NOT NULL,
	[SP_DisplaySeq] [int] NOT NULL,
	[SP_ModifiedBy] [varchar](20) NULL,
	[SP_ModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK__tbl_syst__AA24DA23DF8DB992] PRIMARY KEY CLUSTERED 
(
	[SP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tbl_user_external]    Script Date: 9/22/2024 4:58:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_user_external](
	[UE_UserID] [varchar](50) NOT NULL,
	[UE_FirstName] [varchar](100) NOT NULL,
	[UE_LastName] [varchar](100) NULL,
	[UE_EmailAddress] [varchar](100) NULL,
	[UE_MobileNumber] [varchar](20) NOT NULL,
	[UE_PhoneNumber] [varchar](20) NOT NULL,
	[UE_Remarks] [varchar](200) NOT NULL,
	[UE_ActiveFrom] [date] NOT NULL,
	[UE_ActiveTo] [date] NOT NULL,
	[UE_Status] [bit] NULL,
	[UE_Pwd] [varchar](500) NOT NULL,
	[UE_PwdSalt] [nvarchar](60) NOT NULL,
	[UE_PwdLastResetDateTime] [datetime] NOT NULL,
	[UE_CreatedBy] [varchar](50) NOT NULL,
	[UE_CreatedDateTime] [datetime] NULL,
	[UE_ModifiedBy] [varchar](50) NULL,
	[UE_ModifiedDateTime] [datetime] NULL,
	[UE_Otp] [int] NULL,
	[UE_Otp_Generate_On] [datetime] NULL,
 CONSTRAINT [PK__tbl_user__0E0F0A5C94CA9297] PRIMARY KEY CLUSTERED 
(
	[UE_UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tbl_user_internal]    Script Date: 9/22/2024 4:58:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_user_internal](
	[UE_UserID] [varchar](50) NOT NULL,
	[UE_FirstName] [varchar](100) NOT NULL,
	[UE_LastName] [varchar](100) NULL,
	[UE_EmailAddress] [varchar](100) NULL,
	[UE_MobileNumber] [varchar](20) NOT NULL,
	[UE_PhoneNumber] [varchar](20) NOT NULL,
	[UE_Remarks] [varchar](200) NOT NULL,
	[UE_ActiveFrom] [date] NOT NULL,
	[UE_ActiveTo] [date] NOT NULL,
	[UE_Status] [bit] NULL,
	[UE_Pwd] [varchar](500) NOT NULL,
	[UE_PwdSalt] [nvarchar](60) NOT NULL,
	[UE_PwdLastResetDateTime] [datetime] NOT NULL,
	[UE_CreatedBy] [varchar](50) NOT NULL,
	[UE_CreatedDateTime] [datetime] NULL,
	[UE_ModifiedBy] [varchar](50) NULL,
	[UE_ModifiedDateTime] [datetime] NULL,
	[UE_Otp] [int] NULL,
	[UE_Otp_Generate_On] [datetime] NULL,
	[UE_EmployeeID] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_user_internal] PRIMARY KEY CLUSTERED 
(
	[UE_UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tbl_user_profile_map]    Script Date: 9/22/2024 4:58:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_user_profile_map](
	[UPM_UserID] [varchar](100) NOT NULL,
	[UPM_UserEmail] [varchar](100) NULL,
	[UPM_UserTableID] [varchar](100) NOT NULL,
	[UPM_MobileNumber] [nvarchar](50) NULL,
	[UPM_Description] [varchar](200) NULL,
	[UPM_Type] [varchar](2) NOT NULL,
	[UPM_AuthenticationKey] [varchar](max) NULL,
	[UPM_SyncedDateTime] [datetime] NULL,
	[Last_Access_DateTime] [datetime] NULL,
 CONSTRAINT [PK__tbl_user__94A74A871A0BEA25] PRIMARY KEY CLUSTERED 
(
	[UPM_UserID] ASC,
	[UPM_UserTableID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [tbl_user_profile_map_email_constr] UNIQUE NONCLUSTERED 
(
	[UPM_UserEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblAccessGroup]    Script Date: 9/22/2024 4:58:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblAccessGroup](
	[UAG_AccessGroupID] [varchar](10) NOT NULL,
	[UAG_AccessGroup] [varchar](50) NOT NULL,
	[UAG_Status] [bit] NOT NULL,
	[UAG_CreatedBy] [varchar](10) NULL,
	[UAG_CreatedDateTime] [datetime] NULL,
	[UAG_ModifiedBy] [varchar](10) NULL,
	[UAG_ModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_tblAccessGroup] PRIMARY KEY CLUSTERED 
(
	[UAG_AccessGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblAttributeDetail]    Script Date: 9/22/2024 4:58:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblBranch]    Script Date: 9/22/2024 4:58:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblBranch](
	[MDB_BranchID] [varchar](10) NOT NULL,
	[MDB_Branch] [varchar](50) NOT NULL,
	[MDB_Status] [bit] NOT NULL,
	[MDB_CreatedBy] [varchar](50) NULL,
	[MDB_CreatedDateTime] [datetime] NULL,
	[MDB_ModifiedBy] [varchar](50) NULL,
	[MDB_ModifiedDateTime] [datetime] NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblCountry]    Script Date: 9/22/2024 4:58:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblCountry](
	[MDCTY_CountryID] [varchar](10) NOT NULL,
	[MDCTY_Country] [varchar](50) NOT NULL,
	[MDCTY_Status] [bit] NOT NULL,
	[MDCTY_CreatedBy] [varchar](50) NULL,
	[MDCTY_CreatedDateTime] [datetime] NULL,
	[MDCTY_ModifiedBy] [varchar](50) NULL,
	[MDCTY_ModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK__tbl_coun__83B62EC349567197] PRIMARY KEY CLUSTERED 
(
	[MDCTY_CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblCustomer]    Script Date: 9/22/2024 4:58:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblCustomer](
	[CUS_ID] [varchar](20) NOT NULL,
	[CUS_CompanyName] [varchar](100) NOT NULL,
	[CUS_Adrs_BlockBuildingNo] [varchar](100) NOT NULL,
	[CUS_Adrs_BuildingName] [varchar](100) NOT NULL,
	[CUS_Adrs_UnitNumber] [varchar](20) NOT NULL,
	[CUS_Adrs_StreetName] [varchar](50) NOT NULL,
	[CUS_Adrs_City] [varchar](50) NOT NULL,
	[CUS_Adrs_CountryCode] [varchar](5) NOT NULL,
	[CUS_Adrs_PostalCode] [varchar](10) NOT NULL,
	[CUS_ContactPerson] [varchar](200) NOT NULL,
	[CUS_ContactNumber] [varchar](20) NOT NULL,
	[CUS_PinOrPwd] [varchar](3) NULL,
	[CUS_OTP_By_SMS] [bit] NOT NULL,
	[CUS_OTP_By_Email] [bit] NOT NULL,
	[CUS_Status] [bit] NOT NULL,
	[CUS_CreatedBy] [varchar](100) NOT NULL,
	[CUS_CreatedDateTime] [datetime] NULL,
	[CUS_ModifiedBy] [varchar](100) NULL,
	[CUS_ModifiedDateTime] [datetime] NULL,
	[CUS_GroupCompany] [varchar](50) NULL,
 CONSTRAINT [PK__tbl_cust__373A37B74CC50148] PRIMARY KEY CLUSTERED 
(
	[CUS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblDepartment]    Script Date: 9/22/2024 4:58:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblDepartment](
	[MDD_DepartmentID] [varchar](10) NOT NULL,
	[MDD_Department] [varchar](50) NOT NULL,
	[MDD_LocationID] [varchar](50) NOT NULL,
	[MDD_Status] [bit] NOT NULL,
	[MDD_CreatedBy] [varchar](50) NULL,
	[MDD_CreatedDateTime] [datetime] NULL,
	[MDD_ModifiedBy] [varchar](50) NULL,
	[MDD_ModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_tblDepartment] PRIMARY KEY CLUSTERED 
(
	[MDD_DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblEmployee]    Script Date: 9/22/2024 4:58:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblEmployee](
	[EME_CustomerID] [varchar](10) NOT NULL,
	[EME_DepartmentID] [varchar](10) NOT NULL,
	[EME_EmployeeID] [varchar](10) NOT NULL,
	[EME_FirstName] [varchar](50) NOT NULL,
	[EME_LastName] [varchar](50) NOT NULL,
	[EME_Gender] [varchar](10) NOT NULL,
	[EME_MaritalStatus] [varchar](10) NOT NULL,
	[EME_Nationality] [varchar](10) NOT NULL,
	[EME_BloodGroup] [varchar](5) NOT NULL,
	[EME_NIC] [varchar](20) NULL,
	[EME_Passport] [varchar](20) NULL,
	[EME_DrivingLicense] [varchar](20) NULL,
	[EME_PrefferedName] [varchar](50) NULL,
	[EME_JobTitle_Code] [varchar](10) NULL,
	[EME_ReportingManager] [varchar](10) NULL,
	[EME_EmployeeType] [varchar](10) NULL,
	[EME_PayeeTaxNumber] [varchar](20) NULL,
	[EME_Salary] [decimal](18, 2) NULL,
	[EME_Address] [varchar](100) NULL,
	[EME_EmailAddress] [varchar](50) NULL,
	[EME_MobileNumber] [varchar](10) NULL,
	[EME_PhoneNumber1] [varchar](10) NULL,
	[EME_PhoneNumber2] [varchar](10) NULL,
	[EME_Status] [bit] NULL,
	[EME_CreatedBy] [varchar](50) NULL,
	[EME_CreatedDateTime] [datetime] NULL,
	[EME_ModifiedBy] [varchar](50) NULL,
	[EME_ModifiedDateTime] [datetime] NULL,
	[EME_DateOfHire] [datetime] NULL,
	[EME_DateOfBirth] [datetime] NULL,
 CONSTRAINT [PK__tbl_user__3C52D4B2B768577C] PRIMARY KEY CLUSTERED 
(
	[EME_EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblEmployee_EmployeeDocument]    Script Date: 9/22/2024 4:58:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblEmployee_EmployeeDocument](
	[USRED_EmployeeID] [varchar](50) NULL,
	[USRED_EmployeeDocumentID] [int] IDENTITY(1,1) NOT NULL,
	[USRED_DocumentType] [varchar](50) NULL,
	[USRED_DocumentName] [varchar](50) NULL,
	[USRED_Status] [bit] NULL,
	[USRED_CreatedBy] [varchar](50) NULL,
	[USRED_CreatedDateTime] [datetime] NULL,
	[USRED_ModifiedBy] [varchar](50) NULL,
	[USRED_ModifiedDateTime] [datetime] NULL,
	[USRED_DocumentData] [varchar](max) NULL,
 CONSTRAINT [PK_tblEmployee_EmployeeDocument] PRIMARY KEY CLUSTERED 
(
	[USRED_EmployeeDocumentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblErrorLog]    Script Date: 9/22/2024 4:58:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblJobRole]    Script Date: 9/22/2024 4:58:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblJobRole](
	[MDJR_JobRoleID] [varchar](10) NOT NULL,
	[MDJR_JobRole] [varchar](50) NOT NULL,
	[MDJR_Status] [bit] NOT NULL,
	[MDJR_CreatedBy] [varchar](50) NULL,
	[MDJR_CreatedDateTime] [datetime] NULL,
	[MDJR_ModifiedBy] [varchar](50) NULL,
	[MDJR_ModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_tblJobRole] PRIMARY KEY CLUSTERED 
(
	[MDJR_JobRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblLocation]    Script Date: 9/22/2024 4:58:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblLocation](
	[MDL_LocationID] [varchar](10) NOT NULL,
	[MDL_Location] [varchar](50) NOT NULL,
	[MDL_Status] [bit] NOT NULL,
	[MDL_CreatedBy] [varchar](50) NULL,
	[MDL_CreatedDateTime] [datetime] NULL,
	[MDL_ModifiedBy] [varchar](50) NULL,
	[MDL_ModifiedDateTime] [datetime] NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblMenuAccess]    Script Date: 9/22/2024 4:58:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblMenuAccess](
	[UMA_MenuAccessID] [int] IDENTITY(1,1) NOT NULL,
	[UMA_UserMenuID] [varchar](10) NOT NULL,
	[UMA_AccessGroupID] [varchar](10) NOT NULL,
	[UMA_Status] [bit] NOT NULL,
	[UMA_CreatedBy] [varchar](10) NULL,
	[UMA_CreatedDateTime] [datetime] NULL,
	[UMA_ModifiedBy] [varchar](10) NULL,
	[UMA_ModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_tblMenuAccess] PRIMARY KEY CLUSTERED 
(
	[UMA_MenuAccessID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblUserLog]    Script Date: 9/22/2024 4:58:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblUserLog](
	[UserLogId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserUserId] [varchar](8) NULL,
	[UserLogTime] [datetime] NULL,
	[UserLogOffTime] [datetime] NULL,
 CONSTRAINT [PK_userlog] PRIMARY KEY CLUSTERED 
(
	[UserLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblUserMenu]    Script Date: 9/22/2024 4:58:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblUserMenu](
	[UUM_UserMenuID] [varchar](10) NOT NULL,
	[UUM_UserMenu] [varchar](50) NOT NULL,
	[UUM_Status] [bit] NOT NULL,
	[UUM_CreatedBy] [varchar](10) NULL,
	[UUM_CreatedDateTime] [datetime] NULL,
	[UUM_ModifiedBy] [varchar](10) NULL,
	[UUM_ModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_tblUserMenu] PRIMARY KEY CLUSTERED 
(
	[UUM_UserMenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblUserRole]    Script Date: 9/22/2024 4:58:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblUserRole](
	[UUR_UserRoleID] [varchar](10) NOT NULL,
	[UUR_UserRole] [varchar](50) NOT NULL,
	[UUR_Status] [bit] NOT NULL,
	[UUR_ModifiedDateTime] [datetime] NULL,
	[UUR_ModifiedBy] [varchar](50) NULL,
	[UUR_CreatedDateTime] [datetime] NULL,
	[UUR_CreatedBy] [varchar](50) NULL,
 CONSTRAINT [PK_userrole] PRIMARY KEY CLUSTERED 
(
	[UUR_UserRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblUserRoleAccessGroup]    Script Date: 9/22/2024 4:58:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblUserRoleAccessGroup](
	[UURAG_UserRoleAccessGroupID] [int] IDENTITY(1,1) NOT NULL,
	[UURAG_AccessGroupID] [varchar](10) NOT NULL,
	[UURAG_UserRoleID] [varchar](50) NOT NULL,
	[UURAG_Status] [bit] NOT NULL,
	[UURAG_CreatedBy] [varchar](50) NULL,
	[UURAG_CreatedDateTime] [datetime] NULL,
	[UURAG_ModifiedBy] [varchar](50) NULL,
	[UURAG_ModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_tblUserAccessGroup] PRIMARY KEY CLUSTERED 
(
	[UURAG_UserRoleAccessGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tbl_country] ADD  DEFAULT ((0)) FOR [COU_TimeZoneDifferenceInMinutes]
GO

ALTER TABLE [dbo].[tbl_system_parameter] ADD  CONSTRAINT [DF__tbl_syste__SP_De__3A4CA8FD]  DEFAULT (NULL) FOR [SP_Description]
GO

ALTER TABLE [dbo].[tbl_system_parameter] ADD  CONSTRAINT [DF__tbl_syste__SP_Va__3B40CD36]  DEFAULT (NULL) FOR [SP_Value]
GO

ALTER TABLE [dbo].[tbl_system_parameter] ADD  CONSTRAINT [DF__tbl_syste__SP_Ty__3C34F16F]  DEFAULT (NULL) FOR [SP_Type]
GO

ALTER TABLE [dbo].[tbl_system_parameter] ADD  CONSTRAINT [DF__tbl_syste__SP_Di__3D2915A8]  DEFAULT (NULL) FOR [SP_DisplaySeq]
GO

ALTER TABLE [dbo].[tbl_system_parameter] ADD  CONSTRAINT [DF__tbl_syste__SP_Mo__3E1D39E1]  DEFAULT (NULL) FOR [SP_ModifiedBy]
GO

ALTER TABLE [dbo].[tbl_system_parameter] ADD  CONSTRAINT [DF__tbl_syste__SP_Mo__3F115E1A]  DEFAULT (NULL) FOR [SP_ModifiedDateTime]
GO

ALTER TABLE [dbo].[tbl_user_external] ADD  CONSTRAINT [DF__tbl_user___UE_La__44CA3770]  DEFAULT (NULL) FOR [UE_LastName]
GO

ALTER TABLE [dbo].[tbl_user_external] ADD  CONSTRAINT [DF__tbl_user___UE_Cr__46B27FE2]  DEFAULT (NULL) FOR [UE_CreatedDateTime]
GO

ALTER TABLE [dbo].[tbl_user_external] ADD  CONSTRAINT [DF__tbl_user___UE_Mo__47A6A41B]  DEFAULT (NULL) FOR [UE_ModifiedBy]
GO

ALTER TABLE [dbo].[tbl_user_external] ADD  CONSTRAINT [DF__tbl_user___UE_Mo__489AC854]  DEFAULT (NULL) FOR [UE_ModifiedDateTime]
GO

ALTER TABLE [dbo].[tbl_user_internal] ADD  CONSTRAINT [DF_tbl_user_internal_UE_LastName]  DEFAULT (NULL) FOR [UE_LastName]
GO

ALTER TABLE [dbo].[tbl_user_internal] ADD  CONSTRAINT [DF_tbl_user_internal_UE_CreatedDateTime]  DEFAULT (NULL) FOR [UE_CreatedDateTime]
GO

ALTER TABLE [dbo].[tbl_user_internal] ADD  CONSTRAINT [DF_tbl_user_internal_UE_ModifiedBy]  DEFAULT (NULL) FOR [UE_ModifiedBy]
GO

ALTER TABLE [dbo].[tbl_user_internal] ADD  CONSTRAINT [DF_tbl_user_internal_UE_ModifiedDateTime]  DEFAULT (NULL) FOR [UE_ModifiedDateTime]
GO

ALTER TABLE [dbo].[tbl_user_profile_map] ADD  CONSTRAINT [DF__tbl_user___UPM_U__3A4CA8FD]  DEFAULT ('') FOR [UPM_UserID]
GO

ALTER TABLE [dbo].[tbl_user_profile_map] ADD  CONSTRAINT [DF__tbl_user___UPM_U__3B40CD36]  DEFAULT (NULL) FOR [UPM_UserEmail]
GO

ALTER TABLE [dbo].[tbl_user_profile_map] ADD  CONSTRAINT [DF__tbl_user___UPM_D__3C34F16F]  DEFAULT (NULL) FOR [UPM_Description]
GO

ALTER TABLE [dbo].[tbl_user_profile_map] ADD  CONSTRAINT [DF__tbl_user___UPM_T__3D2915A8]  DEFAULT (NULL) FOR [UPM_Type]
GO

ALTER TABLE [dbo].[tblCountry] ADD  CONSTRAINT [DF__tbl_count__COU_T__49C3F6B7]  DEFAULT ((0)) FOR [MDCTY_CreatedDateTime]
GO

ALTER TABLE [dbo].[tblCustomer] ADD  CONSTRAINT [DF__tbl_custo__CUS_P__7B5B524B]  DEFAULT ('PWD') FOR [CUS_PinOrPwd]
GO

ALTER TABLE [dbo].[tblCustomer] ADD  CONSTRAINT [DF__tbl_custo__CUS_C__7C4F7684]  DEFAULT (NULL) FOR [CUS_CreatedDateTime]
GO

ALTER TABLE [dbo].[tblCustomer] ADD  CONSTRAINT [DF__tbl_custo__CUS_M__7D439ABD]  DEFAULT (NULL) FOR [CUS_ModifiedBy]
GO

ALTER TABLE [dbo].[tblCustomer] ADD  CONSTRAINT [DF__tbl_custo__CUS_M__7E37BEF6]  DEFAULT (NULL) FOR [CUS_ModifiedDateTime]
GO

ALTER TABLE [dbo].[tblEmployee] ADD  CONSTRAINT [DF__tbl_user___USR_D__118A8A8C]  DEFAULT (NULL) FOR [EME_MaritalStatus]
GO

ALTER TABLE [dbo].[tblEmployee] ADD  CONSTRAINT [DF__tbl_user___USR_D__127EAEC5]  DEFAULT (NULL) FOR [EME_Nationality]
GO

ALTER TABLE [dbo].[tblEmployee] ADD  CONSTRAINT [DF__tbl_user___USR_D__1372D2FE]  DEFAULT (NULL) FOR [EME_BloodGroup]
GO

ALTER TABLE [dbo].[tblEmployee] ADD  CONSTRAINT [DF__tbl_user___USR_J__1466F737]  DEFAULT (NULL) FOR [EME_NIC]
GO

ALTER TABLE [dbo].[tblEmployee] ADD  CONSTRAINT [DF__tbl_user___USR_P__155B1B70]  DEFAULT (NULL) FOR [EME_ReportingManager]
GO

ALTER TABLE [dbo].[tblEmployee] ADD  CONSTRAINT [DF__tbl_user___USR_R__164F3FA9]  DEFAULT (NULL) FOR [EME_EmployeeType]
GO

ALTER TABLE [dbo].[tblEmployee] ADD  CONSTRAINT [DF__tbl_user___USR_P__1CFC3D38]  DEFAULT (NULL) FOR [EME_Address]
GO

ALTER TABLE [dbo].[tblEmployee] ADD  CONSTRAINT [DF__tbl_user___USR_L__1EE485AA]  DEFAULT (NULL) FOR [EME_EmailAddress]
GO

ALTER TABLE [dbo].[tblEmployee] ADD  CONSTRAINT [DF__tbl_user___USR_S__1FD8A9E3]  DEFAULT (NULL) FOR [EME_MobileNumber]
GO

ALTER TABLE [dbo].[tblEmployee] ADD  CONSTRAINT [DF__tbl_user___USR_C__20CCCE1C]  DEFAULT (NULL) FOR [EME_CreatedDateTime]
GO

ALTER TABLE [dbo].[tblEmployee] ADD  CONSTRAINT [DF__tbl_user___USR_M__21C0F255]  DEFAULT (NULL) FOR [EME_ModifiedBy]
GO

ALTER TABLE [dbo].[tblEmployee] ADD  CONSTRAINT [DF__tbl_user___USR_M__22B5168E]  DEFAULT (NULL) FOR [EME_ModifiedDateTime]
GO


