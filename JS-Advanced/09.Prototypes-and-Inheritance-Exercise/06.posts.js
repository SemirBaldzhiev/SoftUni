function solution(){
    class Post{
        constructor(title, content){
            this.title = title;
            this.content = content;
        }   

        toString(){
            return `Post: ${this.title}\nContent: ${this.content}`;
        }
    }

    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes){
            super(title, content);
            this.likes = likes;
            this.dislikes = dislikes;
            this._comments = [];
        }

        addComment(comment){
            this._comments.push(comment);
        }

        toString(){

            let baseToString = super.toString();
            let allComments = this._comments.length > 0  
            ? `\nComments:\n${this._comments.map(c => ` * ${c}`).join('\n')}`
            : '';
            return `${baseToString}\nRating: ${this.likes - this.dislikes}${allComments}`;
        }

    }

    class BlogPost extends Post{
        constructor(title, content, views){
            super(title, content);
            this.views = views;
        }

        view(){
            this.views++;
            return this;
        }

        toString(){
            let baseToString = super.toString();

            return `${baseToString}\nViews: ${this.views}`;
        }
    }

    return {
        Post,
        SocialMediaPost,
        BlogPost
    };
}

const classes = solution();
let post = new classes.Post("Post", "Content");

console.log(post.toString());

let scm = new classes.SocialMediaPost("TestTitle", "TestContent", 25, 30);

scm.addComment("Good post");
scm.addComment("Very good post");
scm.addComment("Wow!");

console.log(scm.toString());

