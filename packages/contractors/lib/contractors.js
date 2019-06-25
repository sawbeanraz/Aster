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
