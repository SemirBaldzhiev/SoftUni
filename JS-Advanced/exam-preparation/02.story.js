class Story{
    constructor(title, creator){
        this.title = title;
        this.creator = creator;
        this.comments = [];
        this._likes = [];
    }
    get likes(){
        if (this._likes.length==0) {
            return `${this.title} has 0 likes`;
        }else if (this._likes.length==1) {
            return `${this._likes[0]} likes this story!`;
        }else{
            return `${this._likes[0]} and ${this._likes.length-1} others like this story!`;
        }
    }

    like(username){
        if (this._likes.includes(username)) {
            throw new Error('You can\'t like the same story twice!');
        }

        if (this.creator === username) {
            throw new Error('You can\'t like your own story!');
        }

        this._likes.push(username);
        return `${username} liked ${this.title}!`;
    }
    dislike(username){
        if (!this._likes.includes(username)) {
            throw new Error('You can\'t dislike this story!');
        }
        let index = this._likes.indexOf(username);
        this._likes.splice(index, 1);
        return `${username} disliked ${this.title}`;
    }

    comment(username, content, id){
        if (id === undefined || this.comments.filter(x => x.id === id).length === 0) {
            
            let commentObj = {
                id: this.comments.length + 1,
                username: username,
                content: content,
                replies: [],
            }

            this.comments.push(commentObj);

            return `${username} commented on ${this.title}`;
        } else if(id !== undefined){
            let comment = this.comments.filter(x => x.id === id)[0];

            let reply = {
                id: comment.replies.length + 1,
                username: username,
                content: content,
            };

            comment.replies.push(reply);

            return 'You replied successfully';
        }

        
    }   

    toString(sortingType){

        let order = {
            asc: (a, b) => a.id - b.id,
            desc: (a, b)  => b.id - a.id,
            username: (a, b) => (a.username > b.username) ? 1 : ((b.username > a.username) ? -1 : 0),
        };

        let result = [];

        if (sortingType === 'asc') {
            
            this.comments.sort(order.asc).forEach(c => {
                c.replies.sort(order.asc);
            });

            result.push(`Title: ${this.title}`);
            result.push(`Creator: ${this.creator}`);
            result.push(`Likes: ${this._likes.length}`);
            result.push('Comments:');
            
            this.comments.forEach(c => {

                result.push(`-- ${c.id}. ${c.username}: ${c.content}`);
                c.replies.forEach(r => {
                    result.push(`--- ${c.id}.${r.id}. ${r.username}: ${r.content}`);
                })
            });

        } else if(sortingType === 'desc'){
            
            this.comments.sort(order.desc).forEach(c => {
                c.replies.sort(order.desc);
            });

            result.push(`Title: ${this.title}`);
            result.push(`Creator: ${this.creator}`);
            result.push(`Likes: ${this._likes.length}`);
            result.push('Comments:');
            
            this.comments.forEach(c => {

                result.push(`-- ${c.id}. ${c.username}: ${c.content}`);
                c.replies.forEach(r => {
                    result.push(`--- ${c.id}.${r.id}. ${r.username}: ${r.content}`);
                });
            });
        } else if(sortingType === 'username'){
        
            this.comments.sort(order.username).forEach(c => {
                c.replies.sort(order.username);
            });

            result.push(`Title: ${this.title}`);
            result.push(`Creator: ${this.creator}`);
            result.push(`Likes: ${this._likes.length}`);
            result.push('Comments:');
            
            this.comments.forEach(c => {

                result.push(`-- ${c.id}. ${c.username}: ${c.content}`);
                c.replies.forEach(r => {
                    result.push(`--- ${c.id}.${r.id}. ${r.username}: ${r.content}`);
                });
            });
        
        }
        return result.join('\n').trimEnd();

    }
}


let art = new Story("My Story", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log()
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('desc'));
