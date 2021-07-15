let submitBtn = document.querySelector('form button');
let tBody = document.querySelector('tbody');
let loadBoksBtn = document.getElementById('loadBooks');

tBody.querySelectorAll('tr').forEach(tr => tr.remove());

loadBoksBtn.addEventListener('click', loadAllBooksHandler);

let formElement = document.querySelector('form');

formElement.addEventListener('submit', handleFormSubmit);

function handleFormSubmit(e){
    e.preventDefault();
    let form = e.currentTarget;
    let button = form.querySelector('button');
    
    let formData = new FormData(form);

    if (button.textContent == 'Submit') {
        createBook(formData);
    } else {
        editBook(formData, form.dataset.entryId);
    }
}

function createBook(formData){
    
    let title = formData.get('title');
    let author= formData.get('author');

    if (!title || !author) {
        return;
    }

    let newBook = {
        author,
        title
    }

    fetch('http://localhost:3030/jsonstore/collections/books', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newBook)
    })
        .then(res => res.json())
        .then(book => {
            
            let trElement = creteTableRow(book.author, book.title, book._id);
            tBody.appendChild(trElement);

        })
        .catch(err => {
            console.error(err);
        });
}


function editBook(formData, id){

    let changedBook = {
        title: formData.get('title'),
        author: formData.get('author')
    }

    fetch(`http://localhost:3030/jsonstore/collections/books/${id}`, {
        method: 'PUT', 
        headers:{
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(changedBook)
    })
        .then(res => res.json())
        .then(book => {
            let editedBook = tBody.querySelector(`tr[data-id="${id}"]`);
            let htmlBook = creteTableRow(book.author, book.title, book._id);
            editedBook.replaceWith(htmlBook);
        })
        .catch(err => {
            console.error(err);
        });
}

function loadAllBooksHandler(){

    tBody.querySelectorAll('tr').forEach(tr => tr.remove());

    fetch('http://localhost:3030/jsonstore/collections/books')
        .then(res => res.json())
        .then(books => {

            Object.values(books).forEach(book => {
                let tr = creteTableRow(book.author, book.title, book._id);
                tBody.appendChild(tr);
            });
        })
        .catch(err => {
            console.error(err);
        });
}


function handleEdit(e){

    let currentBook = e.target.parentElement.parentElement;

    let currentAuthor = currentBook.querySelector('td:nth-child(2)');
    let currentTitle = currentBook.querySelector('td:nth-child(1)');

    let titleInput = formElement.querySelector('input[name="title"]');
    let authorInput = formElement.querySelector('input[name="author"]');
    let formHeading = formElement.querySelector('h3');
    let formButn = formElement.querySelector('button');

    formElement.dataset.entryId = currentBook.dataset.id;

    formButn.textContent = 'Save';
    
    formHeading.textContent = 'Edit FORM';

    titleInput.value = currentTitle.textContent;
    authorInput.value = currentAuthor.textContent;

}

async function deleteBookHandler(e){
    let bookToDelete = e.target.parentElement.parentElement;
    let id = bookToDelete.dataset.id;

    let deleteResponse = await fetch(`http://localhost:3030/jsonstore/collections/books/${id}`, {
        method: 'DELETE'
    });

    if (deleteResponse.status === 200) {
        bookToDelete.remove();
    }
}


function creteTableRow(author, title, id){
    let tr = document.createElement('tr');

    let tdTitle = document.createElement('td');
    tdTitle.textContent = title;

    let tdAuthor = document.createElement('td');
    tdAuthor.textContent = author;

    let tdButtons = document.createElement('td');

    let editBtn = document.createElement('button');
    editBtn.textContent = 'Edit'

    editBtn.addEventListener('click', handleEdit);

    let deleteBtn = document.createElement('button');
    deleteBtn.textContent = 'Delete';
    deleteBtn.addEventListener('click', deleteBookHandler);
    
    tdButtons.appendChild(editBtn);
    tdButtons.appendChild(deleteBtn);

    tr.dataset.id = id;

    tr.appendChild(tdTitle);
    tr.appendChild(tdAuthor);
    tr.appendChild(tdButtons);

    return tr;
}