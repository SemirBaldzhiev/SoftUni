import authService from "../services/authService.js";
import { html } from "./../../node_modules/lit-html/lit-html.js";


let guestButtonsTemplate = () => html`  <div id="guest">
<a class="button" href="/login">Login</a>
<a class="button" href="/register">Register</a>
</div>`;

let loggedUserButtonsTemplate = (email, onLogout) => html`<div id="user">
<span>Welcome, ${email}</span>
<a class="button" href="/my-books">My Books</a>
<a class="button" href="/books/create">Add Book</a>
<a @click=${onLogout} class="button" href="javascript:void(0)">Logout</a>
</div>`;

let navigationTemplate = (ctx, onLogout) => html` <nav class="navbar">  
<section class="navbar-dashboard">
    <a href="/books">Dashboard</a>
    ${ctx.isAuthenticated ? loggedUserButtonsTemplate(ctx.email, onLogout) :  guestButtonsTemplate()}
</section>
</nav>`

function renderNavigation(ctx){

    const onLogout = (e) => {
        e.preventDefault();

        authService .logout().then(() => ctx.page.redirect('/books'));
    }

    return navigationTemplate(ctx, onLogout);
}


export default {
    renderNavigation
}