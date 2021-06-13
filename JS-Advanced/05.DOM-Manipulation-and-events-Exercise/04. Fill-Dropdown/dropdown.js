function addItem() {
    let inputTextElement = document.getElementById('newItemText');
    let inputValueElement= document.getElementById('newItemValue');
    let selectElement = document.getElementById('menu');

    let text = inputTextElement.value;
    let value = inputValueElement.value;

    let optionElement = document.createElement('option');
    optionElement.textContent = text;
    optionElement.value = value;

    selectElement.appendChild(optionElement);
    inputTextElement.value = '';
    inputValueElement.value = '';
}