function addItem() {
    const items = document.getElementById("items");
    const value = document.getElementById("newText").value;

    let newItem = document.createElement("li");
    newItem.innerHTML = value;

    let deleteLink = document.createElement("a");
    deleteLink.innerHTML = "[Delete]";
    deleteLink.href = "#";

    newItem.appendChild(deleteLink);
    items.appendChild(newItem);

    document.getElementById("newText").value = "";

    deleteLink.addEventListener("click", function(e) {
        e.preventDefault();

        //премахва li елемента(достигаме до ul елемента и оттам премахваме конкретното дете(li))
        this.parentNode.parentNode.removeChild(this.parentNode);
    })
}