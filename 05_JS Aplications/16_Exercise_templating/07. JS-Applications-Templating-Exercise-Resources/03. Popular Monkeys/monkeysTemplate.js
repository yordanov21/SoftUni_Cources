 import { monkeys } from './monkeys.js';

 (async() => {
     //регистриране на single partial
     Handlebars.registerPartial(
         'monkey',
         await fetch('./monkeys-temp.hbs').then((r) => r.text())
     );
     const tempSrc = await fetch('./all-monkeys-temp.hbs').then((r) => r.text());
     const template = Handlebars.compile(tempSrc);
     //console.log(template); //трябва да върне функция
     const resultHTML = template({ monkeys });
     document.querySelector('section').innerHTML += resultHTML;

     document.querySelectorAll('button').forEach((btn) => {

         btn.addEventListener('click', () => {

             const parent = btn.parentNode; //достъпваме родителя на бутона
             const paragraph = parent.querySelector('p'); //взимаме child-a на родителя с tag p
             const { display } = paragraph.style;

             if (display === 'none') {
                 btn.textContent = "Hide Info";
                 paragraph.style.display = "block";
             } else {
                 btn.textContent = "Info";
                 paragraph.style.display = "none";
             }
         })

     });
 })();