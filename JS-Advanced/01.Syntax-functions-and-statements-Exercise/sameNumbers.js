function solve(num) {

    let numToStr = String(num);
    let firstDigit = numToStr[0];
    let sum = Number(firstDigit);
    let isSame = true;
   
    for (let i = 1; i < numToStr.length; i++) {
        if (firstDigit != numToStr[i]) {
            isSame = false;
        }
        
        sum += Number(numToStr[i]);
    }

    console.log(isSame);
    console.log(sum);

}  