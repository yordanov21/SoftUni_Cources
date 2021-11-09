let author = document.getElementById("author");
let content = document.getElementById("content");
let messages = document.getElementById("messages");
let li = document.createElement("li");
document.getElementById("submit").addEventListener("click", submit);
document.getElementById("refresh").addEventListener("click", refresh);

if (author === null || content === null || document.getElementById("submit") === null
    || document.getElementById("refresh") === null || messages === null) {
    throw new Error('Something wrong');
}

function submit(e) {
    e.preventDefault();
    getData()
        .then(x => {
            fetch('https://messenger-fb101.firebaseio.com/messenger/.json', {
                method: "POST",
                body: JSON.stringify(createAuthor())
            })
        })
}

function createAuthor() {
    let newAuthor = {
        author: author.value,
        content: content.value,
    };

    author.value = "";
    content.value = "";
    return newAuthor;
}

function refresh(e) {
    e.preventDefault();
    extractData();
}

function getData() {
    return fetch("https://messenger-fb101.firebaseio.com/messenger/.json")
        .then(x => x.json())
}

function extractData() {
    let messagesArr = [];
    getData()
        .then(x => {
            Object.values(x).map(x => {
                messagesArr.push(`${x.author}: ${x.content}`);
            });
            messages.innerHTML = "";
            messages.innerHTML = messagesArr.join("\n");
        })
}


