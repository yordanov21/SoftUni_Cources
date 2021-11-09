let Parser = require("./solution.js");
let assert = require("chai").assert;

describe("MyTests for Parser class", () => {

    let actual;
    let expected;

    beforeEach(() => {

        actual = '';
        expected = '';
    })

    describe('Testing constructor', () => {
        it('check _data ', () => {

            let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
            actual = parser._data;
            ;
            expected = [{ "Nancy": "architect" }, { "John": "developer" }, { "Kate": "HR" }];

            assert.deepEqual(actual, expected, 'build the _data')
        })
        it('check _log ', () => {

            let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
            actual = parser._log;
            ;
            expected = [];

            assert.deepEqual(actual, expected, 'build the _log')
        })
        it('check _addToLog ', () => {

            let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
            actual = parser._addToLog.length;
            expected = 1;
            assert.deepEqual(actual, expected, 'build the _addToLog')
        })
    })


    describe('Testing get data()', () => {
        it('check get data()', () => {
            let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
            parser.addEntries("Steven:tech-support Edd:administrator");
            actual = parser.data;

            expected = [
                { Nancy: 'architect' },
                { John: 'developer' },
                { Kate: 'HR' },
                { Steven: 'tech-support' },
                { Edd: 'administrator' }
            ]
                ;
            assert.deepEqual(actual, expected, 'build the _addToLog')
        })
    })


    describe('Testing print()', () => {
        it('check print()', () => {
            let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
            actual = parser.print();

            //id|name|position
            // 0 | Nancy | architect
            // 1 | John | developer
            // 2 | Kate | HR
            expected = 'id|name|position\n0|Nancy|architect\n1|John|developer\n2|Kate|HR';
            assert.equal(actual, expected, 'print()shuld work correctly')
        })
    })


    describe('Testing addEntries(entries)', () => {
        it('check addEntries(entries)', () => {
            let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
            actual = parser.addEntries("Steven:tech-support Edd:administrator");

            expected = "Entries added!";
            assert.equal(actual, expected, 'print()shuld work correctly')
        })
    })

    describe('Testing removeEntry(key) ', () => {
        it('check with valid data', () => {
            let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
            parser.addEntries("Steven:tech-support Edd:administrator");

            actual = parser.removeEntry('Kate')
            expected = "Removed correctly!"
            assert.equal(actual, expected, 'print()shuld work correctly')
        })
        it('check with NOvalid data', () => {
            let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
            parser.addEntries("Steven:tech-support Edd:administrator");

            actual =()=> parser.removeEntry('Kateaaa')
            expected = "There is no such entry!"
            assert.throw(actual, expected, )
        })
    })

    // _addToLogInitial() {
    //     let counter = 0;
    //     return function (command) {
    //         this._log.push(`${counter++}: ${command}`)
    //         return "Added to log";
    //     }
    // }

    // describe('Testing _addToLogInitial()', () => {
    //     it('check _addToLogInitial()', () => {
    //         let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
    //         actual = parser._addToLogInitial;

    //         expected = parser._addToLogInitial;
    //         assert.equal(actual, expected, 'print()shuld work correctly')
    //     })
    // })
});