const initDb = require('./dbConfig');
const User = require('./models/User');

initDb();

User.updateOne({name: 'Gragancho'}, {$set: {name: 'Gragancho2', age: 25, grade: 5}})
    .then(res =>{
        console.log('Updated');
        console.log(res);
    });