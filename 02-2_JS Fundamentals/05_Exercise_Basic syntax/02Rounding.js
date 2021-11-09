function rounding(number, precision) {

    if (precision > 15) {
        precision = 15;
    }

    let output = parseFloat(number.toFixed(precision));  //toFixed - rounding, parseFloat-remove trailing zeroes

    console.log(output);
}

rounding(3.1224566325655565665, 2);
rounding(3.120000, 3);