function magicMatrices(matrix) {

    let isMagic = true;
    let sum = matrix[0].reduce((a, b) => a + b);

    for (let row = 0; row < matrix.length; row++) {
        let rowSum = matrix[row].reduce((a, b) => a + b, 0);  //по дефолт му давам 0(може и без нулата)

        if (sum !== rowSum) {
            isMagic = false;
            break;
        }

        let colSum = 0
        for (let col = 0; col < matrix.length; col++) {
           
            colSum += matrix[col][row];
        }

        if (sum !== colSum) {
            isMagic = false;
            break;
        }
    }

    console.log(isMagic);
}

magicMatrices([[4, 5, 6],
[6, 5, 4],
[5, 5, 5]]
);

magicMatrices([[11, 32, 45],
[21, 0, 1],
[21, 1, 1]]
);

magicMatrices([[1, 0, 0],
[0, 0, 1],
[0, 1, 0]]
);

magicMatrices([
    [5, 0, 0],
    [0, 5, 0],
    [0, 0, 5]]
);


magicMatrices([
    [1, 0, 0],
    [0, 0, 1]
]
);