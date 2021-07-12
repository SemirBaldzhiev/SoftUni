async function solution() {

    let request = await fetch('http://localhost:3030/jsonstore/advanced/articles/list');
    let data = await request.json();
    let section = document.getElementById('main');

    data.forEach(x => {
        console.log(x);
        let htmlArticle = createArticle(x._id, x.title);

        section.appendChild(htmlArticle);
    });
   
    function createArticle(id, title){
        let accordionDiv = document.createElement('div');
        accordionDiv.classList.add('accordion');

        let headDiv = document.createElement('div');
        headDiv.classList.add('head');

        let spanElement = document.createElement('span');
        spanElement.textContent = title;

        let button = document.createElement('button');
        button.classList.add('button');
        button.id = id;
        button.textContent = 'More'

        button.addEventListener('click', showMoreInfoHandler);
        
        headDiv.appendChild(spanElement);
        headDiv.appendChild(button);

        let extraInfoDiv = document.createElement('div');
        extraInfoDiv.classList.add('extra');

        let pElement = document.createElement('p');
        //pElement.textContent = moreInfo;

        extraInfoDiv.appendChild(pElement);

        accordionDiv.appendChild(headDiv);
        accordionDiv.appendChild(extraInfoDiv);

        return accordionDiv;
    }

    async function showMoreInfoHandler(e){

        let button = e.target;
        let id = button.id;

        let moreInfoRequest = await fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${id}`);
        let moreInfo = await moreInfoRequest.json();

        let accordionElement = button.parentElement.parentElement;
        
        let extraInfoElement = accordionElement.querySelector('.extra');
        let paragraph = accordionElement.querySelector('.extra p');
        paragraph.textContent = moreInfo.content;

        button.textContent = button.textContent == 'More' ? 'Less' : 'More';
        
        extraInfoElement.style.display = extraInfoElement.style.display == 'block' ? 'none' : 'block';
    }
}

solution();