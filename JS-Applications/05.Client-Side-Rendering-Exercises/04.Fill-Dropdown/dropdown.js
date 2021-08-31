import { render } from "./../node_modules/lit-html/lit-html.js";
import dropdownListTemplates from "./templates/dropdownListTemplates.js";


let selectElement = document.getElementById('menu');
let addBtn = document.querySelector('input[type="submit"]');

let options = [];

addBtn.addEventListener('click', addItem);

fetch('http://localhost:3030/jsonstore/advanced/dropdown')
    .then(res => res.json())
    .then(listItems => {
        console.log(listItems);
        options = Object.values(listItems);
        render(dropdownListTemplates.allOptionsTemplate(options), selectElement);
    })
    .catch(err => {
        console.error(err);
    });

function addItem(e) {
    e.preventDefault();

    let inputElement = document.getElementById('itemText');
    let text = inputElement.value;

    let newItem = {
        text
    }

    fetch('http://localhost:3030/jsonstore/advanced/dropdown', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newItem)
    })
    .then(res => res.json())
    .then(item => {
        options.push(item);
        render(dropdownListTemplates.allOptionsTemplate(options), selectElement);
    })
    .catch(err => {
        console.error(err);
    });
}