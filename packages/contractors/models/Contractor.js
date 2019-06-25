const Sequelize = require('sequelize');

const sequelize = new Sequelize('dbaster', 'useraster', 'mariapass', {
  host: 'localhost',
  dialect: 'mariadb',
});
