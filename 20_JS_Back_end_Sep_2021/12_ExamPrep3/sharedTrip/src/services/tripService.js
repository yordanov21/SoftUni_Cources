const Trip = require('../models/Trip');

const User = require('../models/User');


exports.getAll = () => Trip.find().lean();

exports.create = (tripData) => Trip.create(tripData);