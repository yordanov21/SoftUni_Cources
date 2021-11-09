function attachEvents() {
    let createBtn = document.getElementById('btnCreate');
    let loadBtn = document.getElementById('btnLoad');
    let phonebook = document.getElementById('phonebook');

    let person = document.getElementById('person');
    let phone = document.getElementById('phone');


    createBtn.addEventListener('click', create);
    loadBtn.addEventListener('click', load);

    function load() {
        phonebook.innerHTML = '';

        fetch(`https://phonebook-nakov.firebaseio.com/phonebook.json`)
            .then(x => x.json())
            .then(x => {
                let listOfPeople = Object.entries(x).forEach(person => {

                    //show only phone numbers with digits
                    if (!Number.isNaN(Number(person[1].phone))) {
                        let newLi = document.createElement('li');
                        let delBtn = document.createElement('button');
                        let id = person[0];

                        newLi.setAttribute('id', id);
                        delBtn.innerText = 'Delete';

                        delBtn.addEventListener('click', () => {
                            fetch(`https://phonebook-nakov.firebaseio.com/phonebook/${id}.json`, {
                                method: 'DELETE'
                            })

                            //removing item from page
                            let currLi = document.getElementById(id);
                            phonebook.removeChild(currLi);
                        })

                        newLi.innerText = `${person[1].person}: ${person[1].phone}`;
                        newLi.appendChild(delBtn);
                        phonebook.appendChild(newLi);

                    }
                })
            });
    }

    function create() {

        let newPerson = {
            person: person.value,
            phone: phone.value
        }

        //checks if there is a given name and a valid number
        if (!newPerson.person || Number.isNaN(Number(newPerson.phone))) {
            person.value = '';
            phone.value = '';
            return;
        }

        fetch(`https://phonebook-nakov.firebaseio.com/phonebook.json`, {
            method: 'POST',
            body: JSON.stringify(newPerson)
        })

        person.value = '';
        phone.value = '';
    }
}

attachEvents();