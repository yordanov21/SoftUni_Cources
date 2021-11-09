let sum = require('./demo');
let assert = require('chai').assert; //взимаме си assert-a oт библиотеката chai
let expect = require('chai').expect; //същото;

describe('sum() behavior', () => {
    it('check the result', () => {
        let result = sum(5, 37);

        assert.equal(result, 42, 'The result should be 42');
    })

    // it('check the result', ()=>{
    //     let result=sum(5,10);

    //     assert.equal(result,42,'The result should be 42');
    // })

    it('check the result', () => {
        let result = sum(5, 10);

        expect(result).to.be.eql(15, 'The result should be 15');
        expect(result).to.equal(15, 'The result should be 15');
    })
})