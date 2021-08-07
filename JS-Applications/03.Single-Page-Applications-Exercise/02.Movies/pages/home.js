import viewChanger from "../viewChanger.js";

let section = undefined;

function setupSection(domElement){
    section = domElement;
}


function getView(){

    fetch('http://localhost:3030/data/movies')
        .then(res => res.json())
        .then(moviesData => {
            console.log(moviesData);

            let moviesHtml = moviesData.map(m => createHtmlMovie(m)).join('\n')

            let movieContainer = document.getElementById('movie-container');
            movieContainer.querySelectorAll('.movie').forEach(m => m.remove());
            movieContainer.innerHTML = moviesHtml;

            movieContainer.querySelectorAll('.link').forEach(el => el.addEventListener('click', viewChanger.changeViewHandler));
        })

    return section;
}

let homePage = {
    setupSection,   
    getView
}

function createHtmlMovie(movie){

    let element = `<div class="card mb-4 movie">
    <img class="card-img-top" src="${movie.img}"
         alt="Card image cap" width="400">
    <div class="card-body">
        <h4 class="card-title">${movie.title}</h4>
    </div>
    <div class="card-footer">
        <a class="link" data-route="movie-details" data-id="${movie._id}" href="#/details/6lOxMFSMkML09wux6sAF">
            <button type="button" class="btn btn-info">Details</button>
        </a>
    </div>

</div>`

return element;
}

export default homePage;