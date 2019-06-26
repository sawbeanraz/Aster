module.exports = (sequelize, DataTypes) => {
  const contractors = sequelize.define('contractors', {
    referenceNo: DataTypes.STRING,
    forename: DataTypes.STRING,
    middlename: DataTypes.STRING,
    surname: DataTypes.STRING,
    dateOfBirth: DataTypes.DATE,
    gender: DataTypes.STRING,
    nationalInsuranceNo: DataTypes.STRING,
    address1: DataTypes.STRING,
    address2: DataTypes.STRING,
    country: DataTypes.STRING,
    postCode: DataTypes.STRING,
    contactNo: DataTypes.STRING,
    email: DataTypes.STRING,
  }, {});
  contractors.associate = function(models) {
    // associations can be defined here
  };
  return contractors;
};
