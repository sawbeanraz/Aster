const user = 'aster';
const password = 'aser-password!23';
const host = 'localhost';
const database = 'asterdb';

const Sequlize = require('sequelize');

const sequelize = new Sequlize(database, user, password, {
  host,
  dialect: 'postgres',
  logging: false,
});

module.exports = sequelize;
