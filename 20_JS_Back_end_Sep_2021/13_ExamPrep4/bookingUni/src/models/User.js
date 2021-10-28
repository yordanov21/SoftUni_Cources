const mongoose = require('mongoose');
const bcrypt = require('bcrypt');
const SALT_ROUNDS = 10;

const userSchema = new mongoose.Schema({
    email: {
        type: String,
        required: true,
        minlength: 5,
        validate: [/(.+)@(.+){2,}\.(.+){2,}/, "Email should be in proper format (mailboxname @ domainname) - username@domain.bg"],
    },
    username: {
        type: String,
        required: true,
        minlength: 5,
        validate: [/^[a-zA-Z0-9 ]+$/, "Username should consist of english letters, digits and spaces",],
    },
    password: {
        type: String,
        required: true,
        minlength: 5,
        validate: [/^[a-zA-Z0-9]+$/, "Password should consist of english letters and digits",],
    },
    bookedHotels: [
        {
            type: mongoose.Types.ObjectId,
            ref: 'Hotel',
        }
    ],
    offeredHotels: [
        {
            type: mongoose.Types.ObjectId,
            ref: 'Hotel',
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

userSchema.method('getBookedHotels', function () {
    return this.bookedHotels.map(x => x.name).join(', ');
})

userSchema.method('getOfferedHotels', function () {
    return this.offeredHotels.map(x => x.name).join(', ');
})

const User = mongoose.model('User', userSchema);

module.exports = User;