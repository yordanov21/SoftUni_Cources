function sumNumbers(stringNum1, stringNum2) {

    //let num1=Number(stringNum1);
    // let num2=Number(stringNum2);
    let num1 = +stringNum1; //short way of writing when string must be parce to number (+string)
    let num2 = +stringNum2;

    let sum=0;
    for (i = num1; i <= num2; i++) {

        sum += i;
    }

    console.log(sum);
}

sumNumbers('-8', '20');
sumNumbers('1','5');