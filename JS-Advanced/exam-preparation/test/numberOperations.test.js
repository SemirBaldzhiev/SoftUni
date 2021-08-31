const assert = require('chai').assert;
const numberOperations = require('../numberOperations');

describe('num operations tests', () => {
    describe('pow tests', () => {
        it('pow should return correct result', () => {
            
            let actualResult = numberOperations.powNumber(2);
            let expectedResult = 4;
            assert.equal(actualResult, expectedResult);

        });
    });

    describe('checker tests', () => {
        it('checker should throw error if input is not a number', () => {

            assert.throws(() => numberOperations.numberChecker('invalid'), 'The input is not a number!');
        });

        it('if the number is less than 100 shoul return message' , () => {
            let expectedResult = 'The number is lower than 100!';
            let actualResult = numberOperations.numberChecker(20);
            assert.equal(actualResult, expectedResult);
        });

        it('if number is greater than 100 should return meaasge', () => {
            let expectedResult = 'The number is greater or equal to 100!';
            let actualResult = numberOperations.numberChecker(120);
            
            assert.equal(actualResult, expectedResult);
        });

        it('if number is equal to 100 should return meaasge', () => {
            let expectedResult = 'The number is greater or equal to 100!';
            let actualResult = numberOperations.numberChecker(100);
            
            assert.equal(expectedResult, actualResult);
        });

    });

    describe('sum array tests', () => {
        it('sum array should return valid result array', () =>{
            let firstArr = [1, 2, 3];
            let secondArr = [1, 2, 3, 4 ,5];

            let expectedResult = [2, 4, 6, 4, 5];
            let actualResult = numberOperations.sumArrays(firstArr, secondArr);

            assert.deepEqual(expectedResult, actualResult);
        });

        it('sum array should return valid result array length', () =>{
            let firstArr = [1, 2, 3];
            let secondArr = [1, 2, 3, 4 ,5];

            let expectedResult = [2, 4, 6, 4, 5];
            let actualResult = numberOperations.sumArrays(firstArr, secondArr);

            assert.equal(expectedResult.length, actualResult.length);
        });
    });
});