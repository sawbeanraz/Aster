const FakeContractors = require('../utils/contractors-data');

module.exports = {
  up: (queryInterface) => {
    return queryInterface.bulkInsert('contractors',
      FakeContractors(100), {});
  },
  down: (queryInterface, Sequelize) => {
    return queryInterface.bulkDelete('People', null, {});
  }
};
