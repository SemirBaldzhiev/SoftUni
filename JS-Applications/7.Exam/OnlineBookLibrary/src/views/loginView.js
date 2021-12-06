import authService from "../services/authService.js";
import { html } from "./../../node_modules/lit-html/lit-html.js";

let loginTemplate = (onLoginSubmit) => html`<section id="login-page" class="login">
<form @submit=${onLoginSubmit} id="login-form" action="" method="">
    <fieldset>
        <legend>Login Form</legend>
        <p class="field">
            <label for="email">Email</label>
            <span class="input">
                <input type="text" name="email" id="email" placeholder="Email">
            </span>
        </p>
        <p class="field">
            <label for="password">Password</label>
            <span class="input">
                <input type="password" name="password" id="password" placeholder="Password">
            </span>
        </p>
        <input class="button submit" type="submit" value="Login">
    </fieldset>
</form>
</section>`

function loginPage(ctx){

    const onLoginSubmit = (e) => {
        e.preventDefault();

        let formData = new FormData(e.currentTarget);

        let email = formData.get('email');
        let password = formData.get('password');

        if (!email || !password) {
            alert('all fields are required');
            return;
        }

        authService.login(email, password).then(() => ctx.page.redirect('/books'));
        
    }

    ctx.render(loginTemplate(onLoginSubmit))
}

export default loginPage;