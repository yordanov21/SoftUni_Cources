const Hotel = require('../models/Hotel');

const User = require('../models/User');


exports.create = (bookingData) => Hotel.create(bookingData);

exports.getOne = (bookingId) => Hotel.findById(bookingId).populate('usersBookedRoom');

exports.getAll = () => Hotel.find().lean();

// exports.getAllPublic = () => Course.find({ isPublic: true }).lean(); // dont forget the lean() to the end :), when return objects form the mongoose

// // add user to coures 
// exports.addUserEnrolled = async (courseId, userId) => {
//     let course = await Course.findById(courseId).populate('usersEnrolled');
//     course.usersEnrolled.push(userId);
//     return course.save();
// };

// // add enrolled coures to user
// exports.enrolledCourse = async (courseId, userId) => {
//     // let user = await User.findById(userId).populate('enrolledCourses');
//     // console.log(user);
//     // user.enrolledCourses.push(courseId);
//     // return user.updateOne();

//     return User.findOneAndUpdate(
//         { _id: userId },
//         {
//             $push: { enrolledCourses: courseId }
//         });
// };

exports.delete = (bookingId) => Hotel.findByIdAndDelete(bookingId);

exports.updateOne = (bookingId, bookingData) => Hotel.findByIdAndUpdate(bookingId, bookingData);

// exports.search = (searchText) => Housing.find({ type: { $regex: searchText, $options: 'i' } }).lean();