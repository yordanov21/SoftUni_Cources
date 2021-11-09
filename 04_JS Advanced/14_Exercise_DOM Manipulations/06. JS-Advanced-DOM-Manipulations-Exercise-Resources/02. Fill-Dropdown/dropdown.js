function addItem() {
    const textItem = document.getElementById("newItemText");
    const textValue = document.getElementById("newItemValue");
    const menu = document.getElementById("menu");

    let optionElement = document.createElement('option');
    optionElement.textContent=textItem.value;
    optionElement.value=textValue.value
    menu.appendChild(optionElement)

textItem.value='';
textValue.value='';
}