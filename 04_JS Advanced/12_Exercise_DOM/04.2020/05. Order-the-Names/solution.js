function solve() {

    let input = document.getElementsByTagName("input")[0];
    let btn = document.getElementsByTagName("button")[0];
    let list = document.getElementsByTagName("ol")[0];

    btn.addEventListener('click', (e) => {


        let currentInput = input.value.split(", ");

        currentInput.forEach(el => {
            let refactoredInput = el;
            let asciiCode = refactoredInput[0].charCodeAt(0);
            let child = list.getElementsByTagName('li')[asciiCode - 97];

            if (child.innerHTML === '') {
                child.innerHTML = refactoredInput;
            } else {
                child.innerHTML += ', ' + refactoredInput;
            }
        })


        input.value = '';
    })
}

// function solve() {

//     let input = document.querySelector('input');
//     let list = document.getElementsByTagName("ol")[0];
//     let button = document.querySelector('button');

//     button.addEventListener('click', () => {

//         let currentInput = input.value.toUpperCase();
//         let refactoredInput = currentInput[0];
//         for (let i = 1; i < currentInput.length; i++) {
//             refactoredInput += currentInput[i].toLowerCase();
//         }

//         let asciiCodeFirstChar = currentInput.charCodeAt(0);
//         let child = list.getElementsByTagName('li')[asciiCodeFirstChar - 65];

//         if(child.innerHTML.length>0){
//             let currentChildText=child.innerHTML;
//             refactoredInput=currentChildText+ ", "+ refactoredInput;
//         }
//         child.innerHTML = refactoredInput;
//         input.value = '';
//     })

// }