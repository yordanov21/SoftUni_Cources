function solve() {

    const links = document.querySelectorAll("a");
    const visits = document.querySelectorAll("p");

    for (let i = 0; i < links.length; i++) {
        updateVisirors(links[i], visits[i]);
    }

    function updateVisirors(link, visit) {
        link.addEventListener("click", (e) => {
            //e.preventDefault();
            let count = visit.innerHTML.split(" ")[1];
            visit.innerHTML = `visited ${++count} times`;
        })
    }
}