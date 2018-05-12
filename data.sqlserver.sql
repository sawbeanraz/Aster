CREATE TABLE Users (
	Id INT PRIMARY KEY IDENTITY(1,1),
	UserName VARCHAR(20),
	Email VARCHAR(255),
	PasswordHash VARCHAR(1024),
	SecurityStamp VARCHAR(200),
	EmailConfirmed BIT
);


INSERT INTO Users (UserName, Email, PasswordHash, SecurityStamp, EmailConfirmed)
VALUES('bean','srdx7@hotmail.com', 'CF6B43C5C1A960625B5B0D426FA50D2C222A6356', NULL, 1);



CREATE TABLE PermissionRecords (
  Id INT PRIMARY KEY IDENTITY(1,1),
  [Name] VARCHAR(200) NOT NULL,
  Portal VARCHAR(200) NOT NULL,
  Category VARCHAR(200) NOT NULL
);


CREATE TABLE Languages (
	Id INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(100)	NOT NULL,
	LanguageCulture VARCHAR(10) NOT NULL,
	RightToLeft BIT DEFAULT 0,
	[Enabled] BIT DEFAULT 1);


INSERT INTO Languages(Name, LanguageCulture, RightToLeft, [Enabled])
VALUES ('English', 'GB-en', 0, 1);

INSERT INTO Languages([Name], LanguageCulture, RightToLeft, [Enabled])
VALUES ('French', 'FR-fr', 0, 1);


CREATE TABLE LocaleStrings (
  Id INT PRIMARY KEY IDENTITY(1,1),
  LanguageId INT, 
  MsgId VARCHAR(1000) NOT NULL,
  MsgStr VARCHAR(1000) NOT NULL,
  FOREIGN KEY (LanguageId) REFERENCES Languages(Id)
);


INSERT INTO LocaleStrings(LanguageId, MsgId, MsgStr)
VALUES(2, 'Hello', 'Bonjour');
INSERT INTO LocaleStrings(LanguageId, MsgId, MsgStr)
VALUES (2, 'Hello!! How are you?', 'Bonjour!! Comment allez-vous?');



CREATE TABLE Logs(
	Id INT PRIMARY KEY IDENTITY(1,1),
	LogLevelId INT NOT NULL,
	ShortMessage VARCHAR(255) NOT NULL,
	FullMessage VARCHAR(2500) NULL,
	Ip VARCHAR(20),
	PageUrl VARCHAR(500),
	ReferrerUrl VARCHAR(500),
	CreatedOnUtc DATETIME NOT NULL,
	Reference VARCHAR(200)
);





CREATE TABLE Contractors (
	Id INT PRIMARY KEY IDENTITY(1,1),
	ReferenceNo VARCHAR(20),
	Forename VARCHAR(MAX),
	Middlename VARCHAR(MAX),
	Surname VARCHAR(MAX),
	DateOfBirth DATETIME, 
	Gender VARCHAR(20),
	NationalInsuranceNo VARCHAR(100),
	Address1 VARCHAR(100),
	Address2 VARCHAR(100),
	County VARCHAR(100),
	PostCode VARCHAR(20),
	ContactNo VARCHAR(30),
	Email VARCHAR(255),
	CreatedOnUtc DATETIME NOT NULL,
	UpdatedOnUtc DATETIME NOT NULL
);


INSERT INTO Contractors (ReferenceNo, Forename, Middlename, Surname, DateOfBirth, Gender, NationalInsuranceNo, Address1, Address2, County, PostCode, ContactNo, Email, CreatedOnUtc, UpdatedOnUtc)
VALUES('C000001','Mickey', NULL, 'Bell', '1980-01-01 00:00:00.000', 'Male', 'N2038JD29EJ', '1 Test Road', NULL, NULL, 'T3S1 0D', '0202 3839 293', 'test@hotmail.com', GETDATE(), GETDATE())