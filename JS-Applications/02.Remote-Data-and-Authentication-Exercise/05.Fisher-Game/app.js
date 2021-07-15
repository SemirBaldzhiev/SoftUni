let loadBtn = document.querySelector('.load');

loadBtn.addEventListener('click', loadCatches);

let catchesDiv = document.getElementById('catches')
catchesDiv.querySelectorAll('div').forEach(x => x.remove());

let addBtn = document.querySelector('#addForm .add');

addBtn.disabled = localStorage.getItem('token') == null;

addBtn.addEventListener('click', createCatch)

function loadCatches(){

    catchesDiv.querySelectorAll('div').forEach(x => x.remove());

    fetch('http://localhost:3030/data/catches')
        .then(res => res.json())
        .then(catches => {
            
            console.log(catches);
            catchesDiv.append(...catches.map(c => createHtmlCatch(c)));
        })
        .catch(err => {
            console.error(err);
        });
}

function createCatch(){
    let anglerInput = document.querySelector('.angler');
    let weightInput = document.querySelector('.weight');
    let speciesInput = document.querySelector('.species');
    let locationInput= document.querySelector('.location');
    let baitInput = document.querySelector('.bait');
    let captureTimeInput = document.querySelector('.captureTime');

    let newCatch = {
        angler: anglerInput.value,
        weight: Number(weightInput.value),
        species: speciesInput.value,
        location: locationInput.value,
        bait: baitInput.value,
        captureTime: Number(captureTimeInput.value),
    }

    fetch('http://localhost:3030/data/catches', {
        method: 'Post',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': localStorage.getItem('token')
        },
        body: JSON.stringify(newCatch)
    })
        .then(res => res.json())
        .then(data => { 
            console.log(data);
            let createdCatch = createHtmlCatch(data);
            catchesDiv.appendChild(createdCatch);
        })
        .catch(err => {
            console.error(err);
        });

}

function updateCatch(e){
    let currCatch = e.target.parentElement;
    let id = currCatch.dataset.id;

    let anglerInput = currCatch.querySelector('.angler');
    let weightInput = currCatch.querySelector('.weight');
    let speciesInput = currCatch.querySelector('.species');
    let locationInput= currCatch.querySelector('.location');
    let baitInput = currCatch.querySelector('.bait');
    let captureTimeInput = currCatch.querySelector('.captureTime');

    let updatedCatch = {
        angler: anglerInput.value,
        weight: Number(weightInput.value),
        species: speciesInput.value,
        location: locationInput.value,
        bait: baitInput.value,
        captureTime: Number(captureTimeInput.value),
    } 

    fetch(`http://localhost:3030/data/catches/${id}`, {
        method: 'Put',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': localStorage.getItem('token')
        },
        body: JSON.stringify(updatedCatch)
    });

}
async function deleteCatch(e){
    let currCatch = e.target.parentElement;
    console.log(currCatch);
    let id = currCatch.dataset.id;

    let deleteResponse = await fetch(`http://localhost:3030/data/catches/${id}`, {
        method: 'Delete',
        headers: {
            'X-Authorization': localStorage.getItem('token')
        }
    });

    if (deleteResponse.status === 200) {
        currCatch.remove();
    }
}

function createHtmlCatch(currentCatch){

    let catchDiv = document.createElement('div');
    catchDiv.classList.add('catch');

    let anglerLabel = document.createElement('label');
    anglerLabel.textContent = 'Angler';

    let anglerInput = document.createElement('input');
    anglerInput.type = 'text';
    anglerInput.classList.add('angler');
    anglerInput.value = currentCatch.angler;

    let hr = document.createTextNode('hr');

    let weightLabel = document.createElement('label');
    weightLabel.textContent = 'Weight';

    let weightInput = document.createElement('input');
    weightInput.type = 'number';
    weightInput.classList.add('weight');
    weightInput.value = currentCatch.weight;

    let speciesLabel = document.createElement('label');
    speciesLabel.textContent = 'Species';

    let speciesInput = document.createElement('input');
    speciesInput.type = 'text';
    speciesInput.classList.add('species');
    speciesInput.value = currentCatch.species;

    let locationLabel = document.createElement('label');
    locationLabel.textContent = 'Location';

    let locationInput = document.createElement('input');
    locationInput.type = 'text';
    locationInput.classList.add('location');
    locationInput.value = currentCatch.location;


    let baitLabel = document.createElement('label');
    baitLabel.textContent = 'Bait';

    let baitInput = document.createElement('input');
    baitInput.type = 'text';
    baitInput.classList.add('bait');
    baitInput.value = currentCatch.bait;

    let captureTimeLabel = document.createElement('label');
    captureTimeLabel.textContent = 'Capture Time';

    let captureTimeInput = document.createElement('input');
    captureTimeInput.type = 'number';
    captureTimeInput.classList.add('captureTime');
    captureTimeInput.value = currentCatch.captureTime;

    let updateBtn = document.createElement('button');
    updateBtn.classList.add('update');
    updateBtn.disabled = true;
    updateBtn.textContent = 'Update';


    updateBtn.addEventListener('click', updateCatch);
    updateBtn.disabled = localStorage.getItem('userId') != currentCatch._ownerId;

    let deleteBtn = document.createElement('button');
    deleteBtn.classList.add('delete');
    deleteBtn.disabled = true;
    deleteBtn.textContent = 'Delete';

    deleteBtn.addEventListener('click', deleteCatch);
    
    deleteBtn.disabled = localStorage.getItem('userId') != currentCatch._ownerId;

    catchDiv.dataset.id = currentCatch._id;
    catchDiv.dataset.ownerId = currentCatch._ownerId;

    catchDiv.appendChild(anglerLabel);
    catchDiv.appendChild(anglerInput);
    catchDiv.appendChild(hr);
    catchDiv.appendChild(weightLabel);
    catchDiv.appendChild(weightInput);
    catchDiv.appendChild(hr);
    catchDiv.appendChild(speciesLabel);
    catchDiv.appendChild(speciesInput);
    catchDiv.appendChild(hr);
    catchDiv.appendChild(locationLabel);
    catchDiv.appendChild(locationInput);
    catchDiv.appendChild(hr);
    catchDiv.appendChild(baitLabel);
    catchDiv.appendChild(baitInput);
    catchDiv.appendChild(hr);
    catchDiv.appendChild(captureTimeLabel);
    catchDiv.appendChild(captureTimeInput);
    catchDiv.appendChild(hr);
    catchDiv.appendChild(updateBtn);
    catchDiv.appendChild(deleteBtn);

    return catchDiv;
}