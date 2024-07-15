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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[tbl_AuditLog_ActionMap]    Script Date: 7/15/2024 8:21:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tbl_AuditLog_ActionMap](
	[Module] [varchar](255) NULL,
	[Controller] [varchar](255) NULL,
	[Action] [varchar](255) NULL,
	[ID] [varchar](10) NOT NULL,
 CONSTRAINT [PK_tbl_AuditLog_ActionMap] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


