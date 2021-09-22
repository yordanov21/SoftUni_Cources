// Events is core module in node.js
const events = require('events');

// evventEmitter is actualy an eventBus
let eventEmitter = new events.EventEmitter();

eventEmitter.on('customEvent', (first, second) => {
    console.log('First: ', first);
    console.log('Second: ', second);
})

eventEmitter.emit('customEvent', 'Pesho', 'Gosho')


eventEmitter.on('click', (a, b) => {
    console.log('A click has been detected!');
    console.log(a + ' ' + b + '!!!'); // outputs 'Hello world'
});

eventEmitter.emit('click', 'Hello', 'world');