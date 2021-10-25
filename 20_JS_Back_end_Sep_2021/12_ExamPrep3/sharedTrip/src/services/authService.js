const jwt = require('../utils/jwt');
const User = require('../models/User');
const { JWT_SECRET } = require('../constants');

exports.login = async ({ email, password }) => {
    let user = await User.findOne({ email });

    if (!user) {
        throw new Error('Invalid email or password1')
    }

    let isValid = await user.validatePassword(password);

    if (!isValid) {
        throw new Error('Invalid username or password2')
    }

    let payload = {
        _id: user._id,
        email: user.email,
        // password: user.password,
    };

    // let token = jwt.sign(payload,JWT_SECRET, {expiresIn: '1h'}); // example with expiresIn like a options 
    let token = await jwt.sign(payload, JWT_SECRET);

    return token;
};

exports.register = (userData) => User.create(userData);

exports.getOne = (userId) => User.findById(userId).populate('enrolledCourses');