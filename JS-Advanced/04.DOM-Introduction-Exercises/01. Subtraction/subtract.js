function subtract() {
    let firstInputElement = document.getElementById('firstNumber');
    let secondInputElement = document.getElementById('secondNumber');
    let resultDivElement = document.getElementById('result');

    let firstNum = Number(firstInputElement.value);
    let secondNum = Number(secondInputElement.value);

    let result = firstNum - secondNum;

    resultDivElement.textContent = result;
}