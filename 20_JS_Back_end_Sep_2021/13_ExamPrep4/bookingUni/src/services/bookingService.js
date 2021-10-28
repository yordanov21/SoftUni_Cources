const Hotel = require('../models/Hotel');

const User = require('../models/User');


exports.create = (bookingData) => Hotel.create(bookingData);

exports.getOne = (bookingId) => Hotel.findById(bookingId).populate('usersBookedRoom');

exports.getAll = () => Hotel.find().lean();

exports.getAllByFreeRooms = () => Hotel.find().sort({ freeRooms: -1 }).lean(); // dont forget the lean() to the end :), when return objects form the mongoose

exports.getLastAddedHotel = () => Hotel.findOne().sort({ createdAt: -1 });

// add user to hotel 
exports.addUserToBookedRoom = async (bookingId, userId) => {
    let booking = await Hotel.findById(bookingId).populate('usersBookedRoom');
    booking.usersBookedRoom.push(userId);
    booking.freeRooms--;
    return booking.save();
};

// add enrolled coures to user
exports.bookedHotels = async (bookingId, userId) => {
    // let user = await User.findById(userId).populate('enrolledCourses');
    // console.log(user);
    // user.enrolledCourses.push(courseId);
    // return user.updateOne();

    return User.findOneAndUpdate(
        { _id: userId },
        {
            $push: { bookedHotels: bookingId }
        });
};

exports.delete = (bookingId) => Hotel.findByIdAndDelete(bookingId);

exports.updateOne = (bookingId, bookingData) => Hotel.findByIdAndUpdate(bookingId, bookingData);

// exports.search = (searchText) => Housing.find({ type: { $regex: searchText, $options: 'i' } }).lean();


exports.addHotelToOfferedHotels = async (userId, bookingId) => {

    return User.findByIdAndUpdate(
        { _id: userId },
        {
            $push: { offeredHotels: bookingId }
        });
};