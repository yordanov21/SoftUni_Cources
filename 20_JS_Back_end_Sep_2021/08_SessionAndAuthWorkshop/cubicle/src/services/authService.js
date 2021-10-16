const bcrypt = require("bcrypt");
const User = require("../models/User");

//named exports,  with function expresion
exports.register = function (username, password, repeatPassword) {
  return bcrypt
    .hash(password, 10)
    .then((hash) => User.create({ username, password: hash }));
};
