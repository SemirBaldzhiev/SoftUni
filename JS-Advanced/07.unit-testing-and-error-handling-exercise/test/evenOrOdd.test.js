const assert = require('chai').assert;
const isOddOrEven = require('../02.evenOrOdd');

describe('tests', () => {
    it('ShouldReturnUndefinedWhenInputIsNotString', () => {
        let actualResult = isOddOrEven(2);
        assert.equal(actualResult, undefined);
    });

    it('ShouldReturnEvenWhenInputIsString', () => {
        let actualResult = isOddOrEven('asda');
        assert.equal(actualResult, 'even');
    });

    it('ShouldReturnOddWhenInputIsString', () => {
        let actualResult = isOddOrEven('asd');
        assert.equal(actualResult, 'odd');
    })
})
    
