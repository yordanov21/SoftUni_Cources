const assert = require('chai').assert;
const expect = require("chai").expect;
const PizzUni = require('./02. PizzUni');

describe('Class PizzUni', () => {

    let actual;
    let expected;

    beforeEach(() => {

        actual = '';
        expected = '';
    })

    describe('Testing Constructor', () => {
        it('registeredUsers property', () => {

            let myClass = new PizzUni();
            actual = myClass.registeredUsers;
            expected = [];

            assert.deepEqual(actual, expected, 'registeredUser prop should be []')
        });

        it('availableProducts property', () => {

            let myClass = new PizzUni();
            actual = myClass.availableProducts;
            expected = {
                pizzas: ['Italian Style', 'Barbeque Classic', 'Classic Margherita'],
                drinks: ['Coca-Cola', 'Fanta', 'Water']
            };

            assert.deepEqual(actual, expected, 'availableProducts prop should be object{}')
        });

        it('orders property', () => {

            let myClass = new PizzUni();
            actual = myClass.orders;
            expected = [];

            assert.deepEqual(actual, expected, 'orders prop should be []')
        });
    });

    describe('Testing registerUser(email)', () => {
        it('Check register user with already registered email', () => {

            let myClass = new PizzUni();
            myClass.registerUser('someEmail');
            actual = () => myClass.registerUser('someEmail');
            expected = `This email address (someEmail) is already being used!`;

            assert.throw(actual, expected);
        });
        it('Check registeredUsers length check', () => {

            let myClass = new PizzUni();
            myClass.registerUser('someEmail');
            actual = myClass.registeredUsers.length;
            expected = 1

            assert.deepEqual(actual, expected, 'the result should be 1')
        });

        //judge не го проверява
        it('Check registerUser(email) return value', () => {

            let myClass = new PizzUni();
            actual = myClass.registerUser('someEmail');
            expected = {
                email: "someEmail",
                orderHistory: []
            }

            assert.deepEqual(actual, expected, 'the result should return corect object')
        });
    });

    describe('Testing makeAnOrder(email, orderedPizza, orderedDrink)', () => {
        it('make order with invalid email', () => {

            let myClass = new PizzUni();

            actual = () => myClass.makeAnOrder('someEmail', 'peperoni', 'Coke');
            expected = `You must be registered to make orders!`;

            assert.throw(actual, expected);
        });
        it('make order with invalid pizzatype', () => {

            let myClass = new PizzUni();
            myClass.registerUser('someEmail');
            actual = () => myClass.makeAnOrder('someEmail', 'peperoni', 'Coke');

            expected = 'You must order at least 1 Pizza to finish the order.';

            assert.throw(actual, expected);
        });
        it('make order with valid data', () => {
            let myClass = new PizzUni();
            myClass.registerUser('someEmail');
            myClass.makeAnOrder('someEmail', 'Classic Margherita', 'Water');
            actual = myClass.registeredUsers[0].orderHistory;
            expected = [{
                orderedPizza: 'Classic Margherita',
                orderedDrink: 'Water',
            }]

            assert.deepEqual(actual, expected)
        });

        it('orders array check', () => {
            let myClass = new PizzUni();
            myClass.registerUser('someEmail');
            myClass.makeAnOrder('someEmail', 'Classic Margherita', 'Water');
            actual = myClass.orders;
            expected = [{
                orderedPizza: 'Classic Margherita',
                orderedDrink: 'Water',
                email: 'someEmail',
                status: 'pending'
            }]

            assert.deepEqual(actual, expected)
        });
        it('orders array check2', () => {
            let myClass = new PizzUni();
            myClass.registerUser('someEmail');

            actual = myClass.makeAnOrder('someEmail', 'Classic Margherita', 'Water');
            expected = 0;

            assert.equal(actual, expected)
        });

        it('detailsAboutMyOrder(id) orderscheck', () => {
            let myClass = new PizzUni();
            myClass.registerUser('someEmail');
            myClass.registerUser('someEmail2');

            myClass.makeAnOrder('someEmail', 'Classic Margherita', 'Water');
            myClass.makeAnOrder('someEmail2', 'Classic Margherita', 'Water');
            actual = myClass.detailsAboutMyOrder(1);

            expected = `Status of your order: pending`;

            assert.deepEqual(actual, expected)
        });
    });

    describe('Testing completeOrder()', () => {


        it('completeOrder() status check', () => {
            let myClass = new PizzUni();
            myClass.registerUser('someEmail');
            myClass.registerUser('someEmail2');

            myClass.makeAnOrder('someEmail', 'Classic Margherita', 'Water');
            myClass.makeAnOrder('someEmail2', 'Classic Margherita', 'Water');
            myClass.completeOrder();
            actual = myClass.orders[0].status

            expected = 'completed'

            assert.equal(actual, expected, 'should be completed')
        });
        it('completeOrder() return check', () => {
            let myClass = new PizzUni();
            myClass.registerUser('someEmail');
            myClass.registerUser('someEmail2');

            myClass.makeAnOrder('someEmail', 'Classic Margherita', 'Water');
            myClass.makeAnOrder('someEmail2', 'Classic Margherita', 'Water');
            actual = myClass.completeOrder();


            expected = {
                orderedPizza: 'Classic Margherita',
                orderedDrink: 'Water',
                email: 'someEmail',
                status: 'completed'
            }
            assert.deepEqual(actual, expected, 'should be completed')
        });
    });

    describe('Testing doesTheUserExist(email)', () => {

        it('Test functionality with existing user', () => {
            let myClass = new PizzUni();
            myClass.registerUser("email1")

            actual = myClass.doesTheUserExist("email1");
            expected = myClass.registeredUsers[0];

            assert.deepInclude(actual, expected)
        });
    });

})