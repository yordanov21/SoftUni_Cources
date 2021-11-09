(async() => {

    Handlebars.registerPartial(
        'cat',
        await fetch('./single-cat-template.hbs').then((r) => r.text())
    );
    const templateSrc = await fetch('./all-cats-template.hbs').then((r) => r.text());
    const template = Handlebars.compile(templateSrc);
    //в template функцията подаваме обект с име на ключa, който съвпада с името на {{#each.....}} в темплейта!!!!!
    const resultHTML = template({ cats });

    document.querySelector("#allCats").innerHTML = resultHTML;

    //трябва да е след като сме закачили горния  resultHTML на DOM дървото;
    document.querySelectorAll('button').forEach((btn) => {

        btn.addEventListener('click', () => {

            const parent = btn.parentNode;
            const statusDiv = parent.querySelector('div.status');
            const { display } = statusDiv.style;

            const parentInfo = statusDiv.parentNode;
            const parentLi = parentInfo.parentNode;
            const img = parentLi.querySelector('img');

            if (display === 'none') {
                btn.textContent = "Hide Status Code"
                statusDiv.style.display = "block"

                //extra stilization
                btn.style.background = "#FFFFFF";
                btn.style.color = "#2AA5FE";
                parentLi.style.background = "#2AA5FE";
                img.src = `images/cat${statusDiv.id}edit.jpg`;

            } else {
                btn.textContent = "Status Code"
                statusDiv.style.display = "none"

                //extra stilization
                btn.style.background = "#2AA5FE";
                btn.style.color = "white";
                parentLi.style.background = "white";
                img.src = `images/cat${statusDiv.id}.jpg`;
            }

        })

    });
})();