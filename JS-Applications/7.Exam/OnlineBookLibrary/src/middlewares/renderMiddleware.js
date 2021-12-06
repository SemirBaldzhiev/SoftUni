import { render } from "./../../node_modules/lit-html/lit-html.js";

let siteContainer = document.querySelector('#site-content');

const contextRender = (templateResult) => render(templateResult, siteContainer);

export function renderMiddleware(ctx, next){
    ctx.render = contextRender;
    next();
}

