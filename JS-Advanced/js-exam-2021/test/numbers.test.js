const testNumbers = require('../numbers');
const assert = require('chai').assert;

describe("numbers tests …", () => {
    describe("sumNumbers", () => {
        it("Should return undefined if parameters typeis incorect", () => {
            assert.equal(testNumbers.sumNumbers('invalid', 1), undefined);
            assert.equal(testNumbers.sumNumbers(1, 'invalid'), undefined);
            assert.equal(testNumbers.sumNumbers('invalid', 'invalid'), undefined);
        });
        it("Should return sum of the numbers", () => {
            assert.equal(testNumbers.sumNumbers(2, 1), 3);
            assert.equal(testNumbers.sumNumbers(1.4, 3.2), 4.6);
            assert.equal(testNumbers.sumNumbers(1.23, 1.431), 2.66);
        });

     });

     describe('numberChecker', () => {
         it('should throw if NAN', () => {
            assert.throw(() => testNumbers.numberChecker('invalid'));
         });

         it('should return even if number is even', () => {
            assert.equal(testNumbers.numberChecker(4), 'The number is even!');
            assert.equal(testNumbers.numberChecker(6), 'The number is even!');
         });

         it('should return odd if number is odd', () => {
            assert.equal(testNumbers.numberChecker(5), 'The number is odd!');
            assert.equal(testNumbers.numberChecker(7), 'The number is odd!');
         });
     });

     describe('averageSumArray', () => {
        it('should return average', () => {
           
            let arr = [1, 2, 3, 4, 5];
            let arr2 = [1, 2, 3, 4];

            let expected2  = 10 / arr2.length;
            assert.equal(testNumbers.averageSumArray(arr), 3);
            assert.equal(testNumbers.averageSumArray(arr2), expected2);

        });
    });
     
});
