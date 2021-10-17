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

// check for valid user in the service with promise, but here is better to use async function
exports.login = function (username, password) {
    return User.findByUsername(username)
        .then(user => {
            return Promise.all([bcrypt.compare(password, user.password), user])
        })
        .then(([isValid, user]) => {
            if (isValid) {
                return user;
            } else {
                throw { message: "Cannot find username or password" };
            }
        })
};

// check for valid user in the model
// exports.login = function (username, password) {
//   return User.findByUsername(username)
//     .then((user) => Promise.all([user.validatePassword(password), user]))
//     .then(([isValid, user]) => {
//       if (isValid) {
//         return user;
//       } else {
//         throw { message: "Cannot find username or password" };
//       }
//     })
//     .catch(() => null);
// };
