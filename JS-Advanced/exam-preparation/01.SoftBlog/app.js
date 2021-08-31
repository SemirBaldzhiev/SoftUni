function solve(){
      let sectionElement = document.querySelector('.site-content main section');
      let createButtonElement = document.querySelector('.create');
      
      createButtonElement.addEventListener('click', createPost);

      function createPost(e){
         e.preventDefault();


         let authorElement  = document.getElementById('creator');
         let titleElement = document.getElementById('title');
         let categoryElement= document.getElementById('category');
         let contentElement = document.getElementById('content');

         let author = authorElement.value;
         let title = titleElement.value;
         let category = categoryElement.value;
         let content = contentElement.value;   
         let articleElement = document.createElement('article');
         
         let h1Element = document.createElement('h1');
         h1Element.textContent = title;
         
         let pCategory = document.createElement('p');
         
         pCategory.textContent = 'Category:';
         let strongCategoryElement = document.createElement('strong');
         strongCategoryElement.textContent = category;
         pCategory.appendChild(strongCategoryElement);

         let pCreator = document.createElement('p');
        
         pCreator.textContent = 'Creator:';
         let strongCreatorElement = document.createElement('strong');
         strongCreatorElement.textContent = author;
         pCreator.appendChild(strongCreatorElement);

         let pContent = document.createElement('p');
         pContent.textContent = content;

         let divElement = document.createElement('div');
         divElement.classList.add('buttons');
         let deleteBtn = document.createElement('button');
         deleteBtn.textContent = 'Delete';
         deleteBtn.classList.add('btn');
         deleteBtn.classList.add('delete');

         let archiveBtn = document.createElement('button');
         archiveBtn.textContent = 'Archive';
         archiveBtn.classList.add('btn');
         archiveBtn.classList.add('archive');

         divElement.appendChild(deleteBtn);
         divElement.appendChild(archiveBtn);

         articleElement.appendChild(h1Element);
         articleElement.appendChild(pCategory);
         articleElement.appendChild(pCreator);
         articleElement.appendChild(pContent);
         articleElement.appendChild(divElement);

         sectionElement.appendChild(articleElement);

         authorElement.value = '';
         titleElement.value = '';
         categoryElement.value = '';
         contentElement.value = '';

         
         let archiveButtons = document.querySelectorAll('.archive');
         Array.from(archiveButtons).forEach(b => {
            b.addEventListener('click', archivePost);
         });

         let deleteButtons = document.querySelectorAll('.delete');

         Array.from(deleteButtons).forEach(b => {
            b.addEventListener('click', deletePost);
         });
        
      }

      function deletePost(e){
         e.target.parentNode.parentNode.remove();
      }

      function archivePost(e){

         let olElement = document.querySelector('.archive-section ol');

         let liElement = document.createElement('li');
         let titleText = e.target.parentNode.parentNode.childNodes[0].textContent;
         liElement.textContent = titleText;
         olElement.appendChild(liElement);

         let sortedLi = Array.from(olElement.childNodes).sort((a, b) => a.textContent.localeCompare(b.textContent));

         olElement.removeChild(liElement);
         sortedLi.forEach(el => {
            olElement.appendChild(el);
         });

         e.target.parentNode.parentNode.remove();
      }


  }
