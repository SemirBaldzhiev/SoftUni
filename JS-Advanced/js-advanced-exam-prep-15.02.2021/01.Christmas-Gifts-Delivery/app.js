function solution() {
    let inputElement = document.querySelector('.container section:nth-child(1) div input');
    let addButtonElement = document.querySelector('.container section:nth-child(1) div button');
    let listOfGiftsElement = document.querySelector('.container section:nth-child(2) ul');
    
    
    let gifts = []; 

    addButtonElement.addEventListener('click', () => {
        
        gifts.push(inputElement.value);
        
        createUlElement(gifts);
        console.log(gifts);
        
        inputElement.value = '';
    });

    function createUlElement(gifts){

        listOfGiftsElement.innerHTML = '';

        gifts.sort((a, b) => a.localeCompare(b)).forEach(gift => {
            let liElement = document.createElement('li');
            liElement.classList.add('gift');
            liElement.textContent = gift;
    
            let sendButtonElement = document.createElement('button');
            sendButtonElement.textContent = 'Send';
            sendButtonElement.setAttribute('id', 'sendButton');

            sendButtonElement.addEventListener('click', (e) => {
                
                let index = gifts.indexOf(gift);
                gifts.splice(index, 1);
                
                
                let sendGiftsElement = document.querySelector('.container section:nth-child(3) ul');
                let sendLiElement = document.createElement('li');
                sendLiElement.textContent = gift; 
                sendGiftsElement.classList.add('gift');
                e.target.parentNode.remove();

                sendGiftsElement.appendChild(sendLiElement);
            });
    
            let discardButtonElement = document.createElement('button');
            discardButtonElement.textContent = 'Discard';
            discardButtonElement.setAttribute('id', 'discardButton');

            discardButtonElement.addEventListener('click', (e) => {
                let index = gifts.indexOf(gift);
                gifts.splice(index, 1);
                
                
                let discardGiftsElement = document.querySelector('.container section:nth-child(4) ul');
                let discardLiElement = document.createElement('li');
                discardLiElement.textContent = gift; 
                discardGiftsElement.classList.add('gift');
                e.target.parentNode.remove();

                discardGiftsElement.appendChild(discardLiElement);
            });
    
            liElement.appendChild(sendButtonElement);
            liElement.appendChild(discardButtonElement);
    
            listOfGiftsElement.appendChild(liElement);
        });
        
    }

}