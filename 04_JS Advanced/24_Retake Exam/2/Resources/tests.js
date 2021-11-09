const assert = require('chai').assert;
const expect = require("chai").expect;
let { Repository } = require("./solution.js");

describe("Tests …", function() {


    let actual;
    let expected;
    let repository;

    let properties = {
        name: "string",
        age: "number",
        birthday: "object"
    };
    //Initialize the repository


    beforeEach(() => {

        actual = '';
        expected = '';
        repository = new Repository(properties);
    })

    describe('Testing Constructor', () => {
        it('props property', () => {


            actual = repository.props;
            expected = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            //deepEqual за сравняване по референция (масиви и обекти)
            assert.deepEqual(actual, expected, )
        });

        it('data property', () => {


            actual = repository.data
            expected = new Map();

            assert.deepEqual(actual, expected, 'prop should be object{}')
        });

        it('id property', () => {

            actual = repository.nextId();

            expected = 0;

            assert.deepEqual(actual, expected)
        });
    });


    describe('Testing getter Count', () => {
        it('getter count', () => {

            actual = repository.count;
            expected = 0;

            assert.deepEqual(actual, expected, )
        });
        it('getter count 1', () => {
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };

            repository.add(entity);
            actual = repository.count;
            expected = 1;

            assert.deepEqual(actual, expected, )
        });
    });

    describe('Testing add func', () => {
        it('add function', () => {
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };

            actual = repository.add(entity);
            expected = 0;

            assert.deepEqual(actual, expected, )
        });

    });


    describe('Testing getId func', () => {
        it('getId function', () => {
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repository.add(entity);
            actual = repository.getId(0);
            expected = { name: 'Pesho', age: 22, birthday: new Date(1998, 0, 7) };

            assert.deepEqual(actual, expected, )
        });

        it('getId function error', () => {


            actual = () => repository.getId(0);
            expected = `Entity with id: 0 does not exist!`;
            assert.throw(actual, expected);
        });
    });


    describe('Testing update func', () => {
        it('update function', () => {
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };

            repository.add(entity);
            repository.add(entity);
            entity = {
                name: 'Gosho',
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repository.update(1, entity);
            actual = repository.getId(1)
            expected = { name: 'Gosho', age: 22, birthday: new Date(1998, 0, 7) };

            assert.deepEqual(actual, expected, 'no')
        });

        it('update function error', () => {

            actual = () => repository.getId(0);
            expected = `Entity with id: 0 does not exist!`;
            assert.throw(actual, expected);
        });


    });


    describe('Testing del func', () => {
        it('del function', () => {
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repository.add(entity);
            repository.add(entity);
            repository.del(0);
            actual = repository.count;
            expected = 1;

            assert.deepEqual(actual, expected, )
        });

        it('del function', () => {
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repository.add(entity);
            repository.add(entity);
            repository.add(entity);
            repository.add(entity);
            repository.del(0);
            repository.del(1)
            actual = repository.count;
            expected = 2;

            assert.deepEqual(actual, expected, )
        });

        it('del function error', () => {
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repository.add(entity);
            repository.add(entity);
            repository.add(entity);
            actual = () => repository.getId(5);
            expected = `Entity with id: 5 does not exist!`;
            assert.throw(actual, expected);
        });
    });


    describe('Testing _validate', () => {
        it('_validate function add err2', () => {
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repository.add(entity);
            entity = {

                name: "Pesho",
                age: 22,
                birthday: 1998
            };
            actual = () => repository.add(entity);
            expected = `Property birthday is not of correct type!`;
            assert.throw(actual, expected);
        });

        it('_validate function add err2', () => {
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repository.add(entity);
            entity = {

                name: 22,
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            actual = () => repository.add(entity);
            expected = `Property name is not of correct type!`;
            assert.throw(actual, expected);
        });


        it('_validate function add err2', () => {
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repository.add(entity);
            entity = {

                name: 'Pesho',
                age: '',
                birthday: new Date(1998, 0, 7)
            };
            actual = () => repository.add(entity);
            expected = `Property age is not of correct type!`;
            assert.throw(actual, expected);
        });
        it('_validate function add err1', () => {
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repository.add(entity);
            let anotherEntity = {
                name1: 'Stamat',
                age: 29,
                birthday: new Date(1991, 0, 21)
            };
            actual = () => repository.add(anotherEntity);
            expected = 'Property name is missing from the entity!';
            assert.throw(actual, expected);
        });

        it('_validate function add err5', () => {
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repository.add(entity);
            let anotherEntity = {
                name: 'Stamat',
                age2: 29,
                birthday: new Date(1991, 0, 21)
            };
            actual = () => repository.add(anotherEntity);
            expected = 'Property age is missing from the entity!';
            assert.throw(actual, expected);
        });
        it('_validate function add err5', () => {
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repository.add(entity);
            let anotherEntity = {
                name: 'Stamat',
                age: 29,
                birthday2: new Date(1991, 0, 21)
            };
            actual = () => repository.add(anotherEntity);
            expected = 'Property birthday is missing from the entity!';
            assert.throw(actual, expected);
        });
        it('_validate function update for type', () => {
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };

            repository.add(entity);
            repository.add(entity);
            let anotherEntity = {
                name: 'Stamat',
                age: 29,
                birthday: 1990
            };
            repository.update(1, entity);

            actual = () => repository.update(0, anotherEntity);
            expected = `Property birthday is not of correct type!`;
            assert.throw(actual, expected);
        });

        it('_validate function update for entyti', () => {
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };

            repository.add(entity);
            repository.add(entity);
            let anotherEntity = {
                name1: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repository.update(1, entity);

            actual = () => repository.update(0, anotherEntity);
            expected = 'Property name is missing from the entity!';
            assert.throw(actual, expected);
        });
        it('_validate function update for entyti', () => {
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };

            repository.add(entity);
            repository.add(entity);
            let anotherEntity = {
                name: "Pesho",
                age2: 22,
                birthday: new Date(1998, 0, 7)
            };
            repository.update(1, entity);

            actual = () => repository.update(0, anotherEntity);
            expected = 'Property age is missing from the entity!';
            assert.throw(actual, expected);
        });
        it('_validate function update for entyti', () => {
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };

            repository.add(entity);
            repository.add(entity);
            let anotherEntity = {
                name: "Pesho",
                age: 22,
                birthday2: new Date(1998, 0, 7)
            };
            repository.update(1, entity);

            actual = () => repository.update(0, anotherEntity);
            expected = 'Property birthday is missing from the entity!';
            assert.throw(actual, expected);
        });
    });

});