function addItem() {
    let text = document.getElementsByTagName('input')[0];
    let valuee = document.getElementsByTagName('input')[1];

    let optioneElement = document.createElement('option');
    optioneElement.textContent = text.value;
    optioneElement.value = valuee.value;
    let menu = document.getElementById('menu');
    menu.appendChild(optioneElement);

    text.value = '';
    valuee.value = '';

    // console.log(text.value);
    // console.log(valuee.value);
}