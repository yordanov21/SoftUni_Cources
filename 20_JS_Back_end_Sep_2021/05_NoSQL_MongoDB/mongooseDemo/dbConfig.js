const mongoose = require('mongoose');

const connectionString = 'mongodb://localhost:27017/testDB';

// 1. getting-started with promise
// mongoose.connect(connectionString)
//     .then(() =>{
//         console.log('Connected');
//     })
//     .catch(err => console.log(err));

// 2. getting-started with async func 
// main().catch(err => console.log(err));

// async function main() {
//     await mongoose.connect(connectionString);
//      console.log('Connected');
// } 


const initDb = () => mongoose.connect(connectionString);   

module.exports = initDb;