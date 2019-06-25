module.exports = {
  up: (queryInterface, Sequelize) => queryInterface.createTable('contractors', {
    id: {
      allowNull: false,
      autoIncrement: true,
      primaryKey: true,
      type: Sequelize.INTEGER,
    },
    referenceNo: {
      type: Sequelize.STRING,
    },
    forename: {
      type: Sequelize.STRING,
    },
    middlename: {
      type: Sequelize.STRING,
    },
    surname: {
      type: Sequelize.STRING,
    },
    dateOfBirth: {
      type: Sequelize.DATE,
    },
    gender: {
      type: Sequelize.STRING,
    },
    nationalInsuranceNo: {
      type: Sequelize.STRING,
    },
    address1: {
      type: Sequelize.STRING,
    },
    address2: {
      type: Sequelize.STRING,
    },
    country: {
      type: Sequelize.STRING,
    },
    postCode: {
      type: Sequelize.STRING,
    },
    contactNo: {
      type: Sequelize.STRING,
    },
    email: {
      type: Sequelize.STRING,
    },
    createdAt: {
      allowNull: false,
      type: Sequelize.DATE,
    },
    updatedAt: {
      allowNull: false,
      type: Sequelize.DATE,
    },
  }),
  down: queryInterface => queryInterface.dropTable('contractors'),
};
