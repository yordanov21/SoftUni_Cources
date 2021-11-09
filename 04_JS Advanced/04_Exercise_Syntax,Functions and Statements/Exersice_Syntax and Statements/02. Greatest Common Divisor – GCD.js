function GreatestCommonDivisor(num1, num2){

    if(num1%9==0&& num2%9==0){

        console.log('9');
    } else if(num1%8==0&& num2%8==0){

        console.log('8');
    } else if(num1%7==0&& num2%7==0){

        console.log('7');
    }else if(num1%6==0&& num2%6==0){

        console.log('6');
    }else if(num1%5==0&& num2%5==0){

        console.log('5');
    }else if(num1%4==0&& num2%4==0){

        console.log('4');
    }else if(num1%3==0&& num2%3==0){

        console.log('3');
    }else if(num1%2==0&& num2%2==0){

        console.log('2');
    }else if(num1%1==0&& num2%1==0){

        console.log('1');
    }
}

GreatestCommonDivisor(2154,458);