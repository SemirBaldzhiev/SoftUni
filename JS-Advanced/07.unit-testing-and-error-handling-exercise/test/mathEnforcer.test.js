const assert = require('chai').assert;
const mathEnforcer = require('../04.mathEnforcer');

describe('mathEnforce tests', () => {
    describe('addFive tests', () => {
        it('Add five should return undefined when parameter is from incorrect type', () => {
            let expectedResult = mathEnforcer.addFive('invalid');
            assert.equal(undefined, expectedResult);
        });

        it('Add five should return result when parameter is correct', () => {
            let expectedResult = mathEnforcer.addFive(5);
            assert.equal(10, expectedResult);
        });

        it('Add five should return result when parameter is correct and negative number', () => {
            let expectedResult = mathEnforcer.addFive(-5);
            assert.equal(0, expectedResult);
        });
        it('Add five should return result when parameter is correct and floating point number', () => {
            let expectedResult = mathEnforcer.addFive(2.5);
            assert.closeTo(7.5, expectedResult, 0.01);
        });
    });

    describe('subtractTen tests', () => {
        it('subtractTen should return undefined when parameter is from incorrect type', () => {
            let expectedResult = mathEnforcer.subtractTen('invalid');
            assert.equal(undefined, expectedResult);
        });

        it('subtractTen should return result when parameter is correct', () => {
            let expectedResult = mathEnforcer.subtractTen(15);
            assert.equal(5, expectedResult);
        });
        it('subtractTen should return result when parameter is correct and negative number', () => {
            let expectedResult = mathEnforcer.subtractTen(-5);
            assert.equal(-15, expectedResult);
        });
        it('subtractTen should return result when parameter is correct and floating point number', () => {
            let expectedResult = mathEnforcer.subtractTen(2.5);
            assert.closeTo(-7.5, expectedResult, 0.01);
        });
    });

    describe('sum tests', () => {
        it('sum should return undefined when both parameters is from incorrect type', () => {
            let expectedResult = mathEnforcer.sum('invalid', 'invalid');
            assert.equal(undefined, expectedResult);
        });

        it('sum should return undefined when first parameter is from incorrect type', () => {
            let expectedResult = mathEnforcer.sum(4, 'invalid');
            assert.equal(undefined, expectedResult);
        });

        it('sum should return undefined when second parameter is from incorrect type', () => {
            let expectedResult = mathEnforcer.sum('invalid', 4);
            assert.equal(undefined, expectedResult);
        });

        it('sum should return result when parameter is correct', () => {
            let expectedResult = mathEnforcer.sum(15, 5);
            assert.equal(20, expectedResult);
        });
        it('subtractTen should return result when parameter is correct and negative number', () => {
            let expectedResult = mathEnforcer.sum(-5, -3);
            assert.equal(-8, expectedResult);
        });
        it('subtractTen should return result when parameter is correct and floating point number', () => {
            let expectedResult = mathEnforcer.sum(2.5, 3.1);
            assert.closeTo(5.6, expectedResult, 0.01);
        });
    });

})
