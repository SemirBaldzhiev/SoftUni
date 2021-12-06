import bookService from "../services/bookService.js";
import { html } from "./../../node_modules/lit-html/lit-html.js";

let addBookTemplate= (onCreateSubmit) => html`<section id="create-page" class="create">
<form @submit=${onCreateSubmit} id="create-form" action="" method="">
    <fieldset>
        <legend>Add new Book</legend>
        <p class="field">
            <label for="title">Title</label>
            <span class="input">
                <input type="text" name="title" id="title" placeholder="Title">
            </span>
        </p>
        <p class="field">
            <label for="description">Description</label>
            <span class="input">
                <textarea name="description" id="description" placeholder="Description"></textarea>
            </span>
        </p>
        <p class="field">
            <label for="image">Image</label>
            <span class="input">
                <input type="text" name="imageUrl" id="image" placeholder="Image">
            </span>
        </p>
        <p class="field">
            <label for="type">Type</label>
            <span class="input">
                <select id="type" name="type">
                    <option value="Fiction">Fiction</option>
                    <option value="Romance">Romance</option>
                    <option value="Mistery">Mistery</option>
                    <option value="Classic">Clasic</option>
                    <option value="Other">Other</option>
                </select>
            </span>
        </p>
        <input class="button submit" type="submit" value="Add Book">
    </fieldset>
</form>
</section>`;

function addBookPage(ctx){
    
    const onCreateSubmit = (e) => {
        e.preventDefault();

        let formData = new FormData(e.currentTarget);

        let title = formData.get('title');;
        let description = formData.get('description');
        let imageUrl = formData.get('imageUrl');
        let type = formData.get('type');



        if (!title || !description || !imageUrl || !type) {
            alert('all fields are required');
            return;
        }   

        bookService.create(title, description, imageUrl, type).then(() => ctx.page.redirect('/books'));

    }

    ctx.render(addBookTemplate(onCreateSubmit));
}

export default addBookPage;