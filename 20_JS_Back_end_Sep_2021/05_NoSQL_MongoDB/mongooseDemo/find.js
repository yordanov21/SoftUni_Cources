const initDb = require('./dbConfig');
const User = require('./models/User');

initDb();

// 1. with promise
// User.find()
//     .then(users =>{
//         console.log(users);
//     });

// 2. with async func
async function  getUsers() {
    let users = await User.find();

    //console.log(users);

    users.forEach(x => console.log(x.greet()));
}

//getUsers();



async function  getUsersUnder30() {
    let users = await User.find();

    //console.log(users);

    users.forEach(x => console.log(x.isUnder30));
}

getUsersUnder30();

async function  getFullInfo() {
    let users = await User.find();

    //console.log(users);

    users.forEach(x => console.log(x.fullInfo));
}

getFullInfo();