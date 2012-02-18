/****** Object:  Table [dbo].[Customer]    Script Date: 02/15/2012 23:24:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Customer](
	[Id] [int] NOT NULL,
	[First] [varchar](20) NOT NULL,
	[Last] [varchar](20) NOT NULL,
	[Street] [varchar](100) NOT NULL,
	[City] [varchar](30) NOT NULL,
	[State] [char](2) NOT NULL,
	[Zip] [char](5) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Phone] [char](12) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Index [FIX_Customer]    Script Date: 02/17/2012 20:59:10 ******/
CREATE UNIQUE NONCLUSTERED INDEX [FIX_Customer] ON [dbo].[Customer] 
(
	[Id] ASC
)
INCLUDE ( [First],
[Last],
[Street],
[City],
[State],
[Zip],
[Email],
[Phone]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = ON, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = OFF, ALLOW_PAGE_LOCKS  = OFF) ON [PRIMARY]
GO

