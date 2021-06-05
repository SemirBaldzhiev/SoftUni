function solve(inputArr){

    let products = {};

    for (let i = 0; i < inputArr.length; i++) {
        let [town, productName, price] = inputArr[i].split(' | ');

        price = Number(price);

        if (!products.hasOwnProperty(productName)) {
            products[productName] = {};
        }
        
        products[productName][town] = price;
    }


    let result = [];

    for (const key in products) {
        let townsSorted = Object.entries(products[key]).sort((a, b) => a[1] - b[1]);
        let cheapestTown = townsSorted[0];

        result.push(`${key} -> ${cheapestTown[1]} (${cheapestTown[0]})`);
    }

    return result.join('\n');
}
