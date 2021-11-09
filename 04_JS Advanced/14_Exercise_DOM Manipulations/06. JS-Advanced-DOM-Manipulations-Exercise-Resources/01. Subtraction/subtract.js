function subtract() {

    let firstNumber=document.getElementById("firstNumber").value; //value защото елемента е input
    let secondNumber=document.getElementById("secondNumber").value;
    let result=document.getElementById("result");

    result.textContent=firstNumber-secondNumber;

}