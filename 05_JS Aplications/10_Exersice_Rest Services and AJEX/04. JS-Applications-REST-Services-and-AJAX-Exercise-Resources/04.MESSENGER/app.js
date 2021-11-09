function attachEvents() {
    const url = "https://rest-messanger.firebaseio.com/messanger.json";
    let messagesData = document.getElementById("messages");
    let sendButton = document.getElementById("submit");
    let refreshButton = document.getElementById("refresh");

    refreshButton.addEventListener('click', () => {
        let inputMessages = [];

        fetch(url)
            .then(resources => resources.json())
            .then(data => {
                Object.entries(data)
                    .forEach(([_, message]) => {
                        const {
                            author,
                            content
                        } = message;
                        inputMessages.push(`${author}: ${content}`);
                    })

                messagesData.textContent = inputMessages.join("\n");
            })
            .catch(() => console.log("Error!!!"));
    })

    sendButton.addEventListener('click', () => {
        let name = document.getElementById("author").value;
        let message = document.getElementById("content").value;

        const headers = {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                author: name,
                content: message
            })
        };

        fetch(url, headers)
            .then(() => {
                document.getElementById("author").value = "";
                document.getElementById("content").value = "";

                refreshMessages();
            })
            .catch(() => console.log("Error!!!"));
    })

}

attachEvents();