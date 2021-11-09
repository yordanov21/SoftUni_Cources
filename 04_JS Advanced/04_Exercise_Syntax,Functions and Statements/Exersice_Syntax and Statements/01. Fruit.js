function solve(fruit, weight, price){

    return`I need $${(weight*price/1000).toFixed(2)} to buy ${(weight/1000).toFixed(2)} kilograms ${fruit}.`;
}

console.log( solve('orange',2500,1.80));
