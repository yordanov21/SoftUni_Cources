function solve() {



   //const textarea= document.querySelector('#site-content main section')

   let textarea = document.querySelector('.site-content main section');
   // usernameInputfield: document.querySelector('#inputSection div input[type="username"]'),
   // askQuestionButton: document.querySelector('#inputSection div button'),
   // pendingQuastionsDiv: document.querySelector('#pendingQuestions'),
   // openQuestionsDiv: document.querySelector('#openQuestions')

   let article = createHTMLElement('article');
   let h1Element = createHTMLElement('h1', null, 'JavaScript');
   let paragraf1 = createHTMLElement('p', null, 'Category: <strong>programming</strong>');
   let paragraf2 = createHTMLElement('p', null, 'Creator: <strong>John</strong>');
   let paragraf3 = createHTMLElement('p', null, 'Lorem, ipsum dolor sit amet consectetur adipisicing elit. Minima hic voluptatem pariatur quibusdam voluptates perspiciatis amet officia impedit aspernatur iusto distinctio exercitationem odit quas id, laborum quae aut dicta tempore!');
   let DivElement = createHTMLElement('div', 'buttons');
   let delButton = createHTMLElement('button', 'btndelete', 'Delete', null, { name: 'click', func: delleteButton });
   let arhButton = createHTMLElement('button', 'btnarchive', 'Archive', null, { name: 'click', func: archeveButton });

   DivElement = appendChildrenToParent([delButton, arhButton], DivElement);
   //article.appendChild(h1Element);
   article = appendChildrenToParent([h1Element, paragraf1, paragraf2, paragraf3, DivElement], article)

   textarea.appendChild(article);
   //  $elements.askQuestionButton.addEventListener('click', askQuestion);

   function delleteButton() {

   }
   function archeveButton() {

   }
   function createHTMLElement(tagName, className, textContent, attributes, event) {

      let element = document.createElement(tagName);

      if (className) {
         element.classList.add(className);
      }

      if (textContent) {
         element.textContent = textContent;
      }

      if (attributes) {
         attributes.forEach((a) => element.setAttribute(a.k, a.v));
      }

      if (event) {
         element.addEventListener(event.name, event.func)
      }

      return element;
   }
   //функция която append-va children to parent !!!Children are ARRAY!!!  
   function appendChildrenToParent(children, parent) {
      children.forEach((c) => parent.appendChild(c));
      return parent;
   }

}

