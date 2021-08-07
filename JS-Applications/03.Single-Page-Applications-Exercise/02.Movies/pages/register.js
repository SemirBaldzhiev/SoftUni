import auth from "../helpers/auth.js";
import viewChanger from "../viewChanger.js";

let section = undefined;

function setupSection(domElement){
    section = domElement;
    let form = section.querySelector('#register-form');
    form.addEventListener('submit', register);
}

function register(e){
    e.preventDefault();

    let form = e.target;
    let formData = new FormData(form);
    
    let email = formData.get('email');
    let password = formData.get('password');
    console.log(password);
    let repeatPassword = formData.get('repeatPassword');

    if (email == '' || password.length < 6 || repeatPassword !== password || password === '') {
        alert('Incorrect email or password');
    }
    
    let user = {
        email: email,
        password: password
    }

    fetch('http://localhost:3030/users/register', {
        method: 'Post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    }) 
        .then(res => res.json())
        .then(userData => {
            console.log(userData);
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

let registerPage = {
    setupSection,
    getView
}

export default registerPage;