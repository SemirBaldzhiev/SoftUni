import bookService from "../services/bookService.js";
import { html } from "./../../node_modules/lit-html/lit-html.js";

let bookTemplate = (book) => html`
<li class="otherBooks">
    <h3>${book.title}</h3>
    <p>Type: ${book.type}</p>
    <p class="img"><img src="${book.imageUrl}"></p>
    <a class="button" href="/books/${book._id}">Details</a>
</li>`;

let allBooksTemplate = (books) => html`<ul class="my-books-list">
${books.map(b => bookTemplate(b))}
</ul>`

let noBooksTemplate = () => html`
<p class="no-books">No books in database!</p>`;


let myBooksTemplate = (books) => html `<section id="my-books-page" class="my-books">
<h1>My Books</h1>
<!-- Display ul: with list-items for every user's books (if any) -->

${books.length > 0 
    ? allBooksTemplate(books)
    : noBooksTemplate()
    }
<!-- Display paragraph: If the user doesn't have his own books  -->

</section>`

function myBooksPage(ctx){

    bookService.myBooks(ctx.userId)
        .then(books => {
            ctx.render(myBooksTemplate(books));
        });
}

export default myBooksPage;