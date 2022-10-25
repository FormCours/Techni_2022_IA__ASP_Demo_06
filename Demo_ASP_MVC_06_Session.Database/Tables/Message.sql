CREATE TABLE [dbo].[Message]
(
	[Message_Id] INT NOT NULL IDENTITY,
	[Content] NVARCHAR(4000) NOT NULL,
	[Create_At] DATETIME2 DEFAULT GETDATE(),
	[Member_Id] INT NOT NULL,
	
	CONSTRAINT PK_Message 
		PRIMARY KEY([Message_Id]),

	CONSTRAINT FK_Message_Member
		FOREIGN KEY([Member_Id])
		REFERENCES [Member]([Member_Id])
)
