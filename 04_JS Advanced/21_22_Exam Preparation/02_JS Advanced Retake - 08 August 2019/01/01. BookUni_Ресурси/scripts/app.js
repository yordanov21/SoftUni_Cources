function solve() {
    let bookTitle = document.querySelectorAll('form input')[0];
    let bookYear = document.querySelectorAll('form input')[1];
    let bookPrice = document.querySelectorAll('form input')[2];
    let addBookButton = document.querySelector('form button');


    const newBookShelf = document.getElementsByClassName('bookShelf')[1];
    const oldBookShelf = document.getElementsByClassName('bookShelf')[0];

    let totalStore = document.querySelectorAll('h1')[1];
    addBookButton.addEventListener('click', addBook);

    function addBook(e) {
        //слага се preventDefault(), за да не се рефрешва страницата;
        e.preventDefault();
        let buttonBuyBook;
        let bookTitleValue = bookTitle.value;

        let bookYearValue = bookYear.value;
        let bookPriceValue = bookPrice.value;
        if (bookTitleValue === '' || bookYearValue < 0 || bookPriceValue < 0) {
            return
        }

        if (bookYearValue >= 2000) {
            let newBook = createHTMLElement('div', 'book');
            let paragrBook = createHTMLElement('p', null, `${bookTitleValue} [${bookYearValue}]`);
            buttonBuyBook = createHTMLElement('button', null, `Buy it only for ${bookPriceValue} BGN`);
            let buttonMoveToOldSection = createHTMLElement('button', null, 'Move to old section');

            newBook.appendChild(paragrBook);
            newBook.appendChild(buttonBuyBook);
            newBook.appendChild(buttonMoveToOldSection);
            newBookShelf.appendChild(newBook);

            buttonMoveToOldSection.addEventListener('click', function(e) {
                //слага се preventDefault(), за да не се рефрешва страницата;
                e.preventDefault();
                let currentBook = e.target.parentNode;
                currentBook.lastElementChild.remove();
                currentBook.lastElementChild.textContent = `Buy it only for ${(bookPriceValue*0.85).toFixed(2)} BGN`

                oldBookShelf.appendChild(currentBook);
            });

        } else {
            let oldBook = createHTMLElement('div', 'book');
            let paragrBook = createHTMLElement('p', null, `${bookTitleValue} [${bookYearValue}]`);
            buttonBuyBook = createHTMLElement('button', null, `Buy it only for ${(bookPriceValue*0.85).toFixed(2)} BGN`);


            oldBook.appendChild(paragrBook);
            oldBook.appendChild(buttonBuyBook);

            oldBookShelf.appendChild(oldBook);
        }


        buttonBuyBook.addEventListener('click', function(e) {
            e.preventDefault();
            let currentButtonInfo = e.target.textContent;
            let currentPrice = Number(currentButtonInfo.split(' ')[4]);
            let totalScoreArray = totalStore.textContent.split(' ');
            let totalScoreNum = Number(totalScoreArray[3]);
            totalScoreNum += currentPrice;
            totalScoreArray[3] = totalScoreNum.toFixed(2);
            totalStore.textContent = totalScoreArray.join(" ");

            e.target.parentNode.remove();
        })


    }


    //функция, с която създаваме HTML елементите !!!attributes is ARRAYs!!! event is OBJEST!!!!
    function createHTMLElement(tagName, className, textContent, attributes, event) {
        //Създаваме елемента
        let element = document.createElement(tagName);
        //ако има клас(class) го добавяме;
        if (className) {
            element.classList.add(className);
        }
        //ако има съдържание(textcontent) го добавя;
        if (textContent) {
            element.textContent = textContent;
        }
        //ако има атрибути(attributes), attributes са масив, който подаваме,  ги добавяме примерно{ k: 'type', v: '1' };
        if (attributes) {
            attributes.forEach((attribute) => element.setAttribute(attribute.k, attribute.v));
        }
        //ако има event го добавя(име на евента и функция);
        if (event) {
            element.addEventListener(event.name, event.func)
        }
        //накрая връщаме създадения елемент;
        return element;
    }

    //функция която append-va children to parent !!!Children are ARRAY!!!  
    function appendChildrenToParent(children, parent) {
        children.forEach((c) => parent.appendChild(c));
        return parent;
    }

}