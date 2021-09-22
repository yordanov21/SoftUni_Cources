const eventBus = require('./eventBus');

const subscribe = require('./subscriber');
const publich = require('./publicher');

// unsubscribe
let unsubscribe = eventBus.subscribe('areYouIn', function(town) {
    console.log(`Yes, I am in ${town}`);
})

// invoke one more time 'areYouThere'
eventBus.publish('areYouThere', 'Varna');


eventBus.subscribe('areYouIn', function(town) {
    console.log(`Yes, I am in ${town}`);
});

// other subscriber and publicher
eventBus.subscribe('howAreYou', function() {
    console.log('I am fine');
})
eventBus.publish('howAreYou');

// other subscriber and publicher with many parames
eventBus.subscribe('fullInfo', function(name, age, town, seasson) {
    console.log(`My name is ${name} on ${age} years from ${town}. My favorite seasson is ${seasson}`);
})
eventBus.publish('fullInfo', 'Nansy', 21, 'London', 'spring');


// test for unsuscribe
eventBus.publish('areYouIn', 'Berlin');
eventBus.publish('areYouIn', 'Madrid');
unsubscribe();
eventBus.publish('areYouIn', 'Paris');