function calculateStringlength (firstString, secondString, thirdString){

    let firstStringLength=firstString.length;
    let secondStringLength=secondString.length;
    let thirdStringLength=thirdString.length;

    let sum=firstStringLength+ secondStringLength+ thirdStringLength;
    let avarageLength=Math.floor(sum/3);

    console.log(sum);
    console.log(avarageLength);
}

calculateStringlength('sdsfdfs','sdadads','2.032');