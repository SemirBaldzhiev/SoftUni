import page from "./../node_modules/page/page.mjs"

import { authMiddleware } from "./middlewares/authMiddleware.js"
import { navMiddleware } from "./middlewares/navigationMiddleware.js";
import { renderMiddleware } from "./middlewares/renderMiddleware.js";
import addBookPage from "./views/addBookView.js";
import detailsPage from "./views/bookDetailsView.js";

import dashboardPage from "./views/dashboardView.js";
import editPage from "./views/editBookView.js";
import loginPage from "./views/loginView.js";
import myBooksPage from "./views/myBooksView.js";
import registerPage from "./views/registerView.js";

page(authMiddleware);
page(navMiddleware);
page(renderMiddleware);

page('/books', dashboardPage);
page('/login', loginPage);
page('/register', registerPage);
page('/books/create', addBookPage);
page('/books/:bookId', detailsPage);
page('/books/:bookId/edit', editPage);
page('/my-books', myBooksPage);




page.start();

