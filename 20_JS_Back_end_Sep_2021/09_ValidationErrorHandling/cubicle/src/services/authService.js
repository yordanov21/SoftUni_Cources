// const jwt = require('jsonwebtoken');
const bcrypt = require("bcrypt");
const User = require("../models/User");
const { jwtSign } = require('../utils/jwtUtils');
const { SECRET } = require('../constants');

//named exports,  with function expresion
exports.register = function (username, password, repeatPassword) {
    // hashing the password in the model or in the servise.
    //   return bcrypt
    //     .hash(password, 10)
    //     .then((hash) => User.create({ username, password: hash }));

    return User.create({ username, password, repeatPassword });
};

// check for valid user in the service with promise, but here is better to use async function
// exports.login = function (username, password) {
//     return User.findByUsername(username)
//         .then(user => {
//             return Promise.all([bcrypt.compare(password, user.password), user])
//         })
//         .then(([isValid, user]) => {
//             if (isValid) {
//                 return user;
//             } else {
//                 throw { message: "Cannot find username or password" };
//             }
//         })
// };

//check for valid user in the model with method validatePassword
exports.login = function (username, password) {
    return User.findByUsername(username)
        .then((user) => Promise.all([user.validatePassword(password), user]))
        .then(([isValid, user]) => {
            if (isValid) {
                return user;
            } else {
                throw { message: "Cannot find username or password" };
            }
        })
        .catch(() => null);
};

// exports.createToken = function (user, onTokenCreate) {
//     let payload = {
//         _id: user._id,
//         username: user.username,
//     }

//     jwt.sign(payload, SECRET, function (err, token) {
//         if (err) {
//             return onTokenCreate(err);
//         }

//         onTokenCreate(null, token);
//     });
// };

exports.createToken = function (user) {
    let payload = {
        _id: user._id,
        username: user.username,
    }

    return jwtSign(payload, SECRET);

    // transform a callback in a func that return promise
    // return new Promise((resolve, reject) => {
    //     jwt.sign(payload, SECRET, function(err, token) {
    //         if (err) {
    //             reject(err);
    //         } else {
    //             resolve(token);
    //         }
    //     })
    // });
};
