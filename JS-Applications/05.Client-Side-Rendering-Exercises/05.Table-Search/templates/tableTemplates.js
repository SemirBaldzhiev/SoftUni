import { html } from './../../node_modules/lit-html/lit-html.js'

let trTemplate = (student) => html` 
<tr class="${student.class}">
<td>${student.firstName} ${student.lastName}</td>
<td>j${student.email}</td>
<td>${student.course}</td>
</tr>`;

let allTrTemplate = (students) => html`${students.map(s => trTemplate(s))}`;

export default {
    allTrTemplate,
    trTemplate
}