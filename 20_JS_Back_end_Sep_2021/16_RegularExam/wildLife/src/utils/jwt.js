const jwt = require('jsonwebtoken');

const util = require('util');

// turn on jwt functions sign and verify in promise variant 
exports.sign = util.promisify(jwt.sign);
exports.verify = util.promisify(jwt.verify);