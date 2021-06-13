function lockedProfile() {
    let buttonElements = document.querySelectorAll('#main .profile button');

    console.log(buttonElements);

    for (let i = 0; i < buttonElements.length; i++) {
           buttonElements[i].addEventListener('click', () => {
                let radioButtonName = `user${i + 1}Locked`;
                let radioButton = document.querySelector(`input[name="${radioButtonName}"]:checked`);

                console.log(radioButton);
                if (radioButton.value === 'unlock') {
                    let hidenElements = document.getElementById(`user${i + 1}HiddenFields`);

                    console.log(hidenElements);
                    hidenElements.style.display = hidenElements.style.display === 'block' ? 'none' : 'block'; 

                    buttonElements[i].textContent = buttonElements[i].textContent === 'Show more' ? 'Hide it' : 'Show more';
                }
                
           });
        
    }
}