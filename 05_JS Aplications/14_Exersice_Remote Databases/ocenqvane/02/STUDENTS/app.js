import { dataBase } from "./dataBaseRequests.js";

let tbody = document.getElementsByTagName("tbody")[0];
let inputField = document.getElementsByTagName("form")[0];
let url = `https://students-a580e.firebaseio.com/`;
let collectionName = "students";
let studEntity = dataBase(url, collectionName);


studEntity.getAllData().then(x => {
    tbody.innerHTML = "";
    Object.values(x).forEach(rec => postRow(rec, tbody));
});

inputField.addEventListener("submit", function (e) {
    e.preventDefault();
    if (validityCheck()) {
        sendData(validityCheck());
    } else {
        clear();
    }
});


function validityCheck() {
    let input = Array.from(inputField.getElementsByTagName("input")).filter(a => a.value !== "");

    // return input.length === 4 ? input : false;
    return input.length === 4 ? input : alert("You must fill out all the fields!");

}

function sendData(arr) {
    let id = tbody.childElementCount;
    let obj = {};

    obj["id"] = id;
    arr.forEach(a => obj[a.name] = a.value);

    studEntity.putData(obj);
    postRow(obj, tbody);
    clear();
}

function postRow(obj, tbody) {
    let { id, firstName, lastName, facultyNumber, grade } = obj;
    let tr = document.createElement("tr");

    tr.innerHTML = `<th>${id}</th>
                    <th>${firstName}</th>
                    <th>${lastName}</th>
                    <th>${facultyNumber}</th>
                    <th>${grade}</th>`;

    tbody.appendChild(tr);

}

function clear() {
    Array.from(inputField.getElementsByTagName("input")).forEach(a => a.value = "");
}


