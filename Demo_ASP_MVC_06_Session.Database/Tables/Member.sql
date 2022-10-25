CREATE TABLE [dbo].[Member]
(
	[Member_Id] INT NOT NULL IDENTITY,
	[Email] NVARCHAR(250) NOT NULL,
	[Pseudo] NVARCHAR(50) NOT NULL,
	[Pwd_Hash] CHAR(97) NOT NULL,

	CONSTRAINT PK_Member
		PRIMARY KEY ([Member_Id]),
		
	CONSTRAINT UK_Member__Email
		UNIQUE ([Email]),
		
	CONSTRAINT UK_Member__Pseudo
		UNIQUE ([Pseudo])
)
