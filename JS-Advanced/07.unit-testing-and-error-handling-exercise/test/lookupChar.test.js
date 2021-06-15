const assert = require('chai').assert;
const lookupChar = require('../charLookUp');


describe('lookupChar tests', () => {
    it('Should return undefined when both parameters have incorrect type', () => {
        let strParam = 12;
        let index = 'str';
        let expetedResult = lookupChar(strParam, index);
        assert.equal(undefined, expetedResult);
    });

    it('Should return undefined when string parameter have incorrect type', () => {
        let strParam = 12;
        let index = 4;
        let expetedResult = lookupChar(strParam, index);
        assert.equal(undefined, expetedResult);
    });

    it('Should return undefined when index parameter have incorrect type', () => {
        let strParam = 'valid str';
        let index = 'str';
        let expetedResult = lookupChar(strParam, index);
        assert.equal(undefined, expetedResult);
    });

    it('Should return undefined when index parameter have incorrect type (floating point)', () => {
        let strParam = 'valid str';
        let index = 2.1;
        let expetedResult = lookupChar(strParam, index);
        assert.equal(undefined, expetedResult);
    });

    it('Should return incorect index when index is bigger than string length', () => {
        let strParam = 'valid str';
        let index = 15;
        let expetedResult = lookupChar(strParam, index);
        let actualResult = 'Incorrect index';
        assert.equal(actualResult, expetedResult);
    });
    it('Should return incorect index when index is less than string length', () => {
        let strParam = 'valid str';
        let index = -1;
        let expetedResult = lookupChar(strParam, index);
        let actualResult = 'Incorrect index';
        assert.equal(actualResult, expetedResult);
    });
    it('Should return incorect index when index is equal to string length', () => {
        let strParam = 'valid str';
        let index = 9;
        let expetedResult = lookupChar(strParam, index);
        let actualResult = 'Incorrect index';
        assert.equal(actualResult, expetedResult);
    });

    it('Should return valid result when parameters are correct', () => {
        let strParam = 'valid str';
        let index = 3;
        let expetedResult = lookupChar(strParam, index);
        let actualResult = 'i';
        assert.equal(actualResult, expetedResult);
    });


});