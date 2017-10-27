CREATE TABLE [dbo].[Table]
(
	[UserID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Fullname] NCHAR(50) NOT NULL, 
    [Username] NCHAR(30) NOT NULL, 
    [Password] NCHAR(30) NOT NULL
)
