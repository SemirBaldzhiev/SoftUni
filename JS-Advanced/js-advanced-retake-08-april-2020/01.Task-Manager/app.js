function solve() {

    let addButtonElement = document.getElementById('add');


    addButtonElement.addEventListener('click', (e) => {

        e.preventDefault();

        let taskInputElement = document.querySelector('input[name="task"]');
        let descriptionElement = document.querySelector('form textarea');
        let dateInputElement = document.querySelector('input[name="date"]');

        if (!taskInputElement.value || !descriptionElement.value || !dateInputElement.value) {
            return;
        }

        let divElement = document.querySelector('.wrapper section:nth-child(2) div:nth-child(2)');

        let articleElement = document.createElement('article');

        let headingElement = document.createElement('h3');
        headingElement.textContent = taskInputElement.value;

        let pDescriptionElement = document.createElement('p');
        pDescriptionElement.textContent = `Description: ${descriptionElement.value}`;

        let pDateElement = document.createElement('p');

        pDateElement.textContent = `Due Date: ${dateInputElement.value}`;

        let buttonsDivElement = document.createElement('div');
        buttonsDivElement.classList.add('flex');

        let startButtonElement = document.createElement('button');
        startButtonElement.classList.add('green');
        startButtonElement.textContent = 'Start';
        
        startButtonElement.addEventListener('click', progressSection);

        let deleteButtonElement = document.createElement('button');
        deleteButtonElement.classList.add('red');
        deleteButtonElement.textContent = 'Delete';

        deleteButtonElement.addEventListener('click', deleteArticle);


        buttonsDivElement.appendChild(startButtonElement);
        buttonsDivElement.appendChild(deleteButtonElement);

        articleElement.appendChild(headingElement);
        articleElement.appendChild(pDescriptionElement);
        articleElement.appendChild(pDateElement);
        articleElement.appendChild(buttonsDivElement);

        divElement.appendChild(articleElement);
       
        taskInputElement.value = '';
        descriptionElement.value = '';
        dateInputElement.value = '';
    }); 

    function deleteArticle(e){
        e.target.parentNode.parentNode.remove();
    }

    function progressSection(e){
        let inProgressElement = document.getElementById('in-progress');
        let articleCopy = e.target.parentNode.parentNode.cloneNode(true);
        

        articleCopy.querySelector('div button').remove();

        let divBtns = articleCopy.querySelector('div');

        let finishButton = document.createElement('button');

        finishButton.textContent = 'Finish';
        finishButton.classList.add('orange');

        divBtns.appendChild(finishButton);

        finishButton.addEventListener('click', addToCompleteSection);

        inProgressElement.appendChild(articleCopy);
        
        articleCopy.querySelector('div button').addEventListener('click', deleteArticle);

        e.target.parentNode.parentNode.remove();
    }

    function addToCompleteSection(e){
        let clonedArticle  = e.target.parentNode.parentNode.cloneNode(true);

        clonedArticle.querySelector('div').remove();

        let sectionElement = document.querySelector('.wrapper section:nth-child(4) div:nth-child(2)');

        sectionElement.appendChild(clonedArticle);

        e.target.parentNode.parentNode.remove();
    }

    
    
}