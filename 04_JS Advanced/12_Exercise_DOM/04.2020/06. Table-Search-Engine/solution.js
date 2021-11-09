function solve() {
    let td = document.querySelectorAll('td');
    let input = document.querySelector("#searchField");
    let button = document.querySelector('#searchBtn')

    button.addEventListener('click', (e) => {

        td.forEach(el => el.parentNode.classList.remove("select"))

        td.forEach(el => {
            let elContent = el.innerHTML;
            if (elContent.includes(input.value)) {

                let parent = el.parentNode;
                parent.classList.add("select");
            }

        })
        if (input.value === '') {
            td.forEach(el => el.parentNode.classList.remove("select"))
        }
        input.value = '';

    })

}