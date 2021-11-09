function juiceFactory(data) {
    let parsedData = {};
    let juice = {};
    for (let i = 0; i < data.length; i++) {

        let tempParsedJuice = data[i].split(' => ');
        if (parsedData[tempParsedJuice[0]]) {

            parsedData[tempParsedJuice[0]] = parsedData[tempParsedJuice[0]] + Number(tempParsedJuice[1])
        } else {
            parsedData[tempParsedJuice[0]] = Number(tempParsedJuice[1])
        }

        let bottleQ = Math.floor(parsedData[tempParsedJuice[0]] / 1000);

        if (bottleQ > 0) {
            juice[tempParsedJuice[0]] = bottleQ
        }
    }
    // Тъпия начин с forIn!!!
    // for (const key in juice) {

    //     let result = `${key} => ${juice[key]}`;
    //     console.log(result);
    // }

    
    //по добрия подход:
    let finalParseData= Object.entries(juice)

    for(let i=0; i<finalParseData.length; i++){
        console.log(finalParseData[i].join(' => '));
    }
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

