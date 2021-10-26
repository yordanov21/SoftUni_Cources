const Trip = require('../models/Trip');

const User = require('../models/User');

exports.getOne = (tripId) => Trip.findById(tripId).populate('buddies');

exports.getAll = () => Trip.find().lean();

exports.create = (tripData) => Trip.create(tripData);