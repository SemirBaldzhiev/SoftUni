import {render } from './../node_modules/lit-html/lit-html.js'
import townTemplates from './templates/townTemplates.js'

let rootElement = document.getElementById('root');
let form = document.querySelector('form');

form.addEventListener('submit', displayAllTownsHandler)

function displayAllTownsHandler(e){

    e.preventDefault();

    let formData = new FormData(e.target);

    let townsData = formData.get('towns');
    let towns = townsData.split(', ');

    render(townTemplates.allTownsTemplate(towns), rootElement);     
}


