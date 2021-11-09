function create(words) {
    let arrWord = words;
    let bigDiv = document.getElementById('content');
    arrWord.forEach(element => {
        let divcho = document.createElement('div');
        let paragravcho = document.createElement('p');
        paragravcho.textContent = element;
        paragravcho.style.display = 'none'
        divcho.appendChild(paragravcho);
        bigDiv.appendChild(divcho);
    });
    bigDiv.addEventListener('click', (e) => {
        let currentDiv = e.target;

        if (currentDiv.firstElementChild.style.display === 'none') {
            currentDiv.firstElementChild.style.display = 'block'
        } else {
            currentDiv.firstElementChild.style.display = 'none'
        }

    })
}