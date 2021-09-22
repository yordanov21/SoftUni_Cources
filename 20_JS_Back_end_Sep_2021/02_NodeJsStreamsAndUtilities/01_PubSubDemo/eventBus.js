// subscribers are private
const subscribers = {};

function subscribe(eventType, callBack) {
    if (!subscribers[eventType]) {
        subscribers[eventType] = [];
    }

    subscribers[eventType].push(callBack);

    //unsubscribe 
    return function() {
        subscribers[eventType] = subscribers[eventType].filter(f => f != callBack);

    }
}

// publich/emit/trigger
function publish(eventType, ...params) {
    if (!subscribers[eventType]) {
        return;
    }

    // foreach function in the eventType of subscribers, execute eventType's functions
    subscribers[eventType].forEach(func => func.apply(null, params));
}

const eventBus = {
    subscribe,
    publish
};


module.exports = eventBus;