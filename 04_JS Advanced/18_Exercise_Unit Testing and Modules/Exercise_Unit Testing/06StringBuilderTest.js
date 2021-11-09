let StringBuilder = require('./06StringBuilder');
let assert = require('chai').assert;
const expect = require('chai').expect;

describe('StringBuilder class behavior', () => {

    let actualResult;
    let expectedResult;

    beforeEach(() => {
        actualResult = null;
        expectedResult = null;
    })

    describe('Constructor behavior', () => {
        //test 1
        it('Testing without params', () => {
            actualResult = new StringBuilder()._stringArray;// достъпване пропъртито, защото то ни трябва.
            expectedResult = [];
            assert.deepEqual(actualResult, expectedResult, 'The expected result should be []')
        });
        //test 2
        it('Testing with params', () => {
            actualResult = new StringBuilder('mama')._stringArray;// достъпване пропъртито, защото то ни трябва.
            expectedResult = ['m', 'a', 'm', 'a'];
            assert.deepEqual(actualResult, expectedResult, 'The expected result should be [m,a,m,a]')
        });

        //горната проверка написана по различен начин
        it('Test withh string', function () {
            let myObj = new StringBuilder('str');
            expect(myObj).to.have.property('_stringArray').with.lengthOf(3);
        });
    })

    describe('append() behavior', () => {
        //test 3
        it('Testing append string', () => {
            actualResult = new StringBuilder('mama');
            actualResult.append('mama');
            actualResult = actualResult._stringArray;
            expectedResult = ['m', 'a', 'm', 'a', 'm', 'a', 'm', 'a'];
            assert.deepEqual(actualResult, expectedResult, 'The expected result should be [m,a,m,a,m,a,m,a]')
        });

         //test 9 (проверява за грешка при извикването на методите на класа), за Judge достатъчно е да се напише проверката за един метод
         it('Testing append with invalid data(aray)', () => {
            let sb = new StringBuilder('mama');
            actualResult = () => sb.append([]);
            expectedResult = 'Argument must be string';
            assert.throw(actualResult, expectedResult)
        });
    })

    describe('prepend() behavior', () => {
        //test 4
        it('Testing prepend string', () => {
            actualResult = new StringBuilder('mama');
            actualResult.prepend('mama');
            actualResult = actualResult._stringArray;
            expectedResult = ['m', 'a', 'm', 'a', 'm', 'a', 'm', 'a'];
            assert.deepEqual(actualResult, expectedResult, 'The expected result should be [m,a,m,a,m,a,m,a]')
        });

        //test 9 (проверява за грешка при извикването на методите на класа)
        it('Testing prepend with invalid data(aray)', () => {
            let sb = new StringBuilder('mama');
            actualResult = () => sb.prepend([]);
            expectedResult = 'Argument must be string';
            assert.throw(actualResult, expectedResult)
        });
    })
    //test 5
    describe('insertAt() behavior', () => {

        it('Testing InsertAr string', () => {
            actualResult = new StringBuilder('mama');
            actualResult.insertAt('FF', 2);
            actualResult = actualResult._stringArray;
            expectedResult = ['m', 'a', 'F', 'F', 'm', 'a'];
            assert.deepEqual(actualResult, expectedResult, 'The expected result should be [m,a,F,F,m,a]')
        });
        
    })
    //test 6
    describe('remove() behavior', () => {

        it('Testing InsertAr string', () => {
            actualResult = new StringBuilder('mama');
            actualResult.remove(1, 2);
            actualResult = actualResult._stringArray;
            expectedResult = ['m', 'a'];
            assert.deepEqual(actualResult, expectedResult, 'The expected result should be [m,a]')
        });
    })
    //test 7 i 8
    describe('toString() behavior', () => {

        it('Testing toString', () => {
            let sb = new StringBuilder('mama');
            actualResult = sb.toString()
            expectedResult = 'mama';
            assert.deepEqual(actualResult, expectedResult, 'The expected result should be [m,a]')
        });
    })

    //Judje ne go proverqva
    describe('static _vrfyParam() behavior', () => {

        it('Testing _vrfyParam() different of string', () => {
            actualResult = () => new StringBuilder(true) //когато очакваме да хвърли грешка го записваме като функция
            expectedResult = 'Argument must be string';
            assert.throw(actualResult, expectedResult)
        });

        it('Testing _vrfyParam() different of string', () => {
            actualResult = () => new StringBuilder(96) //когато очакваме да хвърли грешка го записваме като функция
            expectedResult = 'Argument must be string';
            assert.throw(actualResult, expectedResult)
        });

        //горната проверка написана по различен начин
        it('Test with wrong parameter', function () {
            expect(() => new StringBuilder(1)).to.Throw('Argument must be string');
        });

    })

    describe('Type of StringBuilder', function () {
        // it('StringBuilder exist', function () {
        //     expect(StringBuilder).to.exist
        // });

        // it('StringBuilder type', function () {
        //     expect(typeof StringBuilder).to.equal('function');
        // });


        //test 10
        it('should have the correct function properties', () => {
            assert.isFunction(StringBuilder.prototype.append);
            assert.isFunction(StringBuilder.prototype.prepend);
            assert.isFunction(StringBuilder.prototype.insertAt);
            assert.isFunction(StringBuilder.prototype.remove);
            assert.isFunction(StringBuilder.prototype.toString);
        });

        // it('full test', function () {
        //     let str = new StringBuilder('hello');
        //     str.append(', there');
        //     str.prepend('User, ');
        //     str.insertAt('woop', 5);
        //     str.remove(6, 3);
        //     expect(str.toString()).to.equal('User,w hello, there');
        // });
    });
})