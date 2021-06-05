function solve(inputArr, rotations){

    for (let i = 0; i < rotations; i++) {
        
        let element = inputArr[inputArr.length - 1];

        for (let j = inputArr.length - 1; j > 0; j--) {
            
            inputArr[j] = inputArr[j - 1]; 
        }

        inputArr[0] = element;
    }

    return inputArr.join(' ');

}

console.log(solve(['1', 
'2', 
'3', 
'4'], 
2
));

console.log(solve(['Banana', 
'Orange', 
'Coconut', 
'Apple'], 
15
));