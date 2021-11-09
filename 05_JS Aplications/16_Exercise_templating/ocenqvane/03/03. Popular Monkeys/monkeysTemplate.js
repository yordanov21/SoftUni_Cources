import { monkeys } from './monkeys.js';

(async () => {
    Handlebars.registerPartial('monkey',
        await fetch('./monkeyTemp.hbs').then((r) => r.text())
    );

    const templateSrc = await fetch('./monkeysTemp.hbs').then((r) => r.text());

    const template = Handlebars.compile(templateSrc);
    
    const resultHTML = template({monkeys});

    document.querySelector('section').innerHTML += resultHTML;

    document.querySelectorAll('button').forEach(btn => {
        btn.addEventListener('click', () => {
            const parent = btn.parentNode;
            const info = parent.querySelector('p');
            const {display} = info.style;

            if(display === 'none'){
                info.style.display = 'block';
            } else {
                info.style.display = 'none';
            }
        });
    });
})()
