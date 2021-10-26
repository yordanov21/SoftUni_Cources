const mongoose = require('mongoose');

let tripSchema = new mongoose.Schema({
    startPoint: {
        type: String,
        required: true,
    },
    endPoint: {
        type: String,
        required: true,
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
    },
    carBrand: {
        type: String,
        required: true,
    },
    seats: {
        type: Number,
        required: true,
    },
    price: {
        type: Number,
        required: true,
    },
    description: {
        type: String,
        required: true,
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