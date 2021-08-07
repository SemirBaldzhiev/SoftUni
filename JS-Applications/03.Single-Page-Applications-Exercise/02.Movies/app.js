import addMoviePage from "./pages/addMovie.js";
import editMoviePage from "./pages/editMovie.js";
import homePage from "./pages/home.js";
import loginPage from "./pages/login.js";
import movieDetailsPage from "./pages/movieDetails.js";
import registerPage from "./pages/register.js";
import viewChanger from "./viewChanger.js";



function setup(){
    
    
    loginPage.setupSection(document.getElementById('form-login'));
    registerPage.setupSection(document.getElementById('form-sign-up'));
    homePage.setupSection(document.getElementById('home-page'));
    movieDetailsPage.setupSection(document.getElementById('movie-details'));
    editMoviePage.setupSection(document.getElementById('edit-movie'));
    addMoviePage.setupSection(document.getElementById('add-movie'));

    viewChanger.initialize(document.querySelectorAll('.link'));
    viewChanger.navigateTo('home');

}


setup();