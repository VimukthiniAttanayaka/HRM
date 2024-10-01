USE [Neelaka1]
GO

/****** Object:  Table [dbo].[tbl_auditlog]    Script Date: 10/1/2024 11:45:51 PM ******/
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

/****** Object:  Table [dbo].[tbl_AuditLog_ActionMap]    Script Date: 10/1/2024 11:45:51 PM ******/
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

/****** Object:  Table [dbo].[tbl_country]    Script Date: 10/1/2024 11:45:51 PM ******/
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

/****** Object:  Table [dbo].[tbl_excel_upload_data_tracer]    Script Date: 10/1/2024 11:45:51 PM ******/
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

/****** Object:  Table [dbo].[tbl_holidaycalender]    Script Date: 10/1/2024 11:45:51 PM ******/
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

/****** Object:  Table [dbo].[tbl_system_parameter]    Script Date: 10/1/2024 11:45:51 PM ******/
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

/****** Object:  Table [dbo].[tbl_user_external]    Script Date: 10/1/2024 11:45:51 PM ******/
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
	[UE_UserRoleId] [varchar](50) NULL,
 CONSTRAINT [PK__tbl_user__0E0F0A5C94CA9297] PRIMARY KEY CLUSTERED 
(
	[UE_UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tbl_user_internal]    Script Date: 10/1/2024 11:45:51 PM ******/
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
	[UE_UserRoleId] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_user_internal] PRIMARY KEY CLUSTERED 
(
	[UE_UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tbl_user_profile_map]    Script Date: 10/1/2024 11:45:51 PM ******/
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

/****** Object:  Table [dbo].[tblAccessGroup]    Script Date: 10/1/2024 11:45:51 PM ******/
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

/****** Object:  Table [dbo].[tblAttendance]    Script Date: 10/1/2024 11:45:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblAttendance](
	[EAT_ID] [int] IDENTITY(1,1) NOT NULL,
	[EAT_EmployeeID] [varchar](20) NULL,
	[EAT_Status] [bit] NULL,
	[EAT_CreatedBy] [varchar](50) NULL,
	[EAT_CreatedDateTime] [datetime] NULL,
	[EAT_ModifiedBy] [varchar](50) NULL,
	[EAT_ModifiedDateTime] [datetime] NULL,
	[EAT_Remarks] [varchar](max) NULL,
	[EAT_ApprovedBy] [nchar](10) NULL,
	[EAT_RejectedBy] [nchar](10) NULL,
	[EAT_ApprovedDateTime] [nchar](10) NULL,
	[EAT_ApprovedReason] [varchar](50) NULL,
	[EAT_RejectedDateTime] [nchar](10) NULL,
	[EAT_RejectedReason] [varchar](50) NULL,
	[EAT_AttendanceDate] [date] NULL,
	[EAT_OutTime] [time](7) NULL,
	[EAT_InTime] [time](7) NULL,
	[EAT_Location_latitude] [varchar](50) NULL,
	[EAT_Location_longitude] [varchar](50) NULL,
 CONSTRAINT [PK_tblAttendance] PRIMARY KEY CLUSTERED 
(
	[EAT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblAttributeDetail]    Script Date: 10/1/2024 11:45:51 PM ******/
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

/****** Object:  Table [dbo].[tblBranch]    Script Date: 10/1/2024 11:45:51 PM ******/
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

/****** Object:  Table [dbo].[tblCountry]    Script Date: 10/1/2024 11:45:51 PM ******/
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

/****** Object:  Table [dbo].[tblCustomer]    Script Date: 10/1/2024 11:45:51 PM ******/
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

/****** Object:  Table [dbo].[tblDepartment]    Script Date: 10/1/2024 11:45:51 PM ******/
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

/****** Object:  Table [dbo].[tblEmployee]    Script Date: 10/1/2024 11:45:51 PM ******/
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

/****** Object:  Table [dbo].[tblEmployee_Contact]    Script Date: 10/1/2024 11:45:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblEmployee_Contact](
	[EEC_ID] [int] IDENTITY(1,1) NOT NULL,
	[EEC_EmployeeID] [varchar](20) NULL,
	[EEC_Address] [varchar](200) NULL,
	[EEC_EmailAddress] [varchar](100) NULL,
	[EEC_MobileNumber] [varchar](20) NULL,
	[EEC_Status] [bit] NULL,
	[EEC_CreatedBy] [varchar](50) NULL,
	[EEC_CreatedDateTime] [datetime] NULL,
	[EEC_ModifiedBy] [varchar](50) NULL,
	[EEC_ModifiedDateTime] [datetime] NULL,
	[EEC_Remarks] [varchar](max) NULL,
	[EEC_PhoneNumber1] [varchar](20) NULL,
	[EEC_PhoneNumber2] [varchar](20) NULL,
 CONSTRAINT [PK_tblEmployee_Contact] PRIMARY KEY CLUSTERED 
(
	[EEC_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblEmployee_Document]    Script Date: 10/1/2024 11:45:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblEmployee_Document](
	[EED_EmployeeID] [varchar](50) NULL,
	[EED_EmployeeDocumentID] [int] IDENTITY(1,1) NOT NULL,
	[EED_DocumentType] [varchar](50) NULL,
	[EED_DocumentName] [varchar](50) NULL,
	[EED_Status] [bit] NULL,
	[EED_CreatedBy] [varchar](50) NULL,
	[EED_CreatedDateTime] [datetime] NULL,
	[EED_ModifiedBy] [varchar](50) NULL,
	[EED_ModifiedDateTime] [datetime] NULL,
	[EED_DocumentData] [varchar](max) NULL,
 CONSTRAINT [PK_tblEmployee_EmployeeDocument] PRIMARY KEY CLUSTERED 
(
	[EED_EmployeeDocumentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblEmployee_JobRole]    Script Date: 10/1/2024 11:45:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblEmployee_JobRole](
	[EEJR_ID] [int] IDENTITY(1,1) NOT NULL,
	[EEJR_EmployeeID] [varchar](20) NULL,
	[EEJR_JobRoleID] [varchar](20) NULL,
	[EEJR_ActiveFrom] [date] NULL,
	[EEJR_ActiveTo] [date] NULL,
	[EEJR_Status] [bit] NULL,
	[EEJR_CreatedBy] [varchar](50) NULL,
	[EEJR_CreatedDateTime] [datetime] NULL,
	[EEJR_ModifiedBy] [varchar](50) NULL,
	[EEJR_ModifiedDateTime] [datetime] NULL,
	[EEJR_Remarks] [varchar](max) NULL,
	[EEJR_JobType] [varchar](20) NULL,
	[EEJR_Department] [varchar](20) NULL,
 CONSTRAINT [PK_tblEmployee_JobDescription] PRIMARY KEY CLUSTERED 
(
	[EEJR_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblEmployee_LeaveEntitlement]    Script Date: 10/1/2024 11:45:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblEmployee_LeaveEntitlement](
	[EELE_ID] [int] IDENTITY(1,1) NOT NULL,
	[EELE_EmployeeID] [varchar](20) NULL,
	[EELE_Status] [bit] NULL,
	[EELE_CreatedBy] [varchar](50) NULL,
	[EELE_CreatedDateTime] [datetime] NULL,
	[EELE_ModifiedBy] [varchar](50) NULL,
	[EELE_ModifiedDateTime] [datetime] NULL,
	[EELE_LeaveTypeID] [varchar](20) NULL,
	[EELE_Remain] [decimal](18, 1) NULL,
	[EELE_ActiveFrom] [date] NULL,
	[EELE_ActiveTo] [date] NULL,
	[EELE_LeaveAlotment] [decimal](18, 1) NULL,
 CONSTRAINT [PK_tblEmployee_LeaveEntitlement] PRIMARY KEY CLUSTERED 
(
	[EELE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblEmployee_ReportingManager]    Script Date: 10/1/2024 11:45:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblEmployee_ReportingManager](
	[EERM_ID] [int] IDENTITY(1,1) NOT NULL,
	[EERM_EmployeeID] [varchar](20) NULL,
	[EERM_ReportingManagerID] [varchar](20) NULL,
	[EERM_Status] [bit] NULL,
	[EERM_CreatedBy] [varchar](50) NULL,
	[EERM_CreatedDateTime] [datetime] NULL,
	[EERM_ModifiedBy] [varchar](50) NULL,
	[EERM_ModifiedDateTime] [datetime] NULL,
	[EERM_Remarks] [varchar](max) NULL,
	[EERM_ActiveFrom] [date] NULL,
	[EERM_ActiveTo] [date] NULL,
 CONSTRAINT [PK_tblEmployee_ReportingManager] PRIMARY KEY CLUSTERED 
(
	[EERM_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblEmployee_Salary]    Script Date: 10/1/2024 11:45:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblEmployee_Salary](
	[EES_ID] [int] IDENTITY(1,1) NOT NULL,
	[EES_EmployeeID] [varchar](20) NULL,
	[EES_Salary] [decimal](18, 2) NULL,
	[EES_ActiveFrom] [date] NULL,
	[EES_ActiveTo] [date] NULL,
	[EES_Status] [bit] NULL,
	[EES_CreatedBy] [varchar](50) NULL,
	[EES_CreatedDateTime] [datetime] NULL,
	[EES_ModifiedBy] [varchar](50) NULL,
	[EES_ModifiedDateTime] [datetime] NULL,
	[EES_Remarks] [varchar](max) NULL,
	[EES_SalaryType] [varchar](20) NULL,
 CONSTRAINT [PK_tblEmployee_Salary] PRIMARY KEY CLUSTERED 
(
	[EES_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblEmployee_Termination]    Script Date: 10/1/2024 11:45:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblEmployee_Termination](
	[EET_ID] [int] IDENTITY(1,1) NOT NULL,
	[EET_EmployeeID] [varchar](20) NULL,
	[EET_Status] [bit] NULL,
	[EET_CreatedBy] [varchar](50) NULL,
	[EET_CreatedDateTime] [datetime] NULL,
	[EET_ModifiedBy] [varchar](50) NULL,
	[EET_ModifiedDateTime] [datetime] NULL,
	[EET_Remarks] [varchar](max) NULL,
	[EET_IsBlackListed] [bit] NULL,
	[EET_IsForceTerminated] [bit] NULL,
 CONSTRAINT [PK_tblEmployee_Termination] PRIMARY KEY CLUSTERED 
(
	[EET_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblErrorLog]    Script Date: 10/1/2024 11:45:51 PM ******/
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

/****** Object:  Table [dbo].[tblJobRole]    Script Date: 10/1/2024 11:45:51 PM ******/
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

/****** Object:  Table [dbo].[tblJobRoleDescription]    Script Date: 10/1/2024 11:45:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblJobRoleDescription](
	[MDJR_JobRoleID] [varchar](10) NOT NULL,
	[MDJR_Description] [text] NULL,
 CONSTRAINT [PK_tblJobRoleDescription] PRIMARY KEY CLUSTERED 
(
	[MDJR_JobRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblJobType]    Script Date: 10/1/2024 11:45:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblJobType](
	[MDJT_JobTypeID] [varchar](10) NOT NULL,
	[MDJT_JobType] [varchar](50) NOT NULL,
	[MDJT_Status] [bit] NOT NULL,
	[MDJT_CreatedBy] [varchar](50) NULL,
	[MDJT_CreatedDateTime] [datetime] NULL,
	[MDJT_ModifiedBy] [varchar](50) NULL,
	[MDJT_ModifiedDateTime] [datetime] NULL,
	[MDJT_Description] [varchar](200) NULL,
 CONSTRAINT [PK_tblJobType] PRIMARY KEY CLUSTERED 
(
	[MDJT_JobTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblLeaveType]    Script Date: 10/1/2024 11:45:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblLeaveType](
	[MDLT_LeaveTypeID] [varchar](10) NOT NULL,
	[MDLT_LeaveType] [varchar](50) NOT NULL,
	[MDLT_Status] [bit] NOT NULL,
	[MDLT_CreatedBy] [varchar](50) NULL,
	[MDLT_CreatedDateTime] [datetime] NULL,
	[MDLT_ModifiedBy] [varchar](50) NULL,
	[MDLT_ModifiedDateTime] [datetime] NULL,
	[MDLT_Description] [varchar](200) NULL,
	[MDLT_Duration] [int] NOT NULL,
	[MDLT_LeaveAlotment] [int] NOT NULL,
 CONSTRAINT [PK_tblLeaveType] PRIMARY KEY CLUSTERED 
(
	[MDLT_LeaveTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblLocation]    Script Date: 10/1/2024 11:45:51 PM ******/
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

/****** Object:  Table [dbo].[tblMenuAccess]    Script Date: 10/1/2024 11:45:51 PM ******/
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

/****** Object:  Table [dbo].[tblSalaryType]    Script Date: 10/1/2024 11:45:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblSalaryType](
	[MDST_SalaryTypeID] [varchar](10) NOT NULL,
	[MDST_SalaryType] [varchar](50) NOT NULL,
	[MDST_Status] [bit] NOT NULL,
	[MDST_CreatedBy] [varchar](50) NULL,
	[MDST_CreatedDateTime] [datetime] NULL,
	[MDST_ModifiedBy] [varchar](50) NULL,
	[MDST_ModifiedDateTime] [datetime] NULL,
	[MDST_Description] [varchar](200) NULL,
 CONSTRAINT [PK_tblSalaryType] PRIMARY KEY CLUSTERED 
(
	[MDST_SalaryTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblUserLog]    Script Date: 10/1/2024 11:45:51 PM ******/
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

/****** Object:  Table [dbo].[tblUserMenu]    Script Date: 10/1/2024 11:45:51 PM ******/
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

/****** Object:  Table [dbo].[tblUserRole]    Script Date: 10/1/2024 11:45:51 PM ******/
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

/****** Object:  Table [dbo].[tblUserRoleAccessGroup]    Script Date: 10/1/2024 11:45:51 PM ******/
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

ALTER TABLE [dbo].[tblLeaveType] ADD  CONSTRAINT [DF_tblLeaveType_MDLT_Duration]  DEFAULT ((0)) FOR [MDLT_Duration]
GO

ALTER TABLE [dbo].[tblLeaveType] ADD  CONSTRAINT [DF_tblLeaveType_MDLT_LeaveAlotment]  DEFAULT ((0)) FOR [MDLT_LeaveAlotment]
GO


