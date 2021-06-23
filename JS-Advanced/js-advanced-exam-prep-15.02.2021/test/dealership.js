const dealership = require('../03.dealership');
const assert = require('chai').assert;

describe("dealership tests …", function() {
    describe("newCarCost tests", function() {

        it("should return pirce with discount if old car is in the list with discounts", function() {
            let carModel= 'Audi A4 B8';
            assert.equal(dealership.newCarCost(carModel, 20000), 5000);
        });

        it("should return old pirce if old car is not in the list with discounts", function() {
            let carModel= 'BMW';
            assert.equal(dealership.newCarCost(carModel, 20000), 20000);
        });
     });

     describe('carEquipment tests', () => {
         it('Should return extras length with the given indexes', () => {
            let extras = ['sport rims', 'navigation', 'gps', 'sliding roof'];
            let indexes = [0, 1, 3];

            assert.equal(dealership.carEquipment(extras, indexes).length, ['sport rims', 'navigation', 'sliding roof'].length);
         });

         it('Should return extras with the given indexes', () => {
            let extras = ['sport rims', 'navigation', 'gps', 'sliding roof'];
            let indexes = [0, 1, 3];

            assert.deepEqual(dealership.carEquipment(extras, indexes), ['sport rims', 'navigation', 'sliding roof']);
         });
     });

     describe('euroCategory tests', () => {
         it('should return price with discount if category is greater than 4', () => {
             let total  = 14250;
            assert.equal(dealership.euroCategory(5), `We have added 5% discount to the final price: ${total}.`)
         });

         it('should return price with discount if category is equal to 4', () => {
            let total  = 14250;
           assert.equal(dealership.euroCategory(4), `We have added 5% discount to the final price: ${total}.`)
        });
         it('should return price without discount if category is less than 4', () => {
           assert.equal(dealership.euroCategory(3), `Your euro category is low, so there is no discount from the final price!`)
        });

     })

     
});
