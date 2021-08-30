import { html } from './../../node_modules/lit-html/lit-html.js'

let townLiTemplate = (town) => html`<li class="${town.class}">${town.name}</li>`;


let townsUlTemplate = (towns) => html`<ul>${towns.map(t => townLiTemplate(t))}</ul>`;

export default {
    townsUlTemplate, 
    townLiTemplate
}