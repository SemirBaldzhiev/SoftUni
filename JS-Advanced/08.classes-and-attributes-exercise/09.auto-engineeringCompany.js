function solve(inputArr) {

    let cars = new Map();
    
    for (const el of inputArr) {
        let [brand, model, produced] = el.split(' | ');

        produced = Number(produced);
        
        if (!cars.has(brand)) {
            cars.set(brand, new Map());
        }

        if (!cars.get(brand).has(model)) {
            cars.get(brand).set(model, produced);
        } else{
            cars.get(brand).set(model, cars.get(brand).get(model) + produced);
        }
        
    }

    let result = [];

    let entries = Array.from(cars.entries());

    for (const kvp of entries) {
        result.push(kvp[0]);

        let modelsEntries = Array.from(kvp[1].entries());

        for (const modelKVP of modelsEntries) {
            result.push(`###${modelKVP[0]} -> ${modelKVP[1]}`);
        }
    }

    return result.join('\n');
}

console.log(solve(['Audi | Q7 | 1000',
'Audi | Q6 | 100',
'BMW | X5 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10']
));