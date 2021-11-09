(function () {
    const elements = {
        loadBtn: document.querySelector('#btnLoadTowns'),
        inputInfo: document.querySelector('#towns'),
        divTag: document.querySelector('#root')
    }

    elements.loadBtn.addEventListener('click', async function () {
        const towns = elements.inputInfo.value.split(', ');
        const source = await fetch('http://127.0.0.1:5500/01.%20List%20Towns/towns.hbs').then((r) => r.text())
        const template = Handlebars.compile(source);
        const context = { towns };
        const resultHTML = template(context);
        elements.divTag.innerHTML = resultHTML;
    })

}())
