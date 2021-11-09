function solve(input) {

    let number = input[0];

    for (let i = 1; i < input.length; i++) {

        let operation = input[i];
        if (operation === 'chop') {
            number = number / 2;
            console.log(number);
        } else if (operation === 'dice') {
            number = Math.sqrt(number);
            console.log(number);
        } else if (operation === 'spice') {
            number++;
            console.log(number);
        } else if (operation === 'bake') {
            number = number * 3;
            console.log(number);
        } else if (operation === 'fillet') {
            number = number - number * 0.2;
            console.log(number);
        }

    }
}

solve(['32', 'chop', 'chop', 'chop', 'chop', 'chop']);
solve(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);