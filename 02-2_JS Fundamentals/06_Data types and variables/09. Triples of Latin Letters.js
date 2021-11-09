function solve(num) {

    for (i = 0; i < num; i++) {

        for (j = 0; j < num; j++) {

            for (k = 0; k < num; k++) {

                let letters = String.fromCharCode(97 + i) + String.fromCharCode(97 + j) + String.fromCharCode(97 + k);

                console.log(letters);
            }
        }
    }
}

solve(3)