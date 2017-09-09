USE [master]
USE [TMPExcel]
GO

/****** Object:  Table [dbo].[KyivEnergoRows]    Script Date: 05.09.2017 10:57:06 ******/
DROP TABLE [dbo].[KyivEnergoRows]
GO

/****** Object:  Table [dbo].[KyivEnergoRows]    Script Date: 05.09.2017 10:57:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[KyivEnergoRows](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TO] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Tip] [nvarchar](max) NULL,
	[Tarif] [decimal](18, 0) NULL,
	[Spojito] [decimal](18, 0) NULL,
	[Sum] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


