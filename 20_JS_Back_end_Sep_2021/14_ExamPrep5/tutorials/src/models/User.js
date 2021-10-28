const mongoose = require('mongoose');
const bcrypt = require('bcrypt');
const SALT_ROUNDS = 10;

const userSchema = new mongoose.Schema({
    username: {
        type: String,
        required: true,
        minlength: 5,
        validate: [/^[a-zA-Z0-9]+$/, "Username should consist of english letters, digits and spaces",],
    },
    password: {
        type: String,
        required: true,
        minlength: 5,
        validate: [/^[a-zA-Z0-9]+$/, "Password should consist of english letters and digits",],
    },
    enrolledCourses: [
        {
            type: mongoose.Types.ObjectId,
            ref: 'Course',
        }
    ],
});

userSchema.pre('save', function (next) {
    return bcrypt.hash(this.password, SALT_ROUNDS)
        .then((hash) => {
            this.password = hash;

            return next();
        });
});

userSchema.method('validatePassword', function (password) {
    return bcrypt.compare(password, this.password);
})

userSchema.method('getEnrolledCourses', function () {
    return this.enrolledCourses.map(x => x.title).join(', ');
})



const User = mongoose.model('User', userSchema);

module.exports = User;