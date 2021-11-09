function toggle() {
    //достъпваме na span-a:              div-a  class-a    clasa-a
    const $button = document.querySelector("div > div.head span.button"); //# взима id-то(като го използваме), .head взима div-a с класа head,
    const $divs = document.querySelectorAll("div > div");

    if ($button.textContent === "More") {
        $button.textContent = "Less";
        $divs[1].style.display = "block"; //display-е ключа на стилизацията, а block e value;
    } else{
        $button.textContent="More";
        $divs[1].style.display = "none"; 
    }

}