const initDb = require('./dbConfig');
const User = require('./models/User');

initDb()
    .then(() =>{
        // first way to create db record
        // let user  = new User({
        //     name: 'Penka',
        //     age: 29
        // });

        // user.save()
        //     .then(() => {
        //         console.log('User saved!');
        //     });

        // second way to create db record
        User.create({
            name: 'Ivancho',
            age: 31,
            grade: 6.50,
        })
            .then(user =>{
                console.log('User created:');
                console.log(user);
            });

    });
