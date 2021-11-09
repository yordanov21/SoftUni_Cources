function format() {
  const input = document.getElementById("input").textContent.split('.');
  const output = document.getElementById("output");

  let text = [];

  if (input.length < 3) {
    addParagraph(input.join('.'));
  } else {

    for (i = 0; i < input.length; i++) {
      if (text.length % 3==0) {
        addParagraph(text.join(".")+'.');
        text = [];
      }

      text.push(input[i]);
    }

    if(text.length>0){
      addParagraph(text.join("."));
      text=[];
    }

  }

  function addParagraph(text) {

    const paragraph = document.createElement('p');
    let description = document.createTextNode(text);

    paragraph.appendChild(description);
    output.appendChild(paragraph);
  }

}