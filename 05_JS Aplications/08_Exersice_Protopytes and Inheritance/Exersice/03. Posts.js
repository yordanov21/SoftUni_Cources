function solve() {
    class Post {
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }

        toString() {
            return `Post: ${this.title}\nContent: ${this.content}`
        }
    }

    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes) {
            super(title, content);
            this.likes = likes;
            this.dislikes = dislikes;
            this.comments = [];
        }

        addComment(comment) {
            this.comments.push(comment)
        }

        toString() {
            let output = super.toString() + '\n';
            output += `Rating: ${this.likes-this.dislikes}` + '\n'
            if (this.comments.length > 0) {
                output += 'Comments:\n'
                output += this.comments.map((com) => ` * ${com}`).join("\n");
            }
            return output.trim();
        }


    }


    class BlogPost extends Post {
        constructor(title, content, views) {
            super(title, content);
            this.views = views;

        }

        view() {
            this.views++;
            return this; //return the object, so that chaining is supported. т.е. да можем да правим това BblogPost.view().view().view().view(), иначе ще гърми със undefine
        }

        toString() {
            let output = super.toString() + '\n';
            output += `Views: ${this.views}`
            return output;
        }

    }

    return {
        Post,
        SocialMediaPost,
        BlogPost
    }
}




let post = new Post("Post", "Content");
console.log(post.toString());
// Post: Post
// Content: Content

let scm = new SocialMediaPost("TestTitle", "TestContent", 25, 30);
scm.addComment("Good post");
scm.addComment("Very good post");
scm.addComment("Wow!");
console.log(scm.toString());
// Post: TestTitle
// Content: TestContent
// Rating: -5
// Comments:
//  * Good post
//  * Very good post
//  * Wow!

let blog = new BlogPost("Blog title", "Blog conntent", 20)
blog.view();
blog.view();
blog.view();
blog.view();
blog.view();
console.log(blog.toString());