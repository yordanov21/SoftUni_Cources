function createArticle() {

    let title = document.getElementById('createTitle').value;
    let textParagr = document.getElementById("createContent").value;
    let article = document.getElementById("articles");

    let button = document.getElementsByTagName('button');

    let currentTitle = document.createElement('h3');
    let currentParagr = document.createElement('p');
    let currentArticle = document.createElement('div');

    currentTitle.textContent = title;
    currentParagr.textContent = textParagr;
    currentArticle.appendChild(currentTitle);
    currentArticle.appendChild(currentParagr);
    article.appendChild(currentArticle);
    document.getElementById("createTitle").value = "";
    document.getElementById("createContent").value = "";

    let clearBtn = document.getElementById('clear');

    clearBtn.addEventListener('click', () => {

        currentArticle.innerHTML = '';
    })
}