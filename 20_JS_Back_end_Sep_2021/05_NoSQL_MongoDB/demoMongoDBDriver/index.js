const mongodb = require('mongodb');

const client = new mongodb.MongoClient('mongodb://localhost:27017');

// exaple with promise
client.connect()
.then(() =>{
    console.log('Connected');

    const db = client.db('testDB');
    const usersCollection = db.collection('users');
   
    return usersCollection.find({}).toArray()
       
})
.then(data => {
    console.log(data);
});