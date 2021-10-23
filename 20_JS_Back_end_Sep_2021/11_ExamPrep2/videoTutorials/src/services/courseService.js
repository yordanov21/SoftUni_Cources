const Course = require('../models/Course');


exports.create = (courseData) => Course.create(courseData);

exports.getOne = (courseId) => Course.findById(courseId).populate('usersEnrolled');

exports.getAll = () => Course.find().lean();

exports.getAllPublic = () => Course.find({ isPublic: true }).lean(); // dont forget the lean() to the end :), when return objects form the mongoose


exports.addUserEnrolled = async (courseId, userId) => {
    let course = await Course.findById(courseId).populate('usersEnrolled');
    course.usersEnrolled.push(userId);
    return course.save();
};

exports.delete = (courseId) => Course.findByIdAndDelete(courseId);

exports.updateOne = (courseId, courseData) => Course.findByIdAndUpdate(courseId, courseData);

exports.search = (searchText) => Housing.find({ type: { $regex: searchText, $options: 'i' } }).lean();