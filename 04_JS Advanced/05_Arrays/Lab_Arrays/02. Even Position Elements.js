
function evenPosition(inputArr){
    // let result = [];
    // for (let i = 0; i < inputArr.length; i++) { 

    //     if (i % 2 == 0) { 
    //          result.push(inputArr[i])
    //     } 
    // }
    // let resultOutput=result.join(" ");
    // return resultOutput;
    return inputArr.filter((num,index)=>index%2==0).join(' ');
}

console.log(evenPosition(['20', '30', '40']));