function catalog(data) {
    let parsedData = data.reduce((acc, productLine) => {
        let [name,model, valueCar] = productLine.split(' | ').map(x => x.trim())

        if (acc[name]) {
            acc[name] = [...acc[name], productLine]
        } else {
            acc[name] = [productLine]
        }

        return acc;
    }, {})

    Object.keys(parsedData).map(x => {
        console.log(x)
        parsedData[x].map(product => {
            console.log(`###${product.split(' | ').slice(1).join(' -> ')}`);
        })
    });

}

catalog([
    'Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10'
]
);

catalog([
' Mercedes-Benz | 50PS | 123',
'Mini | Clubman | 20000',
'Mini | Convertible | 1000',
'Mercedes-Benz | 60PS | 3000',
'Hyunday | Elantra GT | 20000',
'Mini | Countryman | 100',
'Mercedes-Benz | W210 | 100',
'Mini | Clubman | 1000',
'Mercedes-Benz | W163 | 200'
])