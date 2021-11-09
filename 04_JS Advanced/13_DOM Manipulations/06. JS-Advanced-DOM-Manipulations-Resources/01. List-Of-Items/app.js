//когато нямаме оnclick в HTML-a на бутона
// function addItem() {
//     let itemList = document.querySelector("#items");
//     let input = document.querySelector("#newItemText");
//     let button = document.querySelectorAll('input')[1];

//     button.addEventListener('click', (e) => {
//         let newElement = document.createElement('li');
//         newElement.innerHTML = input.value;
//         itemList.appendChild(newElement);
//         input.value = '';
//     })
// }
// addItem()


function addItem() {
    const itemsList = document.getElementById("items");
    const input = document.getElementById("newItemText").value;

    let newElement = document.createElement("li");
    newElement.innerHTML = input;

    itemsList.appendChild(newElement);

    document.getElementById("newItemText").value = "";
}