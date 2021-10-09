const initDb = require('./dbConfig');
const User = require('./models/User');

initDb();

User.deleteOne({name: 'Nikolinka'})
    .then(res =>{
        console.log('Deleted');
        console.log(res);
    });