function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let inputTextElement = document.querySelector('#searchField');
      let rowElements = Array.from(document.querySelectorAll('tbody tr'));
      let searchText = inputTextElement.value;

      for (const el of rowElements) {
         el.className = '';
      }

      for (const el of rowElements) {
         let values = Array.from(el.children);
         
         if (values.some(x => x.textContent.includes(searchText))) {
            el.className = 'select';
         }

      }

      inputTextElement.value = '';

      console.log(rowElements);
   }
}