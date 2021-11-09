let mathEnforcer = require('./04MathEnforcer');
let assert = require('chai').assert;

describe('mathEnforser{} behavior', () => {

    describe('object type chek', () => {

        it('Testing Object Type', () => {

            assert.isObject(mathEnforcer);
        })
    })
    describe('addFive function behavior', () => {

        it('Testing addFive() for typeof num', () => {
            let actualResult = mathEnforcer.addFive('five');
            let expectedResult = undefined;

            assert.equal(actualResult, expectedResult, 'The expected result should be undefined')
        });
        it('Testing addFive() with correctValue', () => {
            let actualResult = mathEnforcer.addFive(5);
            let expectedResult = 10;

            assert.equal(actualResult, expectedResult, 'The expected result should be 10')
        });
        it('Testing addFive() with correct negative Value', () => {
            let actualResult = mathEnforcer.addFive(-5);
            let expectedResult = 0;

            assert.equal(actualResult, expectedResult, 'The expected result should be 0')
        });
        it('Testing addFive() with correct decimal Value', () => {
            let actualResult = mathEnforcer.addFive(5.5);
            let expectedResult = 10.5;

            assert.equal(actualResult, expectedResult, 'The expected result should be 10.5')
        });
    })

    describe('subtractTen function behavior', () => {

        it('Testing subtractTen() for typeof num', () => {
            let actualResult = mathEnforcer.subtractTen('five');
            let expectedResult = undefined;

            assert.equal(actualResult, expectedResult, 'The expected result should be undefined')
        });
        it('Testing subtractTen() with correctValue', () => {
            let actualResult = mathEnforcer.subtractTen(15);
            let expectedResult = 5;

            assert.equal(actualResult, expectedResult, 'The expected result should be 5')
        });
        it('Testing subtractTen() with correct negative Value', () => {
            let actualResult = mathEnforcer.subtractTen(-15);
            let expectedResult = -25;

            assert.equal(actualResult, expectedResult, 'The expected result should be -25')
        });
        it('Testing subtractTen() with correct decimal Value', () => {
            let actualResult = mathEnforcer.subtractTen(15.5);
            let expectedResult = 5.5;

            assert.equal(actualResult, expectedResult, 'The expected result should be 5.5')
        });
    })

    describe('sum function behavior', () => {

        it('Testing sum() for typeof num1', () => {
            let actualResult = mathEnforcer.sum('five', 5);
            let expectedResult = undefined;

            assert.equal(actualResult, expectedResult, 'The expected result should be undefined')
        });
        it('Testing sum() for typeof num2', () => {
            let actualResult = mathEnforcer.sum(5, 'five');
            let expectedResult = undefined;

            assert.equal(actualResult, expectedResult, 'The expected result ishould be undefined')
        });
        it('Testing sum() for corect values', () => {
            let actualResult = mathEnforcer.sum(5, 5);
            let expectedResult = 10;

            assert.equal(actualResult, expectedResult, 'The expected result should be 10')
        });
        it('Testing sum() for corect negative values num1', () => {
            let actualResult = mathEnforcer.sum(-5, 5);
            let expectedResult = 0;

            assert.equal(actualResult, expectedResult, 'The expected result should be 0')
        });
        it('Testing sum() for corect negative values num2', () => {
            let actualResult = mathEnforcer.sum(5, -5);
            let expectedResult = 0;

            assert.equal(actualResult, expectedResult, 'The expected result should be 0')
        });
        it('Testing sum() for corect negative values num1 and num2', () => {
            let actualResult = mathEnforcer.sum(-5, -5);
            let expectedResult = -10;

            assert.equal(actualResult, expectedResult, 'The expected result should be -10')
        });
        it('Testing sum() for corect values num1(decimal) and num2', () => {
            let actualResult = mathEnforcer.sum(5.6, 2);
            let expectedResult = 7.6;

            assert.equal(actualResult, expectedResult, 'The expected result should be 7.6')
        });
        it('Testing sum() for corect values num1 and num2(decimal)', () => {
            let actualResult = mathEnforcer.sum(5, 2.6);
            let expectedResult = 7.6;

            assert.equal(actualResult, expectedResult, 'The expected result should be 7.6')
        });
    })

})