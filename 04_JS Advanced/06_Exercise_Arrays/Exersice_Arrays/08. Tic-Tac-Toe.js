function ticTacToe(input = []) {
    let matrix = [[false, false, false],
    [false, false, false],
    [false, false, false]];
    let moveCount = 1;

    for (const item of input) {

        let currentMove = item.split(' ');
        let row = +currentMove[0];
        let col = +currentMove[1];
        var checkerWiner = false;
        var lastMove = false;
        if (input.indexOf(item,input.length-1) == input.length - 1) {
            lastMove = true;
        }
        if (matrix[row][col] == false && moveCount % 2 != 0) {
            matrix[row][col] = 'X';
            moveCount++;
            checkForWiner('X');

            if (checkerWiner === true) {
                break;
            }
        } else if (matrix[row][col] == false && moveCount % 2 == 0) {
            matrix[row][col] = 'O';
            moveCount++;
            checkForWiner('O');
            if (checkerWiner === true) {
                break;
            }
        } else if (checkerWiner === false && lastMove === false && (matrix[row][col] == 'O' || matrix[row][col] == 'X')) {

            console.log("This place is already taken. Please choose another!");

        } else {

            console.log('The game ended! Nobody wins :(');
            matrix.forEach(item => {
                console.log(item.join('\t'))
            });

        }
    }

    function checkForWiner(player) {

        if ((matrix[0][0] === player && matrix[0][1] === player && matrix[0][2] === player) ||
            (matrix[1][0] === player && matrix[1][1] === player && matrix[1][2] === player) ||
            (matrix[2][0] === player && matrix[2][1] === player && matrix[2][2] === player) ||
            (matrix[0][0] === player && matrix[1][0] === player && matrix[2][0] === player) ||
            (matrix[0][1] === player && matrix[1][1] === player && matrix[2][1] === player) ||
            (matrix[0][2] === player && matrix[1][2] === player && matrix[2][2] === player) ||
            (matrix[0][0] === player && matrix[1][1] === player && matrix[2][2] === player) ||
            (matrix[2][0] === player && matrix[1][1] === player && matrix[0][2] === player)) {

            checkerWiner = true;
            console.log(`Player ${player} wins!`);
            matrix.forEach(item => {
                console.log(item.join('\t'))
            });
        }
    }
}



// ticTacToe([
//     "0 1",
//     "0 0",
//     "0 2",
//     "2 0",
//     "1 0",
//     "1 1",
//     "1 2",
//     "2 2",
//     "2 1",
//     "0 0"]
// );

// ticTacToe([
//     "0 0",
//     "0 0",
//     "1 1",
//     "0 1",
//     "1 2",
//     "0 2",
//     "2 2",
//     "1 2",
//     "2 2",
//     "2 1"
// ]
// );


ticTacToe([
    "0 1",
    "0 0",
    "0 2",
    "2 0",
    "1 0",
    "1 2",
    "1 1",
    "2 1",
    "2 2",
    "0 0"
]
);