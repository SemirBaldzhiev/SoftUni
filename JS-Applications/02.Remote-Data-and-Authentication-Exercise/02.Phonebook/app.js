function attachEvents() {
    let loadBtn = document.getElementById('btnLoad');
    let createBtn = document.getElementById('btnCreate');
    let phonebook = document.getElementById('phonebook');

    

    loadBtn.addEventListener('click', loadPhoneNumbersHandler);

    createBtn.addEventListener('click', createContactHandler);

    function loadPhoneNumbersHandler(){
        
        clearPhonebookList(phonebook);
        fetch('http://localhost:3030/jsonstore/phonebook')
            .then(res => res.json())
            .then(data => {
                
                Object.values(data).forEach(x => {
                    let liElement = document.createElement('li');

                    console.log(x);

                    let phoneData = `${x.person}: ${x.phone}`

                    liElement.textContent = phoneData;
                    liElement.setAttribute('data-id', x._id);
                    console.log(liElement);

                    let deleteButton = document.createElement('button');
                    deleteButton.textContent = 'Delete';

                    deleteButton.addEventListener('click', deleteContactHandler);

                    liElement.appendChild(deleteButton);
                    phonebook.appendChild(liElement);
                    
                });
            })
            .catch(err => {
                console.error(err);
            });
    }

    function deleteContactHandler(e){
        
        let id = e.target.parentElement.getAttribute('data-id');
        console.log(id);

        fetch(`http://localhost:3030/jsonstore/phonebook/${id}`,{
            method: 'DELETE'
        })
        .catch(err => {
            console.error(err);
        })

        e.target.parentElement.remove();
    }


    function createContactHandler(){

        let personInput = document.getElementById('person');
        let phoneInput = document.getElementById('phone');

        let newContact = {
            person: personInput.value,
            phone: phoneInput.value
        }

        fetch('http://localhost:3030/jsonstore/phonebook', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newContact)
        })
            .then(res => res.json())
            .then(contact => {
                let liContact = document.createElement('li');
                let deleteBtn = document.createElement('button');
                deleteBtn.textContent = 'Delete';
                liContact.textContent = `${contact.person}: ${contact.phone}`;
                deleteBtn.addEventListener('click', deleteContactHandler);
                liContact.appendChild(deleteBtn);
                phonebook.appendChild(liContact);
            })
            .catch(err => {
                console.error(err);
            });
    }

    function clearPhonebookList(parent){
        while(parent.firstChild){
            parent.removeChild(parent.firstChild);
        }
    }

}

attachEvents();