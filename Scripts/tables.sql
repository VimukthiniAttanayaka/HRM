
CREATE TABLE [dbo].[tbl_country](
	[COU_Code] [varchar](3) NOT NULL,
	[COU_Name] [varchar](100) NOT NULL,
	[COU_ISO_AlphaCode] [varchar](3) NOT NULL,
	[COU_ISO_NumericCode] [decimal](3, 0) NOT NULL,
	[COU_TimeZoneDifferenceInMinutes] [int] NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[COU_Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO



CREATE TABLE [dbo].[tbl_currency](
	[CUR_Code] [varchar](3) NOT NULL,
	[CUR_Name] [varchar](100) NOT NULL,
	[CUR_ISO_Code] [varchar](3) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CUR_Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


CREATE TABLE [dbo].[tbl_customer](
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
	[CUS_PinOrPwd] [varchar](3) NULL CONSTRAINT [DF__tbl_custo__CUS_P__7B5B524B]  DEFAULT ('PWD'),
	[CUS_OTP_By_SMS] [bit] NOT NULL,
	[CUS_OTP_By_Email] [bit] NOT NULL,
	[CUS_Status] [bit] NOT NULL,
	[CUS_CreatedBy] [varchar](100) NOT NULL,
	[CUS_CreatedDateTime] [datetime] NULL CONSTRAINT [DF__tbl_custo__CUS_C__7C4F7684]  DEFAULT (NULL),
	[CUS_ModifiedBy] [varchar](100) NULL CONSTRAINT [DF__tbl_custo__CUS_M__7D439ABD]  DEFAULT (NULL),
	[CUS_ModifiedDateTime] [datetime] NULL CONSTRAINT [DF__tbl_custo__CUS_M__7E37BEF6]  DEFAULT (NULL),
 CONSTRAINT [PK__tbl_cust__373A37B74CC50148] PRIMARY KEY CLUSTERED 
(
	[CUS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[tbl_Employee](
	[USR_CustomerID] [varchar](20) NOT NULL,
	[USR_DepartmentID] [varchar](20) NOT NULL,
	[USR_EmployeeID] [varchar](50) NOT NULL,
	[USR_FirstName] [varchar](100) NOT NULL,
	[USR_LastName] [varchar](100) NOT NULL,
	[USR_PrefferedName] [varchar](100) NOT NULL,
	[USR_OrgStructuralLevel1] [varchar](20) NULL CONSTRAINT [DF__tbl_user___USR_O__0FA2421A]  DEFAULT (NULL),
	[USR_OrgStructuralLevel2] [varchar](20) NULL CONSTRAINT [DF__tbl_user___USR_O__10966653]  DEFAULT (NULL),
	[USR_DepartmentDetail1] [varchar](50) NULL CONSTRAINT [DF__tbl_user___USR_D__118A8A8C]  DEFAULT (NULL),
	[USR_DepartmentDetail2] [varchar](50) NULL CONSTRAINT [DF__tbl_user___USR_D__127EAEC5]  DEFAULT (NULL),
	[USR_DepartmentDetail3] [varchar](50) NULL CONSTRAINT [DF__tbl_user___USR_D__1372D2FE]  DEFAULT (NULL),
	[USR_JobCodeDescription] [varchar](200) NULL CONSTRAINT [DF__tbl_user___USR_J__1466F737]  DEFAULT (NULL),
	[USR_Address] [varchar](200) NOT NULL,
	[USR_EmailAddress] [varchar](100) NULL,
	[USR_MobileNumber] [varchar](20) NULL,
	[USR_PhoneNumber1] [varchar](20) NOT NULL,
	[USR_PhoneNumber2] [varchar](20) NULL CONSTRAINT [DF__tbl_user___USR_P__155B1B70]  DEFAULT (NULL),
	[USR_RankDescription] [varchar](100) NULL CONSTRAINT [DF__tbl_user___USR_R__164F3FA9]  DEFAULT (NULL),
	[USR_StaffLocation] [varchar](50) NOT NULL,
	[USR_Remarks] [varchar](200) NOT NULL,
	[USR_Pwd] [varchar](500) NULL CONSTRAINT [DF__tbl_user___USR_P__1CFC3D38]  DEFAULT (NULL),
	[USR_LastResetDateTime] [datetime] NULL CONSTRAINT [DF__tbl_user___USR_L__1EE485AA]  DEFAULT (NULL),
	[USR_SyncedDateTime] [datetime] NULL CONSTRAINT [DF__tbl_user___USR_S__1FD8A9E3]  DEFAULT (NULL),
	[USR_ActiveFrom] [date] NOT NULL,
	[USR_ActiveTo] [date] NOT NULL,
	[USR_Status] [bit] NULL,
	[USR_CreatedBy] [varchar](50) NOT NULL,
	[USR_CreatedDateTime] [datetime] NULL CONSTRAINT [DF__tbl_user___USR_C__20CCCE1C]  DEFAULT (NULL),
	[USR_ModifiedBy] [varchar](50) NULL CONSTRAINT [DF__tbl_user___USR_M__21C0F255]  DEFAULT (NULL),
	[USR_ModifiedDateTime] [datetime] NULL CONSTRAINT [DF__tbl_user___USR_M__22B5168E]  DEFAULT (NULL),
 CONSTRAINT [PK__tbl_user__3C52D4B2B768577C] PRIMARY KEY CLUSTERED 
(
	[USR_EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO




