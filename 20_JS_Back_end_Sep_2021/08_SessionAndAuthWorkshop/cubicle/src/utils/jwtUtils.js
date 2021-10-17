const jwt = require('jsonwebtoken');
const util = require('util');

// will create jwt.sign in promise variant with util library (turns callback in promise)
// exports.jwtSign = util.promisify(jwt.sign);

// will create jwt.sign in promise variant by hand (turns callback in promise)
exports.jwtSign = function (payload, secret) {
    let promise = new Promise((resolve, reject) => {
        jwt.sign(payload, secret, function (err, token) {
            if (err) {
                reject(err);
            } else {
                resolve(token);
            }
        });
    });

    return promise;
};