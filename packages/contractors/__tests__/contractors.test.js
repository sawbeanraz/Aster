const Sequelize = require('sequelize');
const contractors = require('../lib/contractors');

describe('contractors', () => {
  let testSequalize;

  beforeAll(() => {
    testSequalize = new Sequelize('dbaster', 'useraster', 'mariapass', {
      host: 'localhost',
      dialect: 'mariadb',
    });
  });

  it('needs tests', async () => {
    const u = contractors(testSequalize, Sequelize);
    const data = u.findAll();
    // console.log('data>>>>', data);
    console.log('\n\n\n', JSON.stringify(data, null, 2), '\n\n\n');
  });
});
