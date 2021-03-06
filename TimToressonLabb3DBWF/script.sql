USE [TimToressonLabb3DB]
--GO
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([Id], [First Name], [Last Name], [Birth Date]) VALUES (1, N'Tabbie', N'Hallstone', CAST(N'1998-02-28T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Authors] ([Id], [First Name], [Last Name], [Birth Date]) VALUES (2, N'Matteo', N'Scotsbrook', CAST(N'1968-03-14T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Authors] ([Id], [First Name], [Last Name], [Birth Date]) VALUES (3, N'Elisha', N'Rainville', CAST(N'1950-09-30T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Authors] ([Id], [First Name], [Last Name], [Birth Date]) VALUES (4, N'Petronille', N'Hirsthouse', CAST(N'1950-05-07T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Authors] OFF
--GO
INSERT [dbo].[Books] ([ISBN13], [Title], [Language], [Price], [Publication Date], [AuthorID]) VALUES (9782080642241, N'Dynamite', N'Latvian', 12.0000, CAST(N'2001-01-11T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Books] ([ISBN13], [Title], [Language], [Price], [Publication Date], [AuthorID]) VALUES (9782082172247, N'Forget Me Not', N'Albanian', 11.0000, CAST(N'1998-03-18T00:00:00.0000000' AS DateTime2), 4)
INSERT [dbo].[Books] ([ISBN13], [Title], [Language], [Price], [Publication Date], [AuthorID]) VALUES (9783797492242, N'Ill-Fated Love (Doomed Love) (Amor de Perdição)', N'Danish', 13.0000, CAST(N'1992-01-29T00:00:00.0000000' AS DateTime2), 4)
INSERT [dbo].[Books] ([ISBN13], [Title], [Language], [Price], [Publication Date], [AuthorID]) VALUES (9785220592247, N'China Lake Murders, The', N'Bosnian', 14.0000, CAST(N'1993-06-07T00:00:00.0000000' AS DateTime2), 3)
INSERT [dbo].[Books] ([ISBN13], [Title], [Language], [Price], [Publication Date], [AuthorID]) VALUES (9786181582249, N'Basic Instinct', N'Azeri', 7.0000, CAST(N'1996-05-20T00:00:00.0000000' AS DateTime2), 4)
INSERT [dbo].[Books] ([ISBN13], [Title], [Language], [Price], [Publication Date], [AuthorID]) VALUES (9786572202246, N'Dr. Horrible''s Sing-Along Blog', N'Afrikaans', 20.0000, CAST(N'1976-11-24T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Books] ([ISBN13], [Title], [Language], [Price], [Publication Date], [AuthorID]) VALUES (9786863682249, N'Small Change (Argent de poche, L'')', N'Norwegian', 16.0000, CAST(N'2010-08-29T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Books] ([ISBN13], [Title], [Language], [Price], [Publication Date], [AuthorID]) VALUES (9787177572240, N'Afghan Luke', N'Polish', 24.0000, CAST(N'2006-03-27T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Books] ([ISBN13], [Title], [Language], [Price], [Publication Date], [AuthorID]) VALUES (9788817912240, N'Home Page', N'Bengali', 11.0000, CAST(N'1975-02-08T00:00:00.0000000' AS DateTime2), 3)
INSERT [dbo].[Books] ([ISBN13], [Title], [Language], [Price], [Publication Date], [AuthorID]) VALUES (9789189582244, N'Green Street Hooligans (a.k.a. Hooligans)', N'Moldovan', 13.0000, CAST(N'1977-12-24T00:00:00.0000000' AS DateTime2), 4)
--GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Id], [First Name], [Last Name], [Address], [Email], [Phone]) VALUES (1, N'Bobbe', N'Laurencot', N'62893 Chive Court', N'blaurencot0@behance.net', N'754-604-9904')
INSERT [dbo].[Customers] ([Id], [First Name], [Last Name], [Address], [Email], [Phone]) VALUES (2, N'Muffin', N'Wandtke', N'7 Canary Way', N'mwandtke1@reverbnation.com', N'531-565-1930')
INSERT [dbo].[Customers] ([Id], [First Name], [Last Name], [Address], [Email], [Phone]) VALUES (3, N'Reina', N'Meeus', N'72 Stone Corner Street', N'rmeeus2@tamu.edu', N'286-411-8772')
INSERT [dbo].[Customers] ([Id], [First Name], [Last Name], [Address], [Email], [Phone]) VALUES (4, N'Jessey', N'Sabberton', N'8 Thackeray Circle', N'jsabberton3@ocn.ne.jp', N'153-371-2441')
INSERT [dbo].[Customers] ([Id], [First Name], [Last Name], [Address], [Email], [Phone]) VALUES (5, N'Yolane', N'Adamczyk', N'4560 Mifflin Road', N'yadamczyk4@mlb.com', N'839-416-3031')
INSERT [dbo].[Customers] ([Id], [First Name], [Last Name], [Address], [Email], [Phone]) VALUES (6, N'Shirl', N'De Banke', N'139 Larry Way', N'sdebanke5@vimeo.com', N'989-566-5900')
INSERT [dbo].[Customers] ([Id], [First Name], [Last Name], [Address], [Email], [Phone]) VALUES (7, N'Koralle', N'--GOodinson', N'9130 Surrey Junction', N'k--GOodinson6@prweb.com', N'834-923-9944')
INSERT [dbo].[Customers] ([Id], [First Name], [Last Name], [Address], [Email], [Phone]) VALUES (8, N'Nata', N'Jeannard', N'8649 Everett Plaza', N'njeannard7@vimeo.com', N'749-652-7732')
INSERT [dbo].[Customers] ([Id], [First Name], [Last Name], [Address], [Email], [Phone]) VALUES (9, N'Morgen', N'Malitrott', N'86 Helena Park', N'mmalitrott8@imdb.com', N'610-444-3736')
INSERT [dbo].[Customers] ([Id], [First Name], [Last Name], [Address], [Email], [Phone]) VALUES (10, N'Amy', N'Devin', N'11638 Crownhardt Circle', N'adevin9@cdc.--GOv', N'616-251-0672')
SET IDENTITY_INSERT [dbo].[Customers] OFF
--GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [Order Date], [CustomerID]) VALUES (1, CAST(N'2021-04-03T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Orders] ([Id], [Order Date], [CustomerID]) VALUES (2, CAST(N'2021-01-25T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Orders] ([Id], [Order Date], [CustomerID]) VALUES (3, CAST(N'2020-12-25T00:00:00.0000000' AS DateTime2), 3)
INSERT [dbo].[Orders] ([Id], [Order Date], [CustomerID]) VALUES (4, CAST(N'2021-02-21T00:00:00.0000000' AS DateTime2), 4)
INSERT [dbo].[Orders] ([Id], [Order Date], [CustomerID]) VALUES (5, CAST(N'2020-11-30T00:00:00.0000000' AS DateTime2), 5)
INSERT [dbo].[Orders] ([Id], [Order Date], [CustomerID]) VALUES (6, CAST(N'2021-04-03T00:00:00.0000000' AS DateTime2), 6)
INSERT [dbo].[Orders] ([Id], [Order Date], [CustomerID]) VALUES (7, CAST(N'2021-01-25T00:00:00.0000000' AS DateTime2), 7)
INSERT [dbo].[Orders] ([Id], [Order Date], [CustomerID]) VALUES (8, CAST(N'2020-12-25T00:00:00.0000000' AS DateTime2), 8)
INSERT [dbo].[Orders] ([Id], [Order Date], [CustomerID]) VALUES (9, CAST(N'2021-02-21T00:00:00.0000000' AS DateTime2), 9)
INSERT [dbo].[Orders] ([Id], [Order Date], [CustomerID]) VALUES (10, CAST(N'2020-11-30T00:00:00.0000000' AS DateTime2), 10)
SET IDENTITY_INSERT [dbo].[Orders] OFF
--GO
INSERT [dbo].[Books_Orders] ([ISBN13], [OrderID], [Amount]) VALUES (9782080642241, 1, 2)
INSERT [dbo].[Books_Orders] ([ISBN13], [OrderID], [Amount]) VALUES (9783797492242, 2, 5)
INSERT [dbo].[Books_Orders] ([ISBN13], [OrderID], [Amount]) VALUES (9783797492242, 3, 5)
INSERT [dbo].[Books_Orders] ([ISBN13], [OrderID], [Amount]) VALUES (9785220592247, 4, 3)
INSERT [dbo].[Books_Orders] ([ISBN13], [OrderID], [Amount]) VALUES (9786181582249, 5, 6)
INSERT [dbo].[Books_Orders] ([ISBN13], [OrderID], [Amount]) VALUES (9786572202246, 6, 1)
INSERT [dbo].[Books_Orders] ([ISBN13], [OrderID], [Amount]) VALUES (9786863682249, 7, 6)
--GO
SET IDENTITY_INSERT [dbo].[Bookstores] ON 

INSERT [dbo].[Bookstores] ([Id], [Bookstore Name], [Address], [Postal Code], [Website], [Phone]) VALUES (1, N'Kohler-Macejkovic', N'20 Warbler Hill', N'Apple Street 14', N'kohler-mocejkovic0@arizona.edu', N'988-473-6070')
INSERT [dbo].[Bookstores] ([Id], [Bookstore Name], [Address], [Postal Code], [Website], [Phone]) VALUES (2, N'Zemlak-Donnelly', N'3 Debs Crossing', N'Kings street 15', N'zemlak-donnelly@gmail.com', N'902-699-2913')
INSERT [dbo].[Bookstores] ([Id], [Bookstore Name], [Address], [Postal Code], [Website], [Phone]) VALUES (3, N'Bradtke, Hammes and Beer', N'0 Hauk Lane', N'Queens street 16', N'bh b@gmail.com', N'878-601-1639')
SET IDENTITY_INSERT [dbo].[Bookstores] OFF
--GO
INSERT [dbo].[Stock_Balances] ([BookstoreID], [ISBN13], [Amount]) VALUES (1, 9782080642241, 6)
INSERT [dbo].[Stock_Balances] ([BookstoreID], [ISBN13], [Amount]) VALUES (1, 9786863682249, 11)
INSERT [dbo].[Stock_Balances] ([BookstoreID], [ISBN13], [Amount]) VALUES (1, 9787177572240, 22)
INSERT [dbo].[Stock_Balances] ([BookstoreID], [ISBN13], [Amount]) VALUES (1, 9788817912240, 33)
INSERT [dbo].[Stock_Balances] ([BookstoreID], [ISBN13], [Amount]) VALUES (1, 9789189582244, 44)
INSERT [dbo].[Stock_Balances] ([BookstoreID], [ISBN13], [Amount]) VALUES (2, 9782080642241, 55)
INSERT [dbo].[Stock_Balances] ([BookstoreID], [ISBN13], [Amount]) VALUES (2, 9782082172247, 66)
INSERT [dbo].[Stock_Balances] ([BookstoreID], [ISBN13], [Amount]) VALUES (2, 9783797492242, 77)
INSERT [dbo].[Stock_Balances] ([BookstoreID], [ISBN13], [Amount]) VALUES (2, 9785220592247, 88)
INSERT [dbo].[Stock_Balances] ([BookstoreID], [ISBN13], [Amount]) VALUES (2, 9786181582249, 99)
INSERT [dbo].[Stock_Balances] ([BookstoreID], [ISBN13], [Amount]) VALUES (2, 9786572202246, 12)
INSERT [dbo].[Stock_Balances] ([BookstoreID], [ISBN13], [Amount]) VALUES (2, 9786863682249, 13)
INSERT [dbo].[Stock_Balances] ([BookstoreID], [ISBN13], [Amount]) VALUES (2, 9787177572240, 15)
INSERT [dbo].[Stock_Balances] ([BookstoreID], [ISBN13], [Amount]) VALUES (2, 9788817912240, 61)
INSERT [dbo].[Stock_Balances] ([BookstoreID], [ISBN13], [Amount]) VALUES (2, 9789189582244, 124)
INSERT [dbo].[Stock_Balances] ([BookstoreID], [ISBN13], [Amount]) VALUES (3, 9782080642241, 61)
INSERT [dbo].[Stock_Balances] ([BookstoreID], [ISBN13], [Amount]) VALUES (3, 9782082172247, 612)
INSERT [dbo].[Stock_Balances] ([BookstoreID], [ISBN13], [Amount]) VALUES (3, 9783797492242, 61)
INSERT [dbo].[Stock_Balances] ([BookstoreID], [ISBN13], [Amount]) VALUES (3, 9785220592247, 41)
INSERT [dbo].[Stock_Balances] ([BookstoreID], [ISBN13], [Amount]) VALUES (3, 9786181582249, 41)
INSERT [dbo].[Stock_Balances] ([BookstoreID], [ISBN13], [Amount]) VALUES (3, 9786572202246, 61)
INSERT [dbo].[Stock_Balances] ([BookstoreID], [ISBN13], [Amount]) VALUES (3, 9786863682249, 65)
INSERT [dbo].[Stock_Balances] ([BookstoreID], [ISBN13], [Amount]) VALUES (3, 9787177572240, 71)
INSERT [dbo].[Stock_Balances] ([BookstoreID], [ISBN13], [Amount]) VALUES (3, 9788817912240, 6)
INSERT [dbo].[Stock_Balances] ([BookstoreID], [ISBN13], [Amount]) VALUES (3, 9789189582244, 6)
--GO
