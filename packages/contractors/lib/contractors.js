const Sequelize = require('sequelize');

class Contractors extends Sequalize.Model {
  Contractors.init({
    ReferenceNo: Sequelize.STRING,
    Forename: Sequalize.STRING,
    Middlename: Sequalize.STRING,
    Surname: Sequalize.STRING,
    DateOfBirth: Sequalize.DATE,
    Gender: Sequalize.STRING,
    NationalInsuranceNo: Sequalize.STRING,
    Address1: Sequalize.STRING,
    Address2: Sequalize.STRING,
    County: Sequalize.STRING,
    PostCode: Sequalize.STRING,
    ContactNo: Sequalize.STRING,
    Email: Sequalize.STRING,
    CreatedOnUtc: Sequalize.DATE,
    UpdatedOnUtc: Sequalize.DATE
  }, { sequelize, modelName: 'contractors' })
}

export default Contractors;
