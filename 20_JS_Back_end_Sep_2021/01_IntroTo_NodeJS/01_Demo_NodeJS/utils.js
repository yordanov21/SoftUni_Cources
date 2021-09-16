function sum(a,b){
    return a+b;
}

console.log('In utils file execution')
sayHi();

function div(a,b){
    return a/b;
}



function sayHi(){
    console.log('Hi!');
}


// export sintax in common JS
// export object. This is a short sintax in JS of (calc: calc, div:div ....)
module.exports ={
    sum,
    div,
    sayHi
};

// export sintax if it is only one func
//module.exports = calc;


// //export  sintax in ES6 modules
// const utils = {
//     sum,
//     div,
//     sayHi
// }

// export default utils;