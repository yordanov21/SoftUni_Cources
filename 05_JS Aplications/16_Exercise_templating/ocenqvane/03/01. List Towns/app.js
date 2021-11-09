//https://restcountries.eu/rest/v2/all
(() => {
    const loadButton = document.getElementById('btnLoad');
    const divWrapper = document.getElementById('root');
    const h1 = document.querySelector('body h1');

    loadButton.addEventListener('click', () => {

        Promise.all([
            fetch('https://restcountries.eu/rest/v2/all').then((r) => r.json()),
            fetch('./template.hbs').then((r) => r.text())
        ])
            .then(([countries, templateHbs]) => {
                const template = Handlebars.compile(templateHbs);
                const resultHTML = template({ countries });
                divWrapper.innerHTML = resultHTML;
            })
            .catch(err => h1.textContent = err.message)

    })
})()