import { render } from "./../node_modules/lit-html/lit-html.js";
import { cats } from "./catSeeder.js";
import catTemplates from "./templates/catTemplates.js";

let allCatsContainer = document.getElementById('allCats');

function toggleStatusCodeButton(e){
    let button = e.target;
    button.textContent = button.textContent == 'Show status code' 
    ? 'Hide status code' 
    : 'Show status code';

    let infoDiv = button.closest('.info');

    let statusDiv = infoDiv.querySelector('.status')

    statusDiv.style.display = statusDiv.style.display == 'block' 
    ? 'none'
    : 'block';
}

render(catTemplates.allCatsTemplate(cats, toggleStatusCodeButton), allCatsContainer);