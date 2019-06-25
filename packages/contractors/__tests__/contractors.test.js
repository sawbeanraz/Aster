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

  it('needs tests', (done) => {
    const u = contractors(testSequalize, Sequelize);
    u.findAll().then((data) => {
      console.log('\n\n\n', JSON.stringify(data, null, 2), '\n\n\n');
    }).catch((err) => {
      console.log('ERROR', err);
    }).finally(() => {
      done();
    });
    // console.log('data>>>>', data);
  });
});
