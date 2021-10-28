const mongoose = require('mongoose');

let hotelSchema = new mongoose.Schema({
    name: {
        type: String,
        required: true,
        // minlength: 4,
    },
    city: {
        type: String,
        required: true,
        // minlength: 20,
    },
    imageUrl: {
        type: String,
        required: true,
        validate: [/^https?:\/\//i, 'invalid image url']
    },
    freeRooms: {
        type: Number,
        required: true,
        min: 1,
        max: 100,
    },
    usersBookedRoom: [
        {
            type: mongoose.Types.ObjectId,
            ref: 'User',
        }
    ],
    owner: {
        type: mongoose.Types.ObjectId,
        ref: 'User',
    },
}, {
    timestamps: true
});

// hotelSchema.method('getEnrolled', function () {
//     return this.usersEnrolled.map(x => x.name).join(', ');
// })

let Hotel = mongoose.model('Hotel', hotelSchema);

module.exports = Hotel;