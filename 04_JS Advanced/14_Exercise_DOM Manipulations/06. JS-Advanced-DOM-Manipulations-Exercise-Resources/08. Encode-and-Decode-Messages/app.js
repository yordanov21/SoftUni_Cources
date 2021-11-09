function encodeAndDecodeMessages() {
    const $divs = document.querySelectorAll("div#container main#main div"); //достъпваме div-a на main-a
    const $textareas = document.querySelectorAll('textarea'); //взимаме textarea-ите

    $textareas[0].nextElementSibling.addEventListener('click', encode);//достъпваме button-a следващия елемент след textarea-та 
    $textareas[1].nextElementSibling.addEventListener('click', decode);//textarea и button са sibling

    function encode(e) {
       const inputText = $textareas[0].value
       .split('')
       .map((char) => {
            return String.fromCharCode((char.charCodeAt(0) + 1));
        })
        .join('');
        $textareas[1].value = inputText;
        $textareas[0].value = '';
    };
    function decode(e) {
        inputText = $textareas[1].value
        .split('')
        .map((char) => {
            return String.fromCharCode((char.charCodeAt(0) - 1));
        })
        .join('');
        $textareas[1].value = inputText;

    };
}