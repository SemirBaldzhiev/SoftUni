import auth from "../helpers/auth.js";
import viewChanger from "../viewChanger.js";

let section = undefined;

function setupSection(domElement){
    section = domElement;
    let form = section.querySelector('#login-form');
    form.addEventListener('submit', login);
}

function login(e){
    e.preventDefault();

    let form = e.target;
    let formData = new FormData(form);
    
    let user = {
        email: formData.get('email'),
        password: formData.get('password')
    }

    fetch('http://localhost:3030/users/login', {
        method: 'Post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    }) 
        .then(res => res.json())
        .then(userData => {
            auth.saveToken(userData.accessToken);
            viewChanger.navigateTo('home');
        })
        .catch(err => {
            alert(err);
        });
}

function getView(){
    return section;
}


let loginPage = {
    setupSection,
    getView
}

export default loginPage;