const Trip = require('../models/Trip');

const User = require('../models/User');

exports.getOne = (tripId) => Trip.findById(tripId).populate('buddies');

exports.getLastAddedTrip = () => Trip.findOne().sort({ created_at: -1 });

exports.getAll = () => Trip.find().lean();

exports.create = (tripData) => Trip.create(tripData);

exports.addTripToTripHistory = (userId, tripId) => {
    return User.findByIdAndUpdate(
        { _id: userId },
        {
            $push: { tripHistory: tripId }
        });
};