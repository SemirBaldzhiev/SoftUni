import { html } from './../../node_modules/lit-html/lit-html.js'

let catTemplate = (cat, statusCodeHandler) => html` 
<li>
    <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
    <div class="info">
        <button class="showBtn" @click=${statusCodeHandler}>Show status code</button>
        <div class="status" style="display: none" id="100">
            <h4>Status Code: ${cat.statusCode}</h4>
            <p>${cat.statusMessage}</p>
        </div>
    </div>
</li>`



let allCatsTemplate = (cats, statusCodeHandler) => html`<ul>${cats.map(c => catTemplate(c, statusCodeHandler))}</ul>`

export default {
    allCatsTemplate,
    catTemplate
}

