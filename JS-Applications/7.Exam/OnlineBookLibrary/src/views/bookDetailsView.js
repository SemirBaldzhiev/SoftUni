import authService from "../services/authService.js";
import bookService from "../services/bookService.js";
import { html } from "./../../node_modules/lit-html/lit-html.js";


let ownerButtonsTemplate = (id, onClick) => html`
 <a class="button" href="/books/${id}/edit">Edit</a>
<a @click=${onClick} class="button" href="javascript:void(0)">Delete</a>
`;


let likeButtonTemplate =  (onLikeClick) => html`<a @click=${onLikeClick} class="button" href="javascript:void(0)">Like</a>`;



let bookDetailsTemplate = (book, onDeleteClick,onLikeClick, count, isLiked) => html`<section id="details-page" class="details">
<div class="book-information">
    <h3>${book.title}</h3>
    <p class="type">Type: ${book.type}</p>
    <p class="img"><img src="${book.imageUrl}"></p>
    <div class="actions">

        ${authService.getData()._id == book._ownerId ? ownerButtonsTemplate(book._id, onDeleteClick) : html``} 

        ${authService.getData()._id !== book._ownerId && authService.isAuthenticated() &&  !isLiked ? likeButtonTemplate(onLikeClick) : html``}

        <div class="likes">
            <img class="hearts" src="/images/heart.png">
            <span id="total-likes">Likes: ${count}</span>
        </div>
        <!-- Bonus -->
        <!-- Like button ( Only for logged-in users, which is not creators of the current book ) -->
        
    </div>
</div>
<div class="book-description">
    <h3>Description:</h3>
    <p>${book.description}</p>
</div>
</section>`


function detailsPage(ctx) {

    const onDeleteClick = (e) => {
        e.preventDefault();

        if(confirm('are you sure want to delete this car')){
            bookService.deleteItem(ctx.params.bookId).then(() => {
                ctx.page.redirect('/books');
            })
        }
        
    }

    const onLikeClick = (e) => {

        e.preventDefault();
        bookService.likeBook(ctx.params.bookId).then(data => {
            //console.log(data);

            ctx.page.redirect('/books')
        })

    }

    
        
    

    let count = 0;
    let isLiked = false;

    bookService.likesCount(ctx.params.bookId).then(likesCount => {
        //console.log(likesCount);
        count = likesCount;   

    });


    bookService.likesFromUser(ctx.params.bookId, ctx.userId).then(data => {
        console.log(data);
        if (data == 1) {
            isLiked =  true;
        }
    })



    bookService.getOne(ctx.params.bookId).then(book => {
        ctx.render(bookDetailsTemplate(book, onDeleteClick, onLikeClick, count, isLiked));
     }); 
}

export default detailsPage;