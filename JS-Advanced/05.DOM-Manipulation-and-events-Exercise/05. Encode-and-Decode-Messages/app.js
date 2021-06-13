function encodeAndDecodeMessages() {
    let firstTextAreaElement = document.querySelector('#main div:nth-child(1) textarea');
    let encodeButtonElement = document.querySelector('#main div:nth-child(1) button');
    let secondTextareaElement = document.querySelector('#main div:nth-child(2) textarea');
    let decodeButtonElement = document.querySelector('#main div:nth-child(2) button');
    
    let decodeMessage = '';

    encodeButtonElement.addEventListener('click', () => {
        
        let message = firstTextAreaElement.value;
        decodeMessage = message;
        let encodedText = '';
        for (let i = 0; i < message.length; i++) {
            encodedText += String.fromCharCode(message.charCodeAt(i) + 1);
        }
        secondTextareaElement.value = encodedText;
        firstTextAreaElement.value = '';
    });

    decodeButtonElement.addEventListener('click', () => {
        secondTextareaElement.value = decodeMessage;
    });

}