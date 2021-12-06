import bookService from "../services/bookService.js";
import { html } from "./../../node_modules/lit-html/lit-html.js";

let bookTemplate = (book) => html`
<li class="otherBooks">
    <h3>${book.title}</h3>
    <p>Type: ${book.type}</p>
    <p class="img"><img src="${book.imageUrl}"></p>
    <a class="button" href="/books/${book._id}">Details</a>
</li>`;

let allBooksTemplate = (books) => html`<ul class="other-books-list">
${books.map(b => bookTemplate(b))}
</ul>`

let noBooksTemplate = () => html`
<p class="no-books">No books in database!</p>`;

let dashboardTemplate = (books) => html ` 
<section id="dashboard-page" class="dashboard">
<h1>Dashboard</h1>
    ${books.length > 0 
    ? allBooksTemplate(books)
    : noBooksTemplate()
    }
</section>`;

function dashboardPage(ctx){
    bookService.getAll().then(books => {
        ctx.render(dashboardTemplate(books));
    }); 
}

export default dashboardPage;