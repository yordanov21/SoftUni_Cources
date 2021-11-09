function solve() {

    let optionSelectMenu = document.getElementById("selectMenuTo");

    let binary = document.createElement('option');
    binary.value = "binary";
    binary.textContent = "Binary";
    let hexadecimal = document.createElement('option');
    hexadecimal.value = "hexadecimal";
    hexadecimal.textContent = "Hexadecimal"
    let kilometars = document.createElement('option');
    kilometars.value = "kilometars";
    kilometars.textContent = "Kilometars"
    optionSelectMenu.appendChild(binary);
    optionSelectMenu.appendChild(hexadecimal);
    optionSelectMenu.appendChild(kilometars);


    let result = document.getElementById("result");
    let btnConverIt = document.getElementsByTagName("button")[0];
    btnConverIt.addEventListener('click', (e) => {
        let number = document.getElementById("input").value;
        if (optionSelectMenu.value === "kilometars") {
            result.value = (+number) / 1000;
        } else if (optionSelectMenu.value === 'binary') {
            result.value = (Number(input.value)).toString(2);
        } else {
            result.value = (Number(input.value)).toString(16).toUpperCase();
        }
    });
}