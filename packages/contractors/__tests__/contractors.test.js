const Sequelize = require('sequelize');
// const contractors = require('../lib/contractors');
const { Contractors } = require('aster-database');

describe('contractors', () => {
  let testSequalize;

  beforeAll(() => {
    testSequalize = new Sequelize('dbaster', 'useraster', 'mariapass', {
      host: 'localhost',
      dialect: 'mariadb',
    });
  });

  it('should return list of contractors', async () => {
    const data = await Contractors(testSequalize, Sequelize).findAll();
    data.forEach((c) => {
      expect(c).toMatchObject({
        address1: expect.any(String),
        address2: expect.any(String),
        contactNo: expect.any(String),
        country: expect.any(String),
        dateOfBirth: expect.any(Date),
        email: expect.any(String), // TODO: expect.stringMatching('email')
        forename: expect.any(String),
        gender: expect.any(String),
        id: expect.any(Number),
        middlename: null,
        nationalInsuranceNo: expect.any(String), // TODO: expet.stringMatching(NINO)
        postCode: expect.any(String),
        referenceNo: expect.any(String),
        surname: expect.any(String),
        createdAt: expect.any(Date),
        updatedAt: expect.any(Date),
      });
    });
  });
});
