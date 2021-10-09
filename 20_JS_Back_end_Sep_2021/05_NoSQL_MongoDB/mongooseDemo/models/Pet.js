const mongoose = require('mongoose');

const petSchema = new mongoose.Schema({
    name:{
        type: String,
        require: true,
        maxlength: 10,
    },
    species: {
        type: String,
        require: true,
    }
});


let Pet = mongoose.model('Pet', petSchema);


module.exports = Pet;