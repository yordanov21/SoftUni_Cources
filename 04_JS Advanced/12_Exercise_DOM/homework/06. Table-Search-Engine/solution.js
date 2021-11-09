function solve() {
    let table = document.getElementsByTagName('tbody')[0];
    let searchButton = document.getElementById("searchBtn");
    let searchText = document.getElementById("searchField");

    searchButton.addEventListener('click', () => {

        tr.classList.remove("select");
        let searchedTextString = searchText.value;
        let tableChildren = table.children;

        if (searchedTextString) {

            Array.from(tableChildren).forEach(tr => tr.classList.remove("select"));
            Array.from(tableChildren).forEach(tr => {
                if (tr.textContent.includes(searchedTextString)) {
                    tr.classList.add("select");
                }
            })
        }

        searchText.value = "";

    })

}