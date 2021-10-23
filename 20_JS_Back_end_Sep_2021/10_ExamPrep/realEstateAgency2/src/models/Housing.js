const mongoose = require('mongoose');

let housingSchema = new mongoose.Schema({
    name: {
        type: String,
        required: true,
        minlength: 6,
    },
    type: {
        type: String,
        enum: ['Apartament', 'Villa', 'House'],
        required: true,
    },
    year: {
        type: Number,
        required: true,
        min: 1850,
        max: 2021
    },
    city: {
        type: String,
        required: true,
        minlength: 4,
    },
    image: {
        type: String,
        required: true,
        validate: [/^https?:\/\//i, 'invalid image url']
    },
    description: {
        type: String,
        required: true,
        maxlength: 60,
    },
    availablePieces: {
        type: Number,
        required: true,
        min: 0,
        max: 10,
    },
    tenants: [
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

housingSchema.method('getTenants', function () {
    return this.tenants.map(x => x.name).join(', ');
})

let Housing = mongoose.model('Housing', housingSchema);

module.exports = Housing;