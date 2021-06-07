function search() {
   let allLiElements = document.querySelectorAll('li');
   let inputTextElement = document.querySelector('#searchText');
   let resultElement = document.querySelector('#result');

   let searchText = inputTextElement.value;
   let matches = 0;

   for (const el of allLiElements) {
      if (el.textContent.includes(searchText)) {
         el.style.fontWeight = 'bold';
         el.style.textDecoration = 'underline';
         matches++;
      }
   }

   let result = `${matches} matches found`;
   resultElement.textContent = result;
}
