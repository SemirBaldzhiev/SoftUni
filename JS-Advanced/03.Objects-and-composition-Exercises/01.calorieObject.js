function solve(inputArr){

    let obj = {};

    for (let i = 0; i < inputArr.length; i+=2) {
        let product = inputArr[i];
        let calories = Number(inputArr[i + 1]);
        
        obj[product] = calories;
    }

    return obj;
}