class Article {

    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this._coments = []; //todo for private
        this._likes = []; //todo for private
    }



    get likes() {

        if (this._likes.length === 0) {
            return `${this.title} has 0 likes`
        } else if (this._likes.length === 1) {
            return `${this._likes[0]} likes this article!`
        } else {
            return `${this._likes[0]} and ${this._likes.length - 1} others like this article!`
        }
    }

    like(username) {

        if (this._likes.findIndex(x => x === username) !== -1) {
            throw new Error(`You can't like the same article twice!`);
        }

        if (username === this.creator) {
            throw new Error(`You can't like your own articles!`);
        }

        this._likes.push(username);
        return `${username} liked ${this.title}!`
    }

    dislike(username) {
        if (this._likes.findIndex(x => x === username) === -1) {
            throw new Error(`You can't dislike this article!`);
        }
        const userNameIndex = this._likes.findIndex(x => x === username);
        this._likes.splice(userNameIndex, 1);
        return `${username} disliked ${this.title}`
    }


    comment(username, content, id) {
        const idComent = this._coments.find(x => x.Id == id);
        if (id === undefined || idComent === undefined) {
            const coment = {
                Id: this._coments.length + 1,
                Username: username,
                Content: content,
                Replies: []
            };

            this._coments.push(coment)
            return `${username} commented on ${this.title}`
        }

        if (id === this._coments[id - 1]) {
            const replyId = this._coments[id - 1].Replies.length + 0.1;
            const reply = {
                Id: id + replyId,
                Username: username,
                Content: content
            }
            this._coments[id - 1].Replies.push(reply);
            return "You replied successfully"
        }
    }

    toString(sortingType) {
        if (sortingType === 'asc') {

        } else if (sortingType === 'desc') {

            this._coments.sort((a, b) => b.Id - a.Id);
            this._coments.forEach(el => {
                el.Replies.sort((a, b) => b.Id - a.Id)
            });
        } else if (sortingType === 'username') {

            this._coments.sort((a, b) => a.Username - b.Username);


            this._coments.forEach(el => {
                el.Replies.sort((a, b) => a.Username - b.Username)
            });
        }
        // if (this.numberOfChildren === 0) {
        //     return `No children are enrolled for the trip and the organization of ${this.organizer} falls out...`;
        // }

        // let result = `${this.organizer} will take ${this.numberOfChildren} children on trip to ${this.destination}\n`;

        // for (const grade in this.kids) {
        //     if (this.kids.hasOwnProperty(grade)) {
        //         const kids = this.kids[grade];
        //         result += `Grade: ${grade}\n`;

        //         let count = 1;

        //         for (const kid of kids) {
        //             result += `${count++}. ${kid}\n`;
        //         }
        //     }
        // }
        let result = `Title: ${this.title}\n`;
        result += `Creator: ${this.creator}\n`;
        result += `Likes: ${this._likes.length}\n`;
        result += `Comments:\n`;
        result += this._coments.forEach(el => {
            `\n-- {${el.Id}}. {${el.Username}}: {${el.Content}}`
        });
        return result.trim();
        //     return `Title: ${this.title}\n
        // Creator: ${this.creator}\n
        // Likes: ${this._likes.length}\n
        // Comments:\n
        // ${this._coments.forEach(el=>{
        //   `\n-- {${el.Id}}. {${el.Username}}: {${el.Content}}`
        // })}\n`
        // return this.name+this.rats.map(rat=> `\n##${rat.name}`).join("")
    }

    //     toString(sortingType)
    // This function should print the article information in the following format:
    // •	If the sorting type is 'asc' - The comments and replies should be sorted by id in ascending order
    // •	If the sorting type is 'desc' - The comments and replies should be sorted by id in descending order
    // •	If the sorting type is 'username' - The comments and replies should be sorted by username in ascending order
    // "Title: {title}
    // Creator: {creator}
    // Likes: {likes}
    // Comments:
    // -- {id}. {username}: {content}
    // -- {id}. {username}: {content}
    // --- {replyId}. {username}: {content}
    // --- {replyId}. {username}: {content} 
    // -- {id}. {username}: {content}
    // ..."


    // console.log(this.name);
    // this.rats.map(rat=>{
    //     console.log(`##${rat.name}`);
    // })
    //}
}


let art = new Article("My Article", "Anny");
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
