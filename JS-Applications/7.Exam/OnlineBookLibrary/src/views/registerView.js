import authService from "../services/authService.js";
import { html } from "./../../node_modules/lit-html/lit-html.js";

let registerTemplate = (onRegisterSubmit) => html ` <section id="register-page" class="register">
<form @submit=${onRegisterSubmit} id="register-form" action="" method="">
    <fieldset>
        <legend>Register Form</legend>
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
        <p class="field">
            <label for="repeat-pass">Repeat Password</label>
            <span class="input">
                <input type="password" name="confirm-pass" id="repeat-pass" placeholder="Repeat Password">
            </span>
        </p>
        <input class="button submit" type="submit" value="Register">
    </fieldset>
</form>
</section>`

function registerPage(ctx){

    const onRegisterSubmit = (e) => {
        e.preventDefault();

        let formData = new FormData(e.currentTarget);

        let email = formData.get('email');
        let password = formData.get('password');
        let repeatPass = formData.get('confirm-pass');

        if (!email || !password || !repeatPass || password !==  repeatPass){
            alert('all fields are required and password should match');
            return;
        }

        authService.register(email, password).then((data) => {
            console.log(data);
            ctx.page.redirect('/books')
        });

    }

    ctx.render(registerTemplate(onRegisterSubmit));
}

export default registerPage;