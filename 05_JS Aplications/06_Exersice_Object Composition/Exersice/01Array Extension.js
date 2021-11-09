//IIFE: трябва да работим с IIFE  за тази задача
// (()=>{

// })();

(() => {
    Array.prototype.last = function() {
        //  console.log(this);//this-a е самия масив в случая
        return this[this.length - 1];
    };
    Array.prototype.skip = function(n) {
        return this.slice(n);
    };
    Array.prototype.take = function(n) {
        return this.slice(0, n);
    };
    Array.prototype.sum = function() {
        return this.reduce((a, b) => a + b);
    };
    Array.prototype.average = function() {
        return this.sum() / this.length;
    };

    // let array = [1, 2, 5, 58, 100, 20];
    // console.log(array.last());
    // console.log(array.skip(2));
    // console.log(array.take(3));
    // console.log(array.sum());
    // console.log(array.average());
    // var testArray = [1, 2, 3];
    // console.log(testArray.take(2));
})();