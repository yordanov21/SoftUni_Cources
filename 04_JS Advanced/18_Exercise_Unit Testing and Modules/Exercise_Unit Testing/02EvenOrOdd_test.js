let isOddOrEven = require('./02EvenOrOdd'); //задължително require-ме откъде взимаме функцията за теста;

let assert = require('chai').assert; //взимаме си assert-a oт библиотеката chai

describe('isOddOrEven() behavior', () => {

    it("check the type of the input - Boolen case", () => {

        let result = isOddOrEven(false);

        assert.equal(result, undefined, 'The result is not undefined')
    });

    it("check the type of the input - Number case", () => {

        let result = isOddOrEven(5);

        assert.equal(result, undefined, 'The result is not undefined')
    });

    it("check the type of the input - even case", () => {
        let result = isOddOrEven('mama')
        assert.equal(result, 'even', "The result should be even in this case")
    });

    it("check the type of the input - odd case", () => {
        let result = isOddOrEven('mamam')
        assert.equal(result, 'odd', "The result should be odd in this case")
    });
    // it("", () => {

    // });

});