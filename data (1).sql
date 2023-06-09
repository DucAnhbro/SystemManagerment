USE [PRN231_StudentMGT]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 5/19/2023 5:03:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CourseCode] [varchar](6) NULL,
	[CourseName] [varchar](100) NULL,
	[InstructorName] [varchar](50) NULL,
	[Credits] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enrollments]    Script Date: 5/19/2023 5:03:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrollments](
	[EnrollmentID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[CourseID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EnrollmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 5/19/2023 5:03:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ID] [int] NOT NULL,
	[Name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserCourse]    Script Date: 5/19/2023 5:03:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCourse](
	[UserId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_UserCourse] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/19/2023 5:03:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](max) NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[DateOfBirth] [date] NULL,
	[Gender] [varchar](10) NULL,
	[Address] [varchar](100) NULL,
	[PhoneNumber] [varchar](20) NULL,
	[Email] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([ID], [CourseCode], [CourseName], [InstructorName], [Credits]) VALUES (1, N'PRF192', N'Programming Fundamentals', N'Instructor1', 3)
INSERT [dbo].[Courses] ([ID], [CourseCode], [CourseName], [InstructorName], [Credits]) VALUES (2, N'PRO192', N'Object-Oriented Programming', N'Instructor2', 3)
INSERT [dbo].[Courses] ([ID], [CourseCode], [CourseName], [InstructorName], [Credits]) VALUES (3, N'PRJ301', N'Java Web Application Development', N'Instructor3', 3)
INSERT [dbo].[Courses] ([ID], [CourseCode], [CourseName], [InstructorName], [Credits]) VALUES (5, N'PRU211', N'C# Programming and Unity', N'Instructor2', 3)
INSERT [dbo].[Courses] ([ID], [CourseCode], [CourseName], [InstructorName], [Credits]) VALUES (6, N'SWR302', N'Software Requirement', N'Instructor1', 3)
INSERT [dbo].[Courses] ([ID], [CourseCode], [CourseName], [InstructorName], [Credits]) VALUES (7, N'MLN111', N'	Philosophy of Marxism – Leninism', N'Instructor4', 3)
INSERT [dbo].[Courses] ([ID], [CourseCode], [CourseName], [InstructorName], [Credits]) VALUES (8, N'string', N'string', N'string', 0)
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
SET IDENTITY_INSERT [dbo].[Enrollments] ON 

INSERT [dbo].[Enrollments] ([EnrollmentID], [UserID], [CourseID]) VALUES (1, 7, 1)
INSERT [dbo].[Enrollments] ([EnrollmentID], [UserID], [CourseID]) VALUES (2, 3, 1)
INSERT [dbo].[Enrollments] ([EnrollmentID], [UserID], [CourseID]) VALUES (3, 4, 1)
INSERT [dbo].[Enrollments] ([EnrollmentID], [UserID], [CourseID]) VALUES (4, 2, 1)
INSERT [dbo].[Enrollments] ([EnrollmentID], [UserID], [CourseID]) VALUES (5, 3, 2)
INSERT [dbo].[Enrollments] ([EnrollmentID], [UserID], [CourseID]) VALUES (6, 7, 2)
INSERT [dbo].[Enrollments] ([EnrollmentID], [UserID], [CourseID]) VALUES (7, 2, 2)
INSERT [dbo].[Enrollments] ([EnrollmentID], [UserID], [CourseID]) VALUES (8, 4, 2)
INSERT [dbo].[Enrollments] ([EnrollmentID], [UserID], [CourseID]) VALUES (9, 2, 3)
INSERT [dbo].[Enrollments] ([EnrollmentID], [UserID], [CourseID]) VALUES (10, 6, 1)
INSERT [dbo].[Enrollments] ([EnrollmentID], [UserID], [CourseID]) VALUES (11, 7, 3)
INSERT [dbo].[Enrollments] ([EnrollmentID], [UserID], [CourseID]) VALUES (12, 6, 2)
INSERT [dbo].[Enrollments] ([EnrollmentID], [UserID], [CourseID]) VALUES (13, 5, 1)
INSERT [dbo].[Enrollments] ([EnrollmentID], [UserID], [CourseID]) VALUES (14, 5, 2)
INSERT [dbo].[Enrollments] ([EnrollmentID], [UserID], [CourseID]) VALUES (15, 4, 3)
INSERT [dbo].[Enrollments] ([EnrollmentID], [UserID], [CourseID]) VALUES (18, 3, 3)
SET IDENTITY_INSERT [dbo].[Enrollments] OFF
GO
INSERT [dbo].[Roles] ([ID], [Name]) VALUES (0, N'Admin')
INSERT [dbo].[Roles] ([ID], [Name]) VALUES (1, N'Student')
GO
INSERT [dbo].[UserCourse] ([UserId], [CourseId]) VALUES (1, 1)
INSERT [dbo].[UserCourse] ([UserId], [CourseId]) VALUES (2, 2)
INSERT [dbo].[UserCourse] ([UserId], [CourseId]) VALUES (3, 3)
INSERT [dbo].[UserCourse] ([UserId], [CourseId]) VALUES (5, 5)
INSERT [dbo].[UserCourse] ([UserId], [CourseId]) VALUES (6, 6)
INSERT [dbo].[UserCourse] ([UserId], [CourseId]) VALUES (7, 7)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [RoleID], [Username], [Password], [FirstName], [LastName], [DateOfBirth], [Gender], [Address], [PhoneNumber], [Email]) VALUES (1, 0, N'admin', N'123', N'admin', N'admin', NULL, NULL, NULL, NULL, N'admin@gmail.com')
INSERT [dbo].[Users] ([ID], [RoleID], [Username], [Password], [FirstName], [LastName], [DateOfBirth], [Gender], [Address], [PhoneNumber], [Email]) VALUES (2, 1, N'student1', N'123', N'first1', N'last1', NULL, NULL, NULL, NULL, N'student1@gmail.com')
INSERT [dbo].[Users] ([ID], [RoleID], [Username], [Password], [FirstName], [LastName], [DateOfBirth], [Gender], [Address], [PhoneNumber], [Email]) VALUES (3, 1, N'student2', N'123', N'first2', N'last2', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([ID], [RoleID], [Username], [Password], [FirstName], [LastName], [DateOfBirth], [Gender], [Address], [PhoneNumber], [Email]) VALUES (4, 1, N'student3', N'123', N'first3', N'last3', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([ID], [RoleID], [Username], [Password], [FirstName], [LastName], [DateOfBirth], [Gender], [Address], [PhoneNumber], [Email]) VALUES (5, 1, N'student4', N'123', N'first4', N'last4', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([ID], [RoleID], [Username], [Password], [FirstName], [LastName], [DateOfBirth], [Gender], [Address], [PhoneNumber], [Email]) VALUES (6, 1, N'student5', N'123', N'first5', N'last5', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([ID], [RoleID], [Username], [Password], [FirstName], [LastName], [DateOfBirth], [Gender], [Address], [PhoneNumber], [Email]) VALUES (7, 1, N'student6', N'123', N'first6', N'last6', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([ID], [RoleID], [Username], [Password], [FirstName], [LastName], [DateOfBirth], [Gender], [Address], [PhoneNumber], [Email]) VALUES (9, 1, N'string', N'string', N'string', N'string', CAST(N'2023-05-19' AS Date), N'string', N'string', N'string', N'string')
INSERT [dbo].[Users] ([ID], [RoleID], [Username], [Password], [FirstName], [LastName], [DateOfBirth], [Gender], [Address], [PhoneNumber], [Email]) VALUES (13, 1, N'fcbndfg', N'ghn', N'string', N'string', CAST(N'2023-05-19' AS Date), N'string', N'string', N'string', N'string')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Enrollments]  WITH CHECK ADD FOREIGN KEY([CourseID])
REFERENCES [dbo].[Courses] ([ID])
GO
ALTER TABLE [dbo].[Enrollments]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[UserCourse]  WITH CHECK ADD  CONSTRAINT [FK_UserCourse_Courses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([ID])
GO
ALTER TABLE [dbo].[UserCourse] CHECK CONSTRAINT [FK_UserCourse_Courses]
GO
ALTER TABLE [dbo].[UserCourse]  WITH CHECK ADD  CONSTRAINT [FK_UserCourse_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[UserCourse] CHECK CONSTRAINT [FK_UserCourse_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([ID])
GO
