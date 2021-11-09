function solve(num) {
    let sum = 0;
    let lastLlement = num % 10;
    let sameNumber=true;
    while (num != 0) {

        let element = num % 10;
        sum += element
        num =parseInt (num / 10);
        if (lastLlement == element) {

            sameNumber=true;
        } else{

            sameNumber=false;
        }
    }

    console.log(sameNumber);
    console.log(sum); 
}

solve(2222222);
solve(1234);