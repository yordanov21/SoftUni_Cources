const mongoose = require('mongoose');

const userSchema = new mongoose.Schema({
    name: String,
    age: Number,
    grade: {
        type: Number,
        require: false,
        min: [2, 'Grade cannot be lower than 2'],
        max: [6, 'Grade cannot be bigger than 6, you got {VALUE}']
    },

    pet: {
        type: mongoose.Schema.Types.ObjectId,
        ref: 'Pet',
    }

});


// methods 
userSchema.methods.greet = function() {
    return `Hello I am a ${this.name} and I am ${this.age} years old.`
}

// virtual properties
userSchema.virtual('isUnder30').get(function() {
        return this.age < 30;
});

userSchema.virtual('fullInfo').get(function () {
    return this.name + ' age:' + this.age + ' grade:' + this.grade;
});

// validation property, not very often used. It will return error when create a user.
// Better way is use built-in validators of mongoose like min and max validators for Numbers, minLength and maxLength for string. Enims, regexs.
userSchema.path('name')
  .validate(function () {
   	return this.name.length >= 2 
	&& this.name.length <= 15
}, 'Name must be between 2 and 15 symbols long!');




const User = mongoose.model('User', userSchema);

module.exports = User;