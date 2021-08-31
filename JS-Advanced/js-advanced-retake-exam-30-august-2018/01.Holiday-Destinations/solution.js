function addDestination(){

    let addButtonElement = document.querySelector('.button');

    let seasons = {};

    let cityInputElement = document.querySelector('#input input:nth-child(2)');
    let countryInputElement = document.querySelector('#input input:nth-child(4)');
    let selectListElement = document.getElementById('seasons');
    
    if (!cityInputElement.value || !countryInputElement.value) {
        return;
    }
    
    let season = selectListElement.value[0].toUpperCase() + selectListElement.value.slice(1);

    if (!seasons[season]) {
        seasons[season] = 1;
    }
    else{
        seasons[season]++;
    }


    let tBodyElement = document.getElementById('destinationsList');

    let trElement = document.createElement('tr');
    let firstTdElement = document.createElement('td');
    firstTdElement.textContent = `${cityInputElement.value}, ${countryInputElement.value}`;

    let secondTdElement = document.createElement('td');
    secondTdElement.textContent = `${season}`;

    trElement.appendChild(firstTdElement);
    trElement.appendChild(secondTdElement);

    tBodyElement.appendChild(trElement);

    let summerInputElement = document.getElementById('summer');
    let autumnInputElement = document.getElementById('autumn');
    let winterInputElement = document.getElementById('winter');
    let springInputElement = document.getElementById('spring');

    summerInputElement.value = selectListElement.value === 'summer' ? ++summerInputElement.value : summerInputElement.value;
    autumnInputElement.value = selectListElement.value === 'autumn' ? ++autumnInputElement.value : autumnInputElement.value;
    winterInputElement.value = selectListElement.value === 'winter' ? ++winterInputElement.value: winterInputElement.value;
    springInputElement.value = selectListElement.value === 'spring' ? ++springInputElement.value : springInputElement.value;

    cityInputElement.value = '';
    countryInputElement.value = '';


}