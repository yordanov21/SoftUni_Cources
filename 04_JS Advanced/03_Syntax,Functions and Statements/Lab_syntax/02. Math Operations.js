function mathOperation(num1,num2,operator){

    let result;
    switch (operator){

        case '+': result=num1+num2; break;
        case '-': result=num1-num2; break;
        case '*': result=num1*num2; break;
        case '/': result=num1/num2; break;
        case '%': result=num1%num2; break;
        case '**': result=num1**num2; break; //na stepen
    }

    console.log(result);
}

mathOperation(2,4,'**');