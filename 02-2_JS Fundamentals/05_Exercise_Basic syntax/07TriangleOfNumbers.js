function solve(number) {

    for (let i = 1; i <= number; i++) {
        let outputNumbers = "";
        for (let j = 1; j <= i; j++) {

            outputNumbers += `${i} `
        }

        console.log(outputNumbers);
    }
}

solve(5);