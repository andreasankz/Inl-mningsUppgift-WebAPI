CREATE TABLE Users (
	Id int not null identity(1,1) primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Email varchar(100) not null,
	UHash varbinary(max) not null,
	USalt varbinary(max) not null
)
GO

CREATE TABLE Issues (
	Id int not null identity(1,1) primary key,
	UserId int not null references Users(Id),
	CreatedDate datetime not null,
	ChangedDate datetime null,
	IssueStatus nvarchar(20) not null,
	IssueDescription nvarchar(max) null
)