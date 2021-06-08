function solve() {

    let selectElement = document.querySelector('#selectMenuTo');

    let firstOptionElement = document.createElement('option');
    let secondOptionElement = document.createElement('option');
    firstOptionElement.value = 'binary';
    secondOptionElement.value = 'hexadecimal';
    firstOptionElement.textContent = 'Binary';
    secondOptionElement.textContent = 'Hexadecimal';

    selectElement.appendChild(firstOptionElement);
    selectElement.appendChild(secondOptionElement);

    let resultInputElement = document.querySelector('#result');
    let buttonElement = document.querySelector('button');

    buttonElement.addEventListener('click', onClick);

    function onClick(){
        let inputNumberElement = document.querySelector('#input');
        let number = Number(inputNumberElement.value);

        if (selectElement.value === 'binary') {
            resultInputElement.value = number.toString(2);
        } else if (selectElement.value === 'hexadecimal'){
            resultInputElement.value = number.toString(16).toUpperCase();
        }
    }

}