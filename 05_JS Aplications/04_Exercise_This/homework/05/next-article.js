function getArticleGenerator(articles) {
    let articleCopy = [...articles];
    let contentRef = document.querySelector('#content');

    return function() {
        if (articleCopy.length === 0) {
            return
        }

        let result = articleCopy[0];

        articleCopy = articleCopy.slice(1);

        let resultElement = document.createElement('article');
        resultElement.innerHTML = result;

        contentRef.appendChild(resultElement)
    }
}