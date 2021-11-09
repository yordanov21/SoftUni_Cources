function juiceFactory(data) {

    let pardedData = data.reduce((juiceAcc, juiceKVP) => {
        let [juiceName, quantity] = juiceKVP.split(' => ');

        if (juiceAcc.currentJuiceQuantity[juiceName]) {
            juiceAcc.currentJuiceQuantity[juiceName] += +(quantity)
        } else {
            juiceAcc.currentJuiceQuantity[juiceName] = +quantity;
        }

        let bottleQ = Math.floor(juiceAcc.currentJuiceQuantity[juiceName] / 1000);
        if (bottleQ > 0 && !juiceAcc.competedJuices.includes(juiceName)) {
            juiceAcc.competedJuices.push(juiceName);
        }
        return juiceAcc;

    }, { competedJuices: [], currentJuiceQuantity: {} })

    pardedData.competedJuices.map(juice => {
        console.log(`${juice} => ${Math.floor(pardedData.currentJuiceQuantity[juice] / 1000)}`);
    })
}

console.log(juiceFactory(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']
));

juiceFactory(['Orange => 2000',
    'Peach => 1432',
    'Banana => 450',
    'Peach => 600',
    'Strawberry => 549']
);