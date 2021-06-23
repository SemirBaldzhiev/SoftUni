const pizzUni = require('../03.pizzaPlace');
const assert = require('chai').assert;

describe("pizzUni tests", function() {
    describe("makeAnOrder tests", function() {
        it('Should throw error if order doesnt contains pizza', () =>   {
            let obj = { }
            assert.throws(() => pizzUni.makeAnOrder(obj), 'You must order at least 1 Pizza to finish the order.');
        });

        it('Should return result if order contains pizza only', () =>   {
            let obj = { 
                orderedPizza: 'Pizza'
            }
            assert.equal(pizzUni.makeAnOrder(obj), `You just ordered ${obj.orderedPizza}`);
        });

        it('Should return result if order contains pizza and drink', () =>   {
            let obj = { 
                orderedPizza: 'Pizza',
                orderedDrink: 'pepsi'
            }
            assert.equal(pizzUni.makeAnOrder(obj), `You just ordered ${obj.orderedPizza} and ${obj.orderedDrink}.`);
        });
     });

     describe('getRemainingWork tests', () => {
         it('Should return result with status preparing', () => {
            let arr = [{
                pizzaName: 'Pizza',
                status: 'preparing'
            },
            {
                pizzaName: 'Pizza2',
                status: 'preparing'
            },
            ];

            assert.equal(pizzUni.getRemainingWork(arr), 'The following pizzas are still preparing: Pizza, Pizza2.');
         });

         it('Should return result with status ready', () => {
            let arr = [{
                pizzaName: 'Pizza',
                status: 'ready'
            },
            {
                pizzaName: 'Pizza2',
                status: 'ready'
            },
            ];

            assert.equal(pizzUni.getRemainingWork(arr), 'All orders are complete!');
         });
     });

     describe('orderType tests', () => {
         it('should return price with discount if type is Carry Out', () => {
            assert.equal(pizzUni.orderType(10, 'Carry Out'), 9)
         });

         it('should return price without discount if type is Delivery', () => {
            assert.equal(pizzUni.orderType(10, 'Delivery'), 10)
         });
     });

     
});
