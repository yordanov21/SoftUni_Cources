const loadBtn = document.querySelector('#loadBooks');
const tableBody = document.querySelector('table tbody');
const titleInput = document.querySelector('#title');
const authorInput = document.querySelector('#author');
const isbnInput = document.querySelector('#isbn');
const submitBtn = document.querySelector('form button');
const base_URL = 'https://my-first-project-28412.firebaseio.com/books.json';

submitBtn.addEventListener('click' , createNewBook);

function createNewBook(event) {
    
    event.preventDefault();

    let author = authorInput.value;
    let isbn = isbnInput.value;
    let title = titleInput.value;

    const bookObj = {author , isbn , title};
    const headersObj = {
        method: 'POST',
        headers: {'Content-type' : 'application/json'},
        body: JSON.stringify(bookObj)
    };

    authorInput.value = '';
    isbnInput.value = '';
    titleInput.value = '';

    fetch(base_URL , headersObj)
    .then(() => {
        loadBooks()
        console.log('Success');
    })
    .catch((err) => {
        console.log('Oops...Something went wrong');
    })

}

loadBtn.addEventListener('click' , loadBooks);

function loadBooks() {

    tableBody.innerHTML = ''
    
    fetch(base_URL)
    .then((res) => res.json())
    .then((data) => {
        Object.entries(data).forEach(([bookId , bookInfo]) => {
            
            let {author , isbn , title} = bookInfo;
            
            let tableRow = document.createElement('tr');

            tableRow.innerHTML = ` <td>${title}</td>
                                   <td>${author}</td>
                                   <td>${isbn}</td>
                                   <td>
                                       <button>Edit</button>
                                       <button>Delete</button>
                                    </td>`;
            
            tableBody.appendChild(tableRow);

            const [editBtn , deleteBtn] = Array.from(tableRow.querySelectorAll('button'))
            
            editBtn.setAttribute('data-id' , bookId);
            deleteBtn.setAttribute('data-id' , bookId);
            
            deleteBtn.addEventListener('click' , deleteBook);

            function deleteBook() {
                
                const deleteId = this.getAttribute('data-id');
                const headersObj = {method: 'DELETE'};
                const delete_URL = `https://my-first-project-28412.firebaseio.com/books/${deleteId}.json`

                fetch(delete_URL , headersObj)
                .then(() => {
                    console.log('Success');
                    tableBody.removeChild(this.parentNode.parentNode);
                })
                .catch((err) => {
                    console.log('Oops...Something went wrong');
                })
            };

            editBtn.addEventListener('click' , editBookInfo);

            function editBookInfo() {

                const editId = this.getAttribute('data-id');
                const eidt_URL = `https://my-first-project-28412.firebaseio.com/books/${editId}.json`;

                let author = authorInput.value;
                let isbn = isbnInput.value;
                let title = titleInput.value;

                const obj = {author , isbn , title};

                const headersObj = {
                    method: 'PUT',
                    headers: {'Content-type' : 'application/json'},
                    body: JSON.stringify(obj)
                };

                authorInput.value = '';
                isbnInput.value = '';
                titleInput.value = ''

                fetch(eidt_URL , headersObj)
                .then(() => {
                    loadBooks()
                    console.log('Success');
                })
                .catch((err) => {
                    console.log(`Oops...Something went wrong`);
                });

            };

        });
    })
    .catch(() => {
        console.log('Oops...Something went wrong')
    });

};

