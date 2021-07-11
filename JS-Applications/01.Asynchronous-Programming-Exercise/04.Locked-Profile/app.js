function lockedProfile() {
    (async () => {
        let request = await fetch('http://localhost:3030/jsonstore/advanced/profiles');
        let profiles = await request.json();

        let mainElement = document.getElementById('main');

        let tempaletProfile = document.querySelector('.profile');
        tempaletProfile.remove();

        Object.keys(profiles).forEach((x, i) => {
            let profile = profiles[x];

            let htmlProfile = createProfile(i + 1, profile.username, profile.age, profile.email);
            mainElement.appendChild(htmlProfile);

        })
    })();
            
    function createProfile(index, username, age, email){
        let profileDiv = document.createElement('div');
        profileDiv.classList.add('profile');

        let profileImg = document.createElement('img');
        profileImg.src = './iconProfile2.png';
        profileImg.classList.add('userIcon');

        let lockLable = document.createElement('lable');
        lockLable.textContent = 'Lock';
       
        let lockInput = document.createElement('input');
        lockInput.type = 'radio';
        lockInput.name = `user${index}Locked`;
        lockInput.value = 'lock';
        lockInput.checked = true;

        let unlockLable = document.createElement('lable');
        unlockLable.textContent = 'Unlock';

        let unlockInput = document.createElement('input');
        unlockInput.type = 'radio';
        unlockInput.name = `user${index}Locked`;
        unlockInput.value = 'unlock';
        unlockInput.checked = false;
        
        let brElement = document.createElement('br');

        let hrElement = document.createElement('hr');

        let usernameLable = document.createElement('lable');
        usernameLable.textContent = 'Username';

        let usernameInput = document.createElement('input');
        usernameInput.name = `user${index}Locked`;
        usernameInput.value = username;
        usernameInput.disabled = true;
        usernameInput.readOnly = true;


        let hiddenElementsDiv = document.createElement('div');
        hiddenElementsDiv.id = `user${index}HiddenFields`;


        let hiddenHrElement = document.createElement('hr');

        let emailLable = document.createElement('lable');
        emailLable.textContent = 'Email:';


        let emailInput = document.createElement('input');
        emailInput.type = 'email';
        emailInput.name = `user${index}Email`;
        emailInput.value = email;
        emailInput.disabled = true;
        emailInput.readOnly = true;

        let ageLable = document.createElement('lable');
        ageLable.textContent = 'Age:';

        let ageInput = document.createElement('input');
        ageInput.type = 'email';
        ageInput.name = `user${index}Age`;
        ageInput.value = age;
        ageInput.disabled = true;
        ageInput.readOnly = true;

        hiddenElementsDiv.appendChild(hiddenHrElement);
        hiddenElementsDiv.appendChild(emailLable);
        hiddenElementsDiv.appendChild(emailInput);
        hiddenElementsDiv.appendChild(ageLable);
        hiddenElementsDiv.appendChild(ageInput);

        let buttonElement = document.createElement('button');
        buttonElement.textContent = 'Show more';

        buttonElement.addEventListener('click', showHiddenFieldsHandler)
        
        profileDiv.appendChild(profileImg);
        profileDiv.appendChild(lockLable);
        profileDiv.appendChild(lockInput);
        profileDiv.appendChild(unlockLable);
        profileDiv.appendChild(unlockInput);
        profileDiv.appendChild(brElement);
        profileDiv.appendChild(hrElement);
        profileDiv.appendChild(usernameLable);
        profileDiv.appendChild(usernameInput);
        profileDiv.appendChild(hiddenElementsDiv);
        profileDiv.appendChild(buttonElement);

        return profileDiv;
    }

    function showHiddenFieldsHandler(e){
        let profile = e.target.parentElement;
        let showMoreButton = e.target;
        let hiddenFieldsDiv = e.target.previousElementSibling;
        let radioButton = profile.querySelector('input[type="radio"]:checked');
        
        if (radioButton.value !== 'unlock') {
            return;
        }

        showMoreButton.textContent = showMoreButton.textContent == 'Show more' ? 'Hide it' : 'Show more';

        hiddenFieldsDiv.style.display =  hiddenFieldsDiv.style.display == 'block' ? 'none' : 'block'


    }
}   