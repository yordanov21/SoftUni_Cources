function solve(elements) {
    let arr=elements;
let sumElements=arr.reduce((a, b) => a + b);

let inverseSum = 0;
arr.forEach(function(item){
    inverseSum += 1/Number(item);
});

let concatArr=arr.reduce((a, b) => a + b, '');

console.log(sumElements);
console.log(inverseSum);
console.log(concatArr);
}

solve([1,2,3]);
solve([2,4,8,16]);
solve([3]);