const faker = require('faker');

const fakeContractors = n => new Array(n).fill(() => ({
  referenceNo: faker.random.number(),
  forename: faker.name.firstName(),
  middlename: null,
  surname: faker.name.lastName(),
  dateOfBirth: faker.date.past(18),
  gender: 'Male',
  nationalInsuranceNo: 'NI38282JC',
  address1: faker.address.streetName(),
  address2: faker.address.secondaryAddress(),
  country: faker.address.country(),
  postCode: faker.address.zipCode(),
  contactNo: faker.phone.phoneNumberFormat(),
  email: faker.internet.email(),
  createdAt: new Date(),
  updatedAt: new Date(),
})).map(f => f());

module.exports = fakeContractors;
