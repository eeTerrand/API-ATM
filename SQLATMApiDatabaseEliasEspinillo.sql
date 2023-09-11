IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'ATMApi')
BEGIN
	CREATE DATABASE [ATMApi]
END;
GO
USE [ATMApi]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/09/2023 11:07:53 a.m. ******/
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
/****** Object:  Table [dbo].[UserCards]    Script Date: 11/09/2023 11:07:53 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [nvarchar](max) NOT NULL,
	[Pin] [int] NOT NULL,
	[IsLocked] [bit] NOT NULL,
	[BankBalance] [decimal](18, 2) NOT NULL,
	[LoginAttempts] [int] NOT NULL,
	[ExpirationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_UserCards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserOperation]    Script Date: 11/09/2023 11:07:53 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserOperation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OperationType] [int] NOT NULL,
	[ExecutionDate] [datetime2](7) NOT NULL,
	[WithdrawalAmount] [decimal](18, 2) NULL,
	[UserCardId] [int] NOT NULL,
 CONSTRAINT [PK_UserOperation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserOperation]  WITH CHECK ADD  CONSTRAINT [FK_UserOperation_UserCards_UserCardId] FOREIGN KEY([UserCardId])
REFERENCES [dbo].[UserCards] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserOperation] CHECK CONSTRAINT [FK_UserOperation_UserCards_UserCardId]
GO

CREATE LOGIN useratmapi1 WITH PASSWORD = '1234';
CREATE USER useratmapi1 FOR LOGIN useratmapi;  

INSERT INTO [dbo].[UserCards] (Number, Pin, IsLocked, BankBalance, LoginAttempts, ExpirationDate)
VALUES
    ('1234567890123456', 1234, 0, 1000.00, 0, '2023-12-31 23:59:59'),  -- Registro 1
    ('2345678901234567', 5678, 0, 1500.50, 1, '2023-12-31 23:59:59'),  -- Registro 2
    ('3456789012345678', 9876, 0, 2000.75, 2, '2023-12-31 23:59:59'),  -- Registro 3
    ('4567890123456789', 4321, 0, 500.25, 3, '2023-12-31 23:59:59'),  -- Registro 4
    ('5678901234567890', 8765, 0, 800.80, 0, '2023-12-31 23:59:59');