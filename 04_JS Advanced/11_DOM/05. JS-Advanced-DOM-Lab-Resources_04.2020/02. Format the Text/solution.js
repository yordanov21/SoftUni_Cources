function solve() {
    let paragraphs = document.getElementById('input').textContent.split('.');

    let output = document.getElementById('output');

    paragraphs.pop()

    paragraphs.forEach(el => {
            let currentP = document.createElement('p');

            currentP.textContent = el + '.';
            output.appendChild(currentP);
        }

    )
}