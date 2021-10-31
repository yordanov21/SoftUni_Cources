const mongoose = require('mongoose');

let postSchema = new mongoose.Schema({
    title: {
        type: String,
        required: true,
        unique: true,
        minlength: 6,
    },
    keyword: {
        type: String,
        required: true,
        minlength: 6,
    },
    location: {
        type: String,
        required: true,
        maxlength: 10,
    },
    dateOfCreation: {
        type: String,
        required: true,
        validate: [/^\d{2}.\d{2}.\d{4}$/, 'Invalide data type.']
    },
    image: {
        type: String,
        required: true,
        validate: [/^https?:\/\//i, 'invalid image url']
    },
    description: {
        type: String,
        required: true,
        minlength: 8,
    },
    author: {
        type: mongoose.Types.ObjectId,
        ref: 'User',
    },
    votesOnPosts: [
        {
            type: mongoose.Types.ObjectId,
            ref: 'User',
        }
    ],
    ratingOfPost: {
        type: Number,
    }
}, {
    timestamps: true
});

postSchema.method('getUserVote', function () {
    return this.votesOnPosts.map(x => x.name).join(', ');
})

let Post = mongoose.model('Post', postSchema);

module.exports = Post;