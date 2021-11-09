function solve(carOrder) {

    let engines = {
        Small: { power: 90, volume: 1800 },
        Normal: { power: 120, volume: 2400 },
        Monster: { power: 200, volume: 3500 }
    }

    function getEngine() {
        if (carOrder.power <= 90) {
            return engines.Small;
        } else if (carOrder.power <= 120) {
            return engines.Normal;
        } else {
            return engines.Monster;
        }

    }

    function getWheels() {
        if (carOrder.wheelsize % 2 === 0) {
            return [carOrder.wheelsize - 1, carOrder.wheelsize - 1, carOrder.wheelsize - 1, carOrder.wheelsize - 1];
        } else {
            return [carOrder.wheelsize, carOrder.wheelsize, carOrder.wheelsize, carOrder.wheelsize];
        }
    }

    let outputOrder = {
        model: carOrder.model,
        engine: getEngine(),
        carriage: { type: carOrder.carriage, color: carOrder.color },
        //wheels: getWheels(),
        wheels: Array(4).fill(carOrder.wheelsize % 2 === 0 ? carOrder.wheelsize - 1 : carOrder.wheelsize)
    }

    return outputOrder;
};

console.log(solve({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}));

console.log(solve({
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
}));