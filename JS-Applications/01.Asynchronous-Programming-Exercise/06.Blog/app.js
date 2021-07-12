function attachEvents() {

    let loadPostsBtn = document.getElementById('btnLoadPosts');

    loadPostsBtn.addEventListener('click', loadPostsHandler)

    let viewPostBtn = document.getElementById('btnViewPost');

    viewPostBtn.addEventListener('click', viewPostHandler);

    async function loadPostsHandler(e){
        let postsRequest = await fetch('http://localhost:3030/jsonstore/blog/posts');
        let posts = await postsRequest.json();
        
        let selectElement = document.getElementById('posts');
        removeChildElements(selectElement);


        Object.keys(posts).forEach(key => {
            let optionElement = document.createElement('option');
            optionElement.value = key;
            optionElement.textContent = posts[key].title;

            selectElement.appendChild(optionElement);

        });
    }

    async function viewPostHandler(e){

        let id = e.target.previousElementSibling.value;

        if (!id) {
            return;
        }

        let postRequest = await fetch(`http://localhost:3030/jsonstore/blog/posts/${id}`);

        let post = await postRequest.json();

        let h1 = document.getElementById('post-title');
        h1.textContent = post.title;

        let ulPostBody = document.getElementById('post-body');
        ulPostBody.textContent = post.body;

        let commentsRequest = await fetch('http://localhost:3030/jsonstore/blog/comments');

        let comments = await commentsRequest.json();

       let ulComments = document.getElementById('post-comments');

       removeChildElements(ulComments);

        Object.keys(comments).forEach(key => {
            if (comments[key].postId == id) {
                let liElement = document.createElement('li');

                liElement.textContent = comments[key].text;
                ulComments.appendChild(liElement);
            }
        })


    }

    function removeChildElements(parent){
        while(parent.firstChild){
            parent.removeChild(parent.firstChild);
        }
    }

}

attachEvents();