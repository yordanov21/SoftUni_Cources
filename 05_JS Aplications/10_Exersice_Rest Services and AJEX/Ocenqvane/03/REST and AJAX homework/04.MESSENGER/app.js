function attachEvents() {

    let refreshBtn = document.getElementById('refresh');
    let messages = document.getElementById('messages');

    let submitBtn = document.getElementById('submit');

    let author = document.getElementById('author');
    let content = document.getElementById('content');

    refreshBtn.addEventListener('click', load);
    submitBtn.addEventListener('click', submit);

    function submit() {

        //checks if there is a given author and a message
        if (author.value && content.value) {

            fetch(`https://rest-messanger.firebaseio.com/messanger.json`, {
                method: 'POST',
                body: JSON.stringify({ author: author.value, content: content.value })
            })
        }

        author.value = '';
        content.value = '';
    }

    function load() {
        //cleans previous messages
        messages.value = '';

        fetch(`https://rest-messanger.firebaseio.com/messanger.json`)
            .then(x => x.json())
            .then(x => {
                let list = Object.entries(x);

                for (let i = 0; i < list.length; i++) {

                    //post message if there is a given author and a message
                    if (list[i][1].author && list[i][1].content) {
                        messages.value += `${list[i][1].author}: ${list[i][1].content}\n`;
                    }
                }
            });
    }
}

attachEvents();