function attachEvents() {
    let sendBtn = document.getElementById('submit');
    let refreshBtn = document.getElementById('refresh');
    let textarea = document.getElementById('messages');


    sendBtn.addEventListener('click', createMessageHandler);

    refreshBtn.addEventListener('click', showAllMessagesHandler);

    async function createMessageHandler(){

        try {
            let nameElement = document.querySelector('input[name="author"]');
            let contentElement = document.querySelector('input[name="content"]');
    
            let newMessage = {
                author: nameElement.value,
                content: contentElement.value
            }
    
            let createResponse = await fetch('http://localhost:3030/jsonstore/messenger', {
                method: 'POST',
                headers: {
                    'Content-Type': 'aplication/json'
                },
                body: JSON.stringify(newMessage)
            });
    
            let createResult = await createResponse.json();
    
    
            let messageString = `${createResult.author}: ${createResult.content}`;
    
            textarea.value = textarea.value + `\n${messageString}`;
        } catch (error) {
            console.error(error);
        }
       
    }

    async function showAllMessagesHandler(){
        try {
            let allMessagesResult = await fetch('http://localhost:3030/jsonstore/messenger');
            let messages = await allMessagesResult.json();

            let messagesString = Object.values(messages).map(m => `${m.author}: ${m.content}`).join('\n');

            textarea.value = messagesString;
        } catch (error) {
            console.error(error);
        }
    }

}

attachEvents();