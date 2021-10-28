const Course = require('../models/Course');

const User = require('../models/User');


exports.create = (courseData) => Course.create(courseData);

exports.getOne = (courseId) => Course.findById(courseId).populate('usersEnrolled');

exports.getAllPopulate = () => Course.find().populate('usersEnrolled').lean();

exports.getAll = () => Course.find().lean();

exports.getAllPublic = () => Course.find({ isPublic: true }).lean(); // dont forget the lean() to the end :), when return objects form the mongoose

// add user to coures 
exports.addUserEnrolled = async (courseId, userId) => {
    let course = await Course.findById(courseId).populate('usersEnrolled');
    course.usersEnrolled.push(userId);
    return course.save();
};

// add enrolled coures to user
exports.enrolledCourse = async (courseId, userId) => {
    // let user = await User.findById(userId).populate('enrolledCourses');
    // console.log(user);
    // user.enrolledCourses.push(courseId);
    // return user.updateOne();

    return User.findOneAndUpdate(
        { _id: userId },
        {
            $push: { enrolledCourses: courseId }
        });
};

exports.delete = (courseId) => Course.findByIdAndDelete(courseId);

exports.updateOne = (courseId, courseData) => Course.findByIdAndUpdate(courseId, courseData);

exports.search = (searchText) => Housing.find({ type: { $regex: searchText, $options: 'i' } }).lean();