let ChristmasMovies = require('./02. Christmas Movies_Resources');
let assert = require('chai').assert;

describe("ChristmasMovies class behavior", function () {

    let actualResult;
    let expectedResult;

    beforeEach(() => {
        actualResult = null;
        expectedResult = null;
    })

    describe("Constructor behavior", function () {

        it("Testing create allObject", function () {
            actualResult = new ChristmasMovies();
            let actualResult1 = actualResult.movieCollection;
            let actualResult2 = actualResult.watched;
            let actualResult3 = actualResult.actors;
            expectedResult = {
                movieCollection: [],
                watched: {},
                actors: []
            };

            assert.deepEqual(actualResult, expectedResult)
        });
        it("Testing create movingCollection Array[]", function () {
            actualResult = new ChristmasMovies();
            let actualResult1 = actualResult.movieCollection;
            let actualResult2 = actualResult.watched;
            let actualResult3 = actualResult.actors;
            expectedResult = [];

            assert.deepEqual(actualResult1, expectedResult)
        });
        it("Testing create wathed object{}", function () {
            actualResult = new ChristmasMovies();
            let actualResult1 = actualResult.movieCollection;
            let actualResult2 = actualResult.watched;
            let actualResult3 = actualResult.actors;
            expectedResult = {};

            assert.deepEqual(actualResult2, expectedResult)
        });

        it("Testing create actors Array[]", function () {
            actualResult = new ChristmasMovies();
            let actualResult1 = actualResult.movieCollection;
            let actualResult2 = actualResult.watched;
            let actualResult3 = actualResult.actors;
            expectedResult = [];

            assert.deepEqual(actualResult3, expectedResult)
        });
    });


    describe("buyMovie behavior", function () {
        //test 1
        it("Testing buying Movie with movie not in the collection", function () {
            let movies = new ChristmasMovies();
            let movieName = 'Movie1';
            let output = ['actor1', 'actor2'];
            actualResult = movies.buyMovie(movieName, output);

            expectedResult = `You just got ${movieName} to your collection in which ${output.join(', ')} are taking part!`;

            assert.deepEqual(actualResult, expectedResult, 'method should return: You just got ${movieName} to your collection in which ${output.join(', ')} are taking part!')
        });
        //test 3
        it("Testing buying Movie whit movie in the collection", function () {
            let movies = new ChristmasMovies();
            let movieName = 'Movie1';
            let output = ['actor1', 'actor2'];
            actualResult = movies.buyMovie(movieName, output);
            actualResult = () => movies.buyMovie(movieName, output);

            expectedResult = `You already own ${movieName} in your collection!`;

            assert.throw(actualResult, expectedResult, `method should return: You already own ${movieName} in your collection!`)
        });
    });


    // discardMovie(movieName) {
    //     let filtered = this.movieCollection.filter(x => x.name === movieName)

    //     if (filtered.length === 0) {
    //         throw new Error(`${movieName} is not at your collection!`);
    //     }
    //     let index = this.movieCollection.findIndex(m => m.name === movieName);
    //     this.movieCollection.splice(index, 1);
    //     let { name, _ } = filtered[0];
    //     if (this.watched.hasOwnProperty(name)) {
    //         delete this.watched[name];
    //         return `You just threw away ${name}!`;
    //     } else {
    //         throw new Error(`${movieName} is not watched!`);
    //     }

    // }
    describe("discardMovie behavior", function () {
        //test ..
        it("Testing describe movie that is not in the collection", function () {
            let movies = new ChristmasMovies();
            let movieName = 'Movie1';
            actualResult = () => movies.discardMovie(movieName);
            expectedResult = `${movieName} is not at your collection!`;
            assert.throw(actualResult, expectedResult, `method should return: ${movieName} is not at your collection!`)
        });
        //test ..
        it("Testing buying Movie whit movie in the collection", function () {
            let movies = new ChristmasMovies();
            let movieName = 'Movie1';
            let output = ['actor1', 'actor2'];
            actualResult = movies.buyMovie(movieName, output);
            actualResult = () => movies.buyMovie(movieName, output);

            expectedResult = `You already own ${movieName} in your collection!`;

            assert.throw(actualResult, expectedResult, `method should return: You already own ${movieName} in your collection!`)
        });
    });
});
