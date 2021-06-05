function solve(car){
    const smallEngine = {power: 90, volume: 1800 };
    const normalEngine = {power: 120, volume: 2400 };
    const monsterEngine = {power: 200, volume: 3500 };

    const hatchback = {type: 'hatchback', color: car.color };
    const coupe = {type: 'coupe', color: car.color };

    let resultCar = {model: '', engine: {}, carriage: {}, wheels: []};

    resultCar.model = car.model;

    if (car.power <= 90) {
        resultCar.engine = smallEngine;
    } else if(car.power > 90 && car.power <= 120){
        resultCar.engine = normalEngine;
    } else{
        resultCar.engine = monsterEngine;
    }

    if (car.carriage === 'coupe') {
        resultCar.carriage = coupe;
    }else if(car.carriage === 'hatchback'){
        resultCar.carriage = hatchback;
    }   

    if (car.wheelsize % 2 == 0) {
        car.wheelsize -= 1;
    }

    let arr = [];
    arr.length = 4;
    arr.fill(car.wheelsize, 0, 4);

    resultCar.wheels = arr;

    return resultCar;

}
