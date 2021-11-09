function attachEvents() {
    const messagesArea = document.getElementById('messages')
    const authorInput = document.getElementById('author')
    const contentInput = document.getElementById('content')

    function send() {

        let author = authorInput.value
        let content = contentInput.value


        const headers = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ author, content })
        }

        fetch('https://rest-messanger.firebaseio.com/messanger.json', headers)
            .then(() => {
                authorInput.value = ''
                contentInput.value = ''
            })
            .catch()
    }

    function refresh() {
        messagesArea.value = ''
        fetch(`https://rest-messanger.firebaseio.com/messanger.json`)
            .then(res => res.json())
            .then(data => {
                Object.entries(data)
                    .forEach(([elementId, elementData]) => {
                        const { author, content } = elementData
                        messagesArea.value += `${author}: ${content} \n`.trim()
                        console.log(elementId)
                        console.log(elementData)
                    });
            })
            .catch()
    }

    return {
        send,
        refresh
    }
}

let result = attachEvents();