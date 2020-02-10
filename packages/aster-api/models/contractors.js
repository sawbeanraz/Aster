const { Model, DataTypes } = require('sequelize');
const db = require('../database');

class Contractor extends Model {}

Contractor.init({
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
}, {
  sequelize: db,
  modelName: 'contractor',
  timestamps: false,
});

module.exports = Contractor;
