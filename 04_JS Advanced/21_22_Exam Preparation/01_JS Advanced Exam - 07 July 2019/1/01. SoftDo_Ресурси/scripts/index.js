function mySolution() {
    //обект с достъпените елементите от html-a
    const $elements = {
        //                                          с # достъпваме id-то
        askQuestionTextarea: document.querySelector('#inputSection textarea'),
        usernameInputfield: document.querySelector('#inputSection div input[type="username"]'),
        askQuestionButton: document.querySelector('#inputSection div button'),

        pendingQuastionsDiv: document.querySelector('#pendingQuestions'),

        openQuestionsDiv: document.querySelector('#openQuestions')
    }

    $elements.askQuestionButton.addEventListener('click', askQuestion);

    function askQuestion() {

        //input полетата и textarea ги достъпваме с .value, a елементите като p, span и др с textContent.
        const question = $elements.askQuestionTextarea.value;
        const givenUsername = $elements.usernameInputfield.value;
        const username = givenUsername !== '' ? givenUsername : 'Anonymous';

        let pendingQuastionDiv = createHTMLElement('div', 'pendingQuestion');
        let usernameImage = createHTMLElement(
            'img',
            null,
            null, [{ k: 'src', v: './images/user.png' }, { k: 'width', v: 32 }, { k: 'height', v: 32 }]);
        let usernameSpan = createHTMLElement('span', null, username);
        let quastionParagraph = createHTMLElement('p', null, question);
        let actionDiv = createHTMLElement('div', 'actions');
        let archiveButton = createHTMLElement('button', 'archive', 'Archive', null, { name: 'click', func: archiveQuestion });
        let openButton = createHTMLElement('button', 'open', 'Open', null, { name: 'click', func: openQuestion });

        //append-ваме archiveButton и openButton на actionDiv с функцията  appenfChildrenToParent()
        actionDiv = appendChildrenToParent([archiveButton, openButton], actionDiv);

        //append-ваме usernameImage, usernameSpan, quastionParagraph на pendingQuastionDiv  с функцията  appenfChildrenToParent()
        pendingQuastionDiv = appendChildrenToParent([usernameImage, usernameSpan, quastionParagraph, actionDiv], pendingQuastionDiv);

        //закачаме създадените елементи към DOM дървото;
        $elements.pendingQuastionsDiv.appendChild(pendingQuastionDiv);

    }

    function archiveQuestion(e) {

        //взимаме родителя нагоре по дървото в случая родителя на родителя
        const questionDiv = e.target.parentNode.parentNode;

        //премахваме текущия елемент (въпрос)
        //може и така:questionDiv.outerHTML="";
        questionDiv.remove();
    }

    function openQuestion(e) {

        const questionDiv = e.target.parentNode.parentNode;
        questionDiv.className = "openQuestion";
        let actionDiv = questionDiv.querySelector('div.actions');
        actionDiv.innerHTML = "";
        const replayButton = createHTMLElement('button', 'reply', 'Reply', null, { name: 'click', func: replyToQuestion });
        actionDiv = appendChildrenToParent([replayButton], actionDiv);

        let replySectionDiv = createHTMLElement('div', 'replySection', null, [{ k: 'style', v: 'display: none;' }]);
        let replyInput = createHTMLElement('input', 'replyInput', null, [{ k: 'type', v: 'text' }, { k: 'placeholder', v: 'Reply to this question here...' }])
        let sendAnswerButton = createHTMLElement('button', 'replyButton', 'Send', null, { name: 'click', func: addAnswer });
        let answersOl = createHTMLElement('ol', 'reply', null, [{ k: 'type', v: '1' }]);

        replySectionDiv = appendChildrenToParent([replyInput, sendAnswerButton, answersOl], replySectionDiv);

        questionDiv.appendChild(replySectionDiv)
        $elements.openQuestionsDiv.appendChild(questionDiv);

    }

    function addAnswer() {
        const parent = this.parentNode
        const answerInput = parent.querySelector('input').value;

        let answerLi = createHTMLElement('li', null, answerInput)
        parent.querySelector('ol').appendChild(answerLi);
    }

    function replyToQuestion(e) {
        let button = e.target;
        let replySectionDiv = this.parentNode.parentNode.querySelector('.replySection');

        if (button.textContent === 'Reply') {
            replySectionDiv.style.display = 'block';
            button.textContent = 'Back'
        } else {
            replySectionDiv.style.display = 'none';
            button.textContent = 'Reply';
        }
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

    console.log("10" - 1);
    console.log("10" + 1);


}