import auth from "./helpers/auth.js";
import homePage from "./pages/home.js";
import loginPage from "./pages/login.js";
import movieDetailsPage from "./pages/movieDetails.js";
import registerPage from "./pages/register.js";


let views = {
    'home': () => homePage.getView(),
    'login': () => loginPage.getView(),
    'register': () => registerPage.getView(),
    'logout': () => auth.logout(),
    'movie-details': (id) => movieDetailsPage.getView(id),
    'like': (id) => 
}

function initialize(allLinks){
    allLinks.forEach(x => x.addEventListener('click', changeViewHandler))
}

function changeViewHandler(e){
    let element = e.target.matches('.link') ? e.target : e.target.closest('.link');
    console.log(element);
    let route = element.dataset.route;
    let id = element.dataset.id;
    auth.setUserId(id);
    console.log(route);
    navigateTo(route, id);
}

export function navigateTo(route, id){
    if (views.hasOwnProperty(route)) {
        let view = views[route](id);
        console.log(view);
        let app = document.getElementById('main');
        app.querySelectorAll('.view').forEach(v => v.remove());
        app.appendChild(view);
    }
}


let viewChanger = {
    initialize,
    navigateTo,
    changeViewHandler
}

export default viewChanger;