let lookupChar = require('./03CharLookup');
let assert = require('chai').assert;

describe('lokupChar() behavior', () => {

    it('Testing first argument - Number type', () => {
        let result = lookupChar(5, 5);
        assert.equal(result, undefined, 'The result should be undefined')
    });

    it('Testing second argument -Integer type', () => {
        let result = lookupChar('test', '5');
        assert.equal(result, undefined, 'The result should be undefined')
    });

    it('Testing second argument lenght- Number type', () => {
        let result = lookupChar('test', 2.5);
        assert.equal(result, undefined, 'The result should be undefined')
    });
    //ne e zadulvitelna
    // it('Testing second argument lenght- Number type', () => {
    //     let result = lookupChar('test', {});
    //     assert.equal(result, undefined, 'The result should be undefined')
    // });

    it('Testing first argument - length of first argument is less than index', () => {
        let result = lookupChar('test', 5);
        assert.equal(result, "Incorrect index", 'The result should be :Incorrect index')
    });

    it('Testing second argument - index ', () => {
        let result = lookupChar('test', -1);
        assert.equal(result, "Incorrect index", 'The result should be :Incorrect index')
    });

    it('Testing char index with valid data', () => {
        let result = lookupChar('testingChar', 5);
        assert.equal(result, "n", 'The result should be :"n"')
    });

});