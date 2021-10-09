//import export syntax ES6 
//import mongoose from 'mongoose';

const mongoose = require('mongoose');

function initDatabase(connectionString){
    return mongoose.connect(connectionString);
};

module.exports = initDatabase;