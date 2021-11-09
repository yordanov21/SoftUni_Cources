function biggestElement(input) {
    let matrix = input.map(row => row.map(Number));
    let biggestNum = Number.NEGATIVE_INFINITY;

    matrix.forEach(r => r.forEach( c => biggestNum = Math.max(biggestNum, c)));
    console.log(   biggestNum);
  
}

biggestElement([[20, 50, 10],[8, 33, 145]]);