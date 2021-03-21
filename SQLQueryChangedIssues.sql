CREATE TABLE Issues (
	Id int not null identity(1,1) primary key,
	HandlerId int not null references Users(Id),
	Customer nvarchar(100) not null,
	CreatedDate datetime not null,
	ChangedDate datetime null,
	IssueStatus nvarchar(20) not null,
	IssueDescription nvarchar(max) null
)