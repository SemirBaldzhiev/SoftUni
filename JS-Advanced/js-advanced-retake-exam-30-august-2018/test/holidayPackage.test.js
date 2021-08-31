const HolidayPackage = require('../02.holidayPackage');
const assert = require('chai').assert;



describe('HolidayPackage tests' ,() => {
    it('addVacationer should throw if parmeter is not string', () => {
        let holidayPackage = new HolidayPackage('Italy', 'Summer');
        
        assert.throw(() => holidayPackage.addVacationer(10));
    }); 

    it('addVacationer should throw if parmeter is white space', () => {
        let holidayPackage = new HolidayPackage('Italy', 'Summer');
        
        assert.throw(() => holidayPackage.addVacationer(' '));
    });

    it('addVacationer should throw if parmeter is empty', () => {
        let holidayPackage = new HolidayPackage('Italy', 'Summer');
        
        assert.throw(() => holidayPackage.addVacationer(''));
    });
    
    it('addVacationer should throw if parmeter is contains only one name', () => {
        let holidayPackage = new HolidayPackage('Italy', 'Summer');
        
        assert.throw(() => holidayPackage.addVacationer('Stamat'));
    });

    it('addVacationer should throw if parmeter is contains more than two names', () => {
        let holidayPackage = new HolidayPackage('Italy', 'Summer');
        
        assert.throw(() => holidayPackage.addVacationer('Stamat dadd dasd'));
    });

    it('addVacationer should add vacationer with the given name', () => {
        let holidayPackage = new HolidayPackage('Italy', 'Summer');
        holidayPackage.addVacationer('Stamat Stamatov');
        
        assert.equal(holidayPackage.vacationers.length, 1);
    });

    it('showVacationers should return all Vacationers if list with Vacationers in not empty', () => {
        let holidayPackage = new HolidayPackage('Italy', 'Summer');
        holidayPackage.addVacationer('Stamat Stamatov');
        assert.equal(holidayPackage.showVacationers(), `Vacationers:\n${holidayPackage.vacationers.join("\n")}`)
    });

    it('showVacationers should return message if Vacationers list is empty', () => {
        let holidayPackage = new HolidayPackage('Italy', 'Summer');

        assert.equal(holidayPackage.showVacationers(), 'No vacationers are added yet');
    });

    it('generateHolidayPackage should throw if vacationers are less than 1', () => {
        let holidayPackage = new HolidayPackage('Italy', 'Summer');
        assert.throw(() => holidayPackage.generateHolidayPackage());
    });
   

    it('generateHolidayPackage should return more price if seson is summer and insuranceIncluded is false' , () => {
        let holidayPackage = new HolidayPackage('Italy', 'Summer');
        holidayPackage.addVacationer('Stamat sada');
        holidayPackage.addVacationer('pesho esho');
        let totalPrice = 1000;

        let expected = "Holiday Package Generated\n" + "Destination: " + holidayPackage.destination + "\n" + holidayPackage.showVacationers() + "\n" + "Price: " + totalPrice;

        assert.equal(holidayPackage.generateHolidayPackage(), expected);
    });

    
    it('generateHolidayPackage should return more price if seson is summer and insuranceIncluded is true' , () => {
        let holidayPackage = new HolidayPackage('Italy', 'Summer');
        holidayPackage.addVacationer('Stamat sada');
        holidayPackage.addVacationer('pesho esho');
        holidayPackage.insuranceIncluded = true;
        let totalPrice = 1100;

        let expected = "Holiday Package Generated\n" + "Destination: " + holidayPackage.destination + "\n" + holidayPackage.showVacationers() + "\n" + "Price: " + totalPrice;

        assert.equal(holidayPackage.generateHolidayPackage(), expected);
    });

    it('generateHolidayPackage should return more price if seson is winter and insuranceIncluded is false' , () => {
        let holidayPackage = new HolidayPackage('Italy', 'Winter');
        holidayPackage.addVacationer('Stamat sada');
        holidayPackage.addVacationer('pesho esho');
        let totalPrice = 1000;

        let expected = "Holiday Package Generated\n" + "Destination: " + holidayPackage.destination + "\n" + holidayPackage.showVacationers() + "\n" + "Price: " + totalPrice;

        assert.equal(holidayPackage.generateHolidayPackage(), expected);
    });
    it('generateHolidayPackage should return more price if seson is winter and insuranceIncluded is true' , () => {
        let holidayPackage = new HolidayPackage('Italy', 'Winter');
        holidayPackage.addVacationer('Stamat sada');
        holidayPackage.addVacationer('pesho esho');
        holidayPackage.insuranceIncluded = true;
        let totalPrice = 1100;

        let expected = "Holiday Package Generated\n" + "Destination: " + holidayPackage.destination + "\n" + holidayPackage.showVacationers() + "\n" + "Price: " + totalPrice;

        assert.equal(holidayPackage.generateHolidayPackage(), expected);
    });

    it('generateHolidayPackage should return more price if seson is not special and insuranceIncluded is true' , () => {
        let holidayPackage = new HolidayPackage('Italy', 'Spring');
        holidayPackage.addVacationer('Stamat sada');
        holidayPackage.addVacationer('pesho esho');
        holidayPackage.insuranceIncluded = true;
        let totalPrice = 900;

        let expected = "Holiday Package Generated\n" + "Destination: " + holidayPackage.destination + "\n" + holidayPackage.showVacationers() + "\n" + "Price: " + totalPrice;

        assert.equal(holidayPackage.generateHolidayPackage(), expected);
    });

    it('generateHolidayPackage should return more price if seson is not special and insuranceIncluded is false' , () => {
        let holidayPackage = new HolidayPackage('Italy', 'Spring');
        holidayPackage.addVacationer('Stamat sada');
        holidayPackage.addVacationer('pesho esho');
        let totalPrice = 800;

        let expected = "Holiday Package Generated\n" + "Destination: " + holidayPackage.destination + "\n" + holidayPackage.showVacationers() + "\n" + "Price: " + totalPrice;

        assert.equal(holidayPackage.generateHolidayPackage(), expected);
    });

    it('insuranceIncluded getter should return value', () => {
        let holidayPackage = new HolidayPackage('Italy', 'Spring');
        assert.equal(holidayPackage.insuranceIncluded, false);
    });

    it('insuranceIncluded getter should throw if value is not bolean', () => {
        let holidayPackage = new HolidayPackage('Italy', 'Spring');
        assert.throw(() => holidayPackage.insuranceIncluded = 'adasd');
    });

    it('insuranceIncluded getter should set value', () => {
        let holidayPackage = new HolidayPackage('Italy', 'Spring');
        holidayPackage.insuranceIncluded = true;
        assert.equal(holidayPackage.insuranceIncluded, true);
    });

    it('Initialization tests', () => {
        let holidayPackage = new HolidayPackage('Italy', 'Spring');

        assert.equal(holidayPackage.season, 'Spring');
        assert.equal(holidayPackage.destination, 'Italy');
        assert.equal(holidayPackage.insuranceIncluded, false);
        assert.equal(holidayPackage.vacationers.length, 0);
        assert.deepEqual(holidayPackage.vacationers, []);
    });

});