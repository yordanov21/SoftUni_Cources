function solve(arr) {
    let amountRotation = +arr.pop();
    amountRotation%=arr.length;
    // if (amountRotation > arr.length) {
    //     amountRotation = amountRotation % (arr.length);
    // }

    for (i = 1; i <= amountRotation; i++) {
        let currentElement = arr.pop();
        arr.unshift(currentElement);
    }

    console.log(arr.join(' '));
}

solve(['1',
    '2',
    '3',
    '4',
    '2']
);

solve(['Banana',
    'Orange',
    'Coconut',
    'Apple',
    '15']
);

