function solve() {
    let list = document.getElementsByTagName("ol")[0];
    document.getElementsByTagName('button')[0].onclick = function exe() {
            let name = document.getElementsByTagName('input')[0];
            //alert(name.value);
            console.log(name);
            let refactoredName = name.value.toUpperCase()[0];
            let i = (refactoredName).charCodeAt(0);
            //alert(i);
            console.log(i);
            for (let i = 1; i < name.value.length; i++) {
                refactoredName += name.value[i].toLowerCase();
            }

            let a = list.getElementsByTagName('li')[i - 65];
            //alert(a.innerHTML);
            console.log(a);

            if (a.innerHTML.length === 0) {
                a.innerHTML = refactoredName;
                console.log(a.innerHTML);

            } else {
                a.innerHTML = a.innerHTML + ', ' + refactoredName;
            }

            name.value = '';

        }
        // let input = document.querySelector('input');
        // let list = document.getElementsByTagName("ol")[0];
        // let button = document.querySelector('button');

    // button.addEventListener('click', () => {

    //     let currentInput = input.value.toUpperCase();
    //     let refactoredInput = currentInput[0];
    //     for (let i = 1; i < currentInput.length; i++) {
    //         refactoredInput += currentInput[i].toLowerCase();
    //     }

    //     let asciiCodeFirstChar = currentInput.charCodeAt(0);
    //     let child = list.getElementsByTagName('li')[asciiCodeFirstChar - 65];

    //     if(child.innerHTML.length>0){
    //         let currentChildText=child.innerHTML;
    //         refactoredInput=currentChildText+ ", "+ refactoredInput;
    //     }
    //     child.innerHTML = refactoredInput;
    //     input.value = '';
    // })

}