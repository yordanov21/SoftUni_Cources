const assert = require('chai').assert;
const expect = require("chai").expect;
let SkiResort = require('./solution');

describe('SkiResort', function() {

    let actual;
    let expected;
    let skiResort
    beforeEach(() => {
        skiResort = new SkiResort("Bansko");
        actual = '';
        expected = '';
    })

    // constructor(name) {
    //     this.name = name;
    //     this.voters = 0;
    //     this.hotels = [];
    // }
    describe('Testing Constructor', () => {
        it('name value', () => {
            actual = skiResort.name;
            expected = 'Bansko';
            //deepEqual за сравняване по референция (масиви и обекти)
            assert.deepEqual(actual, expected, 'should be bansko')
        });

        it('voters property', () => {
            actual = skiResort.voters;
            expected = 0;
            //deepEqual за сравняване по референция (масиви и обекти)
            assert.deepEqual(actual, expected, 'should be 0')
        });

        it('hotels property', () => {
            actual = skiResort.hotels;
            expected = [];
            //deepEqual за сравняване по референция (масиви и обекти)
            assert.deepEqual(actual, expected, 'should be []')
        });
    });

    describe('Test get bestHotel()', () => {
        it('Test no voters', () => {
            actual = skiResort.bestHotel;
            expected = "No votes yet";
            assert.deepEqual(actual, expected);
        });

        it('Test functionality', () => {
            skiResort.build("Test1", 5);
            skiResort.build("Test1", 6);
            skiResort.leave("Test1", 5, 12);
            skiResort.leave("Test1", 5, 13);
            const result = skiResort.bestHotel;
            expect(result).to.equal("Best hotel is Test1 with grade 125. Available beds: 15");
        });
    });

    describe('Test build() method', () => {
        it('Test error', () => {
            const result = () => skiResort.build("", 0);
            expect(result).to.throw(Error, `Invalid input`);
        });

        it('Test functionality', () => {
            const result = skiResort.build("Test1", 5);

            expect(skiResort.hotels.length).to.equal(1);
            expect(skiResort.hotels[0]).to.deep.equal({
                name: "Test1",
                beds: 5,
                points: 0
            });
            expect(result).to.equal(`Successfully built new hotel - Test1`);
        });
    });

    describe('Test book() method', () => {
        it('Test error', () => {
            const result = () => skiResort.book("", 0);
            expect(result).to.throw(Error, `Invalid input`);
        });

        it('Test invalid hotel error', () => {
            const result = () => skiResort.book("Test1", 5);
            expect(result).to.throw(Error, "There is no such hotel");
        });

        it('Test invalid beds count error', () => {
            skiResort.build("Test1", 5);
            const result = () => skiResort.book("Test1", 6);
            expect(result).to.throw(Error, "There is no free space");
        });

        it('Test functionality', () => {
            skiResort.build("Test1", 5);
            const result = skiResort.book("Test1", 4);
            expect(skiResort.hotels[0].beds).to.equal(1);
            expect(result).to.equal("Successfully booked");
        });
    });

    describe('Test leave() method', () => {
        it('Test error', () => {
            const result = () => skiResort.leave("", 0, 12);
            expect(result).to.throw(Error, "Invalid input");
        });

        it('Test invalid hotel error', () => {
            const result = () => skiResort.leave("Test1", 5, 12);
            expect(result).to.throw(Error, "There is no such hotel");
        });

        it('Test functionality', () => {
            skiResort.build("Test1", 5);
            const result = skiResort.leave("Test1", 5, 12);

            expect(result).to.equal(`5 people left Test1 hotel`);
            expect(skiResort.voters).to.equal(5);
            expect(skiResort.hotels[0].beds).to.equal(10);
            expect(skiResort.hotels[0].points).to.equal(60);
        });
    });

    describe('Test averageGrade() method', () => {
        it('Test empty voters', () => {
            const result = skiResort.averageGrade();
            expect(result).to.equal("No votes yet");
        });

        it('Test functionality', () => {
            skiResort.build("Test1", 5);
            skiResort.leave("Test1", 5, 12);
            const result = skiResort.averageGrade();
            expect(result).to.equal("Average grade: 12.00");
        });
    });
});