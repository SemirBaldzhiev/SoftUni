import { html } from './../../node_modules/lit-html/lit-html.js'

let optionTemplate = (item) => html`<option value="${item._id}">${item.text}</option>`;

let allOptionsTemplate = (options) => html`${options.map(option => optionTemplate(option))}`;

export default {
    allOptionsTemplate, 
    optionTemplate
}