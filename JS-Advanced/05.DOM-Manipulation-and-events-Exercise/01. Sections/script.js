function create(words) {
   let contentElement = document.querySelector('#content');

   for (const word of words) {
      let divElement = document.createElement('div');
      let pElement = document.createElement('p');

      pElement.textContent = word;
      pElement.style.display = 'none';

      divElement.appendChild(pElement);

      divElement.addEventListener('click', onClick)

      contentElement.appendChild(divElement);

      function onClick(){
         pElement.style.display = 'block';
      }
   }
}