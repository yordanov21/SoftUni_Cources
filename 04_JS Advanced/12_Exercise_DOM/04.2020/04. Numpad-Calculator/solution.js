function solve() {

    let pad = document.getElementsByClassName('keys')[0];
    let output = document.getElementById('expressionOutput');
    let clearButon = document.getElementsByClassName('clear')[0];
    let result = document.getElementById('resultOutput');
    let operators = ['+', '-', '*', '/'];
    let operations = {
        '+': (num1, num2) => Number(num1) + Number(num2),
        '-': (num1, num2) => Number(num1) - Number(num2),
        '*': (num1, num2) => Number(num1) * Number(num2),
        '/': (num1, num2) => Number(num1) / Number(num2),
    }

    clearButon.addEventListener('click', () => {
        output.innerHTML = '';
        result.innerHTML = '';
    })
    pad.addEventListener('click', ({ target: { value } }) => {

        //за да нямаме undefind
        if (!value) {
            return
        }
        if (value === "=") {
            let params = output.innerHTML.split(' ');
            let num2 = params[2] === "" ? NaN : params[2]
            result.innerHTML = operations[params[1]](params[0], num2)
            return;
        }

        if (operators.includes(value)) {
            output.innerHTML = output.innerHTML + ' ' + value + ' ';
        } else {
            output.innerHTML = output.innerHTML + value;
        }

    })
}