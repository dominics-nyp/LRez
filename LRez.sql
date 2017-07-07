
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 30/6/2017 5:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 30/6/2017 5:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 30/6/2017 5:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 30/6/2017 5:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 30/6/2017 5:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Information]    Script Date: 30/6/2017 5:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Information](
	[ID] [int] NOT NULL,
	[value] [varchar](max) NULL,
	[remarks] [varchar](max) NULL,
 CONSTRAINT [PK_Information] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Menu]    Script Date: 30/6/2017 5:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[description] [varchar](max) NULL,
	[url] [varchar](255) NULL,
	[status] [int] NULL,
	[type] [int] NULL,
	[last_modified] [varchar](50) NULL,
	[last_modified_date] [datetime] NULL,
	[remarks] [varchar](max) NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 30/6/2017 5:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservations](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[contact] [varchar](50) NULL,
	[email] [varchar](255) NULL,
	[reservation_datetime] [datetime] NULL,
	[num_visitors] [int] NULL,
	[requests] [varchar](255) NULL,
	[tracking] [varchar](50) NULL,
	[social_account] [varchar](50) NULL,
	[social_provider] [nchar](10) NULL,
	[status] [int] NULL,
	[last_modified] [varchar](50) NULL,
	[last_modified_date] [datetime] NULL,
	[remarks] [varchar](max) NULL,
 CONSTRAINT [PK_Reservations] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201702140852171_InitialCreate', N'LRezWebAppAdmin.Models.ApplicationDbContext', 0x1F8B0800000000000400DD5C6D6FE3B811FE5EA0FF41D0A7B6C85979E92EB681BD879C935C83CB1BD6D96DBF2D6889768895289D44E5923BDC2FEB87FEA4FE850E254A96F8A2175BB19DC3028B881C3E331C0EC9E170E8FFFDE7BFE3EF9F03DF7AC27142423AB18F4687B685A91B7A842E2776CA16DF7DB0BFFFF8E73F8D2FBCE0D9FA52D09D703A68499389FDC85874EA3889FB8803948C02E2C661122ED8C80D030779A1737C78F80FE7E8C8C100610396658D3FA5949100671FF0390DA98B239622FF26F4B09F8872A89965A8D62D0A701221174FECEB4FF8D77FE1F959149D7901A1A3BC856D9DF904813433EC2F6C0B511A32C440D6D3CF099EB138A4CB590405C87F788930D02D909F60D187D31579D7EE1C1EF3EE38AB8605949B262C0C7A021E9D08FD3872F3B5B46C97FA030D5E80A6D90BEF75A6C5897DE5E1ACE853E883026486A7533FE6C413FBA664719644B7988D8A86A31CF23206B85FC2F8DBA88A7860756E7750DAD3F1E890FF3BB0A6A9CFD2184F284E598CFC03EB3E9DFBC4FD09BF3C84DF309D9C1CCD17271FDEBD47DEC9FBBFE39377D59E425F81AE560045F77118E11864C38BB2FFB6E5D4DB3972C3B259A54DAE15B025981AB675839EAF315DB2479834C71F6CEB923C63AF2811C6F599129849D088C5297CDEA6BE8FE63E2EEB9D469EFCFF06AEC7EFDE0FC2F5163D916536F4127F983831CCAB4FD8CF6A934712E5D3AB36DE5F05D9651C06FCBB6E5F79EDD75998C62EEF4C68247940F112B3BA74636765BC9D4C9A430D6FD605EAFE9B369754356F2D29EFD03A33A160B1EDD950C8FBBA7C3B5B1C6C3F30789969718D34199C7EC31A4908079644B732A1A3AE2644A16B7FE415F12240C41F6049ECC0053C920589035CF6F287100C10D1DE32DFA3248115C1FB274A1E1B44873F07107D86DD3406439D311444AFCEEDFE31A4F8360DE6DCFEB7C76BB0A179F825BC442E0BE30BCA5B6D8C771DBADFC2945D50EF1C31FC99B90520FF7C2041778041C439735D9C249760CCD89B86E070178057949D1CF786E38BD4AE5D92A98F48A0F749A4E5F46B41BAF24BF4148A6F6220D3F9274DA25E874B42BB895A909A45CD295A4515647D45E560DD24159466413382563973AAC13CBE6C848677F932D8FDF7F936DBBC4D6B41458D335821F18F98E2189631EF1E318663BA1A812EEBC62E9C856CF838D357DF9B324E5F909F0ECD6AADD9902D02C3CF860C76FF67432626143F118F7B251D0E420531C077A2D79FB1DAE79C24D9B6A743AD9BDB66BE9D35C0345DCE92247449360B34213011C0A8CB0F3E9CD51ECDC87B234744A06360E8846F7950027DB365A3BAA3E7D8C70C5B676E1E229CA2C4459EAA46E890D743B06247D508B68A8CD485FB9BC2132C1DC7BC11E287A004662AA14C9D1684BA24427EAB96A4961DB730DEF792875C738E234C39C3564D7461AE0F8470014A3ED2A0B46968EC542CAED9100D5EAB69CCDB5CD8D5B82BF189ADD8648BEF6CB04BE1BFBD8A61366B6C0BC6D9AC922E0218837ABB30507156E96A00F2C165DF0C543A31190C54B8545B31D0BAC67660A07595BC3903CD8FA85DC75F3AAFEE9B79D60FCADBDFD61BD5B503DBACE963CF4C33F73DA10D83163856CDF37CCE2BF133D31CCE404E713E4B84AB2B9B08079F61560FD9ACFC5DAD1FEA3483C846D404B832B41650711DA8002913AA8770452CAF513AE145F4802DE26E8DB062ED97602B36A06257AF452B84E6CB53D9383B9D3ECA9E95D6A01879A7C34205476310F2E255EF7807A598E2B2AA62BAF8C27DBCE14AC7C4603428A8C5733528A9E8CCE05A2A4CB35D4B3A87AC8F4BB6919624F7C9A0A5A233836B49D868BB92344E410FB7602315D5B7F081265B11E928779BB26EECE41953A260EC1852ABC637288A085D5652AD448935CBF3ACA6DFCDFA271F053986E3269A1CA452DA92130B63B4C4522DB006492F499CB073C4D01CF138CFD40B1432EDDE6A58FE0B96D5ED531DC4621F28A8F9DF227AA7BFC4AFEDB7AA4322702EA19701F76AB250BAC606F4CD2D9EFE867C146BA2F7D3D04F036A76B2CCADF33BBC6AFBBC4445183B92FC8A13A5684C7175EBEAEF3438EAC41870A04A3F66FDC1324398545E78A155A59B3C53334A11A8AAA29882573B1B3C9343D37BC0647FB1FF78B522BCCEFC12492A550051D413A392E7A08055EABAA3D65351AA98F59AEE8852BE491552AAEA216535ABA42664B5622D3C8346F514DD39A879245574B5B63BB226A3A40AADA95E035B23B35CD71D5593745205D65477C75E65A0C80BE91EEF60C653CC465B587ED8DD6C0F3360BCCEAA38CC1658B9D3AF02558A7B62895B7B054C94EFA545194F7C1B59541EE7D8CCA20C18E615A876235E5F801AAFF1CD98B56BEEDA22DF74CD6FC6EB67B7AF6A1DCAA14F2629B997873FE990371607AEF64736CA092C27B1AD428DB0C1BF240C07234E309AFDEC4F7D82F9725E10DC204A163861796A877D7C78742CBDD1D99FF7324E9278BEE6C06A7A34531FB32D6469D12714BB8F28567326367853B20255C2D157D4C3CF13FBB7ACD56916D9E07F65C507D655F299929F53A87888536CFDAEE6800E9363DF7CE0DAD31711DDB57AF5EFAF79D303EB2E8619736A1D4ABA5C6784EBEF247A499337DD409AB55F4FBCDD09557B92A0459526C4FA2F10E6840DF2FAA090F22F017AFE6B5FD1B42F0C3642D4BC22180A6F10159A5E09AC83657C21E0C127CB5E08F4EBACFEC5C03AA2195F0B10DA1F4C7E2BD07D192A5AEE70ABD19C8BB6B124657A6ECDB5DE28F172D77B939292BDD14457D3AE7BC06D905ABD8665BCB1ACE4C176474DD2F160D8BB34ED57CF34DE97E4E255DAC76E738AB79946DC7045F487CA1EDE837C374DFECEEE7384B76D6BA658EE9E275AF6CB04DE336313595DBBCFF7DDB6B199C2BC7B6E6CBDB27AF7CCD676B57FEED8D23A6FA13BCFD155D38D0C7732BA58705B0E6E1E388713FE3C0423C83DCAFCE9A43EE9AB2961B585E18AC4CCD49C6D263356268EC257A16866DBAFAF62C36FECACA069666BC8D16CE22DD6FF46DE82A699B721F37117D9C3DADC435D4677CB3AD69410F596B2856B3D69494E6FF3591B2FD8DF5272F0204AA9CD1EC31DF1DBC9051E4425434E9D1EB9BFEA752FEC9D955F5E84FD3B21CB1504FF1D468ADDDAAE59D25CD145586CDE9244058914A1B9C10C79B0A59EC58C2C90CBA09AC798B3B7DF59DC8EDF74CCB17745EF5216A50CBA8C83B95F0B787127A0897F96E05C97797C17653F63324417404CC263F377F48794F85E29F7A526266480E0DE8588E8F2B1643CB2BB7C29916E43DA1148A8AF748A1E7010F90096DCD1197AC2EBC806E6778D97C87D5945004D20ED035157FBF89CA0658C824460ACDAC327D8B0173C7FFC3F886F088A80540000, N'6.1.3-40302')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'64d46520-1e79-41fe-8e9a-b7be215771ee', N'dominic_sum@nyp.edu.sg', 0, N'AB/9W5Mk66gV67w0l2LqtZWJadtnPGXIvgXeote9I7DjPlIpasQJtE5BQt4OA6kfYQ==', N'b2517bf3-d6ca-4ec2-af8b-f8ba214c2c0f', NULL, 0, 0, NULL, 1, 0, N'admin')
INSERT [dbo].[Information] ([ID], [value], [remarks]) VALUES (1, N'
<p>L''Rez is a Training Restaurant set up by the Nanyang Polytechnic Teaching Enterprise Project Centre to provide hands-on training for students from NYP School of Business, Diploma in Food and Beverage Business. Inaugurated in 2013, L''Rez prides itself in providing a superior fine dining experience at international standards.</p>
<p><br>
<br>
<u>Operation Schedule</u></p>
<p>Academic Year 2016 Semester 1<br>
4 April 2016 - 17 August 2016<br>
(Closed from 18 February to 3 March 2016 for student training)</p>
<p>Mon to Fri: 11:30am to 2:30pm (Last Order at 2:00pm)<br>
Closed on Sat, Sun and Public Holidays</p>
', NULL)
INSERT [dbo].[Information] ([ID], [value], [remarks]) VALUES (2, N'http://localhost:8080/Images/restaurant001.jpg', NULL)
INSERT [dbo].[Information] ([ID], [value], [remarks]) VALUES (3, N'
<p><strong>We are located at:&nbsp;</strong><br>
180 Ang Mo Kio Avenue 8<br>
Nanyang Polytechnic<br>
Blk F, Level 3<br>
Singapore 569830<br>
<br>
<br>
<strong>Please contact us @&nbsp;</strong><br>
Tel: (&#43;65) 6541 4384<br>
Email: L-Rez@mymail.nyp.edu.sg</p>
', NULL)
INSERT [dbo].[Information] ([ID], [value], [remarks]) VALUES (4, N'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3988.656525134089!2d103.847279549542!3d1.3827268618510782!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31da16eb4b4ff25f%3A0xf2491949af7b80a2!2sL&#39;Rez!5e0!3m2!1sen!2ssg!4v1483779457878', NULL)
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([ID], [name], [description], [url], [status], [type], [last_modified], [last_modified_date], [remarks]) VALUES (1, N'Menu 2366', N'Menu Description', N'http://172.20.46.219:8080/Menus/Menu_3Oct2016.jpg', 1, 0, N'admin', CAST(N'2017-06-16T17:34:36.133' AS DateTime), NULL)
INSERT [dbo].[Menu] ([ID], [name], [description], [url], [status], [type], [last_modified], [last_modified_date], [remarks]) VALUES (2, N'Menu 02', N'Menu Description 02', N'http://172.20.46.219:8080/Menus/Menu_24Nov2016.jpg', 0, 0, N'admin', CAST(N'2017-06-16T17:34:33.780' AS DateTime), NULL)
INSERT [dbo].[Menu] ([ID], [name], [description], [url], [status], [type], [last_modified], [last_modified_date], [remarks]) VALUES (3, N'Hello World', N'No Description Available', N'http://172.20.46.219:8080/Menus/2ba8b5d9dbd4eb953a933802e4bf6df4.jpg', 2, 0, N'admin', CAST(N'2017-04-05T11:42:23.193' AS DateTime), NULL)
INSERT [dbo].[Menu] ([ID], [name], [description], [url], [status], [type], [last_modified], [last_modified_date], [remarks]) VALUES (4, N'Menu 002', N'No Description Available', N'http://172.20.46.219:8080/Menus/Bakery-Menu-Template.png', 0, 3, N'admin', CAST(N'2017-04-19T17:47:40.197' AS DateTime), NULL)
INSERT [dbo].[Menu] ([ID], [name], [description], [url], [status], [type], [last_modified], [last_modified_date], [remarks]) VALUES (5, N'Baker Themed Menu 02', N'No Description Available', N'http://172.20.46.219:8080/Menus/Bakery-Menu-Template.png', 0, 2, N'admin', CAST(N'2017-06-20T15:00:50.633' AS DateTime), NULL)
INSERT [dbo].[Menu] ([ID], [name], [description], [url], [status], [type], [last_modified], [last_modified_date], [remarks]) VALUES (6, N'Celebrity Menu 01', N'No Description Available', N'http://172.20.46.219:8080/Menus/canva-pink-and-white-chalkboard-coffee-shop-menu-MACBeuaVfIw.jpg', 1, 1, N'', CAST(N'2017-06-19T16:28:51.810' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Menu] OFF
SET IDENTITY_INSERT [dbo].[Reservations] ON 

INSERT [dbo].[Reservations] ([ID], [name], [contact], [email], [reservation_datetime], [num_visitors], [requests], [tracking], [social_account], [social_provider], [status], [last_modified], [last_modified_date], [remarks]) VALUES (1, N'Dominic', N'98771843', N'domatosource@gmail.com', CAST(N'2017-01-18T12:30:00.000' AS DateTime), 3, N'Table by the window', N'1640239528', NULL, NULL, 0, N'NEW', CAST(N'2017-01-16T14:29:55.593' AS DateTime), NULL)
INSERT [dbo].[Reservations] ([ID], [name], [contact], [email], [reservation_datetime], [num_visitors], [requests], [tracking], [social_account], [social_provider], [status], [last_modified], [last_modified_date], [remarks]) VALUES (6, N'Dominic', N'98771843', N'domatosource@gmail.com', CAST(N'2017-06-19T12:30:00.000' AS DateTime), 3, NULL, N'-23014339', NULL, NULL, 2, N'NEW', CAST(N'2017-01-16T15:01:00.283' AS DateTime), NULL)
INSERT [dbo].[Reservations] ([ID], [name], [contact], [email], [reservation_datetime], [num_visitors], [requests], [tracking], [social_account], [social_provider], [status], [last_modified], [last_modified_date], [remarks]) VALUES (7, N'Dominic Sum Jee Keong', N'987714856', N'dom@gmail.com', CAST(N'2017-06-19T12:30:00.000' AS DateTime), 3, NULL, N'1151285988', NULL, NULL, 1, N'NEW', CAST(N'2017-01-17T16:07:16.770' AS DateTime), NULL)
INSERT [dbo].[Reservations] ([ID], [name], [contact], [email], [reservation_datetime], [num_visitors], [requests], [tracking], [social_account], [social_provider], [status], [last_modified], [last_modified_date], [remarks]) VALUES (8, N'Dominic Sum', N'98771843', N'a@b.com', CAST(N'2017-06-19T13:30:00.000' AS DateTime), 2, N'Some requests', N'1326049069', NULL, NULL, 0, N'NEW', CAST(N'2017-01-23T10:44:24.923' AS DateTime), NULL)
INSERT [dbo].[Reservations] ([ID], [name], [contact], [email], [reservation_datetime], [num_visitors], [requests], [tracking], [social_account], [social_provider], [status], [last_modified], [last_modified_date], [remarks]) VALUES (9, N'Dominic', N'98772843', N'd@s.com', CAST(N'2017-06-22T15:21:00.000' AS DateTime), 3, NULL, N'948714838', NULL, NULL, 0, N'NEW', CAST(N'2017-06-20T15:21:57.240' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Reservations] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 30/6/2017 5:24:40 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 30/6/2017 5:24:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 30/6/2017 5:24:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 30/6/2017 5:24:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 30/6/2017 5:24:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 30/6/2017 5:24:40 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO

