function solve(fruitType, weightGrams, pricePerKg){
    let weightKg = weightGrams / 1000;
    let price = weightKg * pricePerKg;

    console.log(`I need $${price.toFixed(2)} to buy ${weightKg.toFixed(2)} kilograms ${fruitType}.`);
}
