function solve(inputArr){

    let products = {};

    for (let i = 0; i < inputArr.length; i++) {
        let [productName, price] = inputArr[i].split(' : ');

        price = Number(price);

        let productFirstLetter = productName[0];

        if (products[productFirstLetter] === undefined) {
            products[productFirstLetter] = {}
        }

        products[productFirstLetter][productName] = price;
    }

    let sortedProducts = Object.keys(products).sort((a, b) => a.localeCompare(b));
    
    let result = [];    
    for (const key of sortedProducts) {
       let innerSortedProducts = Object.entries(products[key]).sort((a, b) => a[0].localeCompare(b[0]));
       result.push(key);
       result.push(innerSortedProducts.map(x => `  ${x[0]}: ${x[1]}`).join('\n'));
    }

   return result.join('\n')

}

