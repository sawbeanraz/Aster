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