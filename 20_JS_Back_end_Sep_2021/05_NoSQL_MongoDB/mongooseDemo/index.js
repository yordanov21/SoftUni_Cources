const initDb = require('./dbConfig');
const User = require('./models/User');
const Pet = require('./models/Pet');

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
        // User.create({
        //     name: 'Ivancho',
        //     age: 31,
        //     grade: 6.50,
        // })
        //     .then(user =>{
        //         console.log('User created:');
        //         console.log(user);
        //     });


        Pet.create({
            name: 'Jerry',
            species: 'Cat',
        })
            .then( cat =>{
               let user = new User({
                     name: 'Dancho',
                     age: 31,
                     grade: 5.5,
                })

                user.pet =cat;
                return user.save();
            }) 
            .then(res =>{
                console.log('User created:');
                console.log(res);
            });
    });
