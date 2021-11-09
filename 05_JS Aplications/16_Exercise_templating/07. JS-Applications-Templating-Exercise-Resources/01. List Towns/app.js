//import { Handlebars } from "../handlebars.min";

const elements = {
    loadBtbn: document.querySelector('#btnLoadTowns'),
    inputedTown: document.querySelector('input'),
    cityWrapper: document.querySelector('#root')
};

// console.log(elements.loadBtbn);
// console.log(elements.townList);
// console.log(elements.inputedTown);

elements.loadBtbn.addEventListener('click', (e) => {

    let towns = elements.inputedTown.value;
    let townsColection = towns.split(', ').sort();
    console.log(townsColection);
    console.table(townsColection)
    fetch('./template.hbs')
        .then((r) => r.text())
        .then((templateHBS) => {
            console.log(templateHBS);

            const template = Handlebars.compile(templateHBS);
            console.log(template);

            const resultHTML = template({ towns: townsColection }) // задължтелно трябва да е обект с име на ключ, който съвпада с името на {{#each towns}} в темплата!!!!!
            console.log(resultHTML);

            elements.cityWrapper.innerHTML = resultHTML;
        })

});