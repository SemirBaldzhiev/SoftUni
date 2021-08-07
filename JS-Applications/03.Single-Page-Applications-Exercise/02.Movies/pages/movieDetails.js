import auth from "../helpers/auth.js";

let section = undefined;

function setupSection(domElement){
    section = domElement;
}


function getView(id){

    fetch(`http://localhost:3030/data/movies/${id}`)
        .then(res => res.json())
        .then(movie => {

            console.log(movie);
            let movieDetailsHtml = createHtmlMovieDetails(movie);
            let detailsContainer = document.getElementById('movie-details-container');
            [...detailsContainer.children].forEach(x => x.remove());

            detailsContainer.innerHTML = movieDetailsHtml;
        })
        .catch(err => {
            alert(err);
        })

    return section;
}

function like(id){

    fetch(`http://localhost:3030/data/movies/${id}`)
        .then(res => res.json())
        .then(movie => {
            let userId = auth.getUserId();
            let isOwner = auth.getUserId() === movie._ownerId;

            fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${id}%22%20and%20_ownerId%3D%22${userId}%22`)
                .then(res => res.json())
                .then(data => {
                    console.log(data);
                })
        });
    
}

function createHtmlMovieDetails(movie){

    let editBtn = `<a class="btn btn-warning link" data-route"edit" data-id="${movie._id}" href="#">Edit</a>`;
    let deleteBtn = `<a class="btn btn-danger link" data-route"delete" data-id="${movie._id}" href="#">Delete</a>`;
    let likeBtn = `<a class="btn btn-primary link" data-route="like" data-id="${movie._id}" href="#">Like</a>`;

    let buttons = [];
    
    if (auth.getUserId() === movie._owner) {
        buttons.push(deleteBtn, editBtn);
    }else {
        buttons.push(likeBtn);
    }

    let buttonsSection = buttons.join('\n');

    let element = `<div class="row bg-light text-dark">
    <h1>Movie title: ${movie.title}</h1>

    <div class="col-md-8">
        <img class="img-thumbnail" src="${movie.img}"
             alt="Movie">
    </div>
    <div class="col-md-4 text-center">
        <h3 class="my-3 ">Movie Description</h3>
        <p>${movie.description}.</p>
        ${buttonsSection}
        <span class="enrolled-span">Liked 1</span>
    </div>
</div>`

return element;
}

let movieDetailsPage = {
    setupSection,
    getView,
    like
}

export default movieDetailsPage;