CREATE TABLE Users (
	Id INT AUTO_INCREMENT PRIMARY KEY,
	UserName VARCHAR(20),
	Email VARCHAR(255),
	PasswordHash VARCHAR(1024),
	SecurityStamp VARCHAR(200),
	EmailConfirmed BIT
);


INSERT INTO Users (UserName, Email, PasswordHash, SecurityStamp, EmailConfirmed)
VALUES('bean','srdx7@hotmail.com', 'test', 'CF6B43C5C1A960625B5B0D426FA50D2C222A6356', 1);



CREATE TABLE PermissionRecords (
  Id INT AUTO_INCREMENT PRIMARY KEY,
  `Name` VARCHAR(200) NOT NULL,
  Portal VARCHAR(200) NOT NULL,
  Category VARCHAR(200) NOT NULL
)


CREATE TABLE Languages (
	Id INT AUTO_INCREMENT PRIMARY KEY,
	`Name` VARCHAR(100)	 NOT NULL,
	LanguageCulture VARCHAR(10) NOT NULL,
	Rtl BIT DEFAULT 0,
	Enabled BIT DEFAULT 1, 
	`Orders` INT)


INSERT INTO Languages(Name, LanguageCulture, Rtl, Enabled, `Orders`)
VALUES ('English', 'GB-en', 0, 1, 1)

INSERT INTO Languages(`Name`, LanguageCulture, Rtl, Enabled, `Orders`)
VALUES ('French', 'FR-fr', 0, 1, 1)


CREATE TABLE LocaleStrings (
  Id INT AUTO_INCREMENT PRIMARY KEY,
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
	Id INT AUTO_INCREMENT PRIMARY KEY,
	LogLevelId INT NOT NULL,
	ShortMessage VARCHAR(255) NOT NULL,
	FullMessage VARCHAR(2500) NULL,
	Ip VARCHAR(20),
	PageUrl VARCHAR(500),
	ReferrerUrl VARCHAR(500),
	CreatedOnUtc DATETIME NOT NULL,
	Reference VARCHAR(200)
);