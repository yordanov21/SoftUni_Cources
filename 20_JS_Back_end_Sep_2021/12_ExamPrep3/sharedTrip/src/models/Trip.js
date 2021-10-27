const mongoose = require('mongoose');

let tripSchema = new mongoose.Schema({
    startPoint: {
        type: String,
        required: true,
        minlength: 4,
    },
    endPoint: {
        type: String,
        required: true,
        minlength: 4,
    },
    date: {
        type: String,
        required: true,
    },
    time: {
        type: String,
        required: true,
    },
    carImage: {
        type: String,
        required: true,
        validate: [/^https?:\/\//i, 'invalid image url']
    },
    carBrand: {
        type: String,
        required: true,
        minlength: 4,
    },
    seats: {
        type: Number,
        required: true,
    },
    price: {
        type: Number,
        required: true,
        min: 1,
        max: 50,
    },
    description: {
        type: String,
        required: true,
        minlength: 10,
    },
    creator: {
        type: mongoose.Types.ObjectId,
        ref: 'User',
    },
    buddies: [
        {
            type: mongoose.Types.ObjectId,
            ref: 'User',
        }
    ],
}, {
    timestamps: true
});



let Trip = mongoose.model('Trip', tripSchema)

module.exports = Trip;