function validate() {
    let inputElement = document.getElementById('email');
   
   inputElement.addEventListener('change', () => {
        let email = inputElement.value;
        let emailRegex = /^[a-z]+@[a-z]+\.[a-z]+$/;

        if (emailRegex.test(email)) {
            inputElement.classList.remove('error');
        }else {
            inputElement.classList.add('error');
        }
   });
   
}