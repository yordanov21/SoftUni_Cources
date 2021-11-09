function solve() {
    let task = document.querySelector('#task');
    let description = document.querySelector('#description');
    let date = document.querySelector('#date');
    let addButon = document.querySelector('#add');


    let openSection = document.getElementsByTagName('section')[1];
    let progresSection = document.getElementsByTagName('section')[2];
    let finishSection = document.getElementsByTagName('section')[3];
    addButon.addEventListener('click', (e) => {

        e.preventDefault();
        console.log(task.value);
        console.log(description.value);
        console.log(date.value);

        if (task.value === '' || description.value === '' || date.value === '') {
            return
        }
        let openSectionDiv = openSection.lastElementChild;
        console.log(openSectionDiv);
        let articleSection = createHTMLElement('article');

        let h3Article = createHTMLElement('h3', null, task.value);
        let paragrDescription = createHTMLElement('p', null, `Description: ${description.value}`);
        let paragrDate = createHTMLElement('p', null, `Due Date: ${date.value}`);
        let divFlex = createHTMLElement('div', 'flex');
        let startBtn = createHTMLElement('button', 'green', 'Start');
        let deleteBtn = createHTMLElement('button', 'red', 'Delete')

        divFlex.appendChild(startBtn);
        divFlex.appendChild(deleteBtn)

        articleSection.appendChild(h3Article);
        articleSection.appendChild(paragrDescription);
        articleSection.appendChild(paragrDate);
        articleSection.appendChild(divFlex);
        openSectionDiv.appendChild(articleSection);


        startBtn.addEventListener('click', (e) => {
            let inprogresSection = progresSection.lastElementChild;
            articleSection.lastElementChild.remove();
            let divFlexInprogres = createHTMLElement('div', 'flex');
            let delbtnInProgres = createHTMLElement('button', 'red', 'Delete');
            let finishbtnInProgres = createHTMLElement('button', 'orange', 'Finish');
            divFlexInprogres.appendChild(delbtnInProgres);
            divFlexInprogres.appendChild(finishbtnInProgres);
            articleSection.appendChild(divFlexInprogres);
            inprogresSection.appendChild(articleSection);

            delbtnInProgres.addEventListener('click', (e) => {
                articleSection.remove();

            })

            finishbtnInProgres.addEventListener('click', (e) => {
                let finish = finishSection.lastElementChild;
                articleSection.lastElementChild.remove();
                finish.appendChild(articleSection)
            })

        })

        deleteBtn.addEventListener('click', (e) => {
            articleSection.remove();

        })
    })




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