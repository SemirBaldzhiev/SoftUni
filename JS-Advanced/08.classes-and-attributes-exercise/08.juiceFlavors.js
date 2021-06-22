function solve(inputArr){

        let map = new Map();
        let currQuantity = 0;
        let orderedMap = new Map();

        for (const el of inputArr) {
            let [juice, qunatity] = el.split(' => ');
            
            qunatity = Number(qunatity);

            if (!map.has(juice)) {
                map.set(juice, qunatity);
            }else{
                map.set(juice, map.get(juice) + qunatity);
            }

            if (map.get(juice) >= 1000) {
                orderedMap.set(juice, map.get(juice));
            }
        }

        let entries = Array.from(orderedMap.entries());
        let result = [];
        for (const kvp of entries) {
            if (kvp[1] >= 1000) {
                result.push(`${kvp[0]} => ${Math.floor(kvp[1] / 1000)}`);
            }
        }

        return result.join('\n');
}
console.log(solve(['Orange => 2000',
'Peach => 1432',
'Banana => 450',
'Peach => 600',
'Strawberry => 549']
));

console.log(solve(['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789']
));