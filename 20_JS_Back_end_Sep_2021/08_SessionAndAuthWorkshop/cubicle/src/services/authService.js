const bcrypt = require("bcrypt");
const User = require("../models/User");

//named exports,  with function expresion
exports.register = function (username, password, repeatPassword) {
  // hashing the password in the model or in the servise.
  //   return bcrypt
  //     .hash(password, 10)
  //     .then((hash) => User.create({ username, password: hash }));

  return User.create({ username, password });
};
