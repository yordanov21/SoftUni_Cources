import { getData, getSingleData, createBook, updateBook, deleteBook } from "./requestsDB.js";


let url = `https://books-a64e5.firebaseio.com/`;
let collectionName = "books";

const elements = {
    "records": document.querySelector("#records"),
    "newBook": document.querySelector("#newBook"),
    "editBook": document.querySelector("#editBook")
};

const btns = {
    "loadBooks": document.querySelector("#loadBooks"),
    "addBookBtn": document.querySelector("#addBookBtn"),
    "editBook": document.querySelector("#editBook"),
    "all": document.querySelectorAll("button"),
    "update": document.querySelector("#update")
};


btns.loadBooks.addEventListener("click", loadBooks);

btns.addBookBtn.addEventListener("click", async function(e) {
    e.preventDefault();

    if (isInputValid(elements.newBook)) {
        let bookObj = collectData(elements.newBook);


        try {
            await createBook(url, collectionName, bookObj)
        } catch (e) {
            alert(e);
        }

        clearInput(elements.newBook);
        loadBooks();
    } else {
        alert("You must fill out all fields!");
    }
});

function updater(id) {
    btns.update.addEventListener("click", async function(e) {
        e.preventDefault();
        try {
            if (isInputValid(elements.editBook)) {
                let editedBook = await collectData(elements.editBook);
                await updateBook(url, collectionName, id, editedBook);

                clearInput(elements.editBook);
                elements.newBook.style.display = "block";
                elements.editBook.style.display = "none";
                loadBooks();
            } else {
                alert("You must fill out all fields!!!");
            }

        } catch (e) {
            allert(e);
        }
    });
}

function tracker() {
    elements.records.addEventListener("click", async function(e) {
        let parent = e.target.parentNode.closest("tr");
        let parentId = parent.getAttribute("data-id");

        try {
            if (e.target.textContent === "Edit") {
                await updateBook(url, collectionName, parentId, bookObj);

                // edit(currentBook);
                // updater(parentId);

            }

            if (e.target.textContent === "Delete") {
                await deleteBook(url, collectionName, parentId);
                removeElementFromHtml(elements.records, parent);
            }
        } catch (e) {
            allert(e);
        }

    });
}

function edit(e) {
    elements.newBook.style.display = "none";
    elements.editBook.style.display = "block";

    elements.editBook.querySelectorAll("input").forEach(x => {
        x.value = e[x.name];
    });

}

function clearInput(field) {
    field.querySelectorAll("input")
        .forEach(x => x.value = "");
}

function removeElementFromHtml(parent, child) {
    parent.removeChild(child);
}

function collectData(btn) {
    let obj = {};

    btn.querySelectorAll("input")
        .forEach(x => {
            obj[x.name] = x.value;
        });

    return obj;
}



function loadBooks() {
    elements.records.innerHTML = "";

    getData(url, collectionName)
        .then(x => {
            Object.entries(x)
                .forEach(([id, bookObj]) => {
                    newRow(id, bookObj);
                });
            tracker();
        })
        .catch(e => alert);


}

function isInputValid(field) {
    let counts = field.querySelectorAll("input").length;
    let enteredData = [...field.querySelectorAll("input")].filter(x => x.value !== "").length;

    return enteredData === counts ? true : false;
}

function newRow(id, obj) {
    let tr = document.createElement("tr");

    tr.setAttribute("data-id", id);

    tr.innerHTML = `<td>${obj.title}</td>
                        <td>${obj.author}</td>
                        <td>${obj.isbn}</td>
                        <td>
                            <button>Edit</button>
                            <button>Delete</button>
                        </td>`;


    elements.records.appendChild(tr);
}