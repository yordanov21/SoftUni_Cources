const Trip = require('../models/Trip');

const User = require('../models/User');

exports.getOne = (tripId) => Trip.findById(tripId).populate('buddies');

exports.getLastAddedTrip = () => Trip.findOne().sort({ createdAt: -1 });

exports.getAll = () => Trip.find().lean();

exports.create = (tripData) => Trip.create(tripData);

exports.addTripToTripHistory = async (userId, tripId) => {

    // let user = await User.findById(userId).populate('tripHistory');
    // console.log(user);
    // user.tripHistory.push(tripId);
    // return await user.updateOne();

    return User.findByIdAndUpdate(
        { _id: userId },
        {
            $push: { tripHistory: tripId }
        });
};