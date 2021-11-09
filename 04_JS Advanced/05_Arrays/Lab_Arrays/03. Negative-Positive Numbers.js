function numbers(arr){

    arr = arr.map(Number);
    let result = [];

    for(let element of arr) {
        if(element < 0) {
            result.unshift(element);
        } else {
            result.push(element);
        }
    }
return result.forEach(el=>console.log(el));

}

console.log(numbers([7,-2,8,9]));
console.log(numbers([-1,-2,3,0]));
