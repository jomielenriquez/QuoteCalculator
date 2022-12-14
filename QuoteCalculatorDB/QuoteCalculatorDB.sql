USE [CALCUDB]
GO
/****** Object:  Table [dbo].[tblProduct]    Script Date: 11/1/2022 8:23:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProduct](
	[PID] [int] IDENTITY(1,1) NOT NULL,
	[PCODE] [nvarchar](50) NULL,
	[PDESC] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblProduct] PRIMARY KEY CLUSTERED 
(
	[PID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblQuote]    Script Date: 11/1/2022 8:23:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblQuote](
	[QID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Product] [nvarchar](50) NULL,
	[Amount] [decimal](18, 0) NULL,
	[Term] [int] NULL,
	[Email] [nvarchar](50) NULL,
	[DateOfBirth] [datetime] NULL,
	[Mobile] [nvarchar](50) NULL,
	[Weekly] [decimal](18, 4) NULL,
 CONSTRAINT [PK_tblQuote] PRIMARY KEY CLUSTERED 
(
	[QID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblProduct] ON 

INSERT [dbo].[tblProduct] ([PID], [PCODE], [PDESC]) VALUES (1, N'PRODA', N'Product A')
INSERT [dbo].[tblProduct] ([PID], [PCODE], [PDESC]) VALUES (2, N'PRODB', N'Product B')
INSERT [dbo].[tblProduct] ([PID], [PCODE], [PDESC]) VALUES (3, N'PRODC', N'Product C')
SET IDENTITY_INSERT [dbo].[tblProduct] OFF
GO
SET IDENTITY_INSERT [dbo].[tblQuote] ON 

INSERT [dbo].[tblQuote] ([QID], [Title], [FirstName], [LastName], [Product], [Amount], [Term], [Email], [DateOfBirth], [Mobile], [Weekly]) VALUES (6, N'Mr.', N'Jomiel', N'Enriquez', N'PRODA', CAST(1000 AS Decimal(18, 0)), 12, N'enriquez.jliquigan@gmail.com', CAST(N'1998-02-25T00:00:00.000' AS DateTime), N'09953637231', CAST(32.6018 AS Decimal(18, 4)))
INSERT [dbo].[tblQuote] ([QID], [Title], [FirstName], [LastName], [Product], [Amount], [Term], [Email], [DateOfBirth], [Mobile], [Weekly]) VALUES (7, N'Mr.', N'undefined', N'Enriquez', N'undefined', CAST(10000 AS Decimal(18, 0)), 12, N'enriquez.jliquigan@gmail.com', CAST(N'2022-12-12T00:00:00.000' AS DateTime), N'09953637231', NULL)
SET IDENTITY_INSERT [dbo].[tblQuote] OFF
GO
/****** Object:  StoredProcedure [dbo].[proc_getproduct]    Script Date: 11/1/2022 8:23:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_getproduct] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    select * from tblProduct;
END
GO
/****** Object:  StoredProcedure [dbo].[proc_getQuotes]    Script Date: 11/1/2022 8:23:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_getQuotes]
AS
BEGIN
	SET NOCOUNT ON;
	
	select * from tblQuote q
	left join tblProduct p
	on q.Product=p.PCODE;

END
GO
/****** Object:  StoredProcedure [dbo].[proc_insertquote]    Script Date: 11/1/2022 8:23:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_insertquote]
@Title		 NVARCHAR(50),
@FirstName	 NVARCHAR(50),
@LastName	 NVARCHAR(50),
@Product	 NVARCHAR(50),
@Amount		 Decimal(18,4),
@Term		 NVARCHAR(50),
@Email		 NVARCHAR(50),
@DateOfBirth NVARCHAR(50),
@Mobile		 NVARCHAR(50),
@QID INT out
AS
BEGIN
	SET NOCOUNT ON;

	insert into tblQuote(Title,FirstName,LastName,Product,Amount,Term,Email,DateOfBirth,Mobile) 
		values(
			@Title,
			@FirstName,
			@LastName,
			@Product,
			@Amount,
			@Term,
			@Email,
			@DateOfBirth,
			@Mobile
		);
		select @QID =SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[proc_updatedquote]    Script Date: 11/1/2022 8:23:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_updatedquote]
@Title		 NVARCHAR(50),
@FirstName	 NVARCHAR(50),
@LastName	 NVARCHAR(50),
@Product	 NVARCHAR(50),
@Amount		 Decimal(18,4),
@Term		 NVARCHAR(50),
@Email		 NVARCHAR(50),
@DateOfBirth NVARCHAR(50),
@Mobile		 NVARCHAR(50),
@Weekly		 Decimal(18,4),
@QID INT
AS
BEGIN
	SET NOCOUNT ON;
	
	update tblQuote 
	set Title=@Title,
		FirstName=@FirstName,
		LastName=@LastName,
		Product=@Product,
		Amount=@Amount,
		Term=@Term,
		Email=@Email,
		DateOfBirth=@DateOfBirth,
		Mobile=@Mobile,
		Weekly=@Weekly

	where QID=@QID

END
GO
USE [master]
GO
ALTER DATABASE [CALCUDB] SET  READ_WRITE 
GO
