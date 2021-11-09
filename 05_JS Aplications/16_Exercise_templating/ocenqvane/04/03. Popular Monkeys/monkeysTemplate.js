import { monkeys as m} from './monkeys.js';
(async () => {
    Handlebars.registerPartial(
        'monkey',
        await fetch('monkey-template.hbs').then((r) => r.text())
    );

    let templateSrc = await fetch('monkeys-template.hbs').then((r) => r.text());
    let template = Handlebars.compile(templateSrc);

    const resultHTML = template({ m });
    document.querySelector('section').innerHTML +=resultHTML;

    document.querySelectorAll('button').forEach((btn) => {
        btn.addEventListener('click', () => {
            const parentInfo = btn.parentNode.querySelector('p');
            const {display} = parentInfo.style;
            if(display === 'none'){
                parentInfo.style.display = 'block'
            }else{
                parentInfo.style.display = 'none';
            }
        })
    })
})()