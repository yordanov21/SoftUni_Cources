function create(words) {
   const content = document.getElementById('content');
   words.forEach(el => {
      let div = document.createElement('div')
      let paragraph = document.createElement('p')
      paragraph.textContent = el;
      div.appendChild(paragraph);
      paragraph.style.display = 'none';
      content.appendChild(div);

      div.addEventListener('click', () => {
         paragraph.style.display = 'block';
      })
   });
  
   //подобно решение:
   // let divContent = document.getElementById("content");

   // for (const word of words) {
   //     let NewDiv = document.createElement("div");
   //     let newPar = document.createElement("p");
   //     newPar.style.display = "none";
   //     newPar.innerHTML = word;

   //     NewDiv.appendChild(newPar);
   //     NewDiv.addEventListener("click", (e) => {
   //         e.target.children[0].style.display = "block";
   //     })
   //     divContent.appendChild(NewDiv);
   // }
}