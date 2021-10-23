const jwt = require('../utils/jwt');
const User = require('../models/User');
const { JWT_SECRET } = require('../constants');

exports.login = async ({ username, password }) => {
    let user = await User.findOne({ username });

    if (!user) {
        throw new Error('Invalid username or password')
    }

    let isValid = await user.validatePassword(password);

    if (!isValid) {
        throw new Error('Invalid username or password')
    }

    let payload = {
        _id: user._id,
        name: user.name,
        username: user.username,
    };

    // let token = jwt.sign(payload,JWT_SECRET, {expiresIn: '1h'}); // example with expiresIn like a options 
    let token = await jwt.sign(payload, JWT_SECRET);

    return token;
};

// exports.register = async (userData) => {
//     User.create(userData);
// };


exports.register = (userData) => User.create(userData);