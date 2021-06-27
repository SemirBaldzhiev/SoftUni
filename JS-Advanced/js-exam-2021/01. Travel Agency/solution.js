window.addEventListener('load', solution);

function solution() {
  let submitButtonElement = document.getElementById('submitBTN');

  submitButtonElement.addEventListener('click', () => {
    let fullNameElement = document.getElementById('fname');
    let emailElement =  document.getElementById('email');
    let phoneElement = document.getElementById('phone');
    let addressElement = document.getElementById('address');
    let codeElement = document.getElementById('code');

    let fullName = fullNameElement.value;
    let email = emailElement.value;
    let phone = phoneElement.value;
    let address = addressElement.value;
    let code = codeElement.value;


    if (!fullNameElement.value || !emailElement.value) {
      return;
    }

    let ulElement = document.getElementById('infoPreview');

    let fullNameLiElement = document.createElement('li');
    fullNameLiElement.textContent = `Full Name: ${fullNameElement.value}`;

    let emailLiElement = document.createElement('li');
    emailLiElement.textContent = `Email: ${emailElement.value}`;

    let phoneLiElement = document.createElement('li');
    phoneLiElement.textContent = `Phone Number: ${phoneElement.value}`;

    
    let addressLiElement = document.createElement('li');
    addressLiElement.textContent = `Address: ${addressElement.value}`;

    let codeLiElement = document.createElement('li');
    codeLiElement.textContent = `Postal Code: ${codeElement.value}`;

    ulElement.appendChild(fullNameLiElement);
    ulElement.appendChild(emailLiElement);
    ulElement.appendChild(phoneLiElement);
    ulElement.appendChild(addressLiElement);
    ulElement.appendChild(codeLiElement);

    let editButtonElement = document.getElementById('editBTN');
    let continueButtonElement = document.getElementById('continueBTN');

    //editButtonElement.removeAttribute('disabled');
    editButtonElement.disabled = false;
    //continueButtonElement.removeAttribute('disabled');
    continueButtonElement.disabled = false;

    editButtonElement.addEventListener('click', () => {
      
      ulElement.removeChild(fullNameLiElement);
      ulElement.removeChild(emailLiElement);
      ulElement.removeChild(phoneLiElement);
      ulElement.removeChild(addressLiElement);
      ulElement.removeChild(codeLiElement);

      fullNameElement.value = fullName;
      emailElement.value = email;
      phoneElement.value = phone;
      addressElement.value = address;
      codeElement.value = code;

     
      editButtonElement.disabled = true;
      continueButtonElement.disabled = true;

      submitButtonElement.disabled = false;

    });

    continueButtonElement.addEventListener('click', () => {
      let divElement = document.getElementById('block');

      divElement.innerHTML = '';

      let headingElement = document.createElement('h3');

      headingElement.textContent = 'Thank you for your reservation!';

      divElement.appendChild(headingElement);
    });




    submitButtonElement.setAttribute('disabled', true);

    fullNameElement.value = '';
    emailElement.value = '';
    phoneElement.value = '';
    addressElement.value = '';
    codeElement.value = '';


  });
}
