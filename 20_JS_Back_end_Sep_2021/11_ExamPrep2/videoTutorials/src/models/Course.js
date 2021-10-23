const mongoose = require('mongoose');

let courseSchema = new mongoose.Schema({
    title: {
        type: String,
        required: true,
        minlength: 4,
    },
    description: {
        type: String,
        required: true,
        minlength: 20,
    },
    imageUrl: {
        type: String,
        required: true,
        validate: [/^https?:\/\//i, 'invalid image url']
    },
    isPublic: {
        type: Boolean,
        //  default: false,
    },
    createdAt: {
        type: Date,
        required: true,
    },
    creator: {
        type: mongoose.Types.ObjectId,
        ref: 'User',
    },
    usersEnrolled: [
        {
            type: mongoose.Types.ObjectId,
            ref: 'User',
        }
    ],
}, {
    timestamps: true
});

courseSchema.method('getEnrolled', function () {
    return this.usersEnrolled.map(x => x.name).join(', ');
})

let Course = mongoose.model('Course', courseSchema);

module.exports = Course;