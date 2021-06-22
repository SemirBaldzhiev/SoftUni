function solve(matrix) {
 
    let sum = matrix[0].reduce((a, b) => a + b, 0);
 
    let isMagic = true;
 
    for (let i = 0; i < matrix.length; i++) {
 
        let currSum = matrix[i].reduce((a, b) => a + b, 0);
        if (sum != currSum) {
 
            isMagic = false;
        }
 
        for (let h = 0; h < matrix[i].length; h++) {
 
            let currSum2 = 0;
 
            for (let j = 0; j < matrix.length; j++) {
 
                currSum2 += matrix[i][j];
 
            }
            if (sum != currSum2) {
 
                isMagic = false;
            }
        }
    }
 
    console.log(isMagic);
}