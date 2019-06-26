const FakeContractors = require('../utils/contractors-data');

module.exports = {
  up: queryInterface => queryInterface.bulkInsert('contractors',
    FakeContractors(100), {}),
  down: queryInterface => queryInterface.bulkDelete('contractors', null, {}),
};
