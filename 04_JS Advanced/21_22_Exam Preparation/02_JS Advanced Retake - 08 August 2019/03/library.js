class Library {

    constructor(libraryName) {
        this.libraryName = libraryName;
        this.subscribers = [];
        this.subscriptionTypes = {
            normal: libraryName.length,
            special: libraryName.length * 2,
            vip: Number.MAX_SAFE_INTEGER
        };
    }

    subscribe(name, type) {
        if (type !== 'normal' && type !== 'special' && type !== 'vip') {
            throw new Error(`The type ${type} is invalid`);
        }
        let currentSubscriber = {};
        if (this.subscribers.find((x) => x.name === name)) {
            this.subscribers.find(x.name === name).type = type;
        } else {
            currentSubscriber = {
                name: name,
                type: type,
                books: []
            };
            this.subscribers.push(currentSubscriber);
        }

        return currentSubscriber;
    }

    unsubscribe(name) {

        const index = this.subscribers.findIndex(x => x.name === name);

        if (index === -1) {
            throw new Error(`There is no such subscriber as ${name}`);
        }

        this.subscribers.splice(index, 1);


        return this.subscribers;
    }

    receiveBook(subscriberName, bookTitle, bookAuthor) {

        let subscriber = this.subscribers.find(s => s.name === subscriberName);

        if (!subscriber) {
            throw new Error(`There is no such subscriber as ${subscriberName}`);
        }

        if (this.subscriptionTypes[subscriber.type] > subscriber.books.length) {
            let book = {
                title: bookTitle,
                author: bookAuthor
            };

            subscriber.books.push(book);
        } else {
            throw new Error(`You have reached your subscription limit ${this.subscriptionTypes[subscriber.type]}!`);
        }

        return subscriber;

        // const index = this.subscribers.findIndex(x => x.name === subscriberName);
        // if (index === -1) {
        //     throw new Error(`There is no such subscriber as ${subscriberName}`);
        // }

        // let subTypeLimit;
        // const subType = this.subscribers[index].type;

        // if (subType === 'normal') {
        //     subTypeLimit = this.subscriptionTypes.normal;
        // } else if (subType === 'special') {
        //     subTypeLimit = this.subscriptionTypes.special;
        // } else {
        //     subTypeLimit = this.subscriptionTypes.vip;
        // }

        // const booksCapasity = this.subscribers[index].books.length;
        // if (subTypeLimit > booksCapasity) {
        //     throw new Error(`You have reached your subscription limit ${subTypeLimit}!`);
        // }

        // let newBook = {
        //     title: bookTitle,
        //     author: bookAuthor
        // }
        // this.subscribers[index].books.push(newBook);
        // return this.subscribers[index];
    }

    showInfo() {
            if (this.subscribers.length === 0) {
                return `${this.libraryName} has no information about any subscribers`;
            }
            return this.subscribers
                .map(s =>
                    `Subscriber: ${s.name}, Type: ${s.type}\nReceived books: ${s.books
                    .map(b =>
                        `${b.title} by ${b.author}`)
                    .join(", ")}`)
            .join("\n");
    }
}

let lib = new Library('Lib');

lib.subscribe('Peter', 'normal');
lib.subscribe('John', 'special');
console.log(lib.subscribers);
lib.unsubscribe('Peter');
lib.subscribe('Peter2', 'normal');
console.log(lib.subscribers);
console.log(lib.subscribers[0]);
console.log(lib.subscribers[1]);