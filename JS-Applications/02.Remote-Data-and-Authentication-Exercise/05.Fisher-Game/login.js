let registerForm = document.getElementById('register-form');
let loginForm = document.getElementById('login-form');

registerForm.addEventListener('submit', register);

loginForm.addEventListener('submit', login)

function register(e){
    e.preventDefault();

    let from = e.currentTarget;

    let formData = new FormData(from);

    let email = formData.get('email');
    let password = formData.get('password');
    let repeatPassword = formData.get('rePass');

    if (password !== repeatPassword) {
        console.error('Password don\'t match');
        return;
    }

    let newUser = {
        email,
        password
    }

    fetch('http://localhost:3030/users/register', {
        method: 'Post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newUser)
    })
        .then(res => res.json())
        .then(user => {
            localStorage.setItem('token', user.accessToken);
            location.assign('./index.html')
            localStorage.setItem('userId', user._id);
        })
        .catch(err => {
            console.error(err);
        });
}


function login(e){
    e.preventDefault();

    let from = e.currentTarget;

    let formData = new FormData(from);

    let email = formData.get('email');
    let password = formData.get('password');

    
    let loginUser = {
        email,
        password
    }

    fetch('http://localhost:3030/users/login', {
        method: 'Post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(loginUser)
    })
        .then(res => res.json())
        .then(loginUser => {
            localStorage.setItem('token', loginUser.accessToken);
            location.assign('./index.html')
            localStorage.setItem('userId', user._id);
        })
        .catch(err => {
            console.error(err);
        });


}
