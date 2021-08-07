import loginPage from "../pages/login.js";
import viewChanger from "../viewChanger.js";

function saveToken(token){
    localStorage.setItem('auth_token', token);
}

function getToken(){
    return localStorage.getItem('auth_token');
}

function isLoggedIn(){
    return localStorage.getItem('auth_token') !== null;
}

function setUserId(id){
    localStorage.setItem('user_id', id);
}

function getUserId(){
    return localStorage.getItem('user_id');
}

function logout(){
    fetch('http://localhost:3030/users/logout', {
        method: 'Get',
        headers: {
            'X-Authorization': auth.getToken()
        }
    })
        .then(res => res.json());

    localStorage.clear();

    return loginPage.getView();
}

let auth = {
    saveToken,
    getToken,
    isLoggedIn,
    logout,
    setUserId,
    getUserId
}

export default auth;