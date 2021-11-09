function growingWord() {
  let text = document.getElementsByTagName("p")[2]; //става и така: .querySelector("p")[2]

  if (text.style.color === "" && text.style.fontSize === "") {
      text.style.fontSize = "2px";
      text.style.color = "blue";
  } else if (text.style.color === "red") {
      text.style.color = "blue";
      text.style.fontSize = parseInt(text.style.fontSize) * 2 + 'px';
  } else if (text.style.color === "blue") {
      text.style.color = "green";
      text.style.fontSize = parseInt(text.style.fontSize) * 2 + 'px';
  } else if (text.style.color === "green") {
      text.style.color = "red";
      text.style.fontSize = parseInt(text.style.fontSize) * 2 + 'px';
  }
}