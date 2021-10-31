const mongoose = require('mongoose');
const bcrypt = require('bcrypt');
const SALT_ROUNDS = 10;

const userSchema = new mongoose.Schema({
    firstName: {
        type: String,
        required: true,
        minlength: 3,
        validate: [/^[a-zA-Z]+$/, "First name should consist of English letters",],
    },
    lastName: {
        type: String,
        required: true,
        minlength: 5,
        validate: [/^[a-zA-Z]+$/, "Last name should consist of English letters",],
    },
    email: {
        type: String,
        required: true,
        minlength: 5,
        validate: [/(.+)@(.+){2,}\.(.+){2,}/, "The email should be in the following format: <name>@<domain>.<extension>"],
    },
    password: {
        type: String,
        required: true,
        minlength: 4,
        validate: [/^[a-zA-Z0-9]+$/, "Password should consist of english letters and digits",],
    },
    myPosts: [
        {
            type: mongoose.Types.ObjectId,
            ref: 'Post',
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

// userSchema.method('getEnrolledCourses', function () {
//     return this.enrolledCourses.map(x => x.title).join(', ');
// })



const User = mongoose.model('User', userSchema);

module.exports = User;