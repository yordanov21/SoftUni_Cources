function attachEvents() {


    const phoneBook = document.getElementById('phonebook')
    const personInput = document.getElementById('person')
    const phoneInput = document.getElementById('phone')

    function load(){

        phoneBook.innerHTML = ''

        fetch(`https://phonebook-nakov.firebaseio.com/phonebook.json`)
        .then(res => res.json())
        .then(data => {
            Object.entries(data)
            .forEach(([elementId, elementData]) => {
                const {person, phone} = elementData
                const li = document.createElement('li')
                li.textContent = `${person}: ${phone}`

                const deleteButton = document.createElement('button')
                deleteButton.textContent = 'Delete'
                deleteButton.setAttribute('data-target', elementId)
                deleteButton.addEventListener('click', deletePhone)

                li.appendChild(deleteButton)
                phoneBook.appendChild(li)

            });
        })
        .catch()
    }

    function create(){

        const person = personInput.value
        const phone = phoneInput.value

        const headers = {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({person, phone})
        }

        fetch('https://phonebook-nakov.firebaseio.com/phonebook.json', headers)
        .then(() => {
            personInput.value = ''
            phoneInput.value = ''

            load()
        })
        .catch()
    }

    function deletePhone(){

        const phoneId= this.getAttribute('data-target')

        const headers = {
            method: 'DELETE',
        }

        fetch(`https://phonebook-nakov.firebaseio.com/phonebook/${phoneId}.json`, headers)
        .then(() => {
            load()
        })
        .catch()
    }

    return{
        load,
        create,
    }
}

let result = attachEvents();