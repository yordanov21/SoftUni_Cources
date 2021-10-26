const Trip = require('../models/Trip');

const User = require('../models/User');


exports.create = (tripData) => Trip.create(tripData);