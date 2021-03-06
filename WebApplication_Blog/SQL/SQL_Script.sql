
/****** Object:  Table [dbo].[blog]    Script Date: 21-03-2021 21:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[blog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](100) NOT NULL,
	[description] [nvarchar](500) NULL,
	[url] [nvarchar](100) NULL,
 CONSTRAINT [PK_blog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 21-03-2021 21:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[userid] [nvarchar](100) NOT NULL,
	[password] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[userid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Login] ([userid], [password]) VALUES (N'admin', N'admin')
GO
/****** Object:  StoredProcedure [dbo].[AddNewBlog]    Script Date: 21-03-2021 21:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[AddNewBlog]  
(  
   @title nvarchar (100),  
   @description nvarchar (500),  
   @url nvarchar (100)  
) as  
begin  
   Insert into Blog values(@title, @description , @url)  
End
GO
/****** Object:  StoredProcedure [dbo].[DeleteBlog]    Script Date: 21-03-2021 21:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[DeleteBlog]  
(  
   @bId int  
)  
as   
begin  
   Delete from blog where Id=@bId  
End
GO
/****** Object:  StoredProcedure [dbo].[GetBlog]    Script Date: 21-03-2021 21:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[GetBlog] (@bId int)as begin  
   select * from Blog Where Id = @bId
End
GO
/****** Object:  StoredProcedure [dbo].[GetBlogs]    Script Date: 21-03-2021 21:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[GetBlogs] as begin  
   select * from Blog
End
GO
/****** Object:  StoredProcedure [dbo].[GetLogin]    Script Date: 21-03-2021 21:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetLogin] 
( @uid nvarchar (100),  
   @pwd nvarchar (100)
 )as begin  
   select COUNT(*) from Login Where [userid] = @uid
      and [password] = @pwd
End
GO
/****** Object:  StoredProcedure [dbo].[UpdateBlog]    Script Date: 21-03-2021 21:26:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[UpdateBlog]  
(  
   @bId int,  
   @title nvarchar (100),  
   @description nvarchar (500),  
   @url nvarchar (100)  
)  as  
begin  
   Update blog   
   set title=@title,  
   description=@description,  
   url=@url  
   where Id=@bId  
End
GO
