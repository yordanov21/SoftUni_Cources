const mongoose = require('mongoose');
const { DB_CONNECTION_STRING } = require('../constants');

// Export syntax with anonim. func
exports.initDatabase = function () {
    return mongoose.connect(DB_CONNECTION_STRING);
}
