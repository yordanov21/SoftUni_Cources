import { apiKey, createNewBook, getAllBooks, getBookById, updateBook, deleteBook } from './firebase-request.js'

var firebaseConfig = {
    apiKey: "AIzaSyBMpGagRuoqpbIr4wY-O8E6cT5i2eg-Yec",
    authDomain: "bookdatabasejssoftuni.firebaseapp.com",
    databaseURL: "https://bookdatabasejssoftuni.firebaseio.com",
    projectId: "bookdatabasejssoftuni",
    storageBucket: "bookdatabasejssoftuni.appspot.com",
    messagingSenderId: "824106448519",
    appId: "1:824106448519:web:e98aa49b2ff8d2626bea22",
    measurementId: "G-P17T3MSN0S"
};
// Initialize Firebase
// firebase.initializeApp(firebaseConfig);
// firebase.analytics();

function extractFromData(formRef, formConfig) {
    return formConfig.reduce((acc, inputName) => {
        acc[inputName] = formRef.elements[inputName].value;
        return acc;
    }, {})
}

function fillFormWithData(formRef, formValue) {
    Object.entries(formValue).map(([inputName, value]) =>
        formRef.elements.namedItem(inputName).value = value
    );
}

function addTableRow(tbody, bookValue, bookId) {

    let tempRow = document.createElement('tr');
    tempRow.setAttribute('data-book-id', bookId)

    tempRow.innerHTML = `
   <td>${bookValue.title}</td>
   <td>${bookValue.author}</td>
   <td>${bookValue.isbn}</td>
   <td>
       <button data-method="edit" >Edit</button>
       <button data-method="delete" >Delete</button>
   </td>`;

    tbody.appendChild(tempRow)
}

function showAllBooks(tBodyRef) {
    getAllBooks().then(resp => {
        tBodyRef.innerHTML = '';
        Object.entries(resp).map(([id, bookValue]) => {
            addTableRow(tBodyRef, bookValue, id);
        });
    });
}

(function doStuff() {

    let formInputs = ['title', 'author', 'isbn'];

    let formRef = document.querySelector('form');
    let tBodyRef = document.querySelector('tbody');
    let loadBooksButtonRef = document.querySelector('#loadBooks');


    formRef.addEventListener('submit', (e) => {
        e.preventDefault();
        let parsedForm = extractFromData(formRef, formInputs)
        createNewBook(parsedForm)
    });

    loadBooksButtonRef.addEventListener('click', () => {
        showAllBooks(tBodyRef);
    });

    tBodyRef.addEventListener('click', async(e) => {
        let targetBookId = e.target.closest('tr').dataset.bookId;

        if (e.target instanceof HTMLButtonElement) {
            const { method } = e.target.dataset;

            if (method === 'edit') {
                await updateBook(extractFromData(formRef, formInputs), targetBookId)
            }

            if (method === 'delete') {
                await deleteBook(targetBookId)
            }

            showAllBooks(tBodyRef);

            return;
        }

        getBookById(targetBookId).then(x => {
            fillFormWithData(formRef, x)
        });
    })

})();