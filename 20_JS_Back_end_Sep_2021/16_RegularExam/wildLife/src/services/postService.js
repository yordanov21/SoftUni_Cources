const Post = require('../models/Post');

const User = require('../models/User');


exports.create = (postData) => Post.create(postData);

exports.getOne = (postId) => Post.findById(postId).populate('votesOnPosts').populate('author');

exports.getAllPopulate = () => Post.find().sort({ createdAt: 1 }).populate('votesOnPosts').lean();

exports.getLastAddedPost = () => Post.findOne().sort({ createdAt: -1 });

exports.getAll = () => Post.find().lean();


// add user to coures 
exports.findUserVotesOnPosts = async (postId, userId) => {
    let post = await Post.findById(postId).populate('votesOnPosts');

    let user = post.votesOnPosts.find(x => x._id == userId);

    return user;
};

exports.addVotesOnPosts = async (postId, userId) => {
    let post = await Post.findById(postId).populate('votesOnPosts');
    post.votesOnPosts.push(userId);
    return post.save();
};
exports.voteUp = async (postId) => {
    let post = await Post.findById(postId).populate('votesOnPosts');
    post.ratingOfPost++;
    return post.save();
};

exports.voteDown = async (postId) => {
    let post = await Post.findById(postId).populate('votesOnPosts');
    post.ratingOfPost--;
    return post.save();
};


// add post to user my =Post
exports.addToUserPosts = async (postId, userId) => {

    return User.findOneAndUpdate(
        { _id: userId },
        {
            $push: { myPosts: postId }
        });
};

exports.delete = (postId) => Post.findByIdAndDelete(postId);

exports.updateOne = (postId, postData) => Post.findByIdAndUpdate(postId, postData);
