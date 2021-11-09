window.onload  = () =>{
    let buttonLoad = document.getElementById('loadBooks');
    let booksList = document.getElementsByTagName('tbody')[0];
    let newTitle = document.getElementById('title')
    let newAuthor = document.getElementById('author')
    let newIsbn = document.getElementById('isbn')
    let submitButton = document.getElementById('submit')
    let id ;

    buttonLoad.addEventListener('click',(e)=>{
        loadBooks();
    });

    submitButton.addEventListener('click',(e)=>{
        e.preventDefault();
        let newPost ={
            "title":newTitle.value,
            "author":newAuthor.value,
            "isbn":newIsbn.value
        };

        fetch('https://mybooks-a3607.firebaseio.com/books/.json',{
            method:"POST",
            body:JSON.stringify(newPost)
        });

        newTitle.value ='';
        newAuthor.value='';
        newIsbn.value ='';
        loadBooks()
    })

    booksList.addEventListener('click',async (e)=>{
        
        if(e.target.textContent!=="Edit" && e.target.textContent!=="Delete"){
            newTitle.value = e.target.parentNode.children[0].textContent;
            newAuthor.value = e.target.parentNode.children[1].textContent;
            newIsbn.value = e.target.parentNode.children[2].textContent;
            id=e.target.parentNode.dataset.id;
            submitButton.disabled = true;
        }
        
        if(e.target.textContent === 'Edit'&& e.target.parentNode.parentNode.dataset.id === id){
            let newPost ={
                "title":newTitle.value,
                "author":newAuthor.value,
                "isbn":newIsbn.value
            };

            await fetch(`https://mybooks-a3607.firebaseio.com/books/${id}/.json`,{
                method:'PUT',
                body:JSON.stringify(newPost)
            })

            newTitle.value ='';
            newAuthor.value='';
            newIsbn.value ='';
            submitButton.disabled = false;
            loadBooks();
        };

        if(e.target.textContent === 'Delete'){
            id=e.target.parentNode.parentNode.dataset.id;
            await fetch(`https://mybooks-a3607.firebaseio.com/books/${id}/.json`,{
                method:'DELETE'
            })
            loadBooks();
        };
    });

    async function loadBooks() {
        booksList.innerHTML ='';
        let allBooks = await (await fetch('https://mybooks-a3607.firebaseio.com/books/.json')).json();
        Object.entries(allBooks).forEach(([id,book]) => {
            let tempRow = document.createElement('tr')
            tempRow.setAttribute ("data-id" ,`${id}`);
            tempRow.innerHTML=rowElements(book.title,book.author,book.isbn)
            booksList.appendChild(tempRow);
        });

        return// Object.entries(allBooks);
    };

    function rowElements(title,author,isbn) {
        return `<td>${title}</td>`+
                `<td>${author}</td>`+
                `<td>${isbn}</td>`+
                `<td>`+
                    `<button>Edit</button>`+
                    `<button>Delete</button>`+
                `</td>`
    };
}