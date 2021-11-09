function processOddNumbers(arr) {
    arr = arr.map(Number);

    console.log(arr.filter((num, index) => index % 2 == 1).map(num => num * 2).reverse().join(" "));
}

console.log(processOddNumbers([10, 15, 20, 25]));
console.log(processOddNumbers([3, 0, 10, 4, 7, 3]));