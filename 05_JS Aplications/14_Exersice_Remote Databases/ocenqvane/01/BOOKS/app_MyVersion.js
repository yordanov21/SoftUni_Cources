window.onload  = () =>{
    let buttonLoad = document.getElementById('loadBooks');
    let booksList = document.getElementsByTagName('tbody')[0];
    let newTitle = document.getElementById('title')
    let newAuthor = document.getElementById('author')
    let newIsbn = document.getElementById('isbn')
    let submit = document.getElementById('submit')
    let id ;

    buttonLoad.addEventListener('click',(e)=>{
        loadBooks();
    });

    submit.addEventListener('click',(e)=>{
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
        

        
        if(e.target.textContent === 'Edit'){
            let currentRow = e.target.parentNode.parentNode;
            let title = currentRow.children[0].textContent;
            let author = currentRow.children[1].textContent;
            let isbn = currentRow.children[2].textContent;
            id =currentRow.dataset.id;

            currentRow.innerHTML = `<td><input type="text" value ="${title}" /></td>`+
            `<td><input value = "${author}" /></td>`+
            `<td><input value = "${isbn}" /></td>`+
            '<button>Done</button>'
        };

        if(e.target.textContent === 'Done'){
            let title = e.target.parentNode.children[0].children[0].value;
            let author = e.target.parentNode.children[1].children[0].value;
            let isbn = e.target.parentNode.children[2].children[0].value; 
            let newPost ={
                "title":title,
                "author":author,
                "isbn":isbn
            };
            await fetch(`https://mybooks-a3607.firebaseio.com/books/${id}/.json`,{
                method:'PUT',
                body:JSON.stringify(newPost)
            })

            loadBooks();
        };

        if(e.target.textContent === 'Delete'){

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