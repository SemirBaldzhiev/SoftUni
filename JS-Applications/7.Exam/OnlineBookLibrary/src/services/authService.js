import * as request from './requester.js';
import * as api from './api.js';


function saveData({ _id, email, accessToken }) {
    localStorage.setItem('_id', _id);
    localStorage.setItem('email', email);
    localStorage.setItem('access_token', accessToken);
}

function getData() {
    let _id = localStorage.getItem('_id');
    let email = localStorage.getItem('email');
    let accessToken = getToken();
    
    return {
        _id,
        email,
        accessToken,
    }
}
function getToken() {
    let accessToken = localStorage.getItem('access_token');

    return accessToken;
}

function login(email, password) {
    return request.post(api.login, { email, password })
        .then(data => {
            console.log(data);
            saveData(data);
        });
}

function register(email, password) {
    return request.post(api.register, {email, password}).then(data => {
        saveData(data);
    });
}
function isAuthenticated() {
    let token = localStorage.getItem('access_token');

    return Boolean(token);
}

function logout() {
    return request.get(api.logout)
        .then(res => {
            localStorage.clear();
            
            return res;
        })
}


export default {
    logout,
    isAuthenticated,
    register,
    login,
    getToken,
    getData
}