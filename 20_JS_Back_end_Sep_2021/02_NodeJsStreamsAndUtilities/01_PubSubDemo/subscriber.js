const eventBus = require('./eventBus.js')

eventBus.subscribe('areYouThere', function(town) {
    console.log(`Yes, I am in ${town}`);
})