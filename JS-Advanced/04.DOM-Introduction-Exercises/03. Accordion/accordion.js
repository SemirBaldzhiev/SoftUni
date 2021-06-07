function toggle() {
    let buttonElement = document.querySelector('.button');
    let divElement = document.querySelector('#extra');

    if (buttonElement.textContent === 'More') {
        divElement.style.display = 'block';
        buttonElement.textContent = 'Less';
    } else {
        divElement.style.display = 'none';
        buttonElement.textContent = 'More';
    }
}