document.getElementById("btnLoad").addEventListener("click", getInputData);
document.getElementById("btnCreate").addEventListener("click", attachData);
let person = document.getElementById("person");
let phone = document.getElementById("phone");
let phoneBook = document.getElementById("phonebook");
let fragment = document.createDocumentFragment();
let nextId = 0;

function getAllPhones() {
    return fetch('https://test-b861d.firebaseio.com/phonebook/.json')
        .then(x => x.json())
        .then(x => x.filter(x => !!x))
}

function getInputData(e) {
    e.preventDefault();
    getAllPhones()
        .then(userDisplay => {
            nextId = Object.keys(userDisplay).length + 1;

            Object.values(userDisplay)
                .map(x => {
                    let li = document.createElement("li");
                    let buttonDel = document.createElement("button");
                    buttonDel.innerText = "Delete";
                    buttonDel.addEventListener("click", removeContact);
                    li.innerHTML = `${x.person} : ${x.phone}`;
                    li.appendChild(buttonDel);
                    fragment.appendChild(li);
                });
            phoneBook.innerHTML = "";
            phoneBook.appendChild(fragment);
        });
}

function createData() {

    let newPerson = {
        [nextId]: {
            person: person.value,
            phone: phone.value,
        },
    };

    phone.value = "";
    person.value = "";
    return newPerson;
}

function attachData() {
    getAllPhones()
        .then(x => {
            fetch('https://test-b861d.firebaseio.com/phonebook/.json', {
                method: "PATCH",
                body: JSON.stringify(createData())
            })
        })
}

function removeContact(e) {

    let split = e.target.parentNode.innerHTML.split(" : ");

    let delPName = split[0];
    let delPPhone = split[1].match(/[\+][\d+ \d+]+/gm);

    let delPerObj = {
        person:`${delPName}`,
        phone:`${delPPhone}`
    };

    getAllPhones()
        .then(userDisplay => {
            userDisplay = Object.values(userDisplay).filter(x=> JSON.stringify(x)!==JSON.stringify(delPerObj));

            fetch('https://test-b861d.firebaseio.com/phonebook/.json', {
                method: "PUT",
                body: JSON.stringify(userDisplay)
            })
        })
}

