import { render } from "./../../node_modules/lit-html/lit-html.js";
import navigationView from "./../views/navigation.js";

let navElement = document.querySelector('#site-header');

export function navMiddleware(ctx, next) {
    render(navigationView.renderNavigation(ctx), navElement);
    next();
}

