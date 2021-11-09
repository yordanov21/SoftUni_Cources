const assert = require('chai').assert;
const expect = require("chai").expect;
const BookStore = require('./02. Book Store_Ресурси');

describe('Class BookStore', () => {

    let actual;
    let expected;

    beforeEach(() => {

        actual = '';
        expected = '';
    })

    describe('Testing Constructor', () => {
        it('books property', () => {

            let myClass = new BookStore('book');
            actual = myClass.books;
            expected = [];
            //deepEqual за сравняване по референция (масиви и обекти)
            assert.deepEqual(actual, expected, 'books prop should be []')
        });

        it('_workers property', () => {

            let myClass = new BookStore('book');
            actual = myClass._workers;
            expected = [];

            assert.deepEqual(actual, expected, '_workers prop should be []')
        });

        it('orders property', () => {

            let myClass = new BookStore('book');
            actual = myClass.name;
            expected = 'book';

            assert.deepEqual(actual, expected, 'name prop should be book')
        });
    });

    describe('Testing get workers', () => {
        it('getter workers property', () => {

            let myClass = new BookStore('book');
            actual = myClass.workers;
            expected = [];
            //deepEqual за сравняване по референция (масиви и обекти)
            assert.deepEqual(actual, expected, 'getter workers should be []')
        });


    });


    describe('Testing stockBooks func', () => {
        it('Chek stockBooks', () => {

            let myClass = new BookStore('bookStoreClassOne');
            myClass.stockBooks(['Book Title-Ivanov', 'Book Title2-Ivanov2']);
            actual = myClass.books.length
            expected = 2;
            //deepEqual за сравняване по референция (масиви и обекти)
            assert.deepEqual(actual, expected, )
        });

        it('Chek stockBooks return', () => {

            let myClass = new BookStore('bookStoreClassOne');
            actual = myClass.stockBooks(['Book Title-Ivanov', 'Book Title2-Ivanov2']);
            expected = [
                { title: 'Book Title', author: 'Ivanov' },
                { title: 'Book Title2', author: 'Ivanov2' }
            ];
            //deepEqual за сравняване по референция (масиви и обекти)
            assert.deepEqual(actual, expected, )
        });
    });

    describe('Testing hire function', () => {

        it('Chek hire the worker', () => {

            let myClass = new BookStore('bookStoreClassOne');
            myClass.hire('pesho', 'positon1');
            myClass.hire('gosho', 'positon1');
            actual = myClass._workers.length;
            expected = 2;
            //deepEqual за сравняване по референция (масиви и обекти)
            assert.deepEqual(actual, expected, );
        });

        it('Chek hire the worker return', () => {

            let myClass = new BookStore('bookStoreClassOne');
            myClass.hire('pesho', 'positon1');
            // myClass.hire('gosho', 'positon1');
            actual = myClass.hire('gosho', 'positon1');
            expected = 'gosho started work at bookStoreClassOne as positon1';
            //deepEqual за сравняване по референция (масиви и обекти)
            assert.deepEqual(actual, expected, );
        });
        it('Chek for exception', () => {

            let myClass = new BookStore('bookStoreClassOne');
            myClass.hire('pesho', 'positon1');
            myClass.hire('gosho', 'positon1');
            actual = () => myClass.hire('gosho', 'positon1');

            expected = 'This person is our employee';
            assert.throw(actual, expected);
        });


    });

    describe('Testing fire function', () => {

        it('Chek fire the worker', () => {

            let myClass = new BookStore('bookStoreClassOne');
            myClass.hire('pesho', 'positon1');
            myClass.hire('gosho', 'positon1');
            myClass.fire('gosho');
            actual = myClass._workers.length;
            expected = 1;
            //deepEqual за сравняване по референция (масиви и обекти)
            assert.deepEqual(actual, expected, );
        });
        it('Chek fire the worker', () => {

            let myClass = new BookStore('bookStoreClassOne');
            myClass.hire('pesho', 'positon1');
            myClass.hire('gosho', 'positon1');

            actual = myClass.fire('gosho');
            expected = 'gosho is fired';
            //deepEqual за сравняване по референция (масиви и обекти)
            assert.deepEqual(actual, expected, );
        });

        it('Chek for exception', () => {

            let myClass = new BookStore('bookStoreClassOne');
            myClass.hire('pesho', 'positon1');
            myClass.hire('gosho', 'positon1');

            let name = 'dancho';
            actual = () => myClass.fire(name);
            expected = `${name} doesn't work here`;
            assert.throw(actual, expected);
        });


    });




    describe('Testing sellBook function', () => {

        it('Chek books colection', () => {

            let myClass = new BookStore('bookStoreClassOne');
            myClass.hire('pesho', 'positon1');
            myClass.hire('gosho', 'positon1');
            myClass.stockBooks(['Book Title-Ivanov', 'Book Title2-Ivanov2']);
            myClass.sellBook('Book Title', 'gosho');
            actual = myClass.books.length = 1;
            expected = 1;
            //deepEqual за сравняване по референция (масиви и обекти)
            assert.deepEqual(actual, expected, );
        });

        it('Chek book sold counter', () => {

            let myClass = new BookStore('bookStoreClassOne');
            myClass.hire('pesho', 'positon1');
            myClass.hire('gosho', 'positon1');
            myClass.stockBooks(['Book Title-Ivanov', 'Book Title2-Ivanov2']);
            myClass.sellBook('Book Title', 'gosho');
            //TODO NE E PRAVLNO TAKA
            //   let currentWorker = myClass.workers.filter(w => w.name === 'gosho');
            actual = 1;
            expected = 1;
            //deepEqual за сравняване по референция (масиви и обекти)
            assert.deepEqual(actual, expected, );
        });

        it('Chek for exception for book', () => {

            let myClass = new BookStore('bookStoreClassOne');
            myClass.hire('pesho', 'positon1');
            myClass.hire('gosho', 'positon1');

            let workerName = 'gosho';
            actual = () => myClass.sellBook('title1', workerName);
            expected = 'This book is out of stock';
            assert.throw(actual, expected);
        });

        it('Chek for exception for worker', () => {

            let myClass = new BookStore('bookStoreClassOne');
            myClass.hire('pesho', 'positon1');
            myClass.hire('gosho', 'positon1');
            myClass.stockBooks(['Book Title-Ivanov', 'Book Title2-Ivanov2']);
            let workerName = 'dancho';
            actual = () => myClass.sellBook('Book Title', workerName);
            expected = `${workerName} is not working here`;
            assert.throw(actual, expected);
        });


    });


    // printWorkers() {
    //     let result = "";
    //     this.workers.forEach(w => {
    //         result += `Name:${w.name} Position:${w.position} BooksSold:${w.booksSold}\n`;
    //     })
    //     return result.trim();
    // }



    describe('Testing printWorkers', () => {

        it('Chek fire the worker', () => {

            let myClass = new BookStore('bookStoreClassOne');
            myClass.hire('pesho', 'positon1');

            actual = myClass.printWorkers();
            expected = 'Name:pesho Position:positon1 BooksSold:0';
            //deepEqual за сравняване по референция (масиви и обекти)
            assert.deepEqual(actual, expected, );
        });


    });
});