﻿CREATE TABLE [dbo].[UserChats]
(
	[UserId] NVARCHAR(450),
	[ChatId] INT,
	[DateJoined] DATETIME NOT NULL,
	PRIMARY KEY ([UserId], [ChatId]),
	FOREIGN KEY ([UserId]) REFERENCES AspNetUsers ([Id]),
	FOREIGN KEY ([ChatId]) REFERENCES Chats ([Id])
)
