module.exports = (sequalize, DataTypes) => sequalize.define('contractors', {
  referenceNo: DataTypes.STRING,
  forename: DataTypes.STRING,
  middlename: DataTypes.STRING,
  surname: DataTypes.STRING,
  dateOfBirth: DataTypes.DATE,
  gender: DataTypes.STRING,
  nationalInsuranceNo: DataTypes.STRING,
  address1: DataTypes.STRING,
  address2: DataTypes.STRING,
  county: DataTypes.STRING,
  postCode: DataTypes.STRING,
  contactNo: DataTypes.STRING,
  email: DataTypes.STRING,
  createdAt: DataTypes.DATE,
  updatedAt: DataTypes.DATE,
});


// CREATE TABLE contractors (
// 	id INT PRIMARY KEY AUTO_INCRMENT,
// 	referenceNo VARCHAR(20),
// 	forename VARCHAR(200),
// 	middlename VARCHAR(200),
// 	surname VARCHAR(200),
// 	dateOfBirth DATETIME,
// 	gender VARCHAR(20),
// 	nationalInsuranceNo VARCHAR(100),
// 	address1 VARCHAR(100),
// 	address2 VARCHAR(100),
// 	county VARCHAR(100),
// 	postCode VARCHAR(20),
// 	contactNo VARCHAR(30),
// 	email VARCHAR(255),
// 	createdOnUtc DATETIME NOT NULL,
// 	updatedOnUtc DATETIME NOT NULL,
//   createdAt DATETIME,
// );
